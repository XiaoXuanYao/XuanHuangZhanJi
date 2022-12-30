using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowMessage : MonoBehaviour
{
    static Transform Mess;
    static string Mes = "消息：空";
    static List<string> MessageList = new List<string>();
    static bool NewMessage = true;
    public bool Show = true;
    void Awake()
    {
        Mess = GameObject.Find("Canvas").transform.Find("Message").transform.Find("Text");
    }

    void Update()
    {
        if (Show && NewMessage && MessageList.Count > 0)
        {
            Mes = MessageList[0];
            if (MessageList.Count > 2 &&
                MessageList[0].Replace("`", "").Replace("获得 [ ", "`").Split('`').Length > 0 &&
                MessageList[1].Replace("`", "").Replace("获得 [ ", "`").Split('`').Length > 0 &&
                MessageList[2].Replace("`", "").Replace("获得 [ ", "`").Split('`').Length > 0)
            {
                Mes += "\n" + MessageList[1] + "\n" + MessageList[2];
                MessageList.Remove(MessageList[2]);
                MessageList.Remove(MessageList[1]);
                MessageList.Remove(MessageList[0]);
            }
            while (MessageList.Count > 0 && MessageList[0] == Mes)
            {
                MessageList.Remove(MessageList[0]);
            }
            StartCoroutine(ShowMessage0());
        }
    }
    IEnumerator ShowMessage0()
    {
        if (Mess.GetComponent<Text>())
        {
            Mess.GetComponent<Text>().text = Mes;
        }
        else if (Mess.GetComponent<TextMeshProUGUI>())
        {
            Mess.GetComponent<TextMeshProUGUI>().text = Mes;
        }
        NewMessage = false;
        Fade.NewFade("Canvas/Message", 0, 1, 0.35F);
        yield return new WaitForSeconds(0.5F);
        Mes = CleanTextRich(Mes);
        if (Mes.Length > 5)
        {
            yield return new WaitForSeconds(Mathf.Pow(Mes.Length - 5, 0.7F) / 15);
        }
        yield return new WaitForSeconds(0.2F);
        Fade.NewFade("Canvas/Message", 1, 0, 0.6F);
        yield return new WaitForSeconds(0.4F);
        NewMessage = true;
    }
    public static string CleanTextRich(string Str)
    {
        Str = Str.Replace("<color=#", "");
        Str = Str.Replace("</color>", "");
        Str = Str.Replace("<b>", "");
        Str = Str.Replace("</b>", "");
        Str = Str.Replace("<size=", "");
        Str = Str.Replace("</size>", "");
        return Str;
    }
    public static void Message(string Text)
    {
        MessageList.Add(Text);
    }
    public static void MessageBox(string Text, int BoxWidth = 300, int BoxHeight = 200, int FontSize = 50)
    {
        GameObject.Find("Canvas").transform.Find("MessageBox").transform.Find("Box").transform.Find("Text").GetComponent<Text>().text = Text;
        GameObject.Find("Canvas").transform.Find("MessageBox").transform.Find("Box").GetComponent<RectTransform>()
            .sizeDelta = new Vector2((float)BoxWidth, (float)BoxHeight);
        GameObject.Find("Canvas").transform.Find("MessageBox").transform.Find("Box").transform.Find("Text").GetComponent<RectTransform>()
            .sizeDelta = new Vector2((float)BoxWidth, (float)BoxHeight);
        GameObject.Find("Canvas").transform.Find("MessageBox").transform.Find("Box").transform.Find("Text").GetComponent<Text>().fontSize = FontSize;
        Fade.NewFade("Canvas/MessageBox", 0, 1, 0.5F);
    }
}