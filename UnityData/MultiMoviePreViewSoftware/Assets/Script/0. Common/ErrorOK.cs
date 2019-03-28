using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorOK : MonoBehaviour
{
    public Canvas Canvas_ErrorDialog = null;

    void Start()
    {
        Canvas_ErrorDialog = GameObject.Find("Canvas_ErrorDialog").GetComponent<Canvas>();
    }

    // Yes ボタンと関連づけたイベントハンドラ関数
    public void OnClickButton()
    {
        // Canvas を無効にする。(ダイアログを閉じる)
        Canvas_ErrorDialog.enabled = false;
    }
}
