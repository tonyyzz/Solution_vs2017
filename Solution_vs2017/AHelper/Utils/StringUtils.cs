/*********************************************************
** File Name:	StringUtils.cs
** Copyright (C) 2016 TopWork. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description: 字符串帮助类
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System;
using System.Linq;
using HashidsNet;

namespace Auction.Utility.Utils
{
    public static class StringUtils
    {
        /// <summary>
        /// 将userid转成隐藏id
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientType"></param>
        /// <param name="userId"></param>
        /// <param name="slat"></param>
        /// <returns></returns>
        public static string SetDisplayIdByUser(string clientId, byte clientType, long userId)
        {
            var hashids = new Hashids(string.Concat(clientId, "_", clientType));
            return hashids.EncodeLong(userId);
        }
        /// <summary>
        /// 从隐藏id里获取userid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="slat"></param>
        /// <returns></returns>
        public static long GetUserIdByDisplay(string id, string clientId, byte clientType)
        {
            var hashids = new Hashids(string.Concat(clientId, "_", clientType));
            var ids = hashids.DecodeLong(id);
            if (ids.Length > 0)
            {
                return ids[0];
            }
            return 0;
        }
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns> 
        public static string GetRandomString(int length)
        {
            string s = "123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            string reValue = string.Empty;
            System.Random rnd = new System.Random(GetNewSeed());
            while (reValue.Length < length)
            {
                string s1 = s[rnd.Next(0, s.Length)].ToString();
                if (reValue.IndexOf(s1) == -1) reValue += s1;
            }
            return reValue;
        }
        /// <summary>
        /// 将真实Id转成隐藏Id
        /// </summary>
        /// <param name="realId"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string SetDisplayIdWithSalt(long realId, string salt)
        {
            var hashids = new Hashids(salt);
            return hashids.EncodeLong(realId);
        }
        /// <summary>
        /// 将隐藏Id转成真实Id
        /// </summary>
        /// <param name="displayId"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static long GetRealIdWithSalt(string displayId, string salt)
        {
            var hashids = new Hashids(salt);
            var ids = hashids.DecodeLong(displayId);
            if (ids.Length > 0)
            {
                return ids[0];
            }
            return 0;
        }

        /// <summary>
        /// 种子
        /// </summary>
        /// <returns></returns>
        private static int GetNewSeed()
        {
            byte[] rndBytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            return BitConverter.ToInt32(rndBytes, 0);
        }

        /// <summary>
        /// 判断一个字符串数据里的所有元素是否都是string.IsNullOrEmpty()
        /// 如果有至少一个非 NullOrEmpty，则返回false
        /// 全为NullOrEmpty，则返回true
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static bool IsStringsAllEmptyOrNull(params string[] strs)
        {
            return strs != null && strs.All(string.IsNullOrEmpty);
        }
    }
}
