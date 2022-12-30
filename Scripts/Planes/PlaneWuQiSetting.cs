using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneWuQiSetting : MonoBehaviour
{
    public static string OnChosenWuQi = "<color=#999>[双联ATS0发射炮]</color>";

    public static float BasicNengLiang = 180;

    public static float GongJiAdd = 0;
    public static float GongJiPinLv = 1;
    public static float BulletSpeed = 4.5F;
    public static float ZiDanNum = 1;
    public static float ZiDanLianFa = 1;

    public static float HuDunMax = 50;
    public static float HuiFuSuLv = 1;
    public static float XiuFuShiJian = 50;

    public static int NengLiang = 80;

    public static string LastValueChange = "";
    public static bool IsNeedCheck = true;

    public void DoStart()
    {
        OnStart();
    }

    void OnStart()
    {
        WuQiData W = PlanesMessage.GetWuQiDataByName(PlaneUIClick.OnChosenPlane, OnChosenWuQi);
        IsNeedCheck = false;

        if (W.Kind == WuQiKind.WuQi)
        {
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi").gameObject.SetActive(true);
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun").gameObject.SetActive(false);

            PlaneUIClick.GetWuQiBullectMaxMinNum();
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiJiaCheng/Slider").GetComponent<Slider>()
                .value = W.GongJiAdd;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiPinLv/Slider").GetComponent<Slider>()
                .value = W.PerIntervalTime;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanSuDu/Slider").GetComponent<Slider>()
                .value = W.BulletVelocity;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanShuLiang/Slider").GetComponent<Slider>()
                .value = W.BulletNum;
        }
        else if (W.Kind == WuQiKind.HuDun)
        {
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun").gameObject.SetActive(true);

            Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuDunShangXian/Slider").GetComponent<Slider>()
                .value = W.HuDunMax;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuiFuSuLv/Slider").GetComponent<Slider>()
                .value = W.HuDunHuiFuSuLv;
            Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/XiuFuShiJian/Slider").GetComponent<Slider>()
                .value = W.HuDunXiuFuShiJian;
        }

        IsNeedCheck = true;
        RecheckWuQiNengLiangUse();
    }

    public static void RecheckWuQiNengLiangUse()
    {
        if (!IsNeedCheck)
        {
            return;
        }
        WuQiData WuQi = PlanesMessage.GetWuQiDataByName(PlaneUIClick.OnChosenPlane, OnChosenWuQi);
        switch (OnChosenWuQi)
        {
            case "<color=#999>[双联ATS0发射炮]</color>":
                BasicNengLiang = 120;
                break;
            case "<color=#5a6>[单发三弹ATS0霰弹炮]</color>":
                BasicNengLiang = 80;
                break;
            case "<color=#999>[循环高压气体流护盾]</color>":
                BasicNengLiang = 50;
                break;
            case "<color=#999>[双发Z0追踪发射炮]</color>":
                BasicNengLiang = 120;
                break;
            case "<color=#999>[重组晶体护盾]</color>":
                BasicNengLiang = 75;
                break;
            case "<color=#999>[双发ATS0发射炮]</color>":
                BasicNengLiang = 60;
                break;
            case "<color=#999>[单发FR0火元素集阵]</color>":
                BasicNengLiang = 70;
                break;
            case "<color=#49c>[单发FR1火元素集阵]</color>":
                BasicNengLiang = 135;
                break;
        }

        GongJiAdd = Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiJiaCheng/Slider").GetComponent<Slider>().value;
        GongJiPinLv = Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiPinLv/Slider").GetComponent<Slider>().value;
        BulletSpeed = Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanSuDu/Slider").GetComponent<Slider>().value;
        ZiDanNum = Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanShuLiang/Slider").GetComponent<Slider>().value;

        HuDunMax = Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuDunShangXian/Slider").GetComponent<Slider>().value;
        HuiFuSuLv = Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuiFuSuLv/Slider").GetComponent<Slider>().value;
        XiuFuShiJian = Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/XiuFuShiJian/Slider").GetComponent<Slider>().value;

        if (WuQi.Kind == WuQiKind.WuQi)
        {
            NengLiang = (int)(BasicNengLiang * Mathf.Pow(1 + GongJiAdd / 25, 1.5F) * Mathf.Pow(GongJiPinLv, 2) * (BulletSpeed / 4.5F) * ZiDanNum);
        }
        else if (WuQi.Kind == WuQiKind.HuDun)
        {
            NengLiang = (int)(BasicNengLiang * (HuDunMax / 50) * (0.5F + Mathf.Pow(HuiFuSuLv / 2, 2) * 2) * (30F / XiuFuShiJian));
        }
        float MaxNengLiang = PlanesMessage.GetPlaneDataByName(PlaneUIClick.OnChosenPlane).MaxNengLiang + KeJiFun.GetKeJiKeyGrade("NengLiang") * 15;
        float KeJiNengLiang = int.Parse(PlaneUIClick.OnChosenPlane.Replace("FS_1","20").Replace("TU_1", "20").Replace("HZ_1", "30")
            .Replace("BR_1", "10").Replace("FR_1", "30"));
        MaxNengLiang += KeJiFun.GetKeJiKeyGrade(PlaneUIClick.OnChosenPlane + "Basic") * KeJiNengLiang;

        foreach (WuQiData W in PlanesMessage.GetPlaneDataByName(PlaneUIClick.OnChosenPlane).WuQi)
        {
            if (W.WuQiName != OnChosenWuQi)
            {
                MaxNengLiang -= W.NengLiangNeed;
            }
        }

        if (NengLiang > MaxNengLiang)
        {
            switch (LastValueChange)
            {
                case "GongJiJiaCheng":
                    GongJiAdd = (Mathf.Pow(MaxNengLiang / (Mathf.Pow(GongJiPinLv, 2) * (BulletSpeed / 4.5F) * ZiDanNum)
                        / BasicNengLiang, 0.666F) - 1) * 25;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiJiaCheng/Slider")
                        .GetComponent<Slider>().value = GongJiAdd;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiJiaCheng/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
                case "GongJiPinLv":
                    GongJiPinLv = Mathf.Pow(MaxNengLiang / (BasicNengLiang * Mathf.Pow(1 + GongJiAdd / 25, 1.5F)
                        * (BulletSpeed / 4.5F) * ZiDanNum), 0.5F);
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiPinLv/Slider")
                        .GetComponent<Slider>().value = GongJiPinLv;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/GongJiPinLv/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
                case "ZiDanSuDu":
                    BulletSpeed = MaxNengLiang / (BasicNengLiang * Mathf.Pow(1 + GongJiAdd / 25, 1.5F)
                        * Mathf.Pow(GongJiPinLv, 2) * ZiDanNum) * 4.5F;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanSuDu/Slider")
                        .GetComponent<Slider>().value = BulletSpeed;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanSuDu/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
                case "ZiDanShuLiang":
                    ZiDanNum = MaxNengLiang / (BasicNengLiang * Mathf.Pow(1 + GongJiAdd / 25, 1.5F) * Mathf.Pow(GongJiPinLv, 2) * (BulletSpeed / 4.5F));
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanShuLiang/Slider")
                        .GetComponent<Slider>().value = (int)ZiDanNum;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/WuQi/ZiDanShuLiang/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
                case "HuDunShangXian":
                    HuDunMax = MaxNengLiang / (BasicNengLiang * (0.5F + Mathf.Pow(HuiFuSuLv / 2, 2) * 2) * (30F / XiuFuShiJian)) * 50F;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuDunShangXian/Slider")
                        .GetComponent<Slider>().value = HuDunMax;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuDunShangXian/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
                case "HuiFuSuLv":
                    HuiFuSuLv = Mathf.Pow((MaxNengLiang / (BasicNengLiang * (HuDunMax / 50) * (30F / XiuFuShiJian)) - 0.5F) / 2, 0.5F) * 2;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuiFuSuLv/Slider")
                        .GetComponent<Slider>().value = HuiFuSuLv;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/HuiFuSuLv/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
                case "XiuFuShiJian":
                    XiuFuShiJian = BasicNengLiang * (HuDunMax / 50) * (0.5F + Mathf.Pow(HuiFuSuLv / 2, 2) * 2) * 30 / MaxNengLiang;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/XiuFuShiJian/Slider")
                        .GetComponent<Slider>().value = XiuFuShiJian;
                    Fade.StringToTransform("Canvas/Planes/WuQiSetting/HuDun/XiuFuShiJian/Slider")
                        .GetComponent<PlaneUIClick>().ChangeWuQiInputFieldValueToSlider(true);
                    break;
            }
        }

        Fade.StringToTransform("Canvas/Planes/WuQiSetting/NengLiang/Slider").GetComponent<Slider>().maxValue
            = MaxNengLiang;
        Fade.StringToTransform("Canvas/Planes/WuQiSetting/NengLiang/Slider").GetComponent<Slider>().value = NengLiang;
        Fade.StringToTransform("Canvas/Planes/WuQiSetting/NengLiang/Value").GetComponent<TextMeshProUGUI>().text
            = NengLiang.ToString() + " / " + MaxNengLiang.ToString();
    }

    public static void FinishSetting(bool WriteInData = true)
    {
        if (WriteInData)
        {
            int PlaneNum = PlanesMessage.GetPlaneDataNumByName(PlaneUIClick.OnChosenPlane);
            int WuQiNum = PlanesMessage.GetWuQiDataNumByName(PlanesMessage.Planes[PlaneNum].WuQi, OnChosenWuQi);

            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].GongJiAdd = GongJiAdd;
            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].PerIntervalTime = GongJiPinLv;
            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].BulletVelocity = BulletSpeed;
            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].BulletNum = ZiDanNum;

            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].HuDunMax = (int)HuDunMax;
            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].HuDunHuiFuSuLv = HuiFuSuLv;
            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].HuDunXiuFuShiJian = XiuFuShiJian;

            PlanesMessage.Planes[PlaneNum].WuQi[WuQiNum].NengLiangNeed = NengLiang;
        }

        if (PlaneUIClick.OnChosenPlane == PlanesMessage.ChuZhanPlane)
        {
            foreach (GameObject G in Fade.GetAllChildGameObject(GameObject.Find("MyPlane").transform))
            {
                if (G.GetComponent<Weapon>())
                {
                    WuQiData W = PlanesMessage.GetWuQiDataByName(PlaneUIClick.OnChosenPlane, G.name);
                    G.GetComponent<Weapon>().WuQiSettingGongJiAdd = W.GongJiAdd;
                    G.GetComponent<Weapon>().WuQiSettingGongJiPinLv = W.PerIntervalTime;
                    G.GetComponent<Weapon>().BulletVelocity = W.BulletVelocity;
                    G.GetComponent<Weapon>().BulletNum = W.BulletNum;
                }
                else if (G.TryGetComponent<HuDun>(out _))
                {
                    WuQiData W = PlanesMessage.GetWuQiDataByName(PlaneUIClick.OnChosenPlane, G.name);
                    OnUpdate.MyHuDun = G.GetComponent<HuDun>();
                    G.GetComponent<HuDun>().HuDunMaxShengMing = W.HuDunMax;
                    G.GetComponent<HuDun>().HuDunHuiFuSpeed = W.HuDunHuiFuSuLv;
                    G.GetComponent<HuDun>().HuDunChongZhiShiJian = W.HuDunXiuFuShiJian;
                    if (G.transform.Find("HuDun"))
                    {
                        G.transform.Find("HuDun").GetComponent<Inspector>().ShengMing[1] = W.HuDunMax;
                    }
                }
            }
        }

        PlanesMessage.SavePlanesData();
    }
}
