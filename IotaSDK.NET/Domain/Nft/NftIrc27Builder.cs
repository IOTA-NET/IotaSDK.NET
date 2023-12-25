using IotaSDK.NET.Common.Extensions;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Nft
{
    public class NftIrc27Builder
    {
        private NftIrc27 _nft;
        private readonly NftOptionsBuilder _nftOptionsBuilder;
        private readonly Action<string> _populateImmutableMetadataAction;

        public NftIrc27Builder(string mimeType, string nameOfNft, string uri, NftOptionsBuilder nftOptionsBuilder, Action<string> populateImmutableMetadataAction)
        {
            _nft = new NftIrc27(mimeType, nameOfNft, uri);
            _nftOptionsBuilder = nftOptionsBuilder;
            _populateImmutableMetadataAction = populateImmutableMetadataAction;
        }

        public NftIrc27Builder SetCollectionName(string collectionName)
        {
            _nft.SetCollectionName(collectionName);
            return this;
        }

        public NftIrc27Builder SetDescription(string description)
        {
            _nft.SetDescription(description);
            return this;
        }

        public NftIrc27Builder SetIssuerName(string issuerName)
        {
            _nft.SetIssuerName(issuerName);
            return this;
        }

        public NftIrc27Builder AddAttribute(string traitType, string value)
        {
            _nft.AddAttribute(traitType, value);
            return this;
        }

        public NftIrc27Builder AddInternalAttribute(string traitType, string value)
        {
            _nft.AddInternalAttribute(traitType, value);
            return this;
        }

        public NftOptionsBuilder Then()
        {
            _populateImmutableMetadataAction(JsonConvert.SerializeObject(_nft).ToHexString());
            return _nftOptionsBuilder;
        }
    }
}
