using Newtonsoft.Json.Linq;

var client = new HttpClient();

string APIKeys = File.ReadAllText("appsettings.json");

string weatherAppKey = JObject.Parse(APIKeys).GetValue("WeatherAPI").ToString();


string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=11206,US&appid={weatherAppKey}";
var weatherJsonResponse = client.GetStringAsync(weatherURL).Result;



var weatherObject = JObject.Parse(weatherJsonResponse);


string description = weatherObject["weather"].First["description"].ToString();

Console.WriteLine(description);

double temp = double.Parse(weatherObject["main"]["temp"].ToString());

Console.WriteLine(temp);