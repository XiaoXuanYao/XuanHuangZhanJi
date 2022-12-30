using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlaneUIClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static string OnChosenPlane = "FS_1";
    bool OnNeedShow = false;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {

        if (Fade.TransformToString(this.transform.parent) == "Canvas/Planes/ChoosePlane/Planes")
        {
            OnChosenPlane = this.transform.name;
            for (int i = 0; i < Fade.StringToTransform("Canvas/Planes/PlaneImage").childCount; i++)
            {
                Fade.StringToTransform("Canvas/Planes/PlaneImage").GetChild(i).gameObject.SetActive(false);
            }
            Fade.StringToTransform("Canvas/Planes/PlaneImage/" + OnChosenPlane).gameObject.SetActive(true);
            if (PlanesMessage.HasPlane(OnChosenPlane))
            {
                ChangeMessageShow();
                Fade.StringToTransform("Canvas/Planes/Main").gameObject.SetActive(true);
                Fade.StringToTransform("Canvas/Planes/HeCheng").gameObject.SetActive(false);
            }
            else
            {
                Fade.StringToTransform("Canvas/Planes/Main").gameObject.SetActive(false);
                Fade.StringToTransform("Canvas/Planes/HeCheng").gameObject.SetActive(true);
                string ObjectName = OnChosenPlane.Replace("_", "-") + "碎片";
                int ObjectNeed = 20;
                switch (OnChosenPlane)
                {
                    case "FS_1":
                        ObjectNeed = 20;
                        break;
                    case "TU_1":
                        ObjectNeed = 30;
                        break;
                    case "HZ_1":
                        ObjectNeed = 30;
                        break;
                    case "BR_1":
                        ObjectNeed = 20;
                        break;
                    case "FR_1":
                        ObjectNeed = 45;
                        break;
                }
                Fade.StringToTransform("Canvas/Planes/HeCheng/Need").GetComponent<TextMeshProUGUI>().text
                    = "合成需要 [" + ObjectName + "]  * 100      <color=#999>"
                    + "( " + ObjectSystem.GetThingNum(ObjectName) + " / " + ObjectNeed + " )</color>";
            }
            Fade.StringToTransform("Canvas/Planes/QiangHua").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/Planes/WuQiSetting").gameObject.SetActive(false);
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/Main/Help")
        {
            if (!Fade.StringToTransform("Canvas/Planes/HelpContent").gameObject.activeSelf)
            {
                Fade.StringToTransform("Canvas/Planes/HelpContent").gameObject.SetActive(true);
            }
            else
            {
                Fade.StringToTransform("Canvas/Planes/HelpContent").gameObject.SetActive(false);
            }
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/Main/QiangHuaButton")
        {
            Fade.StringToTransform("Canvas/Planes/QiangHua").gameObject.SetActive(true);
            ChangeMessageShow();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/CloseButton")
        {
            Fade.StringToTransform("Canvas/Planes/QiangHua").gameObject.SetActive(false);
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/GongJiQiangHuaButton")
        {
            int i = PlanesMessage.GetPlaneDataNumByName(OnChosenPlane);
            int QiangHuaCiShu = PlanesMessage.Planes[i].QiangHuaNum;
            switch (OnChosenPlane)
            {
                case "FS_1":
                    int JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.5F);
                    int ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("冲子板", ChongZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].GongJiAddNum += 1 + (int)((float)QiangHuaCiShu / 12);
                        PlanesMessage.Planes[i].GongJiAddPercent += 0.006F;
                        PlanesMessage.Planes[i].MaxShengMing += 2;
                        PlanesMessage.Planes[i].MaxNengLiang += 5;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("冲子板", ChongZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 25)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;

                case "TU_1":
                    JingShiNeed = 2 + (int)(0.5F + Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.7F);
                    ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.8F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("冲子板", ChongZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].GongJiAddNum += 1 + (int)((float)QiangHuaCiShu / 15);
                        PlanesMessage.Planes[i].GongJiAddPercent += 0.005F;
                        PlanesMessage.Planes[i].MaxShengMing += 3;
                        PlanesMessage.Planes[i].MaxNengLiang += 6;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("冲子板", ChongZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 30)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "HZ_1":
                    JingShiNeed = 3 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.7F);
                    ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.4F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("冲子板", ChongZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].GongJiAddNum += 1 + (int)((float)QiangHuaCiShu / 9);
                        PlanesMessage.Planes[i].GongJiAddPercent += 0.007F;
                        PlanesMessage.Planes[i].MaxShengMing += 0;
                        PlanesMessage.Planes[i].MaxNengLiang += 6;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("冲子板", ChongZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 30)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "BR_1":
                    JingShiNeed = 1 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.7F);
                    ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("冲子板", ChongZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].GongJiAddNum += 1 + (int)((float)QiangHuaCiShu / 15);
                        PlanesMessage.Planes[i].GongJiAddPercent += 0.005F;
                        PlanesMessage.Planes[i].MaxShengMing += 3;
                        PlanesMessage.Planes[i].MaxNengLiang += 6;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("冲子板", ChongZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 25)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "FR_1":
                    JingShiNeed = 3 + (int)(0.5F + Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.7F);
                    ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.2F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("冲子板", ChongZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].GongJiAddNum += 1 + (int)(0.5F + (float)QiangHuaCiShu / 9);
                        PlanesMessage.Planes[i].GongJiAddPercent += 0.009F;
                        PlanesMessage.Planes[i].MaxShengMing += 1;
                        PlanesMessage.Planes[i].MaxNengLiang += 7;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("冲子板", ChongZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 30)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
            }
            ChangeMessageShow();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/ShengMingQiangHuaButton")
        {
            int i = PlanesMessage.GetPlaneDataNumByName(OnChosenPlane);
            int QiangHuaCiShu = PlanesMessage.Planes[i].QiangHuaNum;
            switch (OnChosenPlane)
            {
                case "FS_1":
                    int JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.5F);
                    int DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("抵子板", DiZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].GongJiAddNum += 1;
                        PlanesMessage.Planes[i].MaxShengMing += 5 + (int)((float)QiangHuaCiShu / 2.1F);
                        PlanesMessage.Planes[i].MaxNengLiang += 6;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("抵子板", DiZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 25)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "TU_1":
                    JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.35F);
                    DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 4.5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("抵子板", DiZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].MaxShengMing += 8 + (int)((float)QiangHuaCiShu / 1.2F);
                        PlanesMessage.Planes[i].MaxNengLiang += 8;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("抵子板", DiZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 35)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "HZ_1":
                    JingShiNeed = 2 + (int)(0.5F + Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.35F);
                    DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("抵子板", DiZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].MaxShengMing += 9 + (int)((float)QiangHuaCiShu / 1.1F);
                        PlanesMessage.Planes[i].MaxNengLiang += 9;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("抵子板", DiZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 30)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "BR_1":
                    JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.35F);
                    DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 4.5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("抵子板", DiZiBanNeed) && QiangHuaCiShu < 25)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].MaxShengMing += 8 + (int)((float)QiangHuaCiShu / 1.2F);
                        PlanesMessage.Planes[i].MaxNengLiang += 10;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("抵子板", DiZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 25)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
                case "FR_1":
                    JingShiNeed = 1 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.35F);
                    DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 4.6F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("抵子板", DiZiBanNeed) && QiangHuaCiShu < 45)
                    {
                        PlanesMessage.Planes[i].QiangHuaNum += 1;
                        PlanesMessage.Planes[i].MaxShengMing += 6 + (int)((float)QiangHuaCiShu / 1.2F);
                        PlanesMessage.Planes[i].MaxNengLiang += 10;
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("抵子板", DiZiBanNeed);
                    }
                    else if (QiangHuaCiShu >= 45)
                    {
                        ShowMessage.Message("强化次数已达上限");
                    }
                    else
                    {
                        ShowMessage.Message("强化材料不足");
                    }
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
                    break;
            }
            ChangeMessageShow();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/Main/WuQiButton")
        {
            Fade.StringToTransform("Canvas/Planes/WuQiSetting").gameObject.SetActive(true);
            List<WuQiData> W = PlanesMessage.GetPlaneDataByName(OnChosenPlane).WuQi;
            PlaneWuQiSetting.OnChosenWuQi = W[0].WuQiName;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQiName").GetComponent<TextMeshProUGUI>()
                .text = PlaneWuQiSetting.OnChosenWuQi;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting").GetComponent<PlaneWuQiSetting>().DoStart();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/WuQiSetting/CloseButton")
        {
            Fade.StringToTransform("Canvas/Planes/WuQiSetting").gameObject.SetActive(false);
            PlaneWuQiSetting.FinishSetting();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/WuQiSetting/FinishButton")
        {
            PlaneWuQiSetting.FinishSetting();
            ShowMessage.Message("武器设置已保存");
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/WuQiSetting/LastWuQiButton")
        {
            List<WuQiData> W = PlanesMessage.GetPlaneDataByName(OnChosenPlane).WuQi;
            int thisWuQiNum = PlanesMessage.GetWuQiDataNumByName(OnChosenPlane, PlaneWuQiSetting.OnChosenWuQi);
            if (thisWuQiNum > 0)
            {
                PlaneWuQiSetting.FinishSetting();
                PlaneWuQiSetting.OnChosenWuQi = W[thisWuQiNum - 1].WuQiName;
                Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQiName").GetComponent<TextMeshProUGUI>()
                    .text = PlaneWuQiSetting.OnChosenWuQi;
                Fade.StringToTransform("Canvas/Planes/WuQiSetting").GetComponent<PlaneWuQiSetting>().DoStart();
            }
            else
            {
                ShowMessage.Message("已是第一项武器了");
            }
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/WuQiSetting/NextWuQiButton")
        {
            List<WuQiData> W = PlanesMessage.GetPlaneDataByName(OnChosenPlane).WuQi;
            int thisWuQiNum = PlanesMessage.GetWuQiDataNumByName(OnChosenPlane, PlaneWuQiSetting.OnChosenWuQi);
            if (thisWuQiNum < W.Count - 1)
            {
                PlaneWuQiSetting.FinishSetting();
                PlaneWuQiSetting.OnChosenWuQi = W[thisWuQiNum + 1].WuQiName;
                Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQiName").GetComponent<TextMeshProUGUI>()
                    .text = PlaneWuQiSetting.OnChosenWuQi;
                Fade.StringToTransform("Canvas/Planes/WuQiSetting").GetComponent<PlaneWuQiSetting>().DoStart();
            }
            else
            {
                ShowMessage.Message("已是最后一项武器了");
            }
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/Main/ChongZhuButton")
        {
            Fade.StringToTransform("Canvas/Planes/ChongZhu").gameObject.SetActive(true);
            switch (OnChosenPlane)
            {
                case "FS_1":
                    #region 刷新材料需求
                    int JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.35F) + 5;
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = "2";
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Image").GetComponent<Image>().sprite
                        = Resources.LoadAll(ObjectSystem.GetObjectPng("FS-1碎片").PngName,
                        typeof(Sprite))[ObjectSystem.GetObjectPng("FS-1碎片").Value] as Sprite;
                    if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    if (!ObjectSystem.HasObject("FS-1碎片", 2))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    #endregion
                    #region 刷新材料返还
                    int BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/JingShi/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/ChongZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 8)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/DiZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 6)).ToString();
                    #endregion
                    break;

                case "TU_1":
                    #region 刷新材料需求
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.45F) + 8;
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = "3";
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Image").GetComponent<Image>().sprite
                        = Resources.LoadAll(ObjectSystem.GetObjectPng("TU-1碎片").PngName,
                        typeof(Sprite))[ObjectSystem.GetObjectPng("TU-1碎片").Value] as Sprite;
                    if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    if (!ObjectSystem.HasObject("TU-1碎片", 3))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    #endregion
                    #region 刷新材料返还
                    BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/JingShi/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/ChongZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 6)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/DiZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 8)).ToString();
                    #endregion
                    break;

                case "HZ_1":
                    #region 刷新材料需求
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.45F) + 8;
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = "3";
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Image").GetComponent<Image>().sprite
                        = Resources.LoadAll(ObjectSystem.GetObjectPng("HZ-1碎片").PngName,
                        typeof(Sprite))[ObjectSystem.GetObjectPng("HZ-1碎片").Value] as Sprite;
                    if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    if (!ObjectSystem.HasObject("HZ-1碎片", 3))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    #endregion
                    #region 刷新材料返还
                    BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/JingShi/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/ChongZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 6)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/DiZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 8)).ToString();
                    #endregion
                    break;

                case "BR_1":
                    #region 刷新材料需求
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.35F) + 6;
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = "3";
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Image").GetComponent<Image>().sprite
                        = Resources.LoadAll(ObjectSystem.GetObjectPng("BR-1碎片").PngName,
                        typeof(Sprite))[ObjectSystem.GetObjectPng("BR-1碎片").Value] as Sprite;
                    if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    if (!ObjectSystem.HasObject("BR-1碎片", 3))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    #endregion
                    #region 刷新材料返还
                    BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/JingShi/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/ChongZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 6)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/DiZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 8)).ToString();
                    #endregion
                    break;

                case "FR_1":
                    #region 刷新材料需求
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.2F) * 0.5F) + 12;
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = "3";
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Image").GetComponent<Image>().sprite
                        = Resources.LoadAll(ObjectSystem.GetObjectPng("FR-1碎片").PngName,
                        typeof(Sprite))[ObjectSystem.GetObjectPng("FR-1碎片").Value] as Sprite;
                    if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/JingShi/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    if (!ObjectSystem.HasObject("FR-1碎片", 3))
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                    }
                    else
                    {
                        Fade.StringToTransform("Canvas/Planes/ChongZhu/Need/SuiPian/Number")
                            .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                    }
                    #endregion
                    #region 刷新材料返还
                    BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 1.6F);
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/JingShi/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/ChongZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 4)).ToString();
                    Fade.StringToTransform("Canvas/Planes/ChongZhu/Return/DiZiBan/Number").GetComponent<TextMeshProUGUI>()
                        .text = ((int)((float)BasicNum * (BasicNum - 1) / 4)).ToString();
                    #endregion
                    break;
            }
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/ChongZhu/ChongZhuButton")
        {
            switch (OnChosenPlane)
            {
                case "FS_1":
                    int JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.35F) + 5;
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("FS-1碎片", 2))
                    {
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("FS-1碎片", 2);

                        int BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                        ObjectSystem.AddThings("晶石", (int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2));
                        ObjectSystem.AddThings("冲子板", (int)((float)BasicNum * (BasicNum - 1) / 8));
                        ObjectSystem.AddThings("抵子板", (int)((float)BasicNum * (BasicNum - 1) / 6));

                        PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)] = new PlaneData()
                        {
                            Name = "普战-1",
                            ShortName = "FS_1",
                            MaxShengMing = 100 + (int)((Random.value - 0.6F) * 50),
                            GongJiAddNum = 0 + (int)(Random.value * 7),
                            GongJiAddPercent = 0 + (float)(int)(Random.value * 3 * 10) / 1000,
                            MoveSpeed = 5,
                            MaxNengLiang = 200 + (int)((Random.value - 0.6F) * 50),
                            QiangHuaNum = 0,
                            WuQi = new List<WuQiData>()
                            {
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[双联ATS0发射炮]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/FS_ATS0"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 4.5F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0,
                                    BulletNum = 1,
                                    BulletDuringTime = 0,
                                    FanRadius = 0,
                                    NengLiangNeed = 120
                                },
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[循环高压气体流护盾]</color>",
                                    Kind = WuQiKind.HuDun,
                                    Bullet = Fade.StringToTransform("ObjectModels/HuDun"),
                                    HuDunHuiFuSuLv = 1,
                                    HuDunMax = 50,
                                    HuDunXiuFuShiJian = 30,
                                    NengLiangNeed = 50
                                }
                            }
                        };
                        PlanesMessage.SavePlanesData();
                        PlaneUIClick.ChangeMessageShow();
                        PlaneWuQiSetting.FinishSetting(false);
                        ShowMessage.Message("重铸完成");
                    }
                    else
                    {
                        ShowMessage.Message("重铸所需材料不足");
                    }
                    break;

                case "TU_1":
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.45F) + 8;
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("TU-1碎片", 3))
                    {
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("TU-1碎片", 3);

                        int BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                        ObjectSystem.AddThings("晶石", (int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2));
                        ObjectSystem.AddThings("冲子板", (int)((float)BasicNum * (BasicNum - 1) / 6));
                        ObjectSystem.AddThings("抵子板", (int)((float)BasicNum * (BasicNum - 1) / 8));

                        PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)] = new PlaneData()
                        {
                            Name = "灵龟-1",
                            ShortName = "TU_1",
                            MaxShengMing = 200 + (int)(Random.value * 80 - 30),
                            GongJiAddNum = Mathf.Max(0 + (int)(Random.value * 10 - 4), 0),
                            GongJiAddPercent = (int)(Random.value * 20) * 0.001F,
                            MoveSpeed = 3,
                            MaxNengLiang = 400 + (int)(Random.value * 80 - 30),
                            QiangHuaNum = 0,
                            WuQi = new List<WuQiData>()
                            {
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[双联ATS0发射炮]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/FS_ATS0"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 4.5F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0,
                                    BulletNum = 1,
                                    BulletDuringTime = 0,
                                    FanRadius = 0,
                                    NengLiangNeed = 120
                                },
                                new WuQiData
                                {
                                    WuQiName = "<color=#5a6>[单发三弹ATS0霰弹炮]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/FS_ATS0"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 4.2F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0.03F + (int)(Random.value * 0.03F - 0.015F * 1000) * 0.001F,
                                    BulletNum = 3,
                                    BulletDuringTime = 0.07F - Random.value * 0.02F,
                                    FanRadius = 0,
                                    NengLiangNeed = 240
                                }
                            }
                        };
                        PlanesMessage.SavePlanesData();
                        PlaneUIClick.ChangeMessageShow();
                        PlaneWuQiSetting.FinishSetting(false);
                        ShowMessage.Message("重铸完成");
                    }
                    else
                    {
                        ShowMessage.Message("重铸所需材料不足");
                    }
                    break;

                case "HZ_1":
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.45F) + 8;
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("HZ-1碎片", 3))
                    {
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("HZ-1碎片", 3);

                        int BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                        ObjectSystem.AddThings("晶石", (int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2));
                        ObjectSystem.AddThings("冲子板", (int)((float)BasicNum * (BasicNum - 1) / 6));
                        ObjectSystem.AddThings("抵子板", (int)((float)BasicNum * (BasicNum - 1) / 8));

                        PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)] = new PlaneData
                        {
                            Name = "银叶-1",
                            ShortName = "HZ_1",
                            MaxShengMing = 150 + (int)(Random.value * 60 - 20),
                            GongJiAddNum = Mathf.Max(3 + (int)(Random.value * 10 - 4), 0),
                            GongJiAddPercent = 0.02F + (int)(Random.value * 36) * 0.001F,
                            MoveSpeed = 5,
                            MaxNengLiang = 240 + (int)(Random.value * 60 - 30),
                            QiangHuaNum = 0,
                            WuQi = new List<WuQiData>()
                            {
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[双发Z0追踪发射炮]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/FS_Z0"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 4.5F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0,
                                    BulletNum = 2,
                                    BulletDuringTime = 0.15F,
                                    FanRadius = 0,
                                    NengLiangNeed = 120
                                },
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[重组晶体护盾]</color>",
                                    Kind = WuQiKind.HuDun,
                                    Bullet = Fade.StringToTransform("ObjectModels/HuDun"),
                                    HuDunHuiFuSuLv = 1,
                                    HuDunMax = 75,
                                    HuDunXiuFuShiJian = 40,
                                    NengLiangNeed = 75
                                }
                            }
                        };
                        PlanesMessage.SavePlanesData();
                        PlaneUIClick.ChangeMessageShow();
                        PlaneWuQiSetting.FinishSetting(false);
                        ShowMessage.Message("重铸完成");
                    }
                    else
                    {
                        ShowMessage.Message("重铸所需材料不足");
                    }
                    break;

                case "BR_1":
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.15F) * 0.35F) + 6;
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("BR-1碎片", 3))
                    {
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("BR-1碎片", 3);

                        int BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 2F);
                        ObjectSystem.AddThings("晶石", (int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2));
                        ObjectSystem.AddThings("冲子板", (int)((float)BasicNum * (BasicNum - 1) / 6));
                        ObjectSystem.AddThings("抵子板", (int)((float)BasicNum * (BasicNum - 1) / 8));

                        PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)] = new PlaneData
                        {
                            Name = "飞鸟-1",
                            ShortName = "HZ_1",
                            MaxShengMing = 175 + (int)(Random.value * 60 - 20),
                            GongJiAddNum = Mathf.Max((int)(Random.value * 6 - 2), 0),
                            GongJiAddPercent = (int)(Random.value * 20) * 0.001F,
                            MoveSpeed = 5,
                            MaxNengLiang = 240,
                            QiangHuaNum = 0,
                            WuQi = new List<WuQiData>()
                            {
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[双发ATS0发射炮]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/FS_ATS0"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 4.5F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0,
                                    BulletNum = 2,
                                    BulletDuringTime = 0.1F,
                                    FanRadius = 0,
                                    NengLiangNeed = 120
                                },
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[循环高压气体流护盾]</color>",
                                    Kind = WuQiKind.HuDun,
                                    Bullet = Fade.StringToTransform("ObjectModels/HuDun"),
                                    HuDunHuiFuSuLv = 1,
                                    HuDunMax = 75,
                                    HuDunXiuFuShiJian = 40,
                                    NengLiangNeed = 75
                                }
                            }
                        };
                        PlanesMessage.SavePlanesData();
                        PlaneUIClick.ChangeMessageShow();
                        PlaneWuQiSetting.FinishSetting(false);
                        ShowMessage.Message("重铸完成");
                    }
                    else
                    {
                        ShowMessage.Message("重铸所需材料不足");
                    }
                    break;

                case "FR_1":
                    JingShiNeed = (int)(Mathf.Pow(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)]
                        .QiangHuaNum, 1.2F) * 0.5F) + 12;
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("BR-1碎片", 4))
                    {
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("BR-1碎片", 3);

                        int BasicNum = (int)(PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].QiangHuaNum / 1.6F);
                        ObjectSystem.AddThings("晶石", (int)(Mathf.Pow((float)(BasicNum + 1) / 2, 1.5F) / 1.5F * BasicNum / 2));
                        ObjectSystem.AddThings("冲子板", (int)((float)BasicNum * (BasicNum - 1) / 4));
                        ObjectSystem.AddThings("抵子板", (int)((float)BasicNum * (BasicNum - 1) / 4));

                        PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)] = new PlaneData
                        {
                            Name = "焰火-1",
                            ShortName = "FR_1",
                            MaxShengMing = 175 + (int)(Random.value * 60 - 20),
                            GongJiAddNum = 2 + Mathf.Max((int)(Random.value * 6 - 2), 0),
                            GongJiAddPercent = 0.02F + (int)(Random.value * 36) * 0.001F,
                            MoveSpeed = 5,
                            MaxNengLiang = 240 + (int)(Random.value * 60 - 20),
                            QiangHuaNum = 0,
                            WuQi = new List<WuQiData>()
                            {
                                new WuQiData
                                {
                                    WuQiName = "<color=#999>[单发FR0火元素集阵]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/MA_FR0"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 4F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0,
                                    BulletNum = 1,
                                    BulletDuringTime = 0.1F,
                                    FanRadius = 0,
                                    NengLiangNeed = 120
                                },
                                new WuQiData
                                {
                                    WuQiName = "<color=#49c>[单发FR1火元素集阵]</color>",
                                    Kind = WuQiKind.WuQi,
                                    Bullet = Fade.StringToTransform("ObjectModels/MA_FR1"),
                                    GongJiAdd = 0,
                                    PerIntervalTime = 1,
                                    BulletVelocity = 3.2F,
                                    BasicRoadRotation = 0,
                                    AngleOffset = 0,
                                    BulletNum = 1,
                                    BulletDuringTime = 0.1F,
                                    FanRadius = 0,
                                    NengLiangNeed = 120
                                }
                            }
                        };
                        PlanesMessage.SavePlanesData();
                        PlaneUIClick.ChangeMessageShow();
                        PlaneWuQiSetting.FinishSetting(false);
                        ShowMessage.Message("重铸完成");
                    }
                    else
                    {
                        ShowMessage.Message("重铸所需材料不足");
                    }
                    break;
            }
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/ChongZhu/CloseButton")
        {
            Fade.StringToTransform("Canvas/Planes/ChongZhu").gameObject.SetActive(false);
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/Main/GaiJinButton")
        {
            Fade.StringToTransform("Canvas/Planes/GaiJin").gameObject.SetActive(true);
            CheckGaiJinNeed();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/GaiJin/GaiJinButton")
        {
            int i = PlanesMessage.GetPlaneDataNumByName(OnChosenPlane);
            switch (OnChosenPlane)
            {
                case "FS_1":
                    int GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                    int JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.4F) +GaiJinNum * 0.9F + 3);
                    int SuiPianNeed = (int)((float)GaiJinNum / 5);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("FS-1碎片", SuiPianNeed))
                    {
                        PlanesMessage.Planes[i].GaiJinNum += 1;
                        if (Random.value < 0.5F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 2;
                        }
                        else if (Random.value < 0.75F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 4;
                        }
                        if (Random.value < 0.33F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 3;
                        }
                        if (Random.value < 0.33F)
                        {
                            PlanesMessage.Planes[i].GongJiAddNum += 2;
                        }
                        if (Random.value < 0.125F)
                        {
                            PlanesMessage.Planes[i].GongJiAddPercent += 0.003F;
                        }
                        ShowMessage.Message("改进成功");
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("FS-1碎片", SuiPianNeed);
                    }
                    else
                    {
                        ShowMessage.Message("改进材料不足");
                    }
                    break;
                case "TU_1":
                    GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                    JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                    SuiPianNeed = (int)((float)GaiJinNum / 4.5F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("TU-1碎片", SuiPianNeed))
                    {
                        PlanesMessage.Planes[i].GaiJinNum += 1;
                        if (Random.value < 0.4F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 3;
                        }
                        else if (Random.value < 0.65F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 8;
                        }
                        if (Random.value < 0.33F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 5;
                        }
                        if (Random.value < 0.33F)
                        {
                            PlanesMessage.Planes[i].GongJiAddNum += 1;
                        }
                        if (Random.value < 0.25F)
                        {
                            PlanesMessage.Planes[i].GongJiAddPercent += 0.002F;
                        }
                        ShowMessage.Message("改进成功");
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("TU-1碎片", SuiPianNeed);
                    }
                    else
                    {
                        ShowMessage.Message("改进材料不足");
                    }
                    break;
                case "HZ_1":
                    GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                    JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                    SuiPianNeed = (int)(GaiJinNum / 4F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("HZ-1碎片", SuiPianNeed))
                    {
                        PlanesMessage.Planes[i].GaiJinNum += 1;
                        if (Random.value < 0.3F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 3;
                        }
                        else if (Random.value < 0.5F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 8;
                        }
                        if (Random.value < 0.4F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 5;
                        }
                        else if (Random.value < 0.6F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 8;
                        }
                        if (Random.value < 0.4F)
                        {
                            PlanesMessage.Planes[i].GongJiAddNum += 1;
                        }
                        if (Random.value < 0.25F)
                        {
                            PlanesMessage.Planes[i].GongJiAddPercent += 0.002F;
                        }
                        ShowMessage.Message("改进成功");
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("HZ-1碎片", SuiPianNeed);
                    }
                    else
                    {
                        ShowMessage.Message("改进材料不足");
                    }
                    break;
                case "BR_1":
                    GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                    JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                    SuiPianNeed = (int)(GaiJinNum / 4F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("BR-1碎片", SuiPianNeed))
                    {
                        PlanesMessage.Planes[i].GaiJinNum += 1;
                        if (Random.value < 0.32)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 2;
                        }
                        else if (Random.value < 0.4F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 6;
                        }
                        if (Random.value < 0.5F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 5;
                        }
                        if (Random.value < 0.3F)
                        {
                            PlanesMessage.Planes[i].GongJiAddNum += 1;
                        }
                        ShowMessage.Message("改进成功");
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("BR-1碎片", SuiPianNeed);
                    }
                    else
                    {
                        ShowMessage.Message("改进材料不足");
                    }
                    break;
                case "FR_1":
                    GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                    JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                    SuiPianNeed = (int)(GaiJinNum / 4F);
                    if (ObjectSystem.HasObject("晶石", JingShiNeed) && ObjectSystem.HasObject("FR-1碎片", SuiPianNeed))
                    {
                        PlanesMessage.Planes[i].GaiJinNum += 1;
                        if (Random.value < 0.3F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 3;
                        }
                        else if (Random.value < 0.5F)
                        {
                            PlanesMessage.Planes[i].MaxShengMing += 8;
                        }
                        if (Random.value < 0.4F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 6;
                        }
                        else if (Random.value < 0.6F)
                        {
                            PlanesMessage.Planes[i].MaxNengLiang += 10;
                        }
                        if (Random.value < 0.45F)
                        {
                            PlanesMessage.Planes[i].GongJiAddNum += 1;
                        }
                        if (Random.value < 0.3F)
                        {
                            PlanesMessage.Planes[i].GongJiAddPercent += 0.002F;
                        }
                        ShowMessage.Message("改进成功");
                        PlanesMessage.SavePlanesData();
                        ObjectSystem.DeleteThings("晶石", JingShiNeed);
                        ObjectSystem.DeleteThings("FR-1碎片", SuiPianNeed);
                    }
                    else
                    {
                        ShowMessage.Message("改进材料不足");
                    }
                    break;
            }
            CheckGaiJinNeed();
            ChangeMessageShow();
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/GaiJin/CloseButton")
        {
            Fade.StringToTransform("Canvas/Planes/GaiJin").gameObject.SetActive(false);
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/HeCheng/HeChengButton")
        {
            switch (OnChosenPlane)
            {
                case "TU_1":
                    if (ObjectSystem.HasObject("TU-1碎片", 30))
                    {
                        PlanesMessage.GetNewPlaneAdd("TU_1");
                        ChangeMessageShow();
                        Fade.StringToTransform("Canvas/Planes/Main").gameObject.SetActive(true);
                        Fade.StringToTransform("Canvas/Planes/HeCheng").gameObject.SetActive(false);
                        ObjectSystem.DeleteThings("TU-1碎片", 30);
                    }
                    else
                    {
                        ShowMessage.Message("碎片不足，无法合成");
                    }
                    break;
                case "HZ_1":
                    if (ObjectSystem.HasObject("HZ-1碎片", 30))
                    {
                        PlanesMessage.GetNewPlaneAdd("HZ_1");
                        ChangeMessageShow();
                        Fade.StringToTransform("Canvas/Planes/Main").gameObject.SetActive(true);
                        Fade.StringToTransform("Canvas/Planes/HeCheng").gameObject.SetActive(false);
                        ObjectSystem.DeleteThings("HZ-1碎片", 30);
                    }
                    else
                    {
                        ShowMessage.Message("碎片不足，无法合成");
                    }
                    break;
                case "BR_1":
                    if (ObjectSystem.HasObject("BR-1碎片", 20))
                    {
                        PlanesMessage.GetNewPlaneAdd("BR_1");
                        ChangeMessageShow();
                        Fade.StringToTransform("Canvas/Planes/Main").gameObject.SetActive(true);
                        Fade.StringToTransform("Canvas/Planes/HeCheng").gameObject.SetActive(false);
                        ObjectSystem.DeleteThings("BR-1碎片", 20);
                    }
                    else
                    {
                        ShowMessage.Message("碎片不足，无法合成");
                    }
                    break;
                case "FR_1":
                    if (ObjectSystem.HasObject("FR-1碎片", 45))
                    {
                        PlanesMessage.GetNewPlaneAdd("FR_1");
                        ChangeMessageShow();
                        Fade.StringToTransform("Canvas/Planes/Main").gameObject.SetActive(true);
                        Fade.StringToTransform("Canvas/Planes/HeCheng").gameObject.SetActive(false);
                        ObjectSystem.DeleteThings("FR-1碎片", 45);
                    }
                    else
                    {
                        ShowMessage.Message("碎片不足，无法合成");
                    }
                    break;
            }
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/Main/ChuZhanButton")
        {
            PlanesMessage.ChangePlaneChuZhan(OnChosenPlane);
            ShowMessage.Message(OnChosenPlane + " 已被设置为出战");
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/GongJiQiangHuaButton")
        {
            int i = PlanesMessage.GetPlaneDataNumByName(OnChosenPlane);
            int QiangHuaCiShu = PlanesMessage.Planes[i].QiangHuaNum;
            switch (OnChosenPlane)
            {
                case "FS_1":
                    int JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.5F);
                    int ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.5F);
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed/Text").GetComponent<TextMeshProUGUI>().text
                        = "强化需要\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("晶石"))
                        + ">晶石</color> x "
                        + JingShiNeed + "\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("冲子板"))
                        + ">冲子板</color> x "
                        + ChongZiBanNeed;
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(true);
                    OnNeedShow = true;
                    break;
                case "TU_1":
                    JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.7F);
                    ChongZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 3.8F);
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed/Text").GetComponent<TextMeshProUGUI>().text
                        = "强化需要\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("晶石"))
                        + ">晶石</color> x "
                        + JingShiNeed + "\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("冲子板"))
                        + ">冲子板</color> x "
                        + ChongZiBanNeed;
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(true);
                    OnNeedShow = true;
                    break;
            }
            StartCoroutine(SetQiangHuaNeedPosition());
        }

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/ShengMingQiangHuaButton")
        {
            int i = PlanesMessage.GetPlaneDataNumByName(OnChosenPlane);
            int QiangHuaCiShu = PlanesMessage.Planes[i].QiangHuaNum;
            switch (OnChosenPlane)
            {
                case "FS_1":
                    int JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.5F);
                    int DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 5F);
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed/Text").GetComponent<TextMeshProUGUI>().text
                        = "强化需要\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("晶石"))
                        + ">晶石</color> x "
                        + JingShiNeed + "\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("抵子板"))
                        + ">抵子板</color> x "
                        + DiZiBanNeed;
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(true);
                    OnNeedShow = true;
                    break;
                case "TU_1":
                    JingShiNeed = 2 + (int)(Mathf.Pow((float)(QiangHuaCiShu + 1) / 2, 1.5F) / 1.35F);
                    DiZiBanNeed = 1 + (int)((float)QiangHuaCiShu / 4.5F);
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed/Text").GetComponent<TextMeshProUGUI>().text
                        = "强化需要\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("晶石"))
                        + ">晶石</color> x "
                        + JingShiNeed + "\n<color=#" + ChangeColorAndHex.Exchange.ColorToHex(ObjectSystem.GetObjectColor("抵子板"))
                        + ">抵子板</color> x "
                        + DiZiBanNeed;
                    Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(true);
                    OnNeedShow = true;
                    break;
            }
            StartCoroutine(SetQiangHuaNeedPosition());
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/GongJiQiangHuaButton" ||
            Fade.TransformToString(this.transform) == "Canvas/Planes/QiangHua/ShengMingQiangHuaButton")
        {
            Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").gameObject.SetActive(false);
            OnNeedShow = false;
        }
    }

    IEnumerator SetQiangHuaNeedPosition()
    {
        while(OnNeedShow)
        {
            yield return new WaitForFixedUpdate();
            Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaNeed").GetComponent<RectTransform>().position
                = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector2(-0.5F, -0.5F);
        }
    }

    public static void ChangeMessageShow()
    {
        for (int i = 0; i < PlanesMessage.Planes.Count; i++)
        {
            string Name = PlanesMessage.Planes[i].ShortName;
            Fade.StringToTransform("Canvas/Planes/ChoosePlane/Planes/" + Name).GetComponent<CanvasGroup>().alpha = 1;
        }
        Fade.StringToTransform("Canvas/Planes/QiangHua/Images/ChongZiBan/Number").GetComponent<TextMeshProUGUI>().text
            = ObjectSystem.GetThingNum("冲子板").ToString();
        Fade.StringToTransform("Canvas/Planes/QiangHua/Images/DiZiBan/Number").GetComponent<TextMeshProUGUI>().text
            = ObjectSystem.GetThingNum("抵子板").ToString();
        Fade.StringToTransform("Canvas/Planes/QiangHua/Images/JingShi/Number").GetComponent<TextMeshProUGUI>().text
            = ObjectSystem.GetThingNum("晶石").ToString();
        for (int i = 0; i < Fade.StringToTransform("Canvas/Planes/PlaneImage").childCount; i++)
        {
            Fade.StringToTransform("Canvas/Planes/PlaneImage").GetChild(i).gameObject.SetActive(false);
        }
        Fade.StringToTransform("Canvas/Planes/PlaneImage").transform.Find(OnChosenPlane).gameObject.SetActive(true);
        PlaneData P = PlanesMessage.GetPlaneDataByName(OnChosenPlane);
        if (P != null)
        {
            Transform Parent = Fade.StringToTransform("Canvas/Planes/Main");
            Parent.transform.Find("XingHao").GetComponent<TextMeshProUGUI>().text
                = "型       号：" + P.Name + "<color=#59c>（" + P.ShortName + "）</color>";
            Parent.transform.Find("ShengMing").GetComponent<TextMeshProUGUI>().text
                = "最大生命：" + P.MaxShengMing.ToString();
            Parent.transform.Find("GongJi").GetComponent<TextMeshProUGUI>().text
                = "攻击加成：" + P.GongJiAddNum.ToString() + " + <color=#ca6>" + (float)(int)(P.GongJiAddPercent * 1000) / 10 + "%</color>";
            Parent.transform.Find("YiSu").GetComponent<TextMeshProUGUI>().text
                = "移       速：" + P.MoveSpeed.ToString();
            Parent.transform.Find("NengLiang").GetComponent<TextMeshProUGUI>().text
                = "能       量：" + P.MaxNengLiang.ToString();
            int QiangHuaCiShuMax = 25;
            switch (P.ShortName)
            {
                case "FS_1":
                    QiangHuaCiShuMax = 25;
                    break;
                case "TU_1":
                    QiangHuaCiShuMax = 35;
                    break;
                case "HZ_1":
                    QiangHuaCiShuMax = 30;
                    break;
                case "BR_1":
                    QiangHuaCiShuMax = 25;
                    break;
                case "FR_1":
                    QiangHuaCiShuMax = 45;
                    break;
            }
            Fade.StringToTransform("Canvas/Planes/QiangHua/QiangHuaCiShu").GetComponent<TextMeshProUGUI>().text
                = P.QiangHuaNum + " / " + QiangHuaCiShuMax;
            Fade.StringToTransform("Canvas/Planes/GaiJin/GaiJinCiShu").GetComponent<TextMeshProUGUI>().text
                = "已改进次数：" + P.GaiJinNum;

            string WuQi = ""; int a = 0;
            foreach (WuQiData W in P.WuQi)
            {
                if (a != 0)
                {
                    WuQi += "\n                 ";
                }
                WuQi += W.WuQiName;
                a++;
            }
            Parent.transform.Find("WuQi").GetComponent<TextMeshProUGUI>().text
                = "武       器：" + WuQi;

            ControlCenter.GongJiAddNum = (int)(Mathf.Pow(P.GongJiAddNum, 0.7F) * 2);
            ControlCenter.GongJiAddPercent = P.GongJiAddPercent;
            GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing = new int[] { P.MaxShengMing, P.MaxShengMing };
        }
    }

    public static void CheckGaiJinNeed()
    {
        switch (OnChosenPlane)
        {
            case "FS_1":
                #region 刷新材料需求
                int GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                int JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.4F) + GaiJinNum * 0.9F + 2);
                int SuiPianNeed = (int)((float)GaiJinNum / 5);
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = SuiPianNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Image").GetComponent<Image>().sprite
                    = Resources.LoadAll(ObjectSystem.GetObjectPng("FS-1碎片").PngName,
                    typeof(Sprite))[ObjectSystem.GetObjectPng("FS-1碎片").Value] as Sprite;
                if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                if (!ObjectSystem.HasObject("FS-1碎片", SuiPianNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                #endregion
                break;

            case "TU_1":
                #region 刷新材料需求
                GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                SuiPianNeed = (int)((float)GaiJinNum / 4.5F);
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = SuiPianNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Image").GetComponent<Image>().sprite
                    = Resources.LoadAll(ObjectSystem.GetObjectPng("TU-1碎片").PngName,
                    typeof(Sprite))[ObjectSystem.GetObjectPng("TU-1碎片").Value] as Sprite;
                if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                if (!ObjectSystem.HasObject("TU-1碎片", SuiPianNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                #endregion
                break;

            case "HZ_1":
                #region 刷新材料需求
                GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                SuiPianNeed = (int)((float)GaiJinNum / 4);
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = SuiPianNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Image").GetComponent<Image>().sprite
                    = Resources.LoadAll(ObjectSystem.GetObjectPng("HZ-1碎片").PngName,
                    typeof(Sprite))[ObjectSystem.GetObjectPng("HZ-1碎片").Value] as Sprite;
                if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                if (!ObjectSystem.HasObject("HZ-1碎片", SuiPianNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                #endregion
                break;

            case "BR_1":
                #region 刷新材料需求
                GaiJinNum = PlanesMessage.Planes[PlanesMessage.GetPlaneDataNumByName(OnChosenPlane)].GaiJinNum;
                JingShiNeed = (int)(0.5F * Mathf.Pow(GaiJinNum, 1.42F) + GaiJinNum * 0.95F + 3);
                SuiPianNeed = (int)((float)GaiJinNum / 4);
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number").GetComponent<TextMeshProUGUI>().text = JingShiNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number").GetComponent<TextMeshProUGUI>().text = SuiPianNeed.ToString();
                Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Image").GetComponent<Image>().sprite
                    = Resources.LoadAll(ObjectSystem.GetObjectPng("BR-1碎片").PngName,
                    typeof(Sprite))[ObjectSystem.GetObjectPng("BR-1碎片").Value] as Sprite;
                if (!ObjectSystem.HasObject("晶石", JingShiNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/JingShi/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                if (!ObjectSystem.HasObject("BR-1碎片", SuiPianNeed))
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(0.3F, 0.3F, 0.3F);
                }
                else
                {
                    Fade.StringToTransform("Canvas/Planes/GaiJin/Images/SuiPian/Number")
                        .GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
                #endregion
                break;
        }
    }

    public void ChangeWuQiInputFieldValueToSlider(bool Inverse = false)
    {
        float Value = this.transform.parent.Find("Slider").GetComponent<Slider>().value;
        if (!Inverse)
        {
            float.TryParse(this.GetComponent<TMP_InputField>().text, out Value);
        }
        if (this.transform.parent.name == "GongJiJiaCheng")
        {
            if (Value > 100)
            {
                Value = 100;
            }
            else if (Value < 0)
            {
                Value = 0;
            }
            Value = Mathf.Floor(Value * 10) / 10;
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0.0");
            PlaneWuQiSetting.LastValueChange = "GongJiJiaCheng";
        }
        if (this.transform.parent.name == "GongJiPinLv")
        {
            if (Value > 1.8F)
            {
                Value = 1.8F;
            }
            else if (Value < 0.4F)
            {
                Value = 0.4F;
            }
            Value = Mathf.Floor(Value * 100) / 100;
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0.00");
            PlaneWuQiSetting.LastValueChange = "GongJiPinLv";
        }
        if (this.transform.parent.name == "ZiDanSuDu")
        {
            if (Value > 6.3F)
            {
                Value = 6.3F;
            }
            else if (Value < 3.2F)
            {
                Value = 3.2F;
            }
            Value = Mathf.Floor(Value * 10) / 10;
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0.0");
            PlaneWuQiSetting.LastValueChange = "ZiDanSuDu";
        }
        if (this.transform.parent.name == "ZiDanShuLiang")
        {
            int MinNum = GetWuQiBullectMaxMinNum()[0];
            int MaxNum = GetWuQiBullectMaxMinNum()[1];
            this.transform.parent.Find("Slider").GetComponent<Slider>().maxValue = MaxNum;

            if (Value > MaxNum)
            {
                Value = MaxNum;
            }
            else if (Value < MinNum)
            {
                Value = MinNum;
            }
            Value = Mathf.Floor(Value);
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0");
            PlaneWuQiSetting.LastValueChange = "ZiDanShuLiang";
        }
        if (this.transform.parent.name == "HuDunShangXian")
        {
            switch (PlaneWuQiSetting.OnChosenWuQi)
            {
                case "<color=#999>[循环高压气体流护盾]</color>":
                    this.transform.parent.Find("Slider").GetComponent<Slider>().maxValue
                        = 50F + PlanesMessage.GetPlaneDataByName(OnChosenPlane).MaxShengMing * 0.2F;
                    break;
                case "<color=#999>[重组晶体护盾]</color>":
                    this.transform.parent.Find("Slider").GetComponent<Slider>().maxValue
                        = 75F + PlanesMessage.GetPlaneDataByName(OnChosenPlane).MaxShengMing * 0.32F;
                    break;
            }
            if (Value > 50F + PlanesMessage.GetPlaneDataByName(OnChosenPlane).MaxShengMing * 0.2F)
            {
                Value = 50F + PlanesMessage.GetPlaneDataByName(OnChosenPlane).MaxShengMing * 0.2F;
            }
            else if (Value < 0F)
            {
                Value = 0F;
            }
            Value = Mathf.Floor(Value);
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0");
            PlaneWuQiSetting.LastValueChange = "HuDunShangXian";
        }
        if (this.transform.parent.name == "HuiFuSuLv")
        {
            if (Value > 2.5F)
            {
                Value = 2.5F;
            }
            else if (Value < 0.1F)
            {
                Value = 0.1F;
            }
            Value = Mathf.Floor(Value * 10) / 10;
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0.0");
            PlaneWuQiSetting.LastValueChange = "HuiFuSuLv";
        }
        if (this.transform.parent.name == "XiuFuShiJian")
        {
            if (Value > 75F)
            {
                Value = 75F;
            }
            else if (Value < 12.5F)
            {
                Value = 12.5F;
            }
            Value = Mathf.Floor(Value * 10) / 10;
            this.transform.parent.Find("Value").GetComponent<TMP_InputField>().text = Value.ToString("#0.0");
            PlaneWuQiSetting.LastValueChange = "XiuFuShiJian";
        }
        this.transform.parent.Find("Slider").GetComponent<Slider>().value = Value;
        PlaneWuQiSetting.RecheckWuQiNengLiangUse();
    }

    public static int[] GetWuQiBullectMaxMinNum()
    {
        int MaxNum = 1;
        int MinNum = 1;
        switch (PlaneWuQiSetting.OnChosenWuQi)
        {
            case "<color=#999>[双联ATS0发射炮]</color>":
                MaxNum = 1;
                break;
            case "<color=#5a6>[单发三弹ATS0霰弹炮]</color>":
                MinNum = 3;
                MaxNum = 5;
                break;
            case "<color=#999>[双发Z0追踪发射炮]</color>":
                MinNum = 2;
                MaxNum = 2;
                break;
        }
        Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanShuLiang/Slider").GetComponent<Slider>().maxValue = MaxNum;
        return new int[] { MinNum, MaxNum };
    }
}