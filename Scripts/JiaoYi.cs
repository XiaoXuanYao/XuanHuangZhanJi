using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JiaoYi : MonoBehaviour
{
    void Update()
    {
        Fade.StringToTransform("Canvas/JiaoYi/JingZuanNum").GetComponent<TextMeshProUGUI>().text =
            "<size=35><sprite=6></size>  <size=28>" + ObjectSystem.GetThingNum("晶钻").ToString() + "</size>";
    }

    public void JingZuanAddButtonClick()
    {
        if (PlayerPrefs.GetInt("JingZuanAddAffirmYesAlways", 0) == 0)
        {
            Fade.NewFade("Canvas/JiaoYi/Affirm", 0, 1, 0.3F);
        }
        else
        {
            Unity_Js.UnityToJs("PlayAd", "JingZuanAdd");
        }
    }

    public void AffirmYesAddJingZuan()
    {
        Unity_Js.UnityToJs("PlayAd", "JingZuanAdd");
        Fade.NewFade("Canvas/JiaoYi/Affirm", 1, 0, 0.3F);
    }

    public void AffirmNoAddJingZuan()
    {
        Fade.NewFade("Canvas/JiaoYi/Affirm", 1, 0, 0.2F);
    }

    public void AffirmYesAlwaysToggled()
    {
        if (Fade.StringToTransform("Canvas/JiaoYi/Affirm/Toggle").GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("JingZuanAddAffirmYesAlways", 1);
        }
        else
        {
            PlayerPrefs.SetInt("JingZuanAddAffirmYesAlways", 0);
        }
    }

    public void Trade(string ObjectName)
    {
        int ObjectNum = 0;
        int JingShiNeed = 0;
        int JingZuanNeed = 0;

        switch (ObjectName)
        {
            case "晶石":
                ObjectNum = 25 + (int)(0.8F * (ControlCenter.FinishedGuanQia.Count - ControlCenter.JiaoChengGuanQiaNum));
                JingZuanNeed = 1;
                break;
            case "冲子板":
                ObjectNum = 5 + (int)(0.21F * (ControlCenter.FinishedGuanQia.Count - ControlCenter.JiaoChengGuanQiaNum));
                JingZuanNeed = 1;
                break;
            case "抵子板":
                ObjectNum = 6 + (int)(0.24F * (ControlCenter.FinishedGuanQia.Count - ControlCenter.JiaoChengGuanQiaNum));
                JingZuanNeed = 1;
                break;
            case "FS-1碎片":
                ObjectNum = 5;
                JingZuanNeed = 1;
                break;
            case "TU-1碎片":
                ObjectNum = 5;
                JingZuanNeed = 1;
                break;
            case "HZ-1碎片":
                ObjectNum = 5;
                JingZuanNeed = 1;
                break;
            case "BR-1碎片":
                ObjectNum = 5;
                JingZuanNeed = 1;
                break;
            case "FR-1碎片":
                ObjectNum = 5;
                JingZuanNeed = 1;
                break;
            case "通行凭证":
                ObjectNum = 3;
                JingZuanNeed = 1;
                break;
            case "硅-30":
                ObjectNum = 2;
                JingZuanNeed = 1;
                break;
            case "构架铁":
                ObjectNum = 2;
                JingZuanNeed = 1;
                break;
        }

        if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("晶钻", JingZuanNeed))
        {
            ObjectSystem.AddThings(ObjectName, ObjectNum);
            ObjectSystem.DeleteThings("晶石", JingShiNeed);
            ObjectSystem.DeleteThings("晶钻", JingZuanNeed);
        }
        else if (!ObjectSystem.HasObject("晶石", JingShiNeed))
        {
            ObjectSystem.ShowObjectNeed("晶石", JingShiNeed);
        }
        else
        {
            ObjectSystem.ShowObjectNeed("晶钻", JingZuanNeed);
        }
    }
}