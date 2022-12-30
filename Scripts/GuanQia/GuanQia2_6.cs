using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_6 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        #region 前期
        float x = Random.value * 5 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 7), new Vector2(x - 1, 3.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 360, 360 },
            GongJi = 40,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });

        x = Random.value * 7 - 3.5F;

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 8), new Vector2(x - 1, 3.5F) }),
            Name = "普战-2",
            ShengMing = new int[] { 180, 180 },
            GongJi = 32,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_2"),
            DuringTime = 3
        });

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1, 8), new Vector2(x + 1, 3.5F) }),
            Name = "普战-2",
            ShengMing = new int[] { 180, 180 },
            GongJi = 32,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_2"),
            DuringTime = 0
        });

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x, 3.5F) }),
            Name = "激光-1",
            ShengMing = new int[] { 160, 160 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JA_1"),
            DuringTime = 3.5F
        });
        #endregion

        #region 中期
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x, 3.5F) }),
            Name = "飞鸟-1",
            ShengMing = new int[] { 180, 180 },
            GongJi = 30,
            HuDun = 135,
            ModleObject = Fade.StringToTransform("ObjectModels/JA_1"),
            DuringTime = 12
        });

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x, 3.5F) }),
            Name = "激光-1",
            ShengMing = new int[] { 150, 150 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JA_1"),
            DuringTime = 2
        });

        for(int i = 0; i < 8; i++)
        {
            x = Random.value * 7 - 3.5F;
            int Add = (int)(Random.value * 7.5F) * 2;
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(x, 6.5F), new Vector2(x, -6F) }),
                Name = "普战-1",
                ShengMing = new int[] { 135 + Add * 5, 135 + Add * 5 },
                GongJi = 30 + Add,
                ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
                DuringTime = 1.5F + Random.value * 2
            });
        }
        #endregion

        #region 后期
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 8), new Vector2(0, -8F) }),
            Name = "星壹舰",
            ShengMing = new int[] { 1200, 1200 },
            GongJi = 35,
            ModleObject = Fade.StringToTransform("ObjectModels/Boos_1"),
            DuringTime = 10
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-2, 6.5F), new Vector2(4, -6F) }),
            Name = "普战-1",
            ShengMing = new int[] { 150, 150 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 3
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-2, 6.5F), new Vector2(4, -6F) }),
            Name = "普战-1",
            ShengMing = new int[] { 150, 150 },
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
        if (!ControlCenter.FinishedGuanQia.Contains("2_6"))
        {
            ControlCenter.FinishedGuanQia.Add("2_6");
            ObjectSystem.AddThings("晶石", 15);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_7"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_7");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
