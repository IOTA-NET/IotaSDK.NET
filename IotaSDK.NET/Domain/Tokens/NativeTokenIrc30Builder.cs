using System;

namespace IotaSDK.NET.Domain.Tokens
{
    public class NativeTokenIrc30Builder
    {
        private string? _name, _symbol, _logoUrl, _description, _resourceUrl;
        private uint _decimals;
        private readonly CreateNativeTokenBuilder _nativeTokenBuilder;
        private readonly Action<NativeTokenIrc30> _setNativeTokenIrc30;

        public NativeTokenIrc30Builder(CreateNativeTokenBuilder nativeTokenBuilder, Action<NativeTokenIrc30> setNativeTokenIrc30)
        {
            _nativeTokenBuilder = nativeTokenBuilder;
            _setNativeTokenIrc30 = setNativeTokenIrc30;
        }

        public NativeTokenIrc30Builder SetTokenName(string tokenName)
        {
            _name = tokenName;
            return this;
        }

        public NativeTokenIrc30Builder SetSymbol(string symbol)
        {
            _symbol = symbol;
            return this;
        }

        public NativeTokenIrc30Builder SetLogoUrl(string logoUrl)
        {
            _logoUrl = logoUrl;
            return this;
        }

        public NativeTokenIrc30Builder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public NativeTokenIrc30Builder SetResourceUrl(string resourceUrl)
        {
            _resourceUrl = resourceUrl;
            return this;
        }

        public NativeTokenIrc30Builder SetNumberOfDecimals(uint decimals)
        {
            _decimals = decimals;
            return this;
        }

        public CreateNativeTokenBuilder Then()
        {
            if (_name == null || _symbol == null)
            {
                throw new ArgumentNullException("Ensure to set Token name, Symbol and decimal");
            }

            NativeTokenIrc30 nativeTokenIrc30 = new NativeTokenIrc30(_name!, _symbol!, _decimals);
            nativeTokenIrc30.LogoUrl = _logoUrl;
            nativeTokenIrc30.Description = _description;
            nativeTokenIrc30.Url = _resourceUrl;

            _setNativeTokenIrc30(nativeTokenIrc30);

            return _nativeTokenBuilder;
        }

    }
}
