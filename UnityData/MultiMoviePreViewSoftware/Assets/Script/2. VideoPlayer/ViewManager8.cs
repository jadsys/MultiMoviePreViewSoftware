using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewManager8 : MonoBehaviour {

    public const int ViewMax = 8;
    public int ViewLayout = 0;

    public VideoPlayerManager vpManager = null;

    Camera[] Cam = new Camera[ViewMax];

    Slider[] Sd = new Slider[ViewMax];

    Text[] FName = new Text[ViewMax];

    Text[] DTime = new Text[ViewMax];

    Text[] ETime = new Text[ViewMax];

    VideoPlayer[] Vp = new VideoPlayer[ViewMax];

    bool[] isZoom = new bool[ViewMax] { false, false, false, false, false, false, false, false };

    public static string[] CameraString = new string[ViewMax] { "Camera_1", "Camera_2" , "Camera_3" , "Camera_4",
                                                                "Camera_5", "Camera_6" , "Camera_7" , "Camera_8" };
    public static string[] SliderString = new string[ViewMax] { "Slider_1", "Slider_2" , "Slider_3" , "Slider_4",
                                                                "Slider_5", "Slider_6" , "Slider_7" , "Slider_8" };
    public static string[] FNameString = new string[ViewMax] { "FileName_1", "FileName_2" , "FileName_3" , "FileName_4",
                                                               "FileName_5", "FileName_6" , "FileName_7" , "FileName_8" };
    public static string[] DTimeString = new string[ViewMax] { "TimesOfDay_1", "TimesOfDay_2" , "TimesOfDay_3" , "TimesOfDay_4",
                                                               "TimesOfDay_5", "TimesOfDay_6" , "TimesOfDay_7" , "TimesOfDay_8" };
    public static string[] ETimeString = new string[ViewMax] { "ElapsedTime_1", "ElapsedTime_2" , "ElapsedTime_3" , "ElapsedTime_4",
                                                               "ElapsedTime_5", "ElapsedTime_6" , "ElapsedTime_7" , "ElapsedTime_8" };
    public static string[] MoviePanelString = new string[ViewMax] { "MoviePanel_1", "MoviePanel_2", "MoviePanel_3", "MoviePanel_4",
                                                                    "MoviePanel_5", "MoviePanel_6", "MoviePanel_7", "MoviePanel_8" };
    // Use this for initialization
    void Start () {

        vpManager = GameObject.Find("VideoPlayerManager").GetComponent<VideoPlayerManager>();

        while (true)
        {
            ViewLayout = vpManager.getViewLayout();
            if (ViewLayout != 0)
            {
                break;
            }
        }

        for (int i = 0; i < ViewLayout; i++)
        {
            Cam[i] = GameObject.Find(CameraString[i]).GetComponent<Camera>();
            Sd[i] = GameObject.Find(SliderString[i]).GetComponent<Slider>();
            FName[i] = GameObject.Find(FNameString[i]).GetComponent<Text>();
            DTime[i] = GameObject.Find(DTimeString[i]).GetComponent<Text>();
            ETime[i] = GameObject.Find(ETimeString[i]).GetComponent<Text>();
            Vp[i] = GameObject.Find(MoviePanelString[i]).GetComponent<VideoPlayer>();
        }

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (!isZoom[0]) {
                // ViewPointの設定のみ、固有処理
                Cam[0].rect = new Rect(0.0f, 0.1f,  0.9f,  0.9f);
                Cam[1].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.9f, 0.1f,  0.1f, 0.13f);

                changeWatchLayout(0);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (!isZoom[1])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.0f, 0.1f,  0.9f, 0.9f);
                Cam[2].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.9f, 0.1f,  0.1f, 0.13f);

                changeWatchLayout(1);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (!isZoom[2])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.0f, 0.1f, 0.9f, 0.9f);
                Cam[3].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.9f, 0.1f, 0.1f, 0.13f);

                changeWatchLayout(2);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (!isZoom[3])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.0f, 0.1f, 0.9f, 0.9f);
                Cam[4].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.9f, 0.1f, 0.1f, 0.13f);

                changeWatchLayout(3);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            if (!isZoom[4])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.0f, 0.1f, 0.9f, 0.9f);
                Cam[5].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.9f, 0.1f, 0.1f, 0.13f);

                changeWatchLayout(4);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            if (!isZoom[5])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.0f, 0.1f, 0.9f, 0.9f);
                Cam[6].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.9f, 0.1f, 0.1f, 0.13f);

                changeWatchLayout(5);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            if (!isZoom[6])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.0f, 0.1f, 0.9f, 0.9f);
                Cam[7].rect = new Rect(0.9f, 0.1f, 0.1f, 0.13f);

                changeWatchLayout(6);
            }
            else
            {
                changeNormalLayout();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            if (!isZoom[7])
            {
                Cam[0].rect = new Rect(0.9f, 0.88f, 0.1f, 0.13f);
                Cam[1].rect = new Rect(0.9f, 0.75f, 0.1f, 0.13f);
                Cam[2].rect = new Rect(0.9f, 0.62f, 0.1f, 0.13f);
                Cam[3].rect = new Rect(0.9f, 0.49f, 0.1f, 0.13f);
                Cam[4].rect = new Rect(0.9f, 0.36f, 0.1f, 0.13f);
                Cam[5].rect = new Rect(0.9f, 0.23f, 0.1f, 0.13f);
                Cam[6].rect = new Rect(0.9f, 0.1f, 0.1f, 0.13f);
                Cam[7].rect = new Rect(0.0f, 0.1f, 0.9f, 0.9f);

                changeWatchLayout(7);
            }
            else
            {
                changeNormalLayout();
            }
        }
    }

    void changeWatchLayout(int num)
    {
        for (int i = 0; i < ViewLayout; i++)
        {
            if (i == num)
            {
                Cam[i].depth = 10f;
                isZoom[i] = true;
                if (vpManager.getAudioSupport(i))
                {
                    Vp[i].SetDirectAudioMute(0, false);
                }
                Sd[i].transform.localPosition = new Vector3(-100.0f, -210.0f, 0.0f);
                FName[i].transform.localPosition = new Vector3(-550.0f, 260.0f, 0.0f);
                DTime[i].transform.localPosition = new Vector3(-50.0f, -256.0f, 0.0f);
                ETime[i].transform.localPosition = new Vector3(-720.0f, -256.0f, 0.0f);

                Sd[i].gameObject.SetActive(true);
                FName[i].gameObject.SetActive(true);
                DTime[i].gameObject.SetActive(true);
                ETime[i].gameObject.SetActive(true);
            }
            else
            {
                Cam[i].depth = -1f;
                isZoom[i] = false;
                Vp[i].SetDirectAudioMute(0, true);
                Sd[i].gameObject.SetActive(false);
                FName[i].gameObject.SetActive(false);
                DTime[i].gameObject.SetActive(false);
                ETime[i].gameObject.SetActive(false);
            }
        }

    }

    void changeNormalLayout()
    {
        Cam[0].rect = new Rect(0.0f, 0.775f, 0.5f, 0.225f);
        Cam[1].rect = new Rect(0.5f, 0.775f, 0.5f, 0.225f);
        Cam[2].rect = new Rect(0.0f,  0.55f, 0.5f, 0.225f);
        Cam[3].rect = new Rect(0.5f,  0.55f, 0.5f, 0.225f);
        Cam[4].rect = new Rect(0.0f, 0.325f, 0.5f, 0.225f);
        Cam[5].rect = new Rect(0.5f, 0.325f, 0.5f, 0.225f);
        Cam[6].rect = new Rect(0.0f,   0.1f, 0.5f, 0.225f);
        Cam[7].rect = new Rect(0.5f,   0.1f, 0.5f, 0.225f);

        Sd[0].transform.localPosition = new Vector3(-250.0f,  165.0f, 0.0f);
        Sd[1].transform.localPosition = new Vector3( 250.0f,  165.0f, 0.0f);
        Sd[2].transform.localPosition = new Vector3(-250.0f,   38.0f, 0.0f);
        Sd[3].transform.localPosition = new Vector3( 250.0f,   38.0f, 0.0f);
        Sd[4].transform.localPosition = new Vector3(-250.0f,  -90.0f, 0.0f);
        Sd[5].transform.localPosition = new Vector3( 250.0f,  -90.0f, 0.0f);
        Sd[6].transform.localPosition = new Vector3(-250.0f, -217.0f, 0.0f);
        Sd[7].transform.localPosition = new Vector3( 250.0f, -217.0f, 0.0f);

        FName[0].transform.localPosition = new Vector3(-550.0f,  260.0f, 0.0f);
        FName[1].transform.localPosition = new Vector3(   0.0f,  260.0f, 0.0f);
        FName[2].transform.localPosition = new Vector3(-550.0f,  125.0f, 0.0f);
        FName[3].transform.localPosition = new Vector3(   0.0f,  125.0f, 0.0f);
        FName[4].transform.localPosition = new Vector3(-550.0f,  -15.0f, 0.0f);
        FName[5].transform.localPosition = new Vector3(   0.0f,  -15.0f, 0.0f);
        FName[6].transform.localPosition = new Vector3(-550.0f, -150.0f, 0.0f);
        FName[7].transform.localPosition = new Vector3(   0.0f, -150.0f, 0.0f);

        DTime[0].transform.localPosition = new Vector3(-400.0f,  170.0f, 0.0f);
        DTime[1].transform.localPosition = new Vector3( 120.0f,  170.0f, 0.0f);
        DTime[2].transform.localPosition = new Vector3(-400.0f,   30.0f, 0.0f);
        DTime[3].transform.localPosition = new Vector3( 120.0f,   30.0f, 0.0f);
        DTime[4].transform.localPosition = new Vector3(-400.0f, -110.0f, 0.0f);
        DTime[5].transform.localPosition = new Vector3( 120.0f, -110.0f, 0.0f);
        DTime[6].transform.localPosition = new Vector3(-400.0f, -245.0f, 0.0f);
        DTime[7].transform.localPosition = new Vector3( 120.0f, -245.0f, 0.0f);

        ETime[0].transform.localPosition = new Vector3(-670.0f,  170.0f, 0.0f);
        ETime[1].transform.localPosition = new Vector3(-125.0f,  170.0f, 0.0f);
        ETime[2].transform.localPosition = new Vector3(-670.0f,   30.0f, 0.0f);
        ETime[3].transform.localPosition = new Vector3(-125.0f,   30.0f, 0.0f);
        ETime[4].transform.localPosition = new Vector3(-670.0f, -110.0f, 0.0f);
        ETime[5].transform.localPosition = new Vector3(-125.0f, -110.0f, 0.0f);
        ETime[6].transform.localPosition = new Vector3(-670.0f, -245.0f, 0.0f);
        ETime[7].transform.localPosition = new Vector3(-125.0f, -245.0f, 0.0f);

        for (int i = 0; i < ViewLayout; i++)
        {
            Cam[i].depth = -1f;
            isZoom[i] = false;
            Sd[i].gameObject.SetActive(true);
            FName[i].gameObject.SetActive(true);
            DTime[i].gameObject.SetActive(true);
            ETime[i].gameObject.SetActive(true);
            Vp[i].SetDirectAudioMute(0, true);
        }

    }
}
