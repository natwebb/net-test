using System;
using System.Threading.Tasks;
using NetTest.Business.Contracts;

namespace NetTest.Business.Models
{
    public class Message : IMessage
    {
        public Guid Id;

        public string Content { get; set; }

        public Task UpdateContent(string message)
        {
            throw new NotImplementedException();
        }
    }
}