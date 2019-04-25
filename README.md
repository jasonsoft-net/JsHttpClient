![Project Icon](https://avatars2.githubusercontent.com/u/22167571?s=40&v=4) JsHttpClient
==================================

[![NuGet](https://img.shields.io/nuget/v/JsHttpClient.svg)](https://www.nuget.org/packages/JsHttpClient/)

JsHttpClient is a simple and flexible HTML page crawling client library for .Net Core 

JsHttpClient 是一个用于在 .Net Core 上简单灵活的 HTML 页面抓取客户端库


Installation
------------

[JsHttpClient is available on NuGet](https://www.nuget.org/packages/JsHttpClient/).

Either open the package console and type:

```
PM> Install-Package JsHttpClient
```

Or right-click your project -> Manage NuGet Packages... -> Online -> search for JsHttpClient in the top right.



Quick Start
-----------

To start, Add JsHttpClient client services at ConfigureServices(IServiceCollection services) .

```csharp
public void ConfigureServices(IServiceCollection services)
{
    //Add JsHttpClient client services
    services.AddJsHttpClient();
            
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}
```

For Example
-----------

```csharp
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
```
