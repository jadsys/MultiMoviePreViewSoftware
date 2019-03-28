using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewManager1 : MonoBehaviour {

    public const int ViewMax = 8;
    public int ViewLayout = 0;

    public VideoPlayerManager vpManager = null;

    VideoPlayer[] Vp = new VideoPlayer[ViewMax];

    bool[] isZoom = new bool[ViewMax] { false, false, false, false, false, false, false, false };

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
            Vp[i] = GameObject.Find(MoviePanelString[i]).GetComponent<VideoPlayer>();
        }

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (!isZoom[0])
            {
                if (vpManager.getAudioSupport(0))
                {
                    Vp[0].SetDirectAudioMute(0, false);
                }
                isZoom[0] = true;
            }
            else
            {
                Vp[0].SetDirectAudioMute(0, true);
                isZoom[0] = false;
            }
        }
    }
}
