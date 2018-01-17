/*********************************************************
** File Name:	EnumUtils.cs
** Copyright (C) 2016 TuJiaTrip. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description: 枚举帮助类
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;


namespace System
{
	/// <summary>
	/// 没用过
	/// </summary>
	public class EnumUtils
	{
		/// <summary>
		/// 获取枚举的描述
		/// </summary>
		/// <param name="enumField"></param>
		/// <returns></returns>
		public static string GetEnumDescription(Enum enumField)
		{
			return GetEnumItem(enumField).Description;
		}

		/// <summary>
		/// 根据枚举字符值获取描述
		/// </summary>
		/// <typeparam name="TEnum">枚举</typeparam>
		/// <param name="value">枚举字符值</param>
		/// <returns></returns>
		public static string GetEnumDescription<TEnum>(string value)
		{
			Type enumType = typeof(TEnum);
			if (!enumType.IsEnum)
			{
				return value;
			}
			string enumItem = value;
			if (enumItem == null)
			{
				return value;
			}
			var e = enumType.GetField(enumItem);
			if (e == null)
			{
				return value;
			}
			object[] objs = e.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (objs == null || objs.Length == 0)
			{
				return value;
			}
			else
			{
				DescriptionAttribute attr = objs[0] as DescriptionAttribute;
				return attr.Description;
			}
		}

		/// <summary>
		/// 根据枚举整型值获取描述
		/// </summary>
		/// <typeparam name="TEnum">枚举</typeparam>
		/// <param name="value">枚举整型值</param>
		/// <returns></returns>
		public static string GetEnumDescription<TEnum>(byte value)
		{
			Type enumType = typeof(TEnum);
			if (!enumType.IsEnum)
			{
				throw new ArgumentException("不是枚举类型");
			}
			string enumItem = Enum.GetName(enumType, value);
			if (enumItem == null)
			{
				return string.Empty;
			}
			object[] objs = enumType.GetField(enumItem).GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (objs == null || objs.Length == 0)
			{
				return string.Empty;
			}
			else
			{
				DescriptionAttribute attr = objs[0] as DescriptionAttribute;
				return attr.Description;
			}
		}

		/// <summary>
		/// 循环出枚举的描述
		/// </summary>
		/// <typeparam name="TEnum">枚举</typeparam>
		/// <returns></returns>
		public static IDictionary<string, int> GetForEachEnumDescription<TEnum>()
		{
			IDictionary<string, int> enumDic = new Dictionary<string, int>();
			Type enumType = typeof(TEnum);
			if (!enumType.IsEnum)
			{
				throw new ArgumentException("不是枚举类型");
			}
			Array arrays = Enum.GetValues(enumType);
			for (int i = 0; i < arrays.LongLength; i++)
			{
				TEnum t = (TEnum)arrays.GetValue(i);
				FieldInfo fieldInfo = t.GetType().GetField(t.ToString());
				object[] attribArray = fieldInfo.GetCustomAttributes(false);
				DescriptionAttribute attr = attribArray[0] as DescriptionAttribute;
				enumDic.Add(attr.Description, Convert.ToInt32(t));
			}
			return enumDic;
		}

		/// <summary>
		/// 获取枚举
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text"></param>
		/// <returns></returns>
		public static T GetEnumObject<T>(string text)
		{
			return (T)Enum.Parse(typeof(T), text, true);
		}

		/// <summary>
		/// 获取枚举项
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumField"></param>
		/// <returns></returns>
		public static EnumItem GetEnumItem<T>(T enumField)
		{
			EnumItemCollection enumItems = GetEnumItems(typeof(T));
			return enumItems[enumField.ToString()];
		}

		/// <summary>
		/// 获取枚举项
		/// </summary>
		/// <param name="enumField"></param>
		/// <returns></returns>
		public static EnumItem GetEnumItem(Enum enumField)
		{
			EnumItemCollection enumItems = GetEnumItems(enumField.GetType());
			return enumItems[enumField.ToString()];
		}

		/// <summary>
		/// 获取枚举项集合
		/// </summary>
		/// <param name="enumType"></param>
		/// <returns></returns>
		public static EnumItemCollection GetEnumItems(Type enumType)
		{
			return EnumItemsCache.Get(enumType);
		}

		/// <summary>
		/// 获取枚举
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public static T GetEnumByKey<T>(string key)
		{
			return GetEnumByKey<T>(key, default(T));
		}

		/// <summary>
		/// 获取枚举
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T GetEnumByKey<T>(string key, T defaultValue)
		{
			T item = defaultValue;
			EnumItem enumItem = null;
			try
			{
				Type enumType = typeof(T);
				EnumItemCollection enumItems = EnumItemsCache.Get(enumType);
				foreach (EnumItem temp in enumItems)
				{
					if (string.Compare(key, temp.Key, true) == 0)
					{
						enumItem = temp;
						break;
					}
				}
				if (enumItem != null)
				{
					item = (T)Enum.ToObject(enumType, enumItem.Value);
				}
			}
			catch
			{
				item = defaultValue;
			}
			return item;
		}

		public static T GetEnumByValue<T>(byte value)
		{
			return GetEnumByValue< T > (value, default(T));
		}

		public static T GetEnumByValue<T>(byte value, T defaultValue)
		{
			T item = defaultValue;
			try
			{
				EnumItemCollection enumItems = GetEnumItems(typeof(T));
				foreach (EnumItem enumItem in enumItems)
				{
					if (enumItem.Value == value)
					{
						item = (T)Enum.ToObject(typeof(T), enumItem.Value);
					}
				}
			}
			catch (InvalidCastException e)
			{
				throw e;
			}
			catch (Exception e)
			{
				throw e;
			}
			return item;
		}


		/// <summary>
		/// 根据枚举值获取枚举
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">枚举值</param>
		/// <returns></returns>
		public static T GetEnumByValue<T>(string value)
		{
			return GetEnumByValue<T>(value, default(T));
		}

		/// <summary>
		/// 根据枚举字符值获取枚举
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">枚举值</param>
		/// <param name="defaultValue">默认值</param>
		/// <returns></returns>
		public static T GetEnumByValue<T>(string value, T defaultValue)
		{
			T item = defaultValue;
			try
			{
				EnumItemCollection enumItems = GetEnumItems(typeof(T));
				foreach (EnumItem enumItem in enumItems)
				{
					if (enumItem.Value.ToString() == value)
					{
						item = (T)Enum.ToObject(typeof(T), enumItem.Value);
					}
				}
			}
			catch
			{
				item = defaultValue;
			}
			return item;
		}

		/// <summary>
		/// 根据枚举描述获取枚举
		/// </summary>
		/// <typeparam name="T">枚举</typeparam>
		/// <param name="description">枚举的描述</param>
		/// <returns></returns>
		public static T GetEnumByDescription<T>(string description)
		{
			if (string.IsNullOrEmpty(description))
			{
				return default(T);
			}

			Type enumType = typeof(T);
			EnumItemCollection list = GetEnumItems(enumType);
			foreach (EnumItem item in list)
			{
				if (item.Description.ToString().ToLower() == description.Trim().ToLower())
				{
					return (T)Enum.ToObject(typeof(T), item.Value);
				}
			}
			return default(T);
		}
	}

	public class EnumItem
	{
		private string _key;
		private byte _value;
		private string _description;


		/// <summary>
		/// Enum Key
		/// </summary>
		public string Key
		{
			get { return _key; }
		}

		/// <summary>
		/// Enum Value
		/// </summary>
		public byte Value
		{
			get { return _value; }
		}


		/// <summary>
		/// Enum Description
		/// </summary>
		public string Description
		{
			get { return _description; }
		}

		/// <summary>
		/// Custructor
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public EnumItem(string key, byte value)
			: this(key, value, key)
		{
		}

		/// <summary>
		/// Custructor
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public EnumItem(string key, byte value, string description)
		{
			_key = key;
			_value = value;
			_description = description;
		}
	}

	public class EnumItemCollection : KeyedCollection<string, EnumItem>
	{
		protected override string GetKeyForItem(EnumItem item)
		{
			return item.Key;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="enumItem"></param>
		/// <returns></returns>
		public bool TryGet(string key, out EnumItem enumItem)
		{
			enumItem = null;
			if (this.Contains(key))
			{
				enumItem = this[key];
				return true;
			}
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool IsKeyExist(string key)
		{
			bool isExists = false;
			foreach (EnumItem enumItem in this)
			{
				if (key == enumItem.Key)
					isExists = true;
			}
			return isExists;
		}
	}

	internal class EnumItemsCache
	{
		private static Dictionary<Type, EnumItemCollection> _typedEnumItemsCache
			= new Dictionary<Type, EnumItemCollection>();
		private static object _syncObj = new object();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumType"></param>
		/// <returns></returns>
		public static EnumItemCollection Get(Type enumType)
		{
			EnumItemCollection enumItems = null;
			if (!_typedEnumItemsCache.TryGetValue(enumType, out enumItems))
			{
				enumItems = GetEnumItems(enumType);
				Add(enumType, enumItems);
			}

			return enumItems;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumType"></param>
		/// <param name="enumItems"></param>
		private static void Add(Type enumType, EnumItemCollection enumItems)
		{
			if (!_typedEnumItemsCache.ContainsKey(enumType))
			{
				lock (_syncObj)
				{
					if (!_typedEnumItemsCache.ContainsKey(enumType))
					{
						_typedEnumItemsCache.Add(enumType, enumItems);
					}
				}
			}
		}

		/// <summary>
		/// get the enum's all list
		/// </summary>
		/// <param name="enumType">the type of the enum</param>
		/// <param name="withAll">identicate whether the returned list should contain the all item</param>
		/// <returns></returns>
		private static EnumItemCollection GetEnumItems(Type enumType)
		{
			EnumItemCollection emumItems = new EnumItemCollection();

			if (enumType.IsEnum != true)
			{
				// just whethe the type is enum type
				throw new InvalidOperationException();
			}

			// 获得特性Description的类型信息
			Type typeDescription = typeof(DescriptionAttribute);

			// 获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
			FieldInfo[] fields = enumType.GetFields();

			// 检索所有字段
			foreach (FieldInfo field in fields)
			{
				// 过滤掉一个不是枚举值的，记录的是枚举的源类型
				if (field.FieldType.IsEnum == false)
				{
					continue;
				}

				// 通过字段的名字得到枚举的值
				byte value = (byte)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
				string description = string.Empty;

				// 获得这个字段的所有自定义特性，这里只查找Description特性
				object[] arr = field.GetCustomAttributes(typeDescription, true);
				if (arr.Length > 0)
				{
					// 因为Description自定义特性不允许重复，所以只取第一个
					DescriptionAttribute descriptionAttri = (DescriptionAttribute)arr[0];

					// 获得特性的描述值
					description = descriptionAttri.Description;
				}
				else
				{
					// 如果没有特性描述，那么就显示英文的字段名
					description = field.Name;
				}
				emumItems.Add(new EnumItem(field.Name, value, description));
			}

			return emumItems;
		}
	}
}
