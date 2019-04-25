using System.Threading.Tasks;

namespace JasonSoft.Net.JsHttpClient.Http
{
    /// <summary>
    /// JasonSoft.Net HttpClient 核心接口
    /// Add by Jason.Song（成长的小猪） on 2019/04/23
    /// </summary>
    public interface IJsHttpClient
    {
        /// <summary>
        /// 发送请求（同步）
        /// Add by Jason.Song（成长的小猪） on 2019/04/23
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JsHttpResponse Send(JsHttpRequest request);

        /// <summary>
        /// 发送请求（异步）
        /// Add by Jason.Song（成长的小猪） on 2019/04/23
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<JsHttpResponse> SendAsync(JsHttpRequest request);
    }
}