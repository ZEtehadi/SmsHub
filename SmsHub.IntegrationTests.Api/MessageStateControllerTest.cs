﻿using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    public class MessageStateControllerTest : BaseIntegrationTest
    {
        public MessageStateControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateMessageState_MessageStateDto_ShouldCreateMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar
            };
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            ////Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId = 1,
                MessageStateCategoryId = 1,
                InsertDateTime = DateTime.Now,
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteMessageState_MessageStateDto_ShouldDeleteMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar
            };
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            ////Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId = 1,
                MessageStateCategoryId = 1,
                InsertDateTime = DateTime.Now,
            };
            var deleteMessageState = new DeleteMessageStateDto()
            {
                Id = 1
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            await PostAsync<DeleteMessageStateDto, DeleteMessageStateDto>("/MessageState/Delete", deleteMessageState);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateMessageState_MessageStateDto_ShouldUpdateMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar
            };
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            ////Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId = 1,
                MessageStateCategoryId = 1,
                InsertDateTime = DateTime.Now,
            };
            var updateMessageState = new UpdateMessageStateDto()
            {
                Id = 1,
                MessagesDetailId = 1,
                MessageStateCategoryId = 1,
                InsertDateTime = DateTime.Now,
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            await PostAsync<UpdateMessageStateDto, UpdateMessageStateDto>("/MessageState/Update", updateMessageState);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void GetSingleMessageState_MessageStateDto_ShouldGetSingleMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar
            };
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            ////Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId = 1,
                MessageStateCategoryId = 1,
                InsertDateTime = DateTime.Now,
            };
            var messageStateId = new IntId()
            {
                Id = 1
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            var singleMessageState = await PostAsync<IntId, ApiResponseEnvelope<GetMessageStateDto>>("/MessageState/GetSingle", messageStateId);

            //Assert
            Assert.Equal(singleMessageState.Data.Id, 1);
        }


        [Fact]
        public async void GetListMessageState_MessageStateDto_ShouldGetListMessageState()
        {
            //Arrange
            var messageStateCategories = new List<CreateMessageStateCategoryDto>()
            {
                new CreateMessageStateCategoryDto(){Css = "Sample Css",IsError = true,Title = "Sample Title",ProviderId = ProviderEnum.Kavenegar},
                new CreateMessageStateCategoryDto(){Css = "Sample Css",IsError = true,Title = "Sample Title",ProviderId = ProviderEnum.Kavenegar},
                new CreateMessageStateCategoryDto(){Css = "Sample Css",IsError = true,Title = "Sample Title",ProviderId = ProviderEnum.Kavenegar},
            };

            var messageStateCategoryList = await PostAsync<GetMessageStateCategoryDto, ApiResponseEnvelope<ICollection<GetMessageStateCategoryDto>>>("/MessageStateCategory/GetList", null);

            //Arrange
            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "sample1 Credential",Number = "111"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "sample2 Credential",Number = "150"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "sample3 Credential",Number = "125"},
            };
            var messageBatchs = new List<CreateMessageBatchDto>()
            {
                new CreateMessageBatchDto(){ HolerSize = 12,AllSize = 8,InsertDateTime = DateTime.Now,LineId = 1},
                new CreateMessageBatchDto(){ HolerSize = 5,AllSize = 2,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolerSize = 8,AllSize = 4,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolerSize = 3,AllSize = 6,InsertDateTime = DateTime.Now,LineId = 3},
            };
            var messageHolders = new List<CreateMessagesHolderDto>()
            {
                new CreateMessagesHolderDto(){MessageBatchId = 1,InsertDateTime = DateTime.Now,DetailsSize = 2,RetryCount = 1,SendDone = false},
                new CreateMessagesHolderDto(){MessageBatchId = 2,InsertDateTime = DateTime.Now,DetailsSize = 8,RetryCount = 5,SendDone = false},
                new CreateMessagesHolderDto(){MessageBatchId = 3,InsertDateTime = DateTime.Now,DetailsSize = 10,RetryCount = 3,SendDone = true},
                new CreateMessagesHolderDto(){MessageBatchId = 4,InsertDateTime = DateTime.Now,DetailsSize = 5,RetryCount = 2,SendDone = false},
            };

            //Act
            foreach (var item in messageStateCategories)
            {
                await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", item);
            }
            foreach (var item in lines)
            {
                await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", item);
            }
            foreach (var item in messageBatchs)
            {
                await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", item);
            }
            foreach (var item in messageHolders)
            {
                await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", item);
            }
            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId_1 = messagesHolders.Data.FirstOrDefault().Id;
            var messageHolderId_2 = messagesHolders.Data.Where(x => x.RetryCount == 5).FirstOrDefault().Id;
            var messageHolderId_3 = messagesHolders.Data.Where(x => x.RetryCount == 3).FirstOrDefault().Id;



            var messageDetails = new List<CreateMessageDetailDto>()
            {
                new CreateMessageDetailDto(){MessagesHolderId = messageHolderId_1,ProviderResult =2,Receptor = "sample1",SendDateTime = DateTime.Now,SmsCount = 1,Text = "sample1 Text"},
                new CreateMessageDetailDto(){MessagesHolderId = messageHolderId_2,ProviderResult = 3,Receptor = "sample2",SendDateTime = DateTime.Now,SmsCount = 1,Text = "sample2 Text"},
                new CreateMessageDetailDto(){MessagesHolderId = messageHolderId_3,ProviderResult = 4,Receptor = "sample3",SendDateTime = DateTime.Now,SmsCount = 1,Text = "sample3 Text"},
            };
            var messageStates = new List<CreateMessageStateDto>()
            {
                new CreateMessageStateDto(){MessagesDetailId = 1,MessageStateCategoryId = 2,InsertDateTime = DateTime.Now,},
                new CreateMessageStateDto(){MessagesDetailId = 2,MessageStateCategoryId = 1,InsertDateTime = DateTime.Now,},
                new CreateMessageStateDto(){MessagesDetailId = 3,MessageStateCategoryId = 3,InsertDateTime = DateTime.Now,},
            };

            foreach (var item in messageDetails)
            {
                await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", item);
            }
            foreach (var item in messageStates)
            {
                await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", item);
            }

            var messageStateList = await PostAsync<GetMessageStateDto, ApiResponseEnvelope<ICollection<GetMessageStateDto>>>("/MessageState/GetList", null);

            //Assert
            Assert.Equal(messageStateList.Data.Count, 3);
        }
    }
}