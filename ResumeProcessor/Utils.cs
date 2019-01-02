using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Net;

namespace PictureServices.Core
{
    public static class Utils
	{

		public static string HtmlEncode(string str)
		{
			return HttpUtility.HtmlEncode(str);
		}

		public static string HtmlDecode(string str)
		{
			return HttpUtility.HtmlDecode(str);
		}

		public static string UrlEncode(string str)
		{
			return HttpUtility.UrlEncode(str);
		}

		public static string UrlDecode(string str)
		{
			return HttpUtility.UrlDecode(str);
        }

		public static string RemoveHtml(string content)
		{
            if (string.IsNullOrEmpty(content)) return "";
            return Regex.Replace(Regex.Replace(content, "<[^>]*>", ""), "<script", string.Empty, RegexOptions.IgnoreCase);
		}

        public static string GetSubString(this string input, string start, string end)
        {
            if (!input.Contains(start)) return "";
            if (!input.Contains(end)) return input.Substring(input.IndexOf(start));
            return input.Substring(input.IndexOf(start), input.IndexOf(end) - input.IndexOf(start));
        }

        public static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }

        public static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }

        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }

        public static string EncodeBase64(Encoding encode, string source)
        {
            byte[] bytes = encode.GetBytes(source);

            return Convert.ToBase64String(bytes);
        }

        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }
}
