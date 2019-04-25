using System.Net;

namespace JasonSoft.Net.JsHttpClient.Http
{
    /// <summary>  
    /// JasonSoft.Net HttpClient 返回结果类
    /// Add by Jason.Song（成长的小猪） on 2019/04/23
    /// </summary>
    public class JsHttpResponse
    {
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>  
        /// Http请求返回的Cookie  
        /// </summary>  
        public string Cookie { get; set; }

        /// <summary>
        /// 返回的String类型数据
        /// </summary>
        public string Html { get; set; }

        /// <summary>  
        /// 返回的Byte数组
        /// </summary>  
        public byte[] ResultByte { get; set; }
    }
}