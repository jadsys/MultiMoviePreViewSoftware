using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectForm : MonoBehaviour {

    public const int ViewMax = 8;
    public int ViewCount = 0;
    public int ViewLayout = 0;

    //[SerializeField]
     public VideoPlayerManager vpManager = null;
    // エディタのインスペクタで、この変数にヒエラルキーにある Canvas を割り当ててください。
    public Canvas Canvas_ErrorDialog = null;
    public Text Text_ErrorTitle = null;
    public Text Text_ErrorMessage = null;

    Text[] MInfo = new Text[ViewMax];
    //    Text Instruction;

    public static string[] MovieInfoString = new string[ViewMax] { "MovieInfo_1", "MovieInfo_2", "MovieInfo_3", "MovieInfo_4",
                                                                   "MovieInfo_5", "MovieInfo_6", "MovieInfo_7", "MovieInfo_8" };

    bool[] isSet = new bool[ViewMax] { false, false, false, false, false, false, false, false };

    void Start()
    {
        vpManager = this.GetComponent<VideoPlayerManager>();

        for (int i = 0; i < ViewMax; i++)
        {
            MInfo[i] = GameObject.Find(MovieInfoString[i]).GetComponent<Text>();

        }
        //        Instruction = GameObject.Find("Instruction").GetComponent<Text>();

        // ダイアログを表示するときまで、 Canvas を無効にしておく。
        if (Canvas_ErrorDialog != null)
        {
            Canvas_ErrorDialog.enabled = false;
        }
    }

    private void Update()
    {
        if (!Canvas_ErrorDialog.enabled)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                OpenFileAndPlay(0);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                OpenFileAndPlay(1);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                OpenFileAndPlay(2);
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                OpenFileAndPlay(3);
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                OpenFileAndPlay(4);
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                OpenFileAndPlay(5);
            }
            if (Input.GetKey(KeyCode.Alpha7))
            {
                OpenFileAndPlay(6);
            }
            if (Input.GetKey(KeyCode.Alpha8))
            {
                OpenFileAndPlay(7);
            }
    
            if (Input.GetKeyDown(KeyCode.Return))
            {
                for (int i = 0; i < ViewMax; i++)
                {
                    if (isSet[i])
                    {
                        ViewCount++;
                    }
                    else
                    {
                        break;
                    }
                }
    
                if (ViewCount >= 1)
                {
                    switch (ViewCount)
                    {
                        case 1:
                            ViewLayout = 1;
                            break;
                        case 2:
                            ViewLayout = 2;
                            break;
                        case 3:
                        case 4:
                            ViewLayout = 4;
                            break;
                        case 5:
                        case 6:
                            ViewLayout = 6;
                            break;
                        case 7:
                        case 8:
                            ViewLayout = 8;
                            break;
                        default:
                            break;
                    }
                    vpManager.setViewCount(ViewCount);
                    vpManager.setViewLayout(ViewLayout);
                    SceneManager.LoadScene(ViewLayout.ToString());
                }
            }
        }
    }

    public void OpenFileAndPlay(int num)
    {
        string filePath = OpenFile();

        if (filePath == "")
        {
            return;
        }

        bool seekCheck = false;
        bool dateCheck = true;
        string line;
        string filename = System.IO.Path.GetFileName(filePath);
        string dirname = System.IO.Path.GetDirectoryName(filePath);
        string filenamewithoutext = System.IO.Path.GetFileNameWithoutExtension(filePath);

        string movieInfoFile = dirname + "\\" + filenamewithoutext + ".txt";

        try
        {
            System.IO.StreamReader seekFile = new System.IO.StreamReader(movieInfoFile);
            Regex rgx = new Regex(@"creation_time", RegexOptions.IgnoreCase);

            while ((line = seekFile.ReadLine()) != null)
            {
                if (rgx.Match(line).Success)
                {
                    seekCheck = true;
                    Match matche = Regex.Match(line, @"20\d{2}(-|\/)((0[1-9])|(1[0-2]))(-|\/)((0[1-9])|([1-2][0-9])|(3[0-1]))(T|\s)(([0-1][0-9])|(2[0-3])):([0-5][0-9]):([0-5][0-9])\.([0-9][0-9][0-9])");

                    if (matche.Success)
                    {
                        string[] words = Regex.Split(matche.Value, @"T|\s");

                        for (int i = 0; i < ViewMax; i++)
                        {
                            if ((i != num) && isSet[i] && (vpManager.getMovieStartDate(i) != words[0]))
                            {
                                dateCheck = false;
                                break;
                            }
                        }

                        if (!dateCheck)
                        {
                            SetErrorDialog("ERROR：Invalid Creation Date", "The date is different from other selected files. [" + words[0] + "]");
                            break;
                        }
                        else
                        {
                            //マネージャーにセット
                            vpManager.setMovieUrl(num, "file://" + filePath);
                            vpManager.setMovieName(num, filename);
                            vpManager.setMovieStartDate(num, words[0]);
                            vpManager.setMovieStartTimes(num, words[1]);
                            vpManager.setAudioSupport(num, true);

                            MInfo[num].text = "動画" + (num + 1) + "ファイル名 : " + filename + " ( creation_time : " + vpManager.getMovieStartDate(num) + " " + vpManager.getMovieStartTimes(num) + ")";
                            isSet[num] = true;
                            /*
                            Debug.Log("動画" + num + ":" + vpManager.getMovieStartDate(num));
                            Debug.Log("動画" + num + ":" + vpManager.getMovieStartTimes(num));
                            */
                            break;
                        }
                    }
                    else
                    {
                        SetErrorDialog("ERROR：Invalid Creation Date", "A date matching the format could not be found.");
                        break;
                    }
                }
            }
            seekFile.Close();

            if (!seekCheck)
            {
                SetErrorDialog("ERROR：Creation date Not Found", "Creation date line was not found.");
            }
        }
        catch ( System.IO.IOException ex)
        {
            SetErrorDialog("ERROR：MovieInfo File Open Error", ex.Message);
        }

        // 音声コーデックがAC-3の場合、再生しない対応

        if (isSet[num])
        {
            CheckAudioSupport(num, movieInfoFile);
        }
    }

    private string OpenFile()
    {
        OpenFileDialog dialog = new OpenFileDialog();
        DialogResult result = dialog.ShowDialog();

        return dialog.FileName;
    }

    private void CheckAudioSupport( int num, string movieInfoFile )
    {
        string line;

        try
        {
            System.IO.StreamReader seekFile = new System.IO.StreamReader(movieInfoFile);
            Regex rgx = new Regex(@"ac3|AC-3", RegexOptions.IgnoreCase);

            while ((line = seekFile.ReadLine()) != null)
            {
                if (rgx.Match(line).Success)
                {
                    vpManager.setAudioSupport(num, false);

                    Debug.Log("The audio codec of this movie is ac-3. AudioSupport is " + vpManager.getAudioSupport(num) + ".");

                }
            }
            seekFile.Close();
        }
        catch (System.IO.IOException ex)
        {
            SetErrorDialog("ERROR：MovieInfo File Open Error", ex.Message);
        }
    }

    void SetErrorDialog(string errTitle, string errMsg)
    {
        Text_ErrorTitle.text = errTitle;
        Text_ErrorMessage.text = errMsg;

        Canvas_ErrorDialog.enabled = true;
    }
}