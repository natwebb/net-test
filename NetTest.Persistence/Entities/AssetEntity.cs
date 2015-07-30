using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace NetTest.Persistence.Entities
{
    public class AssetEntity : TableEntity
    {
        public AssetEntity(Guid id)
        {
            PartitionKey = "2";
            RowKey = id.ToString();
        }

        public AssetEntity() { }

        public string Container { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
