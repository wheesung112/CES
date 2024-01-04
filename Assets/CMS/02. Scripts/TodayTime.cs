using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class OWM_Coord
{
    public float lon;
    public float lat;
}

[System.Serializable]
public class OWM_Weather
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[System.Serializable]
public class OWM_Main
{
    public int temp;
    public float feels_like;
    public int temp_min;
    public int temp_max;
    public int pressure;
    public int humidity;
}

[System.Serializable]
public class OWM_Wind
{
    public float speed;
    public int deg;
}

[System.Serializable]
public class OWM_Clouds
{
    public int all;
}

[System.Serializable]
public class OWM_Sys
{
    public int type;
    public int id;
    public string country;
    public int sunrise;
    public int sunset;
}

[System.Serializable]
public class WeatherData
{
    public OWM_Coord coord;
    public OWM_Weather[] weather;
    public string basem;
    public OWM_Main main;
    public int visibility;
    public OWM_Wind wind;
    public OWM_Clouds clouds;
    public int dt;
    public OWM_Sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;

}

public class TodayTime : MonoBehaviour
{
    public string APP_ID = "88f8043861127489ed60058666eb1853";
    public WeatherData weatherInfo;

    public TMP_Text temper;
    public TMP_Text times;

    // Start is called before the first frame update
    void Start()
    {
        CheckCityWeather("LasVegas");
    }

    public void CheckCityWeather(string city)
    {
        StartCoroutine(GetWeather(city));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetWeather(string city)
    {
        city = UnityWebRequest.EscapeURL(city);
        string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=88f8043861127489ed60058666eb1853";

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to retrieve weather data. Error: " + www.error);
            yield break;
        }

        string json = www.downloadHandler.text;
        json = json.Replace("\"base\":", "\"basem\":");
        weatherInfo = JsonUtility.FromJson<WeatherData>(json);

        if (weatherInfo.weather.Length > 0)
        {
            print(weatherInfo.weather[0].main);

            // 날씨 정보 출력
            temper.text = weatherInfo.main.temp.ToString("0.0") + "°C";


            TimeZoneInfo cityTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            //TimeZoneInfo cityTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");

            // UTC 시간을 도시의 시간대로 변환
            DateTime cityLocalTime = DateTime.UtcNow.AddSeconds(weatherInfo.timezone).Add(cityTimeZone.GetUtcOffset(DateTime.UtcNow));
            print(cityLocalTime);

            // 시간 출력
            //times.text = "Local Time: " + cityLocalTime.ToString("yyyy-MM-dd HH:mm:ss");
            times.text = cityLocalTime.ToString("hh:mm tt");
        }
    }
}
