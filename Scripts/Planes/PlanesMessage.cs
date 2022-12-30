using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanesMessage : MonoBehaviour
{
    public static List<PlaneData> Planes = new List<PlaneData>();
    public static string ChuZhanPlane = "FS_1";

    public static void SavePlanesData()
    {
        string Message = "";
        int Num = 0;
        foreach (PlaneData P in Planes)
        {
            Message += "<Plane" + Num + ">";
            Message += "    <Name>" + P.Name + "</Name>";
            Message += "    <ShortName>" + P.ShortName + "</ShortName>";
            Message += "    <MaxShengMing>" + P.MaxShengMing + "</MaxShengMing>";
            Message += "    <GongJiAddNum>" + P.GongJiAddNum + "</GongJiAddNum>";
            Message += "    <GongJiAddPercent>" + P.GongJiAddPercent + "</GongJiAddPercent>";
            Message += "    <MoveSpeed>" + P.MoveSpeed + "</MoveSpeed>";
            Message += "    <MaxNengLiang>" + P.MaxNengLiang + "</MaxNengLiang>";
            Message += "    <QiangHuaNum>" + P.QiangHuaNum + "</QiangHuaNum>";
            Message += "    <GaiJinNum>" + P.GaiJinNum + "</GaiJinNum>";
            Message += "    <WuQiData>";
            int u = 0;
            foreach (WuQiData W in P.WuQi)
            {
                Message += "<WuQi" + u + ">";
                Message += "    <WuQiName>" + W.WuQiName + "</WuQiName>";
                Message += "    <Kind>" + (int)W.Kind + "</Kind>";
                Message += "    <Bullet>" + Fade.TransformToString(W.Bullet) + "</Bullet>";
                Message += "    <GongJiAdd>" + W.GongJiAdd + "</GongJiAdd>";
                Message += "    <PerIntervalTime>" + W.PerIntervalTime + "</PerIntervalTime>";
                Message += "    <BulletVelocity>" + W.BulletVelocity + "</BulletVelocity>";
                Message += "    <BasicRoadRotation>" + W.BasicRoadRotation + "</BasicRoadRotation>";
                Message += "    <AngleOffset>" + W.AngleOffset + "</AngleOffset>";
                Message += "    <BulletNum>" + W.BulletNum + "</BulletNum>";
                Message += "    <BulletDuringTime>" + W.BulletDuringTime + "</BulletDuringTime>";
                Message += "    <FanRadius>" + W.FanRadius + "</FanRadius>";
                Message += "    <HuDunMax>" + W.HuDunMax + "</HuDunMax>";
                Message += "    <HuDunHuiFuSuLv>" + W.HuDunHuiFuSuLv + "</HuDunHuiFuSuLv>";
                Message += "    <HuDunXiuFuShiJian>" + W.HuDunXiuFuShiJian + "</HuDunXiuFuShiJian>";
                Message += "    <NengLiangNeed>" + W.NengLiangNeed + "</NengLiangNeed>";
                Message += "</WuQi" + u + ">";
                u++;
            }
            Message += "    </WuQiData>";
            Message += "</Plane" + Num + ">";
            Num++;
        }
        Save.SetString("PlanesMessage", Message);
    }

    public static void GetPlanesData()
    {
        string Mes = PlayerPrefs.GetString("PlanesMessage", "");
        for (int i = 0; UserMessage.GetMessage.Has(Mes, "Plane" + i); i++) {
            string[][] SaveMessage = UserMessage.GetMessage.GetAll(UserMessage.GetMessage.Get(Mes, "Plane" + i));
            PlaneData P = new PlaneData();
            foreach (string[] S in SaveMessage)
            {
                switch (S[0])
                {
                    case "Name":
                        P.Name = S[1];
                        break;
                    case "ShortName":
                        P.ShortName = S[1];
                        break;
                    case "MaxShengMing":
                        P.MaxShengMing = int.Parse(S[1]);
                        break;
                    case "GongJiAddNum":
                        P.GongJiAddNum = int.Parse(S[1]);
                        break;
                    case "GongJiAddPercent":
                        P.GongJiAddPercent = float.Parse(S[1]);
                        break;
                    case "MoveSpeed":
                        P.MoveSpeed = int.Parse(S[1]);
                        break;
                    case "MaxNengLiang":
                        P.MaxNengLiang = int.Parse(S[1]);
                        break;
                    case "QiangHuaNum":
                        P.QiangHuaNum = int.Parse(S[1]);
                        break;
                    case "GaiJinNum":
                        P.GaiJinNum = int.Parse(S[1]);
                        break;
                    case "WuQiData":
                        for (int u = 0; UserMessage.GetMessage.Has(S[1], "WuQi" + u); u++)
                        {
                            string Mes2 = UserMessage.GetMessage.Get(S[1], "WuQi" + u);
                            WuQiData W = new WuQiData();
                            foreach(string[] S2 in UserMessage.GetMessage.GetAll(Mes2))
                            {
                                switch (S2[0])
                                {
                                    case "WuQiName":
                                        W.WuQiName = S2[1];
                                        break;
                                    case "Kind":
                                        W.Kind = (WuQiKind)int.Parse(S2[1]);
                                        break;
                                    case "Bullet":
                                        W.Bullet = Fade.StringToTransform(S2[1]);
                                        break;
                                    case "GongJiAdd":
                                        W.GongJiAdd = float.Parse(S2[1]);
                                        break;
                                    case "PerIntervalTime":
                                        W.PerIntervalTime = float.Parse(S2[1]);
                                        break;
                                    case "BulletVelocity":
                                        W.BulletVelocity = float.Parse(S2[1]);
                                        break;
                                    case "BasicRoadRotation":
                                        W.BasicRoadRotation = float.Parse(S2[1]);
                                        break;
                                    case "AngleOffset":
                                        W.AngleOffset = float.Parse(S2[1]);
                                        break;
                                    case "BulletNum":
                                        W.BulletNum = int.Parse(S2[1]);
                                        break;
                                    case "BulletDuringTime":
                                        W.BulletDuringTime = float.Parse(S2[1]);
                                        break;
                                    case "FanRadius":
                                        W.FanRadius = float.Parse(S2[1]);
                                        break;
                                    case "HuDunMax":
                                        W.HuDunMax = int.Parse(S2[1]);
                                        break;
                                    case "HuDunHuiFuSuLv":
                                        W.HuDunHuiFuSuLv = float.Parse(S2[1]);
                                        break;
                                    case "HuDunXiuFuShiJian":
                                        W.HuDunXiuFuShiJian = float.Parse(S2[1]);
                                        break;
                                    case "NengLiangNeed":
                                        W.NengLiangNeed = int.Parse(S2[1]);
                                        break;
                                }
                            }
                            P.WuQi.Add(W);
                        }
                        break;
                }
            }
            Planes.Add(P);
        }
    }

    public static PlaneData GetPlaneDataByName(string PlaneName)
    {
        foreach(PlaneData P in Planes)
        {
            if (P.Name == PlaneName || P.ShortName == PlaneName)
            {
                return P;
            }
        }
        return null;
    }

    public static int GetPlaneDataNumByName(string PlaneName)
    {
        int i = 0;
        foreach (PlaneData P in Planes)
        {
            if (P.Name == PlaneName || P.ShortName == PlaneName)
            {
                return i;
            }
            else
            {
                i++;
            }
        }
        return -1;
    }

    public static WuQiData GetWuQiDataByName(string PlaneName, string WuQiName)
    {
        foreach(WuQiData W in GetPlaneDataByName(PlaneName).WuQi)
        {
            if (W.WuQiName == WuQiName)
            {
                return W;
            }
        }
        return null;
    }

    public static int GetWuQiDataNumByName(string PlaneName, string WuQiName)
    {
        int Num = 0;
        foreach (WuQiData W in GetPlaneDataByName(PlaneName).WuQi)
        {
            if (W.WuQiName == WuQiName)
            {
                return Num;
            }
            Num++;
        }
        return -1;
    }
    public static int GetWuQiDataNumByName(List<WuQiData> PlaneName, string WuQiName)
    {
        int Num = 0;
        foreach (WuQiData W in PlaneName)
        {
            if (W.WuQiName == WuQiName)
            {
                return Num;
            }
            Num++;
        }
        return -1;
    }

    public static void GetNewPlaneAdd(string Name)
    {
        switch (Name)
        {
            case "FS_1":
                Planes.Add(new PlaneData
                {
                    Name = "普战-1",
                    ShortName = "FS_1",
                    MaxShengMing = 100,
                    GongJiAddNum = 0,
                    GongJiAddPercent = 0,
                    MoveSpeed = 5,
                    MaxNengLiang = 200,
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
                });
                break;
            case "TU_1":
                Planes.Add(new PlaneData
                {
                    Name = "灵龟-1",
                    ShortName = "TU_1",
                    MaxShengMing = 240,
                    GongJiAddNum = 0,
                    GongJiAddPercent = 0,
                    MoveSpeed = 3,
                    MaxNengLiang = 400,
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
                            AngleOffset = 0.03F,
                            BulletNum = 3,
                            BulletDuringTime = 0.07F,
                            FanRadius = 0,
                            NengLiangNeed = 240
                        }
                    }
                });
                break;
            case "HZ_1":
                Planes.Add(new PlaneData
                {
                    Name = "银叶-1",
                    ShortName = "HZ_1",
                    MaxShengMing = 150,
                    GongJiAddNum = 9,
                    GongJiAddPercent = 0.02F,
                    MoveSpeed = 5,
                    MaxNengLiang = 400,
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
                            BulletVelocity = 5F,
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
                });
                break;
            case "BR_1":
                Planes.Add(new PlaneData
                {
                    Name = "飞鸟-1",
                    ShortName = "BR_1",
                    MaxShengMing = 175,
                    GongJiAddNum = 5,
                    GongJiAddPercent = 0,
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
                });
                break;
            case "FR_1":
                Planes.Add(new PlaneData
                {
                    Name = "焰火-1",
                    ShortName = "FR_1",
                    MaxShengMing = 175,
                    GongJiAddNum = 2,
                    GongJiAddPercent = 0.04F,
                    MoveSpeed = 5,
                    MaxNengLiang = 240,
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
                });
                break;
        }
        SavePlanesData();
    }

    public static bool HasPlane(string Name)
    {
        foreach(PlaneData P in Planes)
        {
            if (P.ShortName == Name || P.Name == Name)
            {
                return true;
            }
        }
        return false;
    }

    public static void ChangePlaneChuZhan(string Name)
    {
        Transform Obj = Fade.StringToTransform("MyPlaneModels/" + Name);
        if (Obj)
        {
            if (GetPlaneDataByName(Name) != null)
            {
                ChuZhanPlane = Name;
                GameObject.Find("MyPlane").GetComponent<SpriteRenderer>().sprite = Obj.GetComponent<SpriteRenderer>().sprite;
                GameObject.Find("MyPlane").GetComponent<PolygonCollider2D>().points = Obj.GetComponent<PolygonCollider2D>().points;
                for (int i = GameObject.Find("MyPlane").transform.childCount - 1; i >= 0; i--)
                {
                    DestroyImmediate(GameObject.Find("MyPlane").transform.GetChild(i).gameObject);
                }
                for (int i = 0; i < Obj.childCount; i++)
                {
                    Transform Child = Instantiate(Obj.GetChild(i), GameObject.Find("MyPlane").transform);
                    Child.name = Child.name.Replace("(Clone)", "");
                }
                PlaneUIClick.OnChosenPlane = Name;
                PlaneUIClick.ChangeMessageShow();
                PlaneWuQiSetting.FinishSetting(false);
                Save.SetString("DefaultOnChosenPlane", Name);
            }
            else
            {
                Debug.Log("战机已注册");
            }
        }
        else
        {
            Debug.LogError("[PlanesMessage] " + Name + "：战机名称不存在");
        }
    }
}

