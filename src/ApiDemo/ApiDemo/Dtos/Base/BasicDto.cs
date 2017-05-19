using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDemo.Dtos.Base
{
    public class BasicDto
    {
        /// <summary>
        /// 请求对应的appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 请求的时间戳
        /// </summary>
        public long Timestamp { get; set; }
    }
}