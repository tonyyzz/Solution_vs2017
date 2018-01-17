/*********************************************************
** File Name:	XmlUtils.cs
** Copyright (C) 2016 TopWork. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description: XML帮助类
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Auction.Utility.Utils
{
    public static class XmlUtils
    {
        /// <summary>  
        /// 反序列化  
        /// </summary>
        public static T Deserialize<T>(string xml) where T : class
        {
            using (var reader = new StringReader(xml))
            {
                var temp = XmlReader.Create(reader);
                return new XmlSerializer(typeof(T)).Deserialize(temp) as T;
            }
        }

        /// <summary>  
        /// 反序列化  
        /// </summary>
        public static T Deserialize<T>(Stream stream) where T : class
        {
            return new XmlSerializer(typeof(T)).Deserialize(stream) as T;
        }

        /// <summary>  
        /// 序列化XML文件  
        /// </summary>
        public static string Serializer(object obj)
        {
            using (var memory = new MemoryStream())
            {
                var serial = new XmlSerializer(obj.GetType());
                var setting = new XmlWriterSettings()
                {
                    Indent = false,
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.UTF8
                };
                var writer = XmlWriter.Create(memory, setting);
                var space = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) });
                serial.Serialize(writer, obj, space);
                memory.Position = 0;
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}
