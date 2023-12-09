using IotaSDK.NET.Domain.Signatures;

namespace IotaSDK.NET.Domain.Transactions.Unlocks
{
    /// <summary>
    /// An unlock holding one or more signatures unlocking one or more inputs..
    /// </summary>
    public class SignatureUnlock : Unlock
    {
        public SignatureUnlock(Ed25519Signature ed25519Signature) : base((int)UnlockType.Signature)
        {
            Signature = ed25519Signature;
        }

        public Ed25519Signature Signature { get; }
    }
}
