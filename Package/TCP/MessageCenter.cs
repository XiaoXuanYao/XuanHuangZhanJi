using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TCPServer;
class MessageCenter : MonoBehaviour
{
    static string[][] Message = new string[50][];
    static int MesNum = 0;
    public void NewMessage(string Message)
    {
        string Tag = UserMessage.GetMessage.Get(Message, "Tag");
        string Content = UserMessage.GetMessage.Get(Message, "Content");
        NewMessage(Tag, Content, "");
    }
    public static void NewMessage(string Tag, string Content, string Options = "")
    {
        Message[MesNum] = new string[] { Tag, Content };
        MesNum++;
    }
    private void Update()
    {
        while (MesNum > 0)
        {
            switch (Message[0][0])  //Message[0][0] - Tag;        Message[0][1] - Content;
            {
                case "ShowMessage":
                    ShowMessage.Message(Message[0][1]);
                    break;
                case "JingZuanAdd":
                    ObjectSystem.AddThings("晶钻", 1 + (int)(Mathf.Pow(Random.value, 2) * 2F));
                    ObjectSystem.AddThings("宝箱", 3 + (int)(Mathf.Pow(Random.value, 2) * 2.5F));
                    break;
                case "SkipGuanQia":
                    Map.IsSkip = true;
                    Map.StartMap();
                    break;
            }

            //-------------------------------------上为处理组-----------------------------------

            for (int i = 0; i < Message.Length; i++)
            {
                if (i < MesNum)
                {
                    Message[i] = Message[i + 1];
                }
                else
                {
                    Message[i] = new string[2];
                    MesNum--;
                    break;
                }
            }
        }
    }

    public static void PlayAd(string PlayAdFor = "GetReward")
    {
        //Unity_Js.SendMessageToJs("PlayAd".ToCharArray(), PlayAdFor.ToCharArray());
    }

    void OnDestroy()
    {
        if (TCPServer.Client.ClientRunning == true)
        {
            Client.SendMessage("StopClient|true");
            TCPServer.Client.CloseClient();
        }
    }
}
namespace MyRegex
{
    using System.Text.RegularExpressions;
    class MyOwnRegex
    {
        static public string mRegex(string Mes)
        {
            return Mes;
        }
        static public string mReRegex(string Mes)
        {
            return Mes;
        }
    }
}