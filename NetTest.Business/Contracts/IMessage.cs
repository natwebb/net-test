using System;
using System.Threading.Tasks;

namespace NetTest.Business.Contracts
{
    public interface IMessage
    {
        //Properties
        Guid Id { get; }
        string Content { get; }

        //Methods
        Task UpdateContent(string content);
    }
}