using System;
using NetTest.Business.Contracts;
using NetTest.Shared.Constants;

namespace NetTest.Business.Models
{
    public class Asset : IAsset
    {
        public Asset(Guid id, string container, AssetType type, string owner, string title, Uri url)
        {
            Id = id;
            Container = container;
            Type = type;
            Owner = owner;
            Title = title;
            Url = url;
        }

        public Asset() { }

        public Guid Id { get; set; }

        public string Container { get; set; }

        public string Owner { get; set; }

        public string Title { get; set; }

        public AssetType Type { get; set; }

        public Uri Url { get; set; }
    }
}