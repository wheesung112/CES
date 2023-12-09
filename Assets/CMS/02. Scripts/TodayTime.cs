using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
        string url = "https://api.openweathermap.org/data/2.5/weather?q="+city+ "&units=metric&appid=88f8043861127489ed60058666eb1853";

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string json = www.downloadHandler.text;
        json = json.Replace("\"base\":", "\"basem\":");
        weatherInfo = JsonUtility.FromJson<WeatherData>(json);

        if (weatherInfo.weather.Length > 0)
        {
            print(weatherInfo.weather[0].main);

            // 원하는 지역의 시간대 정보 가져오기 (Las Vegas는 Pacific 시간대 사용)
            TimeZoneInfo lasVegasTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            //TimeZoneInfo lasVegasTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");

            // 현재 UTC 시간을 가져오기
            DateTime utcNow = DateTime.UtcNow;

            // UTC 시간을 지역 시간대로 변환
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, lasVegasTimeZone);
            print(localTime);
            
        }

    }
}



