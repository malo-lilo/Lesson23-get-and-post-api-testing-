using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;



namespace Lesson23ApiTestReqres;

public class GetUsersTests
{
    private const string Host = "https://reqres.in/api";
    private const string Api = "/users/";
    private ResponseUsers responseUsers;

    [Test]
    
    public async Task Setup()
    {
        var baseAddress = new Uri(Host + Api);
        var client = new HttpClient() { BaseAddress = baseAddress } ;
        var response = await client.GetAsync(baseAddress, new CancellationToken());
            
        var stringResponse = await response.Content.ReadAsStringAsync();
        if (response.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"{Api} отработала некорректно, дальнейшие проверки бессмысленны!");
        }
        responseUsers = JsonConvert.DeserializeObject<ResponseUsers>(stringResponse);
        
    }
    public void CheckNameFromUsersTesting()
    {
        Assert.AreEqual("Emma", responseUsers.Data[3].First_name, "Поле name в ответе от api не соответствует ожидаемому");
    }
    }
    