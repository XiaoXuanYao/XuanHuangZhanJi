using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeJiFun : MonoBehaviour
{

    public static List<ObjectList> ObjsNeed = new List<ObjectList>();
    public static string OnKeJiChosed = "";

    public static List<(string, int)> KeJiKeys = new List<(string, int)>() { };

    public void OnClick()
    {
        ObjsNeed.Clear();
        OnKeJiChosed = this.name;
        ReLoadKeJi();
        switch (this.name)
        {
            case "Basic":
                ObjsNeed.Add(new ObjectList() { Name = "晶钻", Number = (int)((float)this.GetComponent<KeJiMes>().Grade / 2) + 1 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 20 + 5 });
                ObjsNeed.Add(new ObjectList() { Name = "硅-30", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "抵子板", Number = 3 });
                ObjsNeed.Add(new ObjectList() { Name = "冲子板", Number = 3 });
                break;
            case "NengLiang":
                ObjsNeed.Add(new ObjectList() { Name = "硅-30", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 5 + 1 });
                break;
            case "ShengMing":
                ObjsNeed.Add(new ObjectList() { Name = "抵子板", Number = this.GetComponent<KeJiMes>().Grade + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "ShengMingHuiFu":
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "抵子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "GongJi":
                ObjsNeed.Add(new ObjectList() { Name = "冲子板", Number = this.GetComponent<KeJiMes>().Grade + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "GongJiPersent":
                ObjsNeed.Add(new ObjectList() { Name = "硅-30", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "冲子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "GongJiDuringTime":
                ObjsNeed.Add(new ObjectList() { Name = "硅-30", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "冲子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "HuDunHuiFu":
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "抵子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "HuDunJianShang":
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 2 });
                ObjsNeed.Add(new ObjectList() { Name = "抵子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "ZhanJiJianShang":
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 2 });
                ObjsNeed.Add(new ObjectList() { Name = "抵子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "FS_1Basic":
                ObjsNeed.Add(new ObjectList() { Name = "晶钻", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "FS-1碎片", Number = 5 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "TU_1Basic":
                ObjsNeed.Add(new ObjectList() { Name = "晶钻", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "TU-1碎片", Number = 5 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "HZ_1Basic":
                ObjsNeed.Add(new ObjectList() { Name = "晶钻", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "HZ-1碎片", Number = 5 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "BR_1Basic":
                ObjsNeed.Add(new ObjectList() { Name = "晶钻", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "BR-1碎片", Number = 5 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "FR_1Basic":
                ObjsNeed.Add(new ObjectList() { Name = "晶钻", Number = 1 });
                ObjsNeed.Add(new ObjectList() { Name = "FR-1碎片", Number = 5 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
            case "ExtraShengMing":
                ObjsNeed.Add(new ObjectList() { Name = "构架铁", Number = 2 });
                ObjsNeed.Add(new ObjectList() { Name = "冲子板", Number = this.GetComponent<KeJiMes>().Grade * 2 + 3 });
                ObjsNeed.Add(new ObjectList() { Name = "晶石", Number = this.GetComponent<KeJiMes>().Grade * 3 + 3 });
                break;
        }
        ChangeNeed(ObjsNeed.ToArray());
        string PrepStr = "<color=#6ac>—— · 前置科技 · ——</color>";
        foreach (KeJiMes.Preposition P in this.GetComponent<KeJiMes>().Prep)
        {
            int PrepGradeNeed = (int)Mathf.Ceil((this.GetComponent<KeJiMes>().Grade + 1 - P.Plus) / P.Multiply);
            if (PrepGradeNeed > P.PrepositionPoint.GetComponent<KeJiMes>().Grade)
            {
                PrepStr += "\n<color=#999>" + P.PrepositionPoint.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text
                    + " Lv." + PrepGradeNeed + "</color>";
            }
            else
            {
                PrepStr += "\n<color=#fff>" + P.PrepositionPoint.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text
                    + " Lv." + PrepGradeNeed + "</color>";
            }
        }
        if (this.GetComponent<KeJiMes>().Prep.Length == 0)
        {
            PrepStr += "\n无";
        }
        Fade.StringToTransform("Canvas/KeJi/Preposition/Text").GetComponent<TextMeshProUGUI>().text = PrepStr;
        Fade.StringToTransform("Canvas/KeJi/YanJiu").gameObject.SetActive(true);
        Fade.StringToTransform("Canvas/KeJi/Preposition").gameObject.SetActive(true);
        if (this.GetComponent<KeJiMes>().Introduction != "")
        {
            Fade.StringToTransform("Canvas/KeJi/YanJiu/Tip").GetComponent<TextMeshProUGUI>().text = this.GetComponent<KeJiMes>().Introduction;
        }
        else
        {
            Fade.StringToTransform("Canvas/KeJi/YanJiu/Tip").GetComponent<TextMeshProUGUI>().text = "通过研究科技可以增强实力，并解锁一些特殊能力。";
        }
        Fade.StringToTransform("Canvas/KeJi/YanJiu/Reward").GetComponent<TextMeshProUGUI>().text = this.GetComponent<KeJiMes>().Reward.Replace("\\n","\n");
    }

    public void OnCloseButtonClick()
    {
        OnKeJiChosed = "";
        Fade.StringToTransform("Canvas/KeJi/YanJiu").gameObject.SetActive(false);
        Fade.StringToTransform("Canvas/KeJi/Preposition").gameObject.SetActive(false);
    }

    public static void ChangeNeed(ObjectList[] Objs)
    {
        int UsingNum = Objs.Length;
        Fade.StringToTransform("Canvas/KeJi/YanJiu/ObjectsNeedShow/Main").GetComponent<RectTransform>().sizeDelta = new Vector2(UsingNum * 100 + 30, 100);
        for (int i = Fade.StringToTransform("Canvas/KeJi/YanJiu/ObjectsNeedShow/Main").childCount; i > 0; i--)
        {
            Destroy(Fade.StringToTransform("Canvas/KeJi/YanJiu/ObjectsNeedShow/Main").GetChild(i - 1).gameObject);
        }
        for (int i = 0; i < UsingNum; i++)
        {
            Transform Obj = Instantiate(Fade.StringToTransform("Canvas/KeJi/YanJiu/ObjectsNeedShow/Model")
                , Fade.StringToTransform("Canvas/KeJi/YanJiu/ObjectsNeedShow/Main"));
            Obj.transform.Find("Number").GetComponent<TextMeshProUGUI>().text = Objs[i].Number.ToString();
            Obj.GetComponent<RectTransform>().anchoredPosition = new Vector2((i - UsingNum / 2F) * 100 + 50, 0);
            Obj.transform.Find("Image").GetComponent<Image>().sprite
                = Resources.LoadAll(ObjectSystem.GetObjectPng(Objs[i].Name).PngName
                , typeof(Sprite))[ObjectSystem.GetObjectPng(Objs[i].Name).Value] as Sprite;
            Color C = ObjectSystem.GetObjectColor(Objs[i].Name);
            Obj.transform.Find("BackColor").GetComponent<Image>().color = new Color(C.r, C.g, C.b, 0.6F);
            Obj.transform.Find("Image").GetComponent<Image>().color = new Color(C.r, C.g, C.b) * 0.1F + new Color(1, 1, 1) * 0.85F;
            if (!ObjectSystem.HasObject(Objs[i].Name, Objs[i].Number))
            {
                Obj.transform.Find("Number").GetComponent<TextMeshProUGUI>().color = new Color(0.5F, 0.5F, 0.5F);
            }
            else
            {
                Obj.transform.Find("Number").GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
            }
            Obj.gameObject.SetActive(true);
        }
    }

    public bool IsKeJiKeyExist(string Name)
    {
        foreach ((string, int) K in KeJiKeys)
        {
            if (K.Item1 == Name)
            {
                return true;
            }
        }
        return false;
    }

    public int GetKeJiKeyIndex(string Name)
    {
        int N = 0;
        foreach ((string, int) K in KeJiKeys)
        {
            if (K.Item1 == Name)
            {
                return N;
            }
            N++;
        }
        return -1;
    }

    public static int GetKeJiKeyGrade(string Name)
    {
        foreach ((string, int) K in KeJiKeys)
        {
            if (K.Item1 == Name)
            {
                return K.Item2;
            }
        }
        return 0;
    }

    public void OnYanJiuButtonClick()
    {
        bool HasAllMeterials = true;
        bool PrepAllow = true;
        foreach (ObjectList O in ObjsNeed)
        {
            if (!ObjectSystem.HasObject(O.Name, O.Number))
            {
                HasAllMeterials = false;
            }
        }
        Transform Obj = Fade.StringToTransform("Canvas/KeJi/Main/Content/" + OnKeJiChosed);
        foreach (KeJiMes.Preposition P in Obj.GetComponent<KeJiMes>().Prep)
        {
            int MaxGrade = (int)(P.PrepositionPoint.GetComponent<KeJiMes>().Grade * P.Multiply + P.Plus);
            if (MaxGrade < Obj.GetComponent<KeJiMes>().Grade + 1)
            {
                PrepAllow = false;
            }
        }
        if (!HasAllMeterials)
        {
            ShowMessage.Message("研究材料不足");
        }
        else if (!PrepAllow)
        {
            ShowMessage.Message("缺少前置科技");
        }
        else
        {
            if (IsKeJiKeyExist(OnKeJiChosed))
            {
                KeJiKeys[GetKeJiKeyIndex(OnKeJiChosed)] = (OnKeJiChosed, KeJiKeys[GetKeJiKeyIndex(OnKeJiChosed)].Item2 + 1);
            }
            else
            {
                KeJiKeys.Add((OnKeJiChosed, 1));
            }
            SaveKeJiKeys();
            ReLoadKeJi(true);
            ShowMessage.Message("研究成功");
        }
    }

    public static void ReLoadKeJi(bool DoOnClick = false)
    {
        foreach ((string, int) K in KeJiKeys)
        {
            Fade.StringToTransform("Canvas/KeJi/Main/Content/" + K.Item1 + "/Lv").GetComponent<Image>().fillAmount = (float)K.Item2 /
                Fade.StringToTransform("Canvas/KeJi/Main/Content/" + K.Item1).GetComponent<KeJiMes>().MaxGrade;
            Fade.StringToTransform("Canvas/KeJi/Main/Content/" + K.Item1).GetComponent<KeJiMes>().Grade = K.Item2;
        }
        if (OnKeJiChosed != "")
        {
            Fade.StringToTransform("Canvas/KeJi/YanJiu/Lv").GetComponent<Text>().text = "Lv. " + GetKeJiKeyGrade(OnKeJiChosed) + " / " +
                Fade.StringToTransform("Canvas/KeJi/Main/Content/" + OnKeJiChosed).GetComponent<KeJiMes>().MaxGrade;
            if (DoOnClick)
            {
                Fade.StringToTransform("Canvas/KeJi/Main/Content/" + OnKeJiChosed).GetComponent<KeJiFun>().OnClick();
            }
        }
    }

    public static void SaveKeJiKeys()
    {
        string Str = "";
        foreach ((string, int) K in KeJiKeys)
        {
            Str += "<" + K.Item1 + ">" + K.Item2 + "</" + K.Item1 + ">";
        }
        Save.SetString("KeJiKeys", Str);
    }

    public static void ReadKeJiSave()
    {
        string[][] Mes = UserMessage.GetMessage.GetAll(PlayerPrefs.GetString("KeJiKeys", ""));
        KeJiKeys.Clear();
        for(int i = 0; i < Mes.Length; i++)
        {
            KeJiKeys.Add((Mes[i][0], int.Parse(Mes[i][1])));
        }
        ReLoadKeJi(true);
    }

    [System.Serializable]
    public class ObjectList
    {
        public string Name = "";
        public int Number = 0;
    }

}
