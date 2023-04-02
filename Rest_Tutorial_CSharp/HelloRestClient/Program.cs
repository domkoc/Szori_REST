var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5213/api/hello/");
var result = await client.GetAsync("sayHello?name=me");
var content = await result.Content.ReadAsStringAsync();
Console.WriteLine(content);
Console.ReadKey();
