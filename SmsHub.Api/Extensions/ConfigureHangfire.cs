﻿using Hangfire;
using Hangfire.Dashboard;
using SmsHub.Api.Filters;

namespace SmsHub.Api.Extensions
{
    public static class ConfigureHangfire
    {
        public static void AddHangfire(this WebApplicationBuilder builder)
        {
            builder.Services.AddHangfire(x =>
            {
                x.UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddHangfireServer();
        }
        public static void AddHangfireDashboard(this IApplicationBuilder app)
        {
            //var dashboardOptions = new DashboardOptions
            //{
            //    Authorization = new IDashboardAuthorizationFilter[]
            //    {
            //        new HangfireDashboardJwtAuthorizationFilter(GetTokenValidationParameters(), CustomRoles.Admin)
            //    }
            //};
            //app.UseHangfireDashboard("/main/admin/hangfire", dashboardOptions);

            app.UseHangfireDashboard();
        }
    }
}
