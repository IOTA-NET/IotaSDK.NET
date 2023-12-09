namespace IotaSDK.NET.Domain.Signatures
{
    public class Ed25519Signature : Signature
    {
        public Ed25519Signature(string publicKey, string signature) : base((int)SignatureType.Ed25519)
        {
            PublicKey = publicKey;
            Signature = signature;
        }

        public string PublicKey { get; }
        public string Signature { get; }
    }
}
