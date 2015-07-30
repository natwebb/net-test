using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using NetTest.Persistence.Contracts;
using NetTest.Persistence.Entities;

namespace NetTest.Persistence.Models
{
    public class PersistenceAssetCollection : IPersistenceAssetCollection
    {
        private static readonly CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(WebConfigurationManager.AppSettings["StorageConnectionString"]);
        private static readonly CloudBlobClient BlobClient = StorageAccount.CreateCloudBlobClient();
        private static readonly CloudTableClient TableClient = StorageAccount.CreateCloudTableClient();
        private static readonly CloudTable AssetsTable = TableClient.GetTableReference("assets");

        public async Task<AssetEntity> CreateAsync(string container, string type, string owner, string title, Stream stream)
        {
            string fileName = new StringBuilder().AppendFormat("{0}/{1}/{2}", owner, type, title).ToString().ToLower();
            var newUri = await CreateBlobAsync(container, fileName, stream);
            if (newUri != null)
            {
                return await CreateTableEntityAsync(Guid.NewGuid(), container, type, owner, title, newUri);
            }

            return null;
        } 

        public async Task<Uri> CreateBlobAsync(string container, string fileName, Stream fileStream)
        {
            try
            {
                CloudBlobContainer blobContainer = BlobClient.GetContainerReference(container);
                blobContainer.CreateIfNotExists();

                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(fileName);

                //TODO add block to stop upload if blob with matching fileName already exists

                blockBlob.UploadFromStream(fileStream);

                return blockBlob.Uri;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<AssetEntity> CreateTableEntityAsync(Guid id, string container, string type, string owner, string title, Uri url)
        {
            try
            {
                AssetEntity newAsset = new AssetEntity(id) { Container = container, Type = type, Owner = owner, Title = title, Url = url.ToString() };

                AssetsTable.CreateIfNotExists();

                TableOperation insertOperation = TableOperation.Insert(newAsset);

                AssetsTable.Execute(insertOperation);

                return newAsset;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public async Task<bool> DeleteAsync(Guid id)
        //{
        //    try
        //    {
        //        TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

        //        TableResult retrievedResult = MessagesTable.Execute(retrieveOperation);

        //        MessageEntity deleteEntity = (MessageEntity)retrievedResult.Result;

        //        if (deleteEntity != null)
        //        {
        //            TableOperation updateOperation = TableOperation.Delete(deleteEntity);

        //            MessagesTable.Execute(updateOperation);
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<MessageEntity> FindByIdAsync(Guid id)
        //{
        //    try
        //    {
        //        TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

        //        return (MessageEntity) MessagesTable.Execute(retrieveOperation).Result;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<IEnumerable<MessageEntity>> GetAllAsync()
        //{
        //    try
        //    {
        //        TableQuery<MessageEntity> query = new TableQuery<MessageEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"));

        //        return MessagesTable.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<MessageEntity> UpdateAsync(Guid id, string content)
        //{
        //    try
        //    {
        //        TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>("1", id.ToString());

        //        TableResult retrievedResult = MessagesTable.Execute(retrieveOperation);

        //        MessageEntity updateEntity = (MessageEntity) retrievedResult.Result;

        //        if (updateEntity != null)
        //        {
        //            updateEntity.Content = content;

        //            TableOperation updateOperation = TableOperation.Replace(updateEntity);

        //            MessagesTable.Execute(updateOperation);
        //        }

        //        return updateEntity;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
    }
}