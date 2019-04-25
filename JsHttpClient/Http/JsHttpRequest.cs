using System.Collections.Generic;
using System.Net.Http;
using JasonSoft.Net.JsHttpClient.Http.Enums;

namespace JasonSoft.Net.JsHttpClient.Http
{
    /// <summary>  
    /// JasonSoft.Net HttpClient 请求参数类
    /// Add by Jason.Song（成长的小猪） on 2019/04/23
    /// </summary> 
    public class JsHttpRequest
    {
        /// <summary>
        /// 实例化JsHttpRequest
        /// </summary>
        public JsHttpRequest()
        {
            Headers = new Dictionary<string, string>
            {
                {"Accept-Encoding", "gzip, deflate, br"}, {"Accept-Language", "zh-CN,zh;q=0.9"}
            };
        }

        /// <summary>
        /// Request Headers
        /// </summary>
        public Dictionary<string, string> Headers { get; }

        /// <summary>
        /// 添加数据包头部参数
        /// 例如：
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, string value)
        {
            if (Headers.ContainsKey(name))
            {
                Headers.Remove(name);
            }

            Headers.Add(name, value);
        }

        /// <summary>
        /// 请求URL必须填写
        /// </summary>
        public string Uri { get; set; }

        /// <summary>  
        /// 请求方式
        /// 默认 GET  
        /// </summary>
        public HttpMethod Method { get; set; } = HttpMethod.Get;

        /// <summary>  
        /// 请求超时时间 单位：秒
        /// 默认 100 秒
        /// </summary>  
        public int Timeout { get; set; } = 100;

        /// <summary>  
        /// 设置Host的标头信息  
        /// </summary>  
        public string Host { get; set; }

        /// <summary>  
        /// 请求标头值
        /// 默认为 text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/* 
        /// </summary>  
        public string Accept { get; set; } =
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";

        ///// <summary>  
        ///// 请求返回类型
        ///// 默认 text/html; charset=utf-8
        ///// </summary>  
        //public string ContentType { get; set; } = "text/html; charset=utf-8";

        /// <summary>  
        /// 客户端访问信息
        /// 默认 Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36
        /// </summary>  
        public string UserAgent { get; set; } =
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";

        /// <summary>  
        /// 请求时的Cookie  
        /// </summary>  
        public string Cookie { get; set; }

        /// <summary>  
        /// 来源地址，上次访问地址  
        /// </summary>  
        public string Referer { get; set; }

        /// <summary>  
        /// POST 数据类型
        /// 默认 String
        /// </summary>  
        public PostDataType PostDataType { get; set; } = PostDataType.String;

        /// <summary>  
        /// POST 请求时要发送的String类型数据  
        /// </summary>  
        public string PostString { get; set; }

        /// <summary>  
        /// POST 请求时要发送的Byte类型数据
        /// </summary>  
        public byte[] PostByte { get; set; }

        /// <summary>  
        /// 设置返回类型String和Byte
        /// 默认返回字符串
        /// </summary>  
        public ResultType ResultType { get; set; } = ResultType.String;
    }
}