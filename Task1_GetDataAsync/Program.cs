using System.Net.Http.Json;

public class Post
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }

    public override string ToString()
    {
        return $"id: {id},\nuserId: {userId},\ntitle: {title},\nbody: {body}\n";
    }
}


public class Program
{

    public async static Task<List<Post>> GetDataAsync(string uri)
    {
        var httpClient = new HttpClient(); 
        await Task.Delay(2000);
        return await httpClient.GetFromJsonAsync<List<Post>>(uri); 
    }

    public static async Task Main(string[] args)
    {
        const string uri = "https://jsonplaceholder.typicode.com/posts"; 
        var data = await GetDataAsync(uri);
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
    }
}