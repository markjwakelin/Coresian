using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Coresian.Extensions
{
    public static class HttpClientExtensions
    {
        public static void UseBasicAuth(this HttpClient client, string username, string password)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

    }
}
