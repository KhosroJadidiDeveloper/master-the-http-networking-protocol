using System.Text.Json;

var domain = "api.boot.dev";
var uri = new Uri($"https://cloudflare-dns.com/dns-query?name={domain}&type=A");
var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
requestMessage.Headers.Add("Accept", "application/dns-json");

var client = new HttpClient();
var response = await client.SendAsync(requestMessage);
var responseString = await response.Content.ReadAsStringAsync();

var ip = JsonDocument.Parse(responseString)
    .RootElement
    .GetProperty("Answer")[0]
    .GetProperty("data")
    .GetString();

Console.WriteLine(responseString);
Console.WriteLine(ip);
