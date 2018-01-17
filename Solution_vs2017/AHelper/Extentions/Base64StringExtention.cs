/*********************************************************
** File Name:	Base64StringExtention.cs
** Copyright (C) 2016 TopWork. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description:	Base64扩展
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System;

namespace Auction.Utility.Extentions
{
    public static class Base64StringExtention
    {
        /// <summary>
        /// base64encode for safe-url
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static string Base64UrlEncode(this byte[] input)
        {
            var output = Convert.ToBase64String(input);
            //去掉=
            output = output.Split('=')[0];
            //替换+和/
            output = output.Replace('+', '-');
            output = output.Replace('/', '_');
            return output;
        }

        /// <summary>
        /// base64decode for safe-url
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] Base64UrlDecode(this string input)
        {
            var output = input;
            //替换-和_
            output = output.Replace('-', '+');
            output = output.Replace('_', '/');
            switch (output.Length % 4)
            {
                case 0: break;
                case 2: output += "=="; break;
                case 3: output += "="; break;
                default: throw new FormatException("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output);
            return converted;
        }
    }
}
