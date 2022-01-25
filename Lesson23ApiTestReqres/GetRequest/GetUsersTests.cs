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

    [OneTimeSetUp]
    
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
    [Test]
    public void CheckNameFromUsersTesting()
    {
        Assert.AreEqual("Eve", responseUsers.Data[3].First_name, "Поле name в ответе от api не соответствует ожидаемому");
    }
    [Test]
    public void CheckCountPerPageTesting()
    {
        Assert.AreEqual(6, responseUsers.Per_page, "Количество пользователей не совпадает");
    }
    [Test]
    public void CheckEmailNotNullTesting()
    {
        Assert.IsNotNull(responseUsers.Data[2].Email, "Электронная почта не указана");
    }
    }
    