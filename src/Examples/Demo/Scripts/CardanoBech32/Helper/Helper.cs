using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CardanoBech32
{
  public static class Helper
  {
    public static byte[] ConvertHexStringToByte(string input)
    {
      input = input?.Trim();
      if (!IsHex(input) || string.IsNullOrWhiteSpace(input)) return Array.Empty<byte>();

      if (input.Length % 2 == 1) throw new Exception("The binary key cannot have an odd number of digits");

      byte[] arr = new byte[input.Length >> 1];

      for (int i = 0; i < input.Length >> 1; ++i)
      {
        arr[i] = (byte)((GetHexVal(input[i << 1]) << 4) + (GetHexVal(input[(i << 1) + 1])));
      }

      return arr;

    }
    public static string ConvertHexStringToUTF8(string input)
    {
      var asByte = ConvertHexStringToByte(input);
      return System.Text.Encoding.UTF8.GetString(asByte);
    }

    /// <summary>
    /// Casts char to int value of encoding page (UTF16)
    /// </summary>
    private static int GetHexVal(char hex)
    {
      int val = (int)hex;
      //For uppercase A-F letters:
      //return val - (val < 58 ? 48 : 55);
      //For lowercase a-f letters:
      //return val - (val < 58 ? 48 : 87);
      //Or the two combined, but a bit slower:
      return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
    }
    public static string ConvertByteToHexString(byte[] input)
    {
      if (input == null) return string.Empty;
      return BitConverter.ToString(input).Replace("-", string.Empty).ToLower();

    }
    public static bool TryConvertByteToHexString(byte[] input, out string valueInHex)
    {
      var result = ConvertByteToHexString(input);
      if(!string.IsNullOrWhiteSpace(result) && IsHex(result))
      {
        valueInHex = result;
        return true;
      }

      valueInHex = null;
      return false;
    }
    public static bool TryConvertHexStringToByte(string input, out byte[] valueInHex)
    {
      var result = ConvertHexStringToByte(input);

      if (result != null && result.Length > 0)
      {
        valueInHex = result;
        return true;
      }

      valueInHex = null;
      return false;
    }

    public static string ConvertByteToUTF8String(byte[] input)
    {
      if (input == null) return string.Empty;
      return Encoding.UTF8.GetString(input);
    }
    public static byte[] ConvertUTF8StringToByte(string input)
    {
      return Encoding.UTF8.GetBytes(input);
    }

    public static string ConvertByteToUTF32String(byte[] input)
    {
      if (input == null)
        return string.Empty;
      return Encoding.UTF8.GetString(input);
    }

    /// <summary>
    /// True for 0-9, A-F, a-f
    /// </summary>
    public static bool IsHex(IEnumerable<char> chars)
    {
      if (chars == null)
        return false;
      bool doesApply;
      foreach (var c in chars)
      {
        doesApply = ((c >= '0' && c <= '9') ||
                     (c >= 'a' && c <= 'f') ||
                     (c >= 'A' && c <= 'F'));

        if (!doesApply)
          return false;
      }
      return true;
    }

    /// <summary>
    /// True for 0-9, A-Z, a-z
    /// </summary>
    public static bool IsDigitLetter(IEnumerable<char> chars)
    {
      if (chars == null)
        return false;

      bool doesApply;
      foreach (var c in chars)
      {
        doesApply =
                ((c >= '0' && c <= '9') ||
                 (c >= 'a' && c <= 'z') ||
                 (c >= 'A' && c <= 'Z'));

        if (!doesApply)
          return false;
      }
      return true;
    }
    /// <summary>
    /// True for 0-9, A-Z, a-z, _ and " " 
    /// </summary>
    public static bool IsDigitLetterUnderscoreWhitespace(IEnumerable<char> chars)
    {
      if (chars == null)
        return false;

      bool doesApply;
      foreach (var c in chars)
      {
        doesApply =
                ((c >= '0' && c <= '9') ||
                 (c >= 'a' && c <= 'z') ||
                 (c >= 'A' && c <= 'Z') ||
                 (c == '_') ||
                 (c == ' '));

        if (!doesApply)
          return false;
      }
      return true;
    }

    public static bool IsBech32ToHexConvertible(string addr)
    {
      if (string.IsNullOrWhiteSpace(addr)) return false;

      var lowAdr = addr.ToLower();
      var highAdr = addr.ToUpper();

      // if there's mixed case, that's not OK
      if (addr != lowAdr && addr != highAdr)
      {
        return false;
      }

      return addr.IndexOf("1") > -1;
    }


  }
}
