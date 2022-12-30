using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_1 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        #region ---前期---
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 4), new Vector2(0, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        #endregion

        #region ---中期---
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 6), new Vector2(0, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 4
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(1.5F, 7), new Vector2(1.5F, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 1
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-1.5F, 7), new Vector2(-1.5F, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        #endregion

        #region ---后期---
        float x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -6) }),
            Name = "灵龟-1",
            ShengMing = new int[] { 200, 200 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
            DuringTime = 15
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1.5F, 7), new Vector2(x + 1.5F, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1.5F, 7), new Vector2(x - 1.5F, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 20,
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
        if (!ControlCenter.FinishedGuanQia.Contains("1_1"))
        {
            ControlCenter.FinishedGuanQia.Add("1_1");
            ObjectSystem.AddThings("晶石", 3);
        }

        if (ControlCenter.FinishedGuanQia.Contains("T_1") && ControlCenter.FinishedGuanQia.Contains("1_1"))
        {
            if (!ControlCenter.CouldStartGuanQia.Contains("1_2"))
            {
                ControlCenter.CouldStartGuanQia.Add("1_2");
            }
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
