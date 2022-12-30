using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_2 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        #region ---前期---
        float x = Random.value * 5 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x + 2, 3.5F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 175, 175 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 2F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 0.4F, 8.6F), new Vector2(x + 2.4F, -6F) }),
            Name = "灵龟-1",
            ShengMing = new int[] { 425, 425 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
            DuringTime = 2F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 0.4F, 8.6F), new Vector2(x + 2.4F, -6F) }),
            Name = "光梭-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 35,
            ModleObject = Fade.StringToTransform("ObjectModels/LS_1"),
            HuDun = 100,
            DuringTime = 2
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 0.4F, 8), new Vector2(x + 1.6F, 3.5F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 175, 175 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 1
        });
        #endregion

        #region ---中期---
        x = Random.value * 4 - 2F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 7.5F), new Vector2(x, -6F) }),
            Name = "光梭-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 35,
            ModleObject = Fade.StringToTransform("ObjectModels/LS_1"),
            HuDun = 50,
            DuringTime = 12
        });
        for (int i = 0; i < 3; i++)
        {
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(x - i * 1.2F, 7.5F), new Vector2(x, -6F) }),
                Name = "光梭-1",
                ShengMing = new int[] { 25, 25 },
                GongJi = 40,
                ModleObject = Fade.StringToTransform("ObjectModels/LS_1"),
                HuDun = 25,
                DuringTime = 0
            });
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(x + i * 1.2F, 7.5F), new Vector2(x, -6F) }),
                Name = "光梭-1",
                ShengMing = new int[] { 25, 25 },
                GongJi = 40,
                ModleObject = Fade.StringToTransform("ObjectModels/LS_1"),
                HuDun = 25,
                DuringTime = 1
            });
        }
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 7.5F), new Vector2(x, -6F) }),
            Name = "普战-1",
            ShengMing = new int[] { 135, 135 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        #endregion

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("2_2"))
        {
            ControlCenter.FinishedGuanQia.Add("2_2");
            ObjectSystem.AddThings("晶石", 15);
            ObjectSystem.AddThings("冲子板", 5);
            ObjectSystem.AddThings("抵子板", 3);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_3"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_3");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
