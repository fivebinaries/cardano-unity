using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoBech32
{
  public class CardanoBech32Wrapper : ICardanoBech32Wrapper
  {
    public string ConvertToHexAddressFromBech32(string inBech32)
    {
      if (inBech32 == null) return null;

      inBech32 = inBech32.Trim();

      string hrp;
      byte[] data;
      Bech32Engine.Decode(inBech32, out hrp, out data);

      if (data == null) return string.Empty;
      return BitConverter.ToString(data).Replace("-", string.Empty).ToLower();
    }

    public string ConvertToBech32AddressFromHex(string inHex, AddressType addressType)
    {
      if (inHex == null) return null;

      inHex = inHex.Trim();

      var asByte = Helper.ConvertHexStringToByte(inHex);

      var bech32Address = Bech32Engine.Encode(addressType.ToString(), asByte);

      return bech32Address;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="policyId">Must be in Hex</param>
    /// <param name="assetname">Can be in Hex Or UTF8</param>
    /// <returns></returns>
    public string GenerateAssetNameFingerprint(string policyId, string assetname)
    {
      throw new NotImplementedException();
    }

    public string GetStakeAddressFromAddress(string address)
    {
      var addressInHex = ConvertToHexAddressFromBech32(address);
      if (addressInHex == null) return null;

      int stakeAddressLength = 56;
      var stakeAddressInHex = "e1"+ addressInHex.Substring(addressInHex.Length - stakeAddressLength, stakeAddressLength);

      if (address.StartsWith(AddressType.addr.ToString())) return ConvertToBech32AddressFromHex(stakeAddressInHex, AddressType.stake);

      if (address.StartsWith(AddressType.addr_test.ToString())) return ConvertToBech32AddressFromHex(stakeAddressInHex, AddressType.stake_test);

      return null;
    }

    public bool TryConvertToHexAddressFromBech32(string inBech32, out string valueInHex)
    {
      if(Helper.IsBech32ToHexConvertible(inBech32))
      {
        valueInHex = ConvertToHexAddressFromBech32(inBech32);
        return true;
      }
      valueInHex = null;
      return false;
    }

    public bool TryConvertToHexAddressFromBech32(string inBech32, out byte[] valueInHex)
    {
      if (Helper.IsBech32ToHexConvertible(inBech32))
      {
        var ret = ConvertToHexAddressFromBech32(inBech32);
        valueInHex = Helper.ConvertHexStringToByte(ret);
        return true;
      }
      valueInHex = null;
      return false;
    }
  }

  public enum AddressType
  {
    /// <summary>
    /// Mainnet Address
    /// </summary>
    addr,
    /// <summary>
    /// Mainnet Stake Address
    /// </summary>
    stake,
    /// <summary>
    /// Mainnet Pool Address
    /// </summary>
    pool,
    //asset,
    /// <summary>
    /// Testnet Address
    /// </summary>
    addr_test,
    /// <summary>
    /// Testnet Stake Address
    /// </summary>
    stake_test,
    /// <summary>
    /// Testnet Stake Address
    /// </summary>
    pool_test,
    //asset_test
  }
}
