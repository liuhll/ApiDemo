using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using ApiDemo.Core.AppService;
using ApiDemo.Core.Common.Tools;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace ApiDemo.ApiAuthorization
{
    public class ApiAuthorizePolicy : IApiAuthorizePolicy
    {
        private IDictionary<string, string> _paramList;
        private string _sign;
        private long _timestamp;

        public ApiAuthorizePolicy(IDictionary<string, string> paramList, long timestamp, string sign)
        {
            _paramList = paramList;
            _timestamp = timestamp;
            _sign = sign;
        }

        public bool IsValidTime()
        {
            var now = DateTime.Now;
            var expirationDuration = ConfigHelper.GetIntValues("ExpirationDuration");
            var requestTime = DateTimeHelper.UnixTimestampToDateTime(_timestamp);
            if (requestTime.AddMinutes(expirationDuration) < now
                || requestTime.AddMinutes(-expirationDuration) > now)
            {
                // :todo 日志： "该请求不在有效的时间内";
                return false;
            }
            return true;
        }

        public bool IsLegalSign()
        {
            var appid = _paramList["appid"];
            var appCodeAppService = new AppCodeAppService();
            var appKey = appCodeAppService.GetAppCode(appid);

            if (appKey == null)
            {
                throw new Exception("不存在的appid");
            }
            _paramList.Add("appkey", Regex.Replace(appKey.AppKey, @"\s", ""));
            var encryptedStr = GetSignContent(_paramList);
            var isLegalSign = EncryptionHelper.EncryptSHA256(encryptedStr).Equals(_sign);
            if (!isLegalSign)
            {
                // :todo 日志： "验证签名失败，非法签名"
            }        
            return isLegalSign;
        }


        private string GetSignContent(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            // sign 不参与签名
            parameters.Remove("sign");
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key.ToLower();
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(value).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }
    }
}