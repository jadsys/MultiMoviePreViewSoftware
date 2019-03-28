using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayPause : MonoBehaviour {

    //[SerializeField]
    public VideoPlayerManager vpManager = null;

    public const int ViewMax = 8;
    public int ViewCount = 0;

    static bool isStop = false;

    VideoPlayer[] Vp = new VideoPlayer[ViewMax];

    public static string[] MoviePanelString = new string[ViewMax] { "MoviePanel_1", "MoviePanel_2", "MoviePanel_3", "MoviePanel_4",
                                                                    "MoviePanel_5", "MoviePanel_6", "MoviePanel_7", "MoviePanel_8" };

    void Start()
    {
        vpManager = GameObject.Find("VideoPlayerManager").GetComponent<VideoPlayerManager>();

        while (true)
        {
            ViewCount = vpManager.getViewCount();
            if (ViewCount != 0)
            {
                break;
            }
        }

        for (int i = 0; i < ViewCount; i++)
        {
            Vp[i] = GameObject.Find(MoviePanelString[i]).GetComponent<VideoPlayer>();
        }
    }

    public void OnClickButton()
    {
        // Textコンポーネント郡を取得します。
        var components = this.gameObject.GetComponentsInChildren<Text>();
        // テキストを文字の状態によって変更するようにします。
        components[0].text = components[0].text == "Pause" ? "Play" : "Pause";

        isStop = vpManager.getStatus();
        if (!isStop)
        {
            for (int i = 0; i < ViewCount; i++)
            {
                Vp[i].Pause();
            }
        }
        else
        {
            for (int i = 0; i < ViewCount; i++)
            {
                Vp[i].Play();
            }
        }
        vpManager.setStatus(!isStop);
    }
}
