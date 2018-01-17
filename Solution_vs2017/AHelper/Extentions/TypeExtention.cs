/*********************************************************
** File Name:	TypeExtention.cs
** Copyright (C) 2016 TopWork. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description:	类型扩展
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Auction.Utility.Extentions
{
    public static class TypeExtention
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> ReflectionPropertyCache = new ConcurrentDictionary<Type, PropertyInfo[]>();
        /// <summary>
        /// 添加Type扩展
        /// </summary>
        /// <param name="objectType">类型</param>
        /// <returns></returns>
        private static PropertyInfo[] FindClassProperties(this Type objectType)
        {
            if (ReflectionPropertyCache.ContainsKey(objectType))
            {
                return ReflectionPropertyCache[objectType];
            }
            var result = objectType.GetProperties().ToArray();
            ReflectionPropertyCache.TryAdd(objectType, result);
            return result;
        }
        /// <summary>
        /// 添加Class扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">类实例</param>
        /// <returns></returns>
        public static PropertyInfo[] FindClassProperties<T>(this T obj) where T : class
        {
            var objType = typeof(T);
            return FindClassProperties(objType);
        }
    }
}
