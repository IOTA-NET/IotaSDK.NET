using IotaSDK.NET.Common.Extensions;
using System;

namespace IotaSDK.NET.Domain.Nft
{
    public class NftOptionsBuilder
    {
        private readonly MintNftBuilder _mintNftBuilder;
        private readonly Action<NftOptions> _nftOptionsAddingAction;
        private NftOptions _options;
        private NftIrc27Builder _nftIrc27Builder;

        public NftOptionsBuilder(MintNftBuilder mintNftBuilder, Action<NftOptions> nftOptionsAddingAction)
        {
            _mintNftBuilder = mintNftBuilder;
            _nftOptionsAddingAction = nftOptionsAddingAction;
            _options = new NftOptions();
        }


        public NftIrc27Builder AddImmutableMetadata(string mimeType, string nameOfNft, string uri)
        {
            _nftIrc27Builder = new NftIrc27Builder(mimeType, nameOfNft, uri, this, x => _options.ImmutableMetadata = x);
            return _nftIrc27Builder;
        }

        public NftOptionsBuilder AddMutableMetadata(string metadata)
        {
            _options.Metadata = metadata.ToLower().StartsWith("0x") ? metadata : metadata.ToHexString();
            return this;
        }

        public NftOptionsBuilder AddMintingAddress(string address)
        {
            _options.Address = address;
            return this;
        }

        public NftOptionsBuilder AddSenderAddress(string address)
        {
            _options.Sender = address;
            return this;
        }

        public NftOptionsBuilder AddTag(string tag)
        {
            _options.Tag = tag.ToLower().StartsWith("0x") ? tag : tag.ToHexString();
            return this;
        }

        public NftOptionsBuilder AddIssuer(string address)
        {
            _options.Issuer = address;
            return this;
        }

        public MintNftBuilder Then()
        {
            _nftOptionsAddingAction(_options);
            return _mintNftBuilder;
        }

    }
}
