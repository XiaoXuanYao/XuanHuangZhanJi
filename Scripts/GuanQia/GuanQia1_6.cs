using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_6 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        #region ---前期---
        float x = Random.value * 7 - 3.5F;
        float y = Random.value;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 5), new Vector2(0, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(2, 6), new Vector2(2, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-2, 6), new Vector2(-2, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0
        });
        #endregion

        #region ---中期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "灵龟-1",
            ShengMing = new int[] { 300, 300 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
            DuringTime = 18
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 7), new Vector2(x - 1, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 2
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1, 7), new Vector2(x + 1, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 2, 8), new Vector2(x - 2, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 4
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 2, 8), new Vector2(x + 2, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0
        });
        #endregion

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("1_6"))
        {
            ControlCenter.FinishedGuanQia.Add("1_6");
            ObjectSystem.AddThings("晶石", 15);
        }

        if (!ControlCenter.CouldStartGuanQia.Contains("1_7"))
        {
            ControlCenter.CouldStartGuanQia.Add("1_7");
            ControlCenter.CouldStartGuanQia.Add("T_3");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
