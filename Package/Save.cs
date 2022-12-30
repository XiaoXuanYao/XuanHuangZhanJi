using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UserMessage;
using UnityEngine.UI;
//using Object;

public class Save : MonoBehaviour
{
    static readonly List<SaveFloatClass> FloatSave = new List<SaveFloatClass>();
    static readonly List<SaveIntClass> IntSave = new List<SaveIntClass>();
    static readonly List<SaveStringClass> StringSave = new List<SaveStringClass>();

    public static void SetFloat(string Name, float Value)
    {
        PlayerPrefs.SetFloat(Name, Value);
        SaveFloatClass F = new SaveFloatClass
        {
            Name = Name,
            Value = Value
        };
        bool HasKey = false;
        int Num = 0;
        for (int i = 0; i < FloatSave.Count; i++)
        {
            if (FloatSave[i].Name == Name)
            {
                HasKey = true;
                Num = i;
                break;
            }
        }
        if (HasKey)
        {
            FloatSave[Num].Value = Value;
        }
        else
        {
            FloatSave.Add(F);
        }
    }
    public static void SetInt(string Name, int Value)
    {
        PlayerPrefs.SetInt(Name, Value);
        SaveIntClass I = new SaveIntClass
        {
            Name = Name,
            Value = Value
        };
        bool HasKey = false;
        int Num = 0;
        for (int i = 0; i < IntSave.Count; i++)
        {
            if (IntSave[i].Name == Name)
            {
                HasKey = true;
                Num = i;
                break;
            }
        }
        if (HasKey)
        {
            IntSave[Num].Value = Value;
        }
        else
        {
            IntSave.Add(I);
        }
    }
    public static void SetString(string Name, string Value)
    {
        PlayerPrefs.SetString(Name, Value);
        SaveStringClass S = new SaveStringClass
        {
            Name = Name,
            Value = Value
        };
        bool HasKey = false;
        int Num = 0;
        for (int i = 0; i < StringSave.Count; i++)
        {
            if (StringSave[i].Name == Name)
            {
                HasKey = true;
                Num = i;
                break;
            }
        }
        if (HasKey)
        {
            StringSave[Num].Value = Value;
        }
        else
        {
            StringSave.Add(S);
        }
    }

    public static void ReadLocalSave()
    {
        foreach(string[] S in GetMessage.GetAll(PlayerPrefs.GetString("CouldStartGuanQia")))
        {
            ControlCenter.CouldStartGuanQia.Add(S[1]);
        }
        foreach (string[] S in GetMessage.GetAll(PlayerPrefs.GetString("FinishedGuanQia")))
        {
            ControlCenter.FinishedGuanQia.Add(S[1]);
        }
        foreach (string[] S in GetMessage.GetAll(PlayerPrefs.GetString("FinishedAppendGuanQiaAppendMessage")))
        {
            ControlCenter.FinishedAppendGuanQiaAppendMessage.Add(S[1]);
        }
        ObjectSystem.ObjectsList = new List<Object>();
        for (int i = 0; i < PlayerPrefs.GetInt("ObjectInBaoGuoLength"); i++)
        {
            string Message = PlayerPrefs.GetString("ObjectInBaoGuo" + i);
            ObjectSystem.ObjectsList.Add(new Object
            {
                Name = GetMessage.Get(Message, "Name"),
                Number = int.Parse(GetMessage.Get(Message, "Number")),
                AppendantMessage = GetMessage.Get(Message, "AppendantMessage"),
            });
        }
        ObjectSystem.ReWriteThings();
        KeJiFun.ReadKeJiSave();
    }

    public static void WriteOnlineSave()
    {
        string Save = "";
        int i = 0;
        for (int u = 0; u < FloatSave.Count; u++)
        {
            Save += $"<Name{i}>{FloatSave[u].Name}</Name{i}><Kind{i}>Float</Kind{i}><Value{i}>{FloatSave[u].Value}</Value{i}>\n";
            i++;
        }
        for (int u = 0; u < IntSave.Count; u++)
        {
            Save += $"<Name{i}>{IntSave[u].Name}</Name{i}><Kind{i}>Int</Kind{i}><Value{i}>{IntSave[u].Value}</Value{i}>\n";
            i++;
        }
        for (int u = 0; u < StringSave.Count; u++)
        {
            Save += $"<Name{i}>{StringSave[u].Name}</Name{i}><Kind{i}>String</Kind{i}><Value{i}>{StringSave[u].Value}</Value{i}>\n";
            i++;
        }
        Save = Unicode.ToUnicode(Save);
        //GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(OnlineSave(Save));
        if (ControlCenter.SignInType == "4399Account")
        Unity_Js.UnityToJs("WriteSave", Save);
    }

    static IEnumerator OnlineSave(string SaveMessage)
    {
        WWWForm Form = new WWWForm();
        Form.AddField("Tag", "Save");
        Form.AddField("Content", ControlCenter.SaveAccount + "[`]" + SaveMessage);
        UnityWebRequest WebRequest = UnityWebRequest.Post(ControlCenter.WebServerUrl + "/ExchangeMessage.asp", Form);
        yield return WebRequest.SendWebRequest();
        if (WebRequest.error != null)
        {
#if UNITY_EDITOR
            Debug.Log("存档失败：" + WebRequest.error);
#endif
            ShowMessage.Message("存档失败，请重启游戏。" + WebRequest.error);
        }
    }

    public static void ReadOnlineSave(string Message)
    {
        //Message = Regex.Unescape(Message);
        List<string> SaveName = new List<string>();
        List<string> SaveKind = new List<string>();
        List<string> SaveValue = new List<string>();
        for (int i = 0; GetMessage.Has(Message, "Name" + i); i++)
        {
            if (GetMessage.Get(Message, "Name" + i).Replace(" ", "") != "")
            {
                SaveName.Add(Regex.Unescape(GetMessage.Get(Message, "Name" + i)));
                SaveKind.Add(Regex.Unescape(GetMessage.Get(Message, "Kind" + i)));
                SaveValue.Add(Regex.Unescape(GetMessage.Get(Message, "Value" + i)));
            }
        }
        for (int i = 0; i < SaveName.Count; i++)
        {
            if (SaveKind[i] == "Float")
            {
                Save.SetFloat(SaveName[i], float.Parse(SaveValue[i]));
            }
            else if (SaveKind[i] == "Int")
            {
                Save.SetInt(SaveName[i], int.Parse(SaveValue[i]));
            }
            else
            {
                Save.SetString(SaveName[i], SaveValue[i]);
            }
        }
        ReadLocalSave();
        ShowMessage.Message("读取存档成功");
    }
}

class SaveFloatClass
{
    public string Name = "";
    public float Value = 0F;
}
class SaveIntClass
{
    public string Name = "";
    public int Value = 0;
}
class SaveStringClass
{
    public string Name = "";
    public string Value = "";
}