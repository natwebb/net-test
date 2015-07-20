using System.Threading.Tasks;

namespace NetTest.Business.Contracts
{
    public interface IMessage
    {
        //Properties
        string Content { get; }

        //Methods
        Task UpdateContent(string content);
    }
}