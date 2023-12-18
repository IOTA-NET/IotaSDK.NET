using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Models;

namespace IotaSDK.NET.Common.Exceptions
{
    [System.Serializable]
    public class IotaSDKException : System.Exception
    {
        public IotaSDKException() { }
        public IotaSDKException(string message) : base(message) { }
        public IotaSDKException(string message, System.Exception inner) : base(message, inner) { }
        protected IotaSDKException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public static void CheckForException(string response)
        {
            if (response!.HasError())
                throw new IotaSDKException(IotaSDKResponse<IotaSDKErrorResponse>.CreateInstance(response).ToString());
        }
    }
}
