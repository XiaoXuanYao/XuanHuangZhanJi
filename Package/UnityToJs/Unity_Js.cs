using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class Unity_Js : MonoBehaviour
{
    void Awake()
    {
        Init();
        StartCoroutine(GetJsMessage());
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void Init();
    [DllImport("__Internal")]
    private static extern void UnityToJs(string Tag, string Content);
    [DllImport("__Internal")]
    private static extern string JsToUnity();
#else
    private static void UnityToJs(string Tag, string Content)
    {
        if (Tag == "PlayAd" && Content == "SkipGuanQia")
        {
            MessageCenter.NewMessage("SkipGuanQia", "");
        }
        else if (Tag == "PlayAd" && Content == "JingZuanAdd")
        {
            MessageCenter.NewMessage("JingZuanAdd", "");
        }
    }
    private static void Init() { }
    private static string JsToUnity() { return ""; }
#endif

    public static void UnityToJs(string Tag, string Content, bool Send = true)
    {
        UnityToJs(Tag, Content);
    }

    IEnumerator GetJsMessage()
    {
        int MessageNum = 0;
        string Message = "";
        while (true)
        {
            yield return new WaitForSeconds(0.1F);
            Message += JsToUnity().ToString().Replace("\n", "");
            if (Message != "")
            {
                try
                {
                    string Message0 = UserMessage.GetMessage.Get(Message, "Message" + MessageNum);
                    Message = Message.Replace("<Message" + MessageNum + ">" + Message0 + "</Message" + MessageNum + ">", "");
                    MessageCenter.NewMessage(Message0.Split(':')[0].Replace("`[0001]", ":"), Message0.Split(':')[1].Replace("`[0001]", ":"));
                }
                finally
                {
                    MessageNum++;
                }
            }
        }
    }

    public void MessageReturn(string Content)
    {
        string Mes = System.Text.RegularExpressions.Regex.Unescape(Content);
        for (int i = 1; UserMessage.GetMessage.Has(Mes, "`Part" + i); i++)
        {
            string Str = UserMessage.GetMessage.Get(Mes, "`Part" + i);
            MessageCenter.NewMessage(UserMessage.GetMessage.GetAll(Str)[0][0], UserMessage.GetMessage.GetAll(Str)[0][1]);
        }
    }

    //-----------------------------Get message form server---------------------------------------

    static int MessageNum = 1;
    public static void ServerMessage()
    {
        GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(CheckNewMessage());
    }

    public static IEnumerator CheckNewMessage()
    {
        UnityWebRequest WebRequest = UnityWebRequest.Get(ControlCenter.WebServerUrl + "UserMessage/" + ControlCenter.Account + "_ExchangeNum.en");
        yield return WebRequest.SendWebRequest();
        string Mes0 = WebRequest.downloadHandler.text;
        //MessageNum = int.Parse(Mes0);

        while (true)
        {
            yield return new WaitForSecondsRealtime(1.5F + ControlCenter.UnActive);
            WebRequest = UnityWebRequest.Get(ControlCenter.WebServerUrl + "UserMessage/" + ControlCenter.Account + "_ExchangeNum.en");
            yield return WebRequest.SendWebRequest();
            string Mes1 = WebRequest.downloadHandler.text;

            if (int.Parse(Mes1) >= MessageNum)
            {
                WebRequest = UnityWebRequest.Get(ControlCenter.WebServerUrl + "UserMessage/" + ControlCenter.Account + "_Exchange.ec");
                yield return WebRequest.SendWebRequest();
                string Message = WebRequest.downloadHandler.text;
                try
                {
                    Message = UserMessage.GetMessage.Get(Message, "M_" + MessageNum);
                    MessageNum++;
                }
                catch { }
                while (true)
                {
                    MatchCollection Tag0 = Regex.Matches(Message, "[<][^>]+[>]");
                    if (Tag0.Count > 0)
                    {
                        string Tag = "";
                        foreach (Match M in Tag0)
                        {
                            Tag = M.ToString();
                            break;
                        }
                        Tag = Tag.Replace("<", "");
                        Tag = Tag.Replace(">", "");
                        MatchCollection Content0 = Regex.Matches(Message, "[<][^>]+[>][^<]{0,}[<][^>]+[>]");
                        string Content = "";
                        if (Content0.Count > 0)
                        {
                            foreach (Match M in Content0)
                            {
                                Content = M.ToString();
                                break;
                            }
                        }
                        if (Content == "")
                        {
                            break;
                        }
                        Message = Message.Replace(Content, "");
                        Content = Content.Replace("<" + Tag + ">", "");
                        Content = Content.Replace("</" + Tag + ">", "");
                        MessageCenter.NewMessage(Tag, Content);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
class UnityWebForm
{
    public static void NewForm(WWWForm Form)
    {
        //GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(NewFormRequest(Form));
    }
    static IEnumerator NewFormRequest(WWWForm Form)
    {
        //添加文件（输入对象的名字、二进制数组、文件名）
        //form.AddBinaryData("file", newFile, name);

        UnityWebRequest WebRequest = UnityWebRequest.Post(ControlCenter.WebServerUrl + "ExchangeMessage.asp", Form);
        yield return WebRequest.SendWebRequest();
    }
}