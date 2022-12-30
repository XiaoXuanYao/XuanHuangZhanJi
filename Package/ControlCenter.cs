using System.Collections.Generic;
using UnityEngine;

public class ControlCenter : MonoBehaviour
{
    public static bool Test = false;
    public bool Test0 = false;

    public static bool isTCPServer = false;
    public static string StartingServerIP = "192.168.0.101";
    public static int StartingServerPort = 1031;
    public static bool HandConnect = false;
    public string StartingServerIP0 = "192.168.0.101";
    public int StartingServerPort0 = 1031;
    public bool HandConnect0 = false;
    public bool isTCPServer0 = false;

    public static string WebServerUrl = "172.81.210.39/Flying/";
    public static string ProductVersion = "V1.0.2";

    public static string GameFor = "Ohayoo";

    public static int UnActive = 0;

    //--------------------------------下列为本游戏内数据-------------------------------

    public static string Account = "";
    public static string SaveAccount = "";
    public static string SignInType = "YouKeDengLu";  //YouKeDengLu / 4399Account
    public static string UserName = "";

    public static readonly string RegiveDate = "1970-1-1";
    /// <summary>
    /// [计算类型]   0：曲率估算（最高效率）    1：逐加（2级准确度）     2：逐加（3级准确度）
    /// </summary>
    public static int CalculateType = 0;

    public static List<string> CouldStartGuanQia = new List<string>();
    public static List<string> FinishedGuanQia = new List<string>();
    public static List<string> FinishedAppendGuanQiaAppendMessage = new List<string>();
    public static int JiaoChengGuanQiaNum = 3;
    public static List<ObjectMessage> Objects = new List<ObjectMessage>();

    public static int GongJiAddNum = 0;
    public static float GongJiAddPercent = 0;

    //temp:



    //---------------------------------------end---------------------------------------

    public static string MainButtonsLastClick = "";
    void Awake()
    {
        Test = Test0;
        isTCPServer = isTCPServer0;
        if (Test)
        {
            StartingServerIP = StartingServerIP0;
            StartingServerPort = StartingServerPort0;
            HandConnect = HandConnect0;
        }
    }
}