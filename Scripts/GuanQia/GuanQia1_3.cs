using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_3 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        #region ---前期---
        float x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 4), new Vector2(x, -8) }),
            Name = "普战-2",
            ShengMing = new int[] { 180, 180 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_2"),
            DuringTime = 0
        });
        #endregion

        #region ---中期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 300, 300 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 12
        });
        #endregion

        #region ---后期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x - 1.5F, -8) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 420, 420 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 17.5F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6.5F), new Vector2(x - 1.5F, -8) }),
            Name = "飞鸟-1",
            ShengMing = new int[] { 70, 70 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/BR_1"),
            HuDun = 50,
            DuringTime = 0
        });
        #endregion

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("1_3"))
        {
            ControlCenter.FinishedGuanQia.Add("1_3");
            ObjectSystem.AddThings("晶石", 7);
        }

        if (!ControlCenter.CouldStartGuanQia.Contains("1_4"))
        {
            ControlCenter.CouldStartGuanQia.Add("1_4");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
