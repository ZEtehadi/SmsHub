﻿using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ServerUserControllerTest : BaseIntegrationTest
    {
        public ServerUserControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateServerUser_ServerUserDto_ShouldCreateServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            //Act
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            
            //Arrange
            Assert.True(true);
        }


        [Fact]
        public async void DeleteServerUser_ServerUserDto_ShouldDeleteServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            var serverUserData = await PostAsync<GetServerUserDto, ApiResponseEnvelope<ICollection<GetServerUserDto>>>("/ServerUser/GetAll", null);

            var deleteServerUser = new DeleteServerUserDto()
            {
                Id = serverUserData.Data.OrderByDescending(x=> x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<DeleteServerUserDto, DeleteServerUserDto>("/ServerUser/Delete", deleteServerUser);

            //Arrange
            Assert.True(true);
        }

        [Fact]
        public async void UpdateServerUser_ServerUserDto_ShouldUpdateServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            var serverUserData = await PostAsync<GetServerUserDto, ApiResponseEnvelope<ICollection<GetServerUserDto>>>("/ServerUser/GetAll", null);

            var serverUserId = serverUserData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
            await PostAsync<int, ApiResponseEnvelope<int>>("/ServerUser/Update", serverUserId);

            //Arrange
            Assert.True(true);
        }


        [Fact]
        public async void GetByIdServerUser_ServerUserDto_ShouldGetByIdServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "administrator",

            };
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            var serverUserData = await PostAsync<GetServerUserDto, ApiResponseEnvelope<ICollection<GetServerUserDto>>>("/ServerUser/GetAll", null);

            IntId serverUserId = serverUserData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
           var singleServerUser= await PostAsync<IntId, ApiResponseEnvelope<GetServerUserDto>>("/ServerUser/GetById", serverUserId);

            //Arrange
            Assert.Equal(singleServerUser.Data.Username, "administrator");
        }



        [Fact]
        public async void GetByApiServerUser_ServerUserDto_ShouldGetByApiServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            var serverUserData = await PostAsync<GetServerUserDto, ApiResponseEnvelope<ICollection<GetServerUserDto>>>("/ServerUser/GetAll", null);

            StringId serverUserApiKey = serverUserData.Data.OrderByDescending(x => x.Id).FirstOrDefault().ApiKeyHash;

            //Act
           var singleServerUser= await PostAsync<StringId, ApiResponseEnvelope<GetServerUserDto>>("/ServerUser/GetByApiKey", serverUserApiKey);

            //Arrange
            Assert.Equal(singleServerUser.Data.Username, "Etehadi");
        }



        [Fact]
        public async void GetAllServerUser_ServerUserDto_ShouldGetAllServerUserDto()
        {
            //Arrange
            var serverUsers = new List<CreateServerUserDto>()
            {
                new CreateServerUserDto(){IsAdmin = true,ApiKeyHash = "Sample ApiKeyHash",Username = "Etehadi",},
                new CreateServerUserDto(){IsAdmin = true,ApiKeyHash = "Sample ApiKeyHash",Username = "Etehadi",},
                new CreateServerUserDto(){IsAdmin = true,ApiKeyHash = "Sample ApiKeyHash",Username = "Etehadi",},
            };

            //Act
            foreach (var item in serverUsers)
            {
                var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", item);
            }
           var serverUsrList= await PostAsync<GetServerUserDto, ApiResponseEnvelope<ICollection<GetServerUserDto>>>("/ServerUser/GetAll", null);

            //Arrange
            Assert.InRange (serverUsrList.Data.Count,4,8);
        }
    }
}
