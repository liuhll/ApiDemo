using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using Request.Lib.Common.Tools;

namespace Request.Lib.Data
{
    public class RequestParams
    {
        private IDictionary<string, object> m_values;
        private bool _isSign = false;

        public RequestParams()
        {
            m_values = new SortedDictionary<string, object>();
        }

        public IDictionary<string, object> GetValues()
        {
            return m_values;
        }


        /// <summary>
        /// 设置某个字段的值
        /// </summary>
        /// <param name="key">字段名称</param>
        /// <param name="value">字段值</param>
        public void SetValue(string key, object value)
        {
            m_values[key] = value;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }

        public void RemoveValue(string key)
        {
            if (IsSet(key))
            {
                m_values.Remove(key);
            }
        }

        /// <summary>
        /// 判断是否设置了某个字段
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            if (null != o)
                return true;
            else
                return false;
        }

        public string ToJson()
        {
            string jsonStr = JsonMapper.ToJson(m_values);
            return jsonStr;
        }

        public void MakeSign()
        {
            // 1. 设置应用的AppId
            if (!IsSet("appid"))
            {
               SetValue("appid",ConfigHelper.GetValuesByKey("appid"));
            }

            // 2. 获取应用的 AppKey 
            if (!IsSet("appkey"))
            {
                var appkey = ConfigHelper.GetValuesByKey("appkey");
                m_values.Add("appkey", Regex.Replace(appkey, @"\s", ""));
            }

            // 3. 时间戳
            if (!IsSet("timestamp"))
            {
                var timestamp = DateTimeHelper.DateTimeToUnixTimestamp(DateTime.Now);
                m_values.Add("timestamp", timestamp.ToString());
            }

            //4. 获取加密的encryptedStr
            var encryptedStr = GetSignContent(m_values);
            
            //5. 得到签名，并设置签名参数
            SetValue("sign", EncryptionHelper.EncryptSHA256(encryptedStr));

            RemoveValue("appkey");

            _isSign = true;
        }

        private string GetSignContent(IDictionary<string, object> parameters)
        {
            IEnumerator<KeyValuePair<string, object>> dem = m_values.GetEnumerator();
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key.ToLower();
                string value = dem.Current.Value.ToString();
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(value).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);
            return content;
        }

        public bool IsSign()
        {
            return _isSign;
        }

    }
}
