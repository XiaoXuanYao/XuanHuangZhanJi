using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_7 : MonoBehaviour
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
            ShengMing = new int[] { 100, 100 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 7), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(2, 6), new Vector2(x, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(-x, -8) }),
            Name = "三锥-1",
            ShengMing = new int[] { 225, 225 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/SQ_1"),
            DuringTime = 2
        });
        #endregion

        #region ---中期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 420, 420 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 16
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 7), new Vector2(x - 1, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 2
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1, 7), new Vector2(x + 1, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 120, 120 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 2, 8), new Vector2(x - 2, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 12
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 2, 8), new Vector2(x + 2, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 120, 120 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 1
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(-x, -8) }),
            Name = "三锥-1",
            ShengMing = new int[] { 225, 225 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/SQ_1"),
            DuringTime = 0
        });
        #endregion

        #region ---后期---
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 7), new Vector2(x - 1, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 120, 120 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 14
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 420, 420 },
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 2
        });
        #endregion

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("1_7"))
        {
            ControlCenter.FinishedGuanQia.Add("1_7");
            ObjectSystem.AddThings("晶石", 15);
        }

        if (ControlCenter.FinishedGuanQia.Contains("T_3") && ControlCenter.FinishedGuanQia.Contains("1_7"))
        {
            if (!ControlCenter.CouldStartGuanQia.Contains("1_8"))
            {
                ControlCenter.CouldStartGuanQia.Add("1_8");
            }
        }

        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
