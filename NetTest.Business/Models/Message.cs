using System;
using System.Threading.Tasks;
using NetTest.Business.Contracts;

namespace NetTest.Business.Models
{
    public class Message : IMessage
    {
        public Message(Guid id, string content)
        {
            Id = id;
            Content = content;
        }

        public Message() { }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public Task UpdateContent(string message)
        {
            throw new NotImplementedException();
        }
    }
}