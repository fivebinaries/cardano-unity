using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoBech32
{
  interface ICardanoBech32Wrapper
  {
    string ConvertToHexAddressFromBech32(string inBech32);
    bool TryConvertToHexAddressFromBech32(string inBech32, out string valueInHex);
    bool TryConvertToHexAddressFromBech32(string inBech32, out byte[] valueInHex);
    string ConvertToBech32AddressFromHex(string inHex, AddressType addressType);
    string GenerateAssetNameFingerprint(string policyId, string assetname);
    string GetStakeAddressFromAddress(string address);
  }
}
