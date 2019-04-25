using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JasonSoft.Net.JsHttpClient.Http;

namespace JsHttpClient.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IJsHttpClient _client;

        /// <summary>
        /// 实例化
        /// Add by Jason.Song（成长的小猪） on 2019/04/24
        /// </summary>
        /// <param name="client"></param>
        public TestController(IJsHttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Asynchronous request test
        /// 异步请求测试
        /// Add by Jason.Song（成长的小猪） on 2019/04/24
        /// </summary>
        /// <returns></returns>
        [HttpGet("HttpAsync")]
        public async Task<IActionResult> HttpAsync()
        {
            const string urlString = "https://blog.csdn.net/jasonsong2008";
            var request = new JsHttpRequest {Uri = urlString};
            //request.Method = HttpMethod.Get;
            //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";
            //request.Referer = "https://blog.csdn.net/";
            //request.Host = "blog.csdn.net";
            //request.Cookie = "";
            //request.Timeout = 30;
            //request.Add("Upgrade-Insecure-Requests", "1");

            var result = await _client.SendAsync(request);
            return Content(result.Html, "text/html; charset=utf-8");
        }

        /// <summary>
        /// Synchronous request test
        /// 同步请求测试
        /// Add by Jason.Song（成长的小猪） on 2019/04/24
        /// </summary>
        /// <returns></returns>
        [HttpGet("HttpSync")]
        public IActionResult HttpSync()
        {
            const string urlString = "https://blog.csdn.net/jasonsong2008";
            var request = new JsHttpRequest {Uri = urlString};
            //request.Method = HttpMethod.Get;
            //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";
            //request.Referer = "https://blog.csdn.net/";
            //request.Host = "blog.csdn.net";
            //request.Cookie = "";
            //request.Timeout = 30;
            //request.Add("Upgrade-Insecure-Requests", "1");

            var result = _client.Send(request);
            return Content(result.Html, "text/html; charset=utf-8");
        }
    }
}