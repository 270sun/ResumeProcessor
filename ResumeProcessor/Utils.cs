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

        #region URL And HTML 编码解码

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

        #endregion

		public static string RemoveHtml(string content)
		{
            //string regexstr = @"<[^>]*>";
            //return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(content)) return "";
            return Regex.Replace(Regex.Replace(content, "<[^>]*>", ""), "<script", string.Empty, RegexOptions.IgnoreCase);

		}

        public static string GetString(this string input, string start, string end)
        {
            if (!input.Contains(start)) return "";
            if (!input.Contains(end)) return input.Substring(input.IndexOf(start));
            return input.Substring(input.IndexOf(start), input.IndexOf(end) - input.IndexOf(start)-end.Length+1);
        }

    }
}