[System.Serializable]
public class PlaneData
{
    public string Name = "";
    public string ShortName = "";
    public int MaxShengMing = 100;
    public int GongJiAddNum = 0;
    public float GongJiAddPercent = 0;
    public float MoveSpeed = 0;
    public int MaxNengLiang = 200;
    public int QiangHuaNum = 0;
    public int GaiJinNum = 0;
    public List<WuQiData> WuQi = new List<WuQiData>();
}

[System.Serializable]
public class WuQiData
{
    [Tooltip("武器名称)")]
    public string WuQiName = "";
    [Tooltip("类型")]
    public WuQiKind Kind = WuQiKind.WuQi;

    #region ==== 武器 ====
    [Tooltip("子弹物体标准(模板)")]
    public Transform Bullet;
    [Tooltip("攻击附加(百分比)")]
    public float GongJiAdd;
    [Tooltip("子弹发射频率")]
    public float PerIntervalTime = 1;
    [Tooltip("子弹速度")]
    public float BulletVelocity = 2;
    [Tooltip("轨迹旋转基本量")]
    public float BasicRoadRotation = 0;
    [Tooltip("角度偏移量  |  (float) 0 ~ 1")]
    public float AngleOffset = 0.003F;
    [Tooltip("发射数量")]
    public float BulletNum = 1;
    [Tooltip("发射间隔")]
    public float BulletDuringTime = 0;
    [Tooltip("扇形角度")]
    public float FanRadius = 0;
    #endregion

    #region ==== 护盾 ====
    [Tooltip("护盾物体标准(模板)")]
    public Transform HuDun;
    [Tooltip("护盾最大值")]
    public int HuDunMax;
    [Tooltip("护盾恢复速率")]
    public float HuDunHuiFuSuLv;
    [Tooltip("护盾重铸时间")]
    public float HuDunXiuFuShiJian;
    #endregion

    [Tooltip("能量需要")]
    public int NengLiangNeed = 50;
}

public enum WuQiKind
{
    WuQi,
    HuDun
}