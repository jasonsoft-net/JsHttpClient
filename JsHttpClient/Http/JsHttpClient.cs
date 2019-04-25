using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.Net.JsHttpClient.Http.Enums;

namespace JasonSoft.Net.JsHttpClient.Http
{
    /// <inheritdoc />
    /// <summary>
    /// JasonSoft.Net HttpClient 核心接口实现
    /// Add by Jason.Song（成长的小猪） on 2019/04/23
    /// </summary>
    public class JsHttpClient : IJsHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 实例化 HttpClient 抽象工厂
        /// Add by Jason.Song（成长的小猪） on 2019/04/23
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public JsHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <inheritdoc />
        /// <summary>
        /// 发送请求（同步）
        /// Add by Jason.Song（成长的小猪） on 2019/04/23
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsHttpResponse Send(JsHttpRequest request)
        {
            return SendAsync(request).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        /// <summary>
        /// 发送请求（异步）
        /// Add by Jason.Song（成长的小猪） on 2019/04/23
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JsHttpResponse> SendAsync(JsHttpRequest request)
        {
            var result = new JsHttpResponse();
            var message = new HttpRequestMessage()
            {
                Method = request.Method,
                RequestUri = new Uri(request.Uri)
            };

            message.Headers.UserAgent.TryParseAdd(request.UserAgent);
            message.Headers.Accept.TryParseAdd(request.Accept);

            if (!string.IsNullOrWhiteSpace(request.Host))
                message.Headers.Host = request.Host;

            if (!string.IsNullOrWhiteSpace(request.Referer))
                message.Headers.Referrer = new Uri(request.Referer);

            if (!string.IsNullOrWhiteSpace(request.Cookie))
                message.Headers.Add("Cookie", request.Cookie);

            foreach (var header in request.Headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }

            switch (request.PostDataType)
            {
                case PostDataType.String:
                    if (!string.IsNullOrWhiteSpace(request.PostString))
                        message.Content = new StringContent(request.PostString);
                    break;
                case PostDataType.Byte:
                    if (request.PostByte != null && request.PostByte.Length > 0)
                        message.Content = new ByteArrayContent(request.PostByte);
                    break;
            }

            try
            {
                var client = _httpClientFactory.CreateClient("JasonSoft");
                client.Timeout = TimeSpan.FromSeconds(request.Timeout);
                var response = await client.SendAsync(message).ConfigureAwait(false);
                result.StatusCode = response.StatusCode;
                result.IsSuccess = response.IsSuccessStatusCode;
                if (response.IsSuccessStatusCode)
                {
                    //获取Cookie
                    if (response.Headers.TryGetValues("Set-Cookie", out var cookieValues))
                    {
                        var cookiesBuilder = new StringBuilder();
                        const string separator = "; ";
                        foreach (var cookieValue in cookieValues)
                        {
                            var c = cookieValue.Split(new[] {separator}, StringSplitOptions.None).First();
                            cookiesBuilder.Append($"{c}; ");

                            //foreach (var c in cookieValue.Split(new[] {separator}, StringSplitOptions.None))
                            //{
                            //    if (!c.Contains("="))
                            //        continue;

                            //    var key = c.Split('=')[0];
                            //    if (key.EndsWith("domain", StringComparison.OrdinalIgnoreCase) ||
                            //        key.EndsWith("path", StringComparison.OrdinalIgnoreCase) ||
                            //        key.EndsWith("expires", StringComparison.OrdinalIgnoreCase) ||
                            //        key.EndsWith("secure", StringComparison.OrdinalIgnoreCase) ||
                            //        key.EndsWith("max-age", StringComparison.OrdinalIgnoreCase))
                            //        continue;

                            //    cookiesBuilder.Append($"{c}; ");
                            //}
                        }

                        result.Cookie = cookiesBuilder.ToString().TrimEnd(separator.ToCharArray());
                    }

                    switch (request.ResultType)
                    {
                        case ResultType.String:
                            result.Html = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            break;
                        case ResultType.Byte:
                            result.ResultByte = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Html = e.Message;
                throw;
            }


            return result;
        }
    }
}