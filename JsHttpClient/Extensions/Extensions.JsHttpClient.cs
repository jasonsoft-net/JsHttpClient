using System.Net;
using System.Net.Http;
using JasonSoft.Net.JsHttpClient.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JasonSoft.Net.JsHttpClient.Extensions
{
    /// <summary>
    /// JasonSoft.Net HttpClient 扩展服务
    /// Add by Jason.Song on 2019/04/23
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 要配置的 HttpClient 的逻辑名称。
        /// Add by Jason.Song on 2019/04/23
        /// </summary>
        private const string Name = "JasonSoft";


        /// <summary>
        /// 添加 JasonSoft.Net HttpClient 至DI容器
        /// Add by Jason.Song on 2019/04/23
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddJsHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient(Name).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });
            services.AddTransient<IJsHttpClient, Http.JsHttpClient>();
            return services;
        }
    }
}