using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class VideoPlayerManager : MonoBehaviour {
    public const int ViewMax = 8;
    public static int ViewCount = 0;
    public static int ViewLayout = 0;
    public static string[] movieUrls = new string[ViewMax];
    public static string[] movieNames = new string[ViewMax];
    public static bool[] isAudioSupport = new bool[ViewMax] { true, true, true, true, true, true, true, true };

    public static string[] vpStrShootStartDate = new string[ViewMax];
    public static string[] vpStrShootStartTimes = new string[ViewMax];

    VideoPlayer[] Vp = new VideoPlayer[ViewMax];

    Slider SdAll;
    Slider[] Sd = new Slider[ViewMax];

    //例(エンコード日を取得したと考え)
    //string[] vpStrShootStartTimes = new string[ViewCount] { "01:00:00.500", "01:00:05.500", "01:00:10.500", "01:00:15.500" };
    //string[] vpStrShootStartTimes = new string[4] { "00:00:10.00", "00:00:05.34", "00:00:10.23", "00:00:50.20" };
    //string vp_2_shootStartTime = "13:00:10";
    //string vp_3_shootStartTime = "13:00:15";
    //string vp_4_shootStartTime = "13:00:25";

    static float[] vpMediaTimes = new float[ViewMax] { 0, 0, 0, 0, 0, 0, 0, 0 };
    static float[] vpShootStartTimes = new float[ViewMax] { 0, 0, 0, 0, 0, 0, 0, 0 };
    static float[] vpShootEndTimes = new float[ViewMax] { 0, 0, 0, 0, 0, 0, 0, 0 };
    static float vpShootStartTimeMin = 0;
    static float vpShootEndTimeMax = 0;

    static bool isPrepared = false;
    public static string[] MoviePanelString = new string[ViewMax] { "MoviePanel_1", "MoviePanel_2", "MoviePanel_3", "MoviePanel_4",
                                                                      "MoviePanel_5", "MoviePanel_6", "MoviePanel_7", "MoviePanel_8" };
    public static string[] SliderString = new string[ViewMax] { "Slider_1", "Slider_2" , "Slider_3" , "Slider_4",
                                                                "Slider_5", "Slider_6" , "Slider_7" , "Slider_8" };

    public bool isStop = false;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == ViewLayout.ToString() )
        {
            for (int i = 0; i < ViewCount; i++)
            {
                Vp[i] = GameObject.Find(MoviePanelString[i]).GetComponent<VideoPlayer>();
                Sd[i] = GameObject.Find(SliderString[i]).GetComponent<Slider>();

                Vp[i].url = movieUrls[i];
                Debug.Log(Vp[i].url);
            }

            SdAll = GameObject.Find("Slider").GetComponent<Slider>();

            for (int i = 0; i < ViewCount; i++)
            {
                Sd[i].interactable = !Sd[i].interactable;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == ViewLayout.ToString() )
        {
            isPrepared = true;

            for (int i = 0; i < ViewCount; i++)
            {
                if (!Vp[i].isPrepared)
                {
                    isPrepared = false;
                    break;
                }
            }

            if (isPrepared)
            {
                allMovieViewTime();
            
                if (SdAll && !isStop && !Input.GetMouseButton(0))
                {
                    SdAll.value += Time.deltaTime;
                }

                for (int i = 0; i < ViewCount; i++)
                {
                    if (Sd[i] && !isStop && !Input.GetMouseButton(0))
                    {
                        Sd[i].value += Time.deltaTime;
                    }
                }

                movieStartTime();

                if (!SdAll.interactable)
                {
                    moveMovie();
                }
                else
                {
                    moveAllMovie();
                }
            }
        }
    }

    // 全ての動画の時間を算出
    void allMovieViewTime()
    {
        stringToFloat();

        for (int i = 0; i < ViewCount; i++)
        {
            // VpがPrepare状態のときじゃないと正しいframeCountとframeRateが取れない。
            vpMediaTimes[i] = Vp[i].frameCount / Vp[i].frameRate;
            vpShootEndTimes[i] = vpShootStartTimes[i] + vpMediaTimes[i];
            Sd[i].maxValue = vpShootEndTimes[i];
        }

        // vpShootEndTimeMax = Mathf.Max(vpShootEndTimes[0], vpShootEndTimes[1], vpShootEndTimes[2], vpShootEndTimes[3]);
        vpShootEndTimeMax = vpShootEndTimes[0];
        for (int i = 0; i < ViewCount; i++)
        {
            if (vpShootEndTimeMax < vpShootEndTimes[i])
            {
                vpShootEndTimeMax = vpShootEndTimes[i];
            }
        }

        SdAll.maxValue = vpShootEndTimeMax;

    }
    // 文字列の操作と再生開始位置の設定
    void stringToFloat()
    {
        float minute = 60.0f;
        float hour = minute * minute;

        for (int i = 0; i < ViewCount; i++)
        {
            vpShootStartTimes[i] =
                hour * float.Parse(vpStrShootStartTimes[i].Substring(0, 2)) +
                minute * float.Parse(vpStrShootStartTimes[i].Substring(3, 2)) +
                float.Parse(vpStrShootStartTimes[i].Substring(6, 2)) +
                float.Parse(vpStrShootStartTimes[i].Substring(9, 2))/100;

            //デバッグ
 //           Debug.Log((i + 1) + "番目(Start)　" + vpShootStartTimes[i]);
        }

        vpShootStartTimeMin = vpShootStartTimes[0];
        for (int i = 0; i < ViewCount; i++)
        {
            if (vpShootStartTimeMin > vpShootStartTimes[i])
            {
                vpShootStartTimeMin = vpShootStartTimes[i];
            }
        }

        SdAll.minValue = vpShootStartTimeMin;

        for (int i = 0; i < ViewCount; i++)
        {
            Sd[i].minValue = vpShootStartTimes[i];
        }
    }
    // 各動画の再生開始
    void movieStartTime()
    {
        float nowTime = SdAll.value;

        for (int i = 0; i < ViewCount; i++)
        {
            if ((nowTime >= vpShootStartTimes[i]) && (nowTime < vpShootEndTimes[i]) && !isStop)
            {
                if (!Vp[i].isPlaying)
                {
                    Vp[i].Play();
                    Sd[i].value = nowTime;
                }
            }
            else if ((nowTime >= vpShootStartTimes[i]) && (nowTime < vpShootEndTimes[i]) && isStop)
            {
                Vp[i].Pause();
            }
            else
            {
                Vp[i].frame = 1;
                Vp[i].Pause();
                Sd[i].value = vpShootStartTimes[i];
            }
        }
    }

    void moveAllMovie()
    {
        float nowTime = SdAll.value;
        float[] nowVpSeekTime = new float[ViewCount];

        for (int i = 0; i < ViewCount; i++)
        {
            nowVpSeekTime[i] = Mathf.Abs((vpShootStartTimeMin - vpShootStartTimes[i]) - (vpShootStartTimeMin - nowTime));
        }

        if (Input.GetMouseButton(0))
        {

            for (int i = 0; i < ViewCount; i++)
            {
                if (nowVpSeekTime[i] > 0 && Vp[i].isPlaying)
                {
                    Vp[i].time = nowVpSeekTime[i];
                    Sd[i].value = vpShootStartTimes[i] + nowVpSeekTime[i];
                }
            }
        }
    }

    void moveMovie()
    {
        float[] nowTime = new float[ViewCount];
        float[] nowVpSeekTime = new float[ViewCount];

        for (int i = 0; i < ViewCount; i++)
        {
            nowTime[i] = Sd[i].value;
            nowVpSeekTime[i] = Mathf.Abs((vpShootStartTimeMin - vpShootStartTimes[i]) - (vpShootStartTimeMin - nowTime[i]));
        }

        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < ViewCount; i++)
            {

                if (nowVpSeekTime[i] > 0 && Vp[i].isPlaying)
                {
                    Vp[i].time = nowVpSeekTime[i];
                    Sd[i].value = vpShootStartTimes[i] + nowVpSeekTime[i];
                }
            }
        }
    }


    // 読み込むファイルのURLのアクセサ
    public string getMovieUrl(int num)
    {
        return movieUrls[num];
    }

    public void setMovieUrl(int num, string url)
    {
        movieUrls[num] = url;
    }

    // 読み込むファイルのURLのアクセサ
    public string getMovieName(int num)
    {
        return movieNames[num];
    }

    public void setMovieName(int num, string name)
    {
        movieNames[num] = name;
    }

    // 再生状態のアクセサ
    public bool getStatus()
    {
        return isStop;
    }

    public void setStatus(bool status)
    {
        isStop = status;
    }

    // 読み込むファイルの日付情報のアクセサ
    public string getMovieStartDate(int num)
    {
        return vpStrShootStartDate[num];
    }

    public void setMovieStartDate(int num, string date)
    {
        vpStrShootStartDate[num] = date;
    }

    // 読み込むファイルの時刻情報のアクセサ
    public string getMovieStartTimes(int num)
    {
        return vpStrShootStartTimes[num];
    }

    public void setMovieStartTimes(int num, string time)
    {
        vpStrShootStartTimes[num] = time;
    }

    // 再生する動画数のアクセサ
    public int getViewCount()
    {
        return ViewCount;
    }

    public void setViewCount(int count)
    {
        ViewCount = count;
    }

    // レイアウト番号のアクセサ
    public int getViewLayout()
    {
        return ViewLayout;
    }

    public void setViewLayout(int num)
    {
        ViewLayout = num;
    }

    // Audio再生有無のアクセサ
    public bool getAudioSupport(int num)
    {
        return isAudioSupport[num];
    }

    public void setAudioSupport(int num, bool isAudio)
    {
        isAudioSupport[num] = isAudio;
    }

}
