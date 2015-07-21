using System;
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
            MessageEntity newMessage = new MessageEntity(id) { Content = content };

            try
            {
                MessagesTable.CreateIfNotExists();

                TableOperation insertOperation = TableOperation.Insert(newMessage);

                MessagesTable.Execute(insertOperation);
            } catch (Exception e)
            {
                // ignored
            }

            return newMessage;
        }

        public async Task<MessageEntity> FindByIdAsync(Guid id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

            return (MessageEntity)MessagesTable.Execute(retrieveOperation).Result;
        }

        public async Task<System.Collections.Generic.IEnumerable<MessageEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}