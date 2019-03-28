using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public const int ViewMax = 8;
    public int ViewCount = 0;
    public string date = "";

    public VideoPlayerManager vpManager = null;

    Slider SdAll;
    Slider[] Sd = new Slider[ViewMax];

    Text[] FName = new Text[ViewMax];

    Text DTimeAll;
    Text[] DTime = new Text[ViewMax];

    Text ETimeAll;
    Text[] ETime = new Text[ViewMax];

    public static string[] SliderString = new string[ViewMax] { "Slider_1", "Slider_2" , "Slider_3" , "Slider_4",
                                                                "Slider_5", "Slider_6" , "Slider_7" , "Slider_8" };
    public static string[] FNameString = new string[ViewMax] { "FileName_1", "FileName_2" , "FileName_3" , "FileName_4",
                                                               "FileName_5", "FileName_6" , "FileName_7" , "FileName_8" };
    public static string[] DTimeString = new string[ViewMax] { "TimesOfDay_1", "TimesOfDay_2" , "TimesOfDay_3" , "TimesOfDay_4",
                                                               "TimesOfDay_5", "TimesOfDay_6" , "TimesOfDay_7" , "TimesOfDay_8" };
    public static string[] ETimeString = new string[ViewMax] { "ElapsedTime_1", "ElapsedTime_2" , "ElapsedTime_3" , "ElapsedTime_4",
                                                               "ElapsedTime_5", "ElapsedTime_6" , "ElapsedTime_7" , "ElapsedTime_8" };

    // Use this for initialization
    void Start () {

        vpManager = GameObject.Find("VideoPlayerManager").GetComponent<VideoPlayerManager>();

        while (true)
        {
            ViewCount = vpManager.getViewCount();
            if ( ViewCount != 0)
            {
                break;
            }
        }

        date = vpManager.getMovieStartDate(0) + " ";

        SdAll = GameObject.Find("Slider").GetComponent<Slider>();

        DTimeAll = GameObject.Find("TimesOfDay").GetComponent<Text>();

        ETimeAll = GameObject.Find("ElapsedTime").GetComponent<Text>();

        for (int i = 0; i < ViewCount; i++)
        {
            Sd[i] = GameObject.Find(SliderString[i]).GetComponent<Slider>();
            FName[i] = GameObject.Find(FNameString[i]).GetComponent<Text>();
            DTime[i] = GameObject.Find(DTimeString[i]).GetComponent<Text>();
            ETime[i] = GameObject.Find(ETimeString[i]).GetComponent<Text>();
            if (vpManager.getAudioSupport(i))
            {
                FName[i].text = vpManager.getMovieName(i);
            }
            else
            {
                FName[i].text = vpManager.getMovieName(i) + " (Audio codec not supported)";
                FName[i].color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
            }
        }
    }

    // Update is called once per frame
    void Update () {

        DTimeAll.text = CalcTimeOfDay(date, SdAll.value);

        for (int i = 0; i < ViewCount; i++)
        {
            DTime[i].text = CalcTimeOfDay(date, Sd[i].value);
        }

        ETimeAll.text = CalcElapsedTime(SdAll.value, SdAll.minValue, SdAll.maxValue);

        for (int i = 0; i < ViewCount; i++)
        {
            ETime[i].text = CalcElapsedTime(Sd[i].value, Sd[i].minValue, Sd[i].maxValue);
        }
    }

    public string CalcTimeOfDay(string date, float sliderValue)
    {
        string text;

        float hour = 0;
        float minute = 0;
        float tmpMin = 0;
        float second = 0f;
        float nowTime = 0f;

        nowTime = sliderValue;

        hour = nowTime / 3600;
        tmpMin = nowTime % 3600;

        minute = tmpMin / 60;
        second = tmpMin % 60;

        text = date + hour.ToString("00") + ":" + minute.ToString("00") + ":" + (second).ToString("00.000");

        return text; 
    }

    public string CalcElapsedTime(float sliderValue, float sliderMinValue, float sliderMaxValue)
    {
        string text;
        float totalTime = 0f;
        float elapsedTime = 0f;

        totalTime = sliderMaxValue - sliderMinValue;
        elapsedTime = sliderValue - sliderMinValue;

        text = elapsedTime.ToString("0.000") + " / " + totalTime.ToString("0.000");

        return text;
    }

}
