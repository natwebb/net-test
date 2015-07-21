using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace NetTest.Persistence.Entities
{
    public class MessageEntity : TableEntity
    {
        public MessageEntity(Guid id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }

        public MessageEntity() { }

        public string Content { get; set; }
    }
}
