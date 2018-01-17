using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Auction.Utility.Extentions;

namespace Auction.Utility.Utils
{
    public static class SignUtils
    {
        /// <summary>
        /// HMACSHA1签名数据
        /// </summary>
        /// <param name="source">待签名字符串</param>
        /// <param name="signKey">加密Key</param>
        /// <returns></returns>
        public static string SignDataForToBase64(string source, string signKey)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(signKey))
            {
                return null;
            }
            var alg = new HMACSHA1();
            alg.Key = Encoding.UTF8.GetBytes(signKey);
            byte[] word = Encoding.UTF8.GetBytes(source);
            byte[] result = alg.ComputeHash(word);
            return result.Concat(word).ToArray().Base64UrlEncode();
        }
        /// <summary>
        /// HMACSHA1验证数据
        /// </summary>
        /// <param name="source">待验证字符串</param>
        /// <param name="signKey">加密Key</param>
        /// <returns></returns>
        public static bool VerityDataFromBase64(string source, string signKey)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(signKey))
            {
                return false;
            }
            var alg = new HMACSHA1();
            byte[] data = source.Base64UrlDecode();
            var receivedHash = data.Take(alg.HashSize >> 3);
            //提取数据本身
            var dataContent = data.Skip(alg.HashSize >> 3).ToArray();
            //设置密钥
            alg.Key = Encoding.UTF8.GetBytes(signKey);
            //计算数据哈希值和收到的哈希值
            var computedHash = alg.ComputeHash(dataContent);
            //如果相等则数据正确
            return receivedHash.SequenceEqual(computedHash);
        }

        /// <summary>
        /// HMACSHA1签名数据
        /// </summary>
        /// <param name="source">待签名字符串</param>
        /// <param name="signKey">加密Key</param>
        /// <returns></returns>
        public static string SignDataForToHex(string source, string signKey)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(signKey))
            {
                return null;
            }
            var alg = new HMACSHA1();
            alg.Key = Encoding.UTF8.GetBytes(signKey);
            byte[] word = Encoding.UTF8.GetBytes(source);
            byte[] result = alg.ComputeHash(word);
            return ByteArrayToHexString(result.Concat(word).ToArray());
        }
        /// <summary>
        /// HMACSHA1验证数据
        /// </summary>
        /// <param name="source">待验证字符串</param>
        /// <param name="signKey">加密Key</param>
        /// <returns></returns>
        public static bool VerityDataFromHex(string source, string signKey)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(signKey))
            {
                return false;
            }
            var alg = new HMACSHA1();
            byte[] data = HexStringToByteArray(source);
            var receivedHash = data.Take(alg.HashSize >> 3);
            //提取数据本身
            var dataContent = data.Skip(alg.HashSize >> 3).ToArray();
            //设置密钥
            alg.Key = Encoding.UTF8.GetBytes(signKey);
            //计算数据哈希值和收到的哈希值
            var computedHash = alg.ComputeHash(dataContent);
            //如果相等则数据正确
            return receivedHash.SequenceEqual(computedHash);
        }

        /// <summary>
        /// HMACSHA1获取原数据
        /// </summary>
        /// <param name="source">待验证字符串</param>
        /// <param name="signKey">加密Key</param>
        /// <returns></returns>
        public static Tuple<bool, string> GetVerityDataHSHA1FromBase64(string source, string signKey)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(signKey))
            {
                return null;
            }
            var alg = new HMACSHA1();
            byte[] data = Convert.FromBase64String(source);
            //提取数据本身
            var dataContent = data.Skip(alg.HashSize >> 3).ToArray();
            //如果相等则数据正确
            var verf = VerityDataFromBase64(source, signKey);
            if (verf)
            {
                return new Tuple<bool, string>(verf, Encoding.UTF8.GetString(dataContent));
            }
            return null;
        }
        /// <summary>
        /// HMACSHA1获取原数据
        /// </summary>
        /// <param name="source">待验证字符串</param>
        /// <param name="signKey">加密Key</param>
        /// <returns></returns>
        public static Tuple<bool, string> GetVerityDataHSHA1FromHex(string source, string signKey)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(signKey))
            {
                return null;
            }
            var alg = new HMACSHA1();
            byte[] data = HexStringToByteArray(source);
            //提取数据本身
            var dataContent = data.Skip(alg.HashSize >> 3).ToArray();
            //如果相等则数据正确
            var verf = VerityDataFromHex(source, signKey);
            if (verf)
            {
                return new Tuple<bool, string>(verf, Encoding.UTF8.GetString(dataContent));
            }
            return null;
        }
     
        #region 私有方法

        /// <summary>
        /// 字节数组转16进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] bytes)
        {
            var hexString = string.Empty;
            if (bytes != null)
            {
                foreach (var b in bytes)
                {
                    hexString += b.ToString("X2");
                }
            }
            return hexString;
        }
        // <summary>
        /// 16进制转字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
        }
        #endregion
    }
}
