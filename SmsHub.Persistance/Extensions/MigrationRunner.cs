﻿using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;
using SmsHub.Persistence.DbSeeder.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using SmsHub.Persistence.Migrations;

namespace SmsHub.Persistence.Extensions
{
    public static class MigrationRunner
    {
        public static void UpdateAndSeedDb(this IServiceCollection services)
        {
            var connectionInfo = GetConnectionInfo();
            using (var serviceProvider = CreateServices(services, connectionInfo.Item1))
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    EnsureDatabase(connectionInfo.Item1, connectionInfo.Item2);
                    UpdateDatabase(scope.ServiceProvider);
                    SeedDatabse(scope.ServiceProvider);
                }
            }
        }
        private static ServiceProvider CreateServices(IServiceCollection services, string connectionString)
        {  
            return services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    //.ScanIn(typeof(DbInitialDesign).Assembly).For.Migrations())
                    .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        public static void EnsureDatabase(string connectionString, DatabaseCreationParameters databaseCreationParameters)
        {           
            var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
            var initialCatalog =connectionBuilder.InitialCatalog;

            connectionBuilder.InitialCatalog = "master";
            using var connection = new SqlConnection(connectionBuilder.ConnectionString);
            var str =
                $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{initialCatalog}') "+
                $"BEGIN "+
                $"CREATE DATABASE {initialCatalog} " +
                $"ON PRIMARY " +
                    $"(NAME = {databaseCreationParameters.MdfName}, " +
                    $"FILENAME = '{databaseCreationParameters.MdfFileName}', " +
                    $"SIZE = {databaseCreationParameters.MdfSize}, " +
                    $"MAXSIZE = {databaseCreationParameters.MdfMaxSize}, " +
                    $"FILEGROWTH = {databaseCreationParameters.MdfFileGrowth}) " +
                $"LOG ON " +
                    $"(NAME = {databaseCreationParameters.LdfName}, "+
                    $"FILENAME = '{databaseCreationParameters.LdfFileName}', " +
                    $"SIZE = {databaseCreationParameters.LdfSize}, " +
                    $"MAXSIZE = {databaseCreationParameters.LdfMaxSize}, " +
                    $"FILEGROWTH = {databaseCreationParameters.LdfFileGrowth}) "+
                $"END"
             ;

            SqlCommand myCommand = new SqlCommand(str, connection);
            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();

        }
        public static void SeedDatabse(IServiceProvider serviceProvider)
        {
            var runner= serviceProvider.GetRequiredService<IDataSeedersRunner>();
            runner.RunAllDataSeeders();
        }
        internal static Tuple<string,DatabaseCreationParameters> GetConnectionInfo()
        {
            var basePath = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(basePath)
                                    .AddJsonFile("appsettings.json")
                                    .Build();          
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var databaseCreationParametersJson = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:MdfName").Value;
            var databaseCreationParameters = new DatabaseCreationParameters()
            {
                MdfName= configuration.GetSection($"{nameof(DatabaseCreationParameters)}:MdfName").Value,
                LdfName= configuration.GetSection($"{nameof(DatabaseCreationParameters)}:LdfName").Value,
                MdfFileName= configuration.GetSection($"{nameof(DatabaseCreationParameters)}:MdfFileName").Value,
                LdfFileName= configuration.GetSection($"{nameof(DatabaseCreationParameters)}:LdfFileName").Value,
                MdfSize = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:MdfSize").Value,
                LdfSize = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:LdfSize").Value,
                MdfMaxSize = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:MdfMaxSize").Value,
                LdfMaxSize = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:LdfMaxSize").Value,
                MdfFileGrowth = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:MdfFileGrowth").Value,
                LdfFileGrowth = configuration.GetSection($"{nameof(DatabaseCreationParameters)}:LdfFileGrowth").Value,
            };
            return new Tuple<string, DatabaseCreationParameters>(connectionString, databaseCreationParameters);
        }
    }
}
