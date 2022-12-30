using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_4 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        #region ---前期---
        float x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8.5F), new Vector2(x, 3.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 240, 240 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6.5F), new Vector2(x, -6F) }),
            Name = "灵龟-1",
            ShengMing = new int[] { 420, 420 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
            DuringTime = 2F
        });
        #endregion

        #region ---中期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6.5F), new Vector2(x, -6F) }),
            Name = "飞鸟-1",
            ShengMing = new int[] { 150, 150 },
            GongJi = 20,
            HuDun = 120,
            ModleObject = Fade.StringToTransform("ObjectModels/BR_1"),
            DuringTime = 9F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1.5F, 6.5F), new Vector2(x - 1.5F, -6F) }),
            Name = "普战-1",
            ShengMing = new int[] { 135, 135 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 1
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1.5F, 6.5F), new Vector2(x + 1.5F, -6F) }),
            Name = "普战-1",
            ShengMing = new int[] { 135, 135 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6.5F), new Vector2(x, 3.5F) }),
            Name = "激光-1",
            ShengMing = new int[] { 180, 180 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JA_1"),
            DuringTime = 1F
        });
        #endregion

        #region ---后期---
        x = Random.value * 5 - 2.5F;
        float y = Mathf.Pow(6.25F - x * x, 0.5F) * Mathf.Sign(Random.value - 0.5F) + 8.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, y), new Vector2(x, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 150, 150 },
            HuDun = 100,
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 15F
        });
        for (int i = 1; i < 5; i++)
        {
            x = Random.value * 5 - 2.5F;
            y = Mathf.Pow(6.25F - x * x, 0.5F) * Mathf.Sign(Random.value - 0.5F) + 8.5F;
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(x, y), new Vector2(x, -8) }),
                Name = "银叶-1",
                ShengMing = new int[] { 120, 120 },
                HuDun = 100,
                GongJi = 25,
                ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
                DuringTime = 0.05F
            });
        }
        #endregion

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("2_4"))
        {
            ControlCenter.FinishedGuanQia.Add("2_4");
            ObjectSystem.AddThings("晶石", 15);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_5"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_5");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
