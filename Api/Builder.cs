using NUnit.Framework;
using RestSharp;
using System.IO;
using System.Threading.Tasks;

namespace TestProjectWithDB.Api
{
    public class Builder
    {
        public RestClient restClient;
        public RestRequest restRequest;

        public Builder(string url)
        {
            restClient = new RestClient(url);
            restRequest = new RestRequest();
        }

        public Builder AddPath(params string[] urls)
        {
            string url = string.Empty;
            foreach (var path in urls)
            {
                url = Path.Combine(url, path);
            }

            restRequest.Resource = url;

            return this;
        }

        public Builder AddMethod(Method method)
        {
            restRequest.Method = method;

            return this;
        }

        public Builder AddBody(object model)
        {
            restRequest.AddBody(model);

            return this;
        }

        public async Task<RestResponse> Execute(System.Net.HttpStatusCode statusCode)
        {
            var result = await restClient.ExecuteAsync(restRequest);
            Assert.IsTrue(result.StatusCode == statusCode, "Wrong status code");

            return result;
        }
    }
}
