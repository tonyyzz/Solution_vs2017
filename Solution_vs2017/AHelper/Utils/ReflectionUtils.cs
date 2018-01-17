/*********************************************************
** File Name:	ReflectionUtils.cs
** Copyright (C) 2016 TopWork. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description: 反射帮助类
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Utility.Extentions;

namespace Auction.Utility.Utils
{
    public static class ReflectionUtils
    {
       
        /// <summary>
        /// 获取object属性转换成字典
        /// </summary>
        /// <param name="obj">object类型参数</param>
        /// <param name="field">排除字段</param>
        /// <returns></returns>
        public static IDictionary<string, object> GetObjectValues(object obj, string field = null)
        {
            if (obj == null)
            {
                return null;
            }
            IDictionary<string, object> result = new Dictionary<string, object>();
            foreach (var propertyInfo in obj.FindClassProperties())
            {
                var name = propertyInfo.Name;
                if (field != null)
                {
                    if (name.ToLower() != field.ToLower())
                    {
                        var value = propertyInfo.GetValue(obj, null);
                        result[name] = value;
                    }
                }
                else
                {
                    var value = propertyInfo.GetValue(obj, null);
                    result[name] = value;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取object属性转换成字典
        /// </summary>
        /// <param name="obj">object类型参数</param>
        /// <param name="alias">别名</param>
        /// <param name="isAlias">是否添加别名</param>
        /// <returns></returns>
        public static IDictionary<string, object> GetObjectValues(object obj, string alias, bool isAlias)
        {
            if (obj == null)
            {
                return null;
            }
            IDictionary<string, object> result = new Dictionary<string, object>();
            foreach (var propertyInfo in obj.FindClassProperties())
            {
                var name = propertyInfo.Name;
                var value = propertyInfo.GetValue(obj, null);
                if (isAlias)
                {
                    alias = alias ?? obj.GetType().Name;
                    result[string.Concat(alias, "_", name)] = value;
                }
                else
                {
                    result[name] = value;
                }

            }
            return result;
        }

        /// <summary>
        /// 获取特性的值
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="type"></param>
        /// <param name="valueSelector"></param>
        /// <returns></returns>
        public static TValue GetAttributeValue<TAttribute, TValue>(Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
}
