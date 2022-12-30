using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_7 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        #region 前期
        float x = Random.value * 5 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 8), new Vector2(x - 1, 3.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 400, 400 },
            GongJi = 40,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1, 8), new Vector2(x + 1, 3.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 400, 400 },
            GongJi = 40,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 3
        });
        #endregion

        #region 中期
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 7.5F), new Vector2(x, -7.5F) }),
            Name = "银叶-1",
            ShengMing = new int[] { 225, 225 },
            HuDun = 125,
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 15F
        });

        for (int i = 0; i < 9 + Random.value * 6; i++)
        {
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(-3, 7.5F), new Vector2(-4, 2F), new Vector2(4, -2F), new Vector2(3, -8) }),
                Name = "普战-1",
                ShengMing = new int[] { 120 + i * 5, 120 + i * 5 },
                GongJi = 25 + i,
                ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
                DuringTime = 4.2F
            });
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(3, 7.5F), new Vector2(4, 2F), new Vector2(-4, -2F), new Vector2(-3, -8) }),
                Name = "普战-1",
                ShengMing = new int[] { 120 + i * 5, 120 + i * 5 },
                GongJi = 25 + i,
                ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
                DuringTime = 0
            });
        }
        #endregion

        #region 后期

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-3F, 8), new Vector2(-3F, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 200, 200 },
            HuDun = 125,
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 13F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-1F, 8), new Vector2(-1F, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 120, 120 },
            HuDun = 75,
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(1F, 8), new Vector2(1F, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 200, 200 },
            HuDun = 125,
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(3F, 8), new Vector2(3F, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 120, 120 },
            HuDun = 75,
            GongJi = 30,
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
        if (!ControlCenter.FinishedGuanQia.Contains("2_7"))
        {
            ControlCenter.FinishedGuanQia.Add("2_7");
            ObjectSystem.AddThings("晶石", 18);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_8"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_8");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
