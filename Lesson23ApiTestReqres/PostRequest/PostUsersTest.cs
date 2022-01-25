using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Lesson23ApiTestReqres.PostRequest;

public class PostUsersTest
{
    private const string Host = "https://reqres.in/api";
    private const string Api = "/users/";
    


    [Test]
    public async Task CheckPostUsersTesting()
    {
        var baseAddress = Host + Api;
        var client = new HttpClient();
        var strBody = "{\"name\": \"mortheus\",\"job\": \"leader\"}";
        var contentBody = new StringContent(strBody, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(baseAddress, contentBody);

        var statusCode = response.StatusCode;
        Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");
    }

    

    public async Task CheckPostUserByJsonTesting()
    {
        var baseAddress = Host + Api;
        var client = new HttpClient();
        var request = new RequestUsers()
        {
            Name = "morpheus",
            Job = "leader"
        };

        var response = await client.PostAsJsonAsync(baseAddress, request);

        var statusCode = response.StatusCode;
        Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");

    }





}