using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput
{
    internal class GetOutputQueryHandler : IRequestHandler<GetOutputQuery, IotaSDKResponse<OutputData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetOutputQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<OutputData>> Handle(GetOutputQuery request, CancellationToken cancellationToken)
        {
            GetOutputQueryModelData innerModelData = new GetOutputQueryModelData(request.OutputId);
            IotaSDKModel<GetOutputQueryModelData> modelData = new IotaSDKModel<GetOutputQueryModelData>("getOutput", innerModelData);
            AccountModelData<GetOutputQueryModelData> accountModelData = new AccountModelData<GetOutputQueryModelData>(request.AccountIndex, modelData);
            IotaSDKAccountModel<GetOutputQueryModelData> accountModel = new IotaSDKAccountModel<GetOutputQueryModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<OutputData>.CreateInstance(accountResponse);
        }
    }
}
