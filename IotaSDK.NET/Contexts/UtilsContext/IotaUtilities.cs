using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Contexts.UtilsContext.Commands.AliasIdToBech32;
using IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHash;
using IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic;
using IotaSDK.NET.Contexts.UtilsContext.Commands.HashToBech32;
using IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed;
using IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32;
using IotaSDK.NET.Contexts.UtilsContext.Commands.OutputIdToNftId;
using IotaSDK.NET.Contexts.UtilsContext.Commands.PublicKeyToBech32;
using IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyBech32Address;
using IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext
{
    public class IotaUtilities : IIotaUtilities
    {
        private readonly IMediator _mediator;

        public IotaUtilities(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<string>> ConvertMnemonicToHexSeedAsync(string mnemonic)
        {
            return await _mediator.Send(new MnemonicToHexSeedCommand(mnemonic, "mnemonicToHexSeed"));
        }

        public async Task<IotaSDKResponse<bool>> VerifyMnemonicAsync(string mnemonic)
        {
            return await _mediator.Send(new VerifyMnemonicCommand(mnemonic, "verifyMnemonic"));
        }

        public async Task<IotaSDKResponse<string>> GenerateMnemonicAsync()
        {
            IotaSDKResponse<string> generateMnemonicResponse = await _mediator.Send(new GenerateMnemonicCommand("generateMnemonic"));

            return generateMnemonicResponse;
        }

        public async Task<IotaSDKResponse<string>> ConvertNftIdToBech32Async(string nftId, HumanReadablePart humanReadablePart)
        {
            return await _mediator.Send(new NftIdToBech32Command(nftId, humanReadablePart, "nftIdToBech32"));
        }

        public async Task<IotaSDKResponse<string>> ConvertBech32ToHashAsync(string bech32Address)
        {
            return await _mediator.Send(new Bech32ToHashCommand(bech32Address, "bech32ToHex"));
        }

        public async Task<IotaSDKResponse<string>> ConvertAliasIdToBech32Async(string aliasId, HumanReadablePart humanReadablePart)
        {
            return await _mediator.Send(new AliasIdToBech32Command(aliasId, humanReadablePart, "aliasIdToBech32"));
        }

        public async Task<IotaSDKResponse<bool>> VerifyBech32Address(string bech32Address)
        {
            return await _mediator.Send(new VerifyBech32AddressCommand(bech32Address, "isAddressValid"));
        }

        public async Task<IotaSDKResponse<string>> ConvertPublicKeyToBech32Async(string hexEncodedPublicKey, HumanReadablePart humanReadablePart)
        {
            return await _mediator.Send(new PublicKeyToBech32Command(hexEncodedPublicKey, humanReadablePart, "hexPublicKeyToBech32Address"));
        }

        public async Task<IotaSDKResponse<string>> ConvertHashToBech32Async(string hexEncodedHash, HumanReadablePart humanReadablePart)
        {
            return await _mediator.Send(new HashToBech32Command(hexEncodedHash, humanReadablePart, "hexToBech32"));
        }

        public async Task<IotaSDKResponse<string>> ConvertOutputIdToNftIdAsync(string hexEncodedOutputId)
        {
            return await _mediator.Send(new OutputIdToNftIdCommand(hexEncodedOutputId, "computeNftId"));
        }
    }
}
