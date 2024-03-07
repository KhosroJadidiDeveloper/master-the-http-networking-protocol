var uri = new Uri("http://dragonslayer:pwn3d@fantasyquest.com:8080/maps?sort=rank#id");

Console.WriteLine(uri.Scheme);
Console.WriteLine(uri.UserInfo.Split(":")[0]);
Console.WriteLine(uri.UserInfo.Split(":")[1]);
Console.WriteLine(uri.Host);
Console.WriteLine(uri.Port);
Console.WriteLine(uri.AbsolutePath);
Console.WriteLine(uri.Query);
Console.WriteLine(uri.Fragment);
