using System;
using NetTest.Shared.Constants;

namespace NetTest.Business.Contracts
{
    public interface IAsset
    {
        //Properties
        Guid Id { get; }
        string Container { get; }
        string Owner { get; }
        string Title { get; }
        AssetType Type { get; }
        Uri Url { get; } 
    }
}