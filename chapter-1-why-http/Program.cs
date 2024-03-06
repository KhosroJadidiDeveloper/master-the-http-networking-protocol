using System.Text.Json;
// ReSharper disable UnusedAutoPropertyAccessor.Global

var client = new HttpClient
{
    BaseAddress = new("https://api.boot.dev/v1/courses_rest_api/learn-http/items")
};

var message = new HttpRequestMessage(HttpMethod.Get, string.Empty);
message.Headers.Add("X-API-Key", "1k4h8s6l5h3nd01l");
// message.Headers.Add("Content-Type","application/json");

var result = await client.SendAsync(message, new());
var resultString = await result.Content.ReadAsStringAsync();

var serializerOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = false,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
var items = JsonSerializer.Deserialize<IEnumerable<Item>>(resultString, serializerOptions)
    ?.ToList();

ArgumentNullException.ThrowIfNull(items);

foreach (var item in items)
    Console.WriteLine(item.ToString());

internal struct Item
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Quality { get; set; }

    public override string ToString()
    {
        return $$"""
                 id : {{Id}},
                 name:{{Name}},
                 quality:{{Quality}}
                 """;
    }
}