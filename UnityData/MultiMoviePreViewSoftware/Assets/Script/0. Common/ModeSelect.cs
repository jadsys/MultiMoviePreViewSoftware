using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelect : MonoBehaviour {

    public const int ViewMax = 8;
    public int ViewCount = 0;

    public VideoPlayerManager vpManager = null;

    Slider SdAll;
    Slider[] Sd = new Slider[ViewMax];

    public static string[] SliderString = new string[ViewMax] { "Slider_1", "Slider_2" , "Slider_3" , "Slider_4",
                                                                "Slider_5", "Slider_6" , "Slider_7" , "Slider_8" };

    // Use this for initialization
    void Start () {

        vpManager = GameObject.Find("VideoPlayerManager").GetComponent<VideoPlayerManager>();

        while (true)
        {
            ViewCount = vpManager.getViewCount();
            if (ViewCount != 0)
            {
                break;
            }
        }

        SdAll = GameObject.Find("Slider").GetComponent<Slider>();

        for (int i = 0; i < ViewCount; i++)
        {
            Sd[i] = GameObject.Find(SliderString[i]).GetComponent<Slider>();
        }
    }

    public void OnClickButton()
    {
        // Textコンポーネント郡を取得します。
        var components = this.gameObject.GetComponentsInChildren<Text>();
        // テキストを文字の状態によって変更するようにします。
        components[0].text = components[0].text == "ALL" ? "Single" : "ALL";

        SdAll.interactable = !SdAll.interactable;

        for (int i = 0; i < ViewCount; i++)
        {
            Sd[i].interactable = !Sd[i].interactable;
        }
    }

}
