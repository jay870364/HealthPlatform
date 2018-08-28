using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Bossinfo.HealthPlatform.Models.Utility;
using System.Reflection;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Bossinfo.HealthPlatform.UtilityTools
{
    public class ToolLibs
    {

        /// <summary>
        /// 此專案預設格式為 yyyyMMddhhmmssffffff
        /// </summary>
        /// <param name="defaultFormat">回傳日期的預設格式</param>
        /// <returns></returns>
        public static string GetDateTimeNowDefaultString(string defaultFormat = "yyyyMMddhhmmssffffff")
        {
            return DateTime.Now.ToString(defaultFormat);
        }


        /// <summary>   
        /// DES 加密字串   
        /// </summary>   
        /// <span  name="original" class="mceItemParam"></span>原始字串</param>   
        /// <span  name="key" class="mceItemParam"></span>Key，長度必須為 8 個 ASCII 字元</param>   
        /// <span  name="iv" class="mceItemParam"></span>IV，長度必須為 8 個 ASCII 字元</param>   
        /// <returns></returns>   
        public static string EncryptDES(string original, string key, string iv)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider
                {
                    Key = Encoding.ASCII.GetBytes(key),
                    IV = Encoding.ASCII.GetBytes(iv)
                };
                byte[] s = Encoding.ASCII.GetBytes(original);
                ICryptoTransform desencrypt = des.CreateEncryptor();
                return BitConverter.ToString(desencrypt.TransformFinalBlock(s, 0, s.Length)).Replace("-", string.Empty);
            }
            catch { return original; }
        }

        /// <summary>   
        /// DES 解密字串   
        /// </summary>   
        /// <span  name="hexString" class="mceItemParam"></span>加密後 Hex String</param>   
        /// <span  name="key" class="mceItemParam"></span>Key，長度必須為 8 個 ASCII 字元</param>   
        /// <span  name="iv" class="mceItemParam"></span>IV，長度必須為 8 個 ASCII 字元</param>   
        /// <returns></returns>   
        public static string DecryptDES(string hexString, string key, string iv)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider
                {
                    Key = Encoding.ASCII.GetBytes(key),
                    IV = Encoding.ASCII.GetBytes(iv)
                };

                byte[] s = new byte[hexString.Length / 2];
                int j = 0;
                for (int i = 0; i < hexString.Length / 2; i++)
                {
                    s[i] = Byte.Parse(hexString[j].ToString() + hexString[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                    j += 2;
                }
                ICryptoTransform desencrypt = des.CreateDecryptor();
                return Encoding.ASCII.GetString(desencrypt.TransformFinalBlock(s, 0, s.Length));
            }
            catch { return hexString; }
        }

        public static string GetResultRemarkData()
        {
            var path = $"{System.AppDomain.CurrentDomain.BaseDirectory}Data\\{Config.InitialDataFile}";

            if (File.Exists(path))
            {
                // Create a file to write to.
                return File.ReadAllText(path);
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 取得列舉的描述
        /// </summary>
        /// <param name="value">列舉值</param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            else
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// 從描述取得列舉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description">列舉的描述</param>
        /// <returns></returns>
        public static T GetEnumFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        /// <summary>
        /// 字串轉列舉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static T GetEnum<T>(string text)
        {
            return (T)Enum.Parse(typeof(T), text);

            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        /// <summary>
        /// 列舉值轉換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnum<T>(int value)
        {
            return (T)Enum.ToObject(typeof(T), value);

            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        /// <summary>
        /// JSON 序列化成字串
        /// </summary>
        /// <param name="obj">傳入的物件</param>
        /// <returns></returns>
        public static string ConvertObjToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


        public static InitialResultRemark ConvertJSONToObj(string json)
        {
            var x = Regex.Replace(json, @"\n|\r", "");
            return JsonConvert.DeserializeObject<InitialResultRemark>(x);
        }
    }
}
