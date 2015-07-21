using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using NetTest.Persistence.Contracts;
using NetTest.Persistence.Entities;

namespace NetTest.Persistence.Models
{
    public class PersistenceMessageCollection : IPersistenceMessageCollection
    {
        private static readonly CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(WebConfigurationManager.AppSettings["StorageConnectionString"]);
        private static readonly CloudTableClient TableClient = StorageAccount.CreateCloudTableClient();
        private static readonly CloudTable MessagesTable = TableClient.GetTableReference("Messages");

        public async Task<MessageEntity> CreateAsync(Guid id, string content)
        {
            try
            {
                MessageEntity newMessage = new MessageEntity(id) { Content = content };

                MessagesTable.CreateIfNotExists();

                TableOperation insertOperation = TableOperation.Insert(newMessage);

                MessagesTable.Execute(insertOperation);

                return newMessage;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

                TableResult retrievedResult = MessagesTable.Execute(retrieveOperation);

                MessageEntity deleteEntity = (MessageEntity)retrievedResult.Result;

                if (deleteEntity != null)
                {
                    TableOperation updateOperation = TableOperation.Delete(deleteEntity);

                    MessagesTable.Execute(updateOperation);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<MessageEntity> FindByIdAsync(Guid id)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

                return (MessageEntity) MessagesTable.Execute(retrieveOperation).Result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<MessageEntity>> GetAllAsync()
        {
            try
            {
                TableQuery<MessageEntity> query = new TableQuery<MessageEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"));

                return MessagesTable.ExecuteQuery(query);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<MessageEntity> UpdateAsync(Guid id, string content)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

                TableResult retrievedResult = MessagesTable.Execute(retrieveOperation);

                MessageEntity updateEntity = (MessageEntity) retrievedResult.Result;

                if (updateEntity != null)
                {
                    updateEntity.Content = content;

                    TableOperation updateOperation = TableOperation.Replace(updateEntity);

                    MessagesTable.Execute(updateOperation);
                }

                return updateEntity;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}