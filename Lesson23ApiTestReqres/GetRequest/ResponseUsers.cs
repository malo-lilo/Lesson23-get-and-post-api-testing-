using Newtonsoft.Json;

namespace Lesson23ApiTestReqres;

public class ResponseUsers
{
    [JsonProperty("page")]
    public int Page { get; set; }
    
    [JsonProperty("per_page")]
    public int Per_page { get; set; }
    
    [JsonProperty("total")]
    public int Total { get; set; }
    
    [JsonProperty("total_pages")]
    public int Total_pages { get; set; }
    
    [JsonProperty("data")]
    public User[] Data { get; set; }

    [JsonProperty("support")]
    public Support Support { get; set; }
    
}

public class User
{
    [JsonProperty("id")]
    public int Id { get; set; }
        
    [JsonProperty("email")]
    public string Email { get; set; }
        
    [JsonProperty("first_name")]
    public string First_name { get; set; }
        
    [JsonProperty("last_name")]
    public string Last_name { get; set; }
        
    [JsonProperty("avatar")]
    public string Avatar { get; set; }
}

public class Support
{
    [JsonProperty("url")]
    public string Url { get; set; }
    
    [JsonProperty("text")]
    public string Text { get; set; }
}
