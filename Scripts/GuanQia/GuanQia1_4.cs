using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_4 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        #region ---前期---
        float x = Random.value * 7 - 3.5F;
        float y = Random.value;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 4), new Vector2(0, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(y, -6F), new Vector2(y, -3.6F + Random.value) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            Layer = 9,
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        #endregion

        #region ---中期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value + 4
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 320, 320 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 1
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, -6F), new Vector2(x, -3.6F + Random.value) }),
            Name = "普战-1",
            ShengMing = new int[] { 80, 80 },
            Layer = 9,
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value
        });
        #endregion

        #region ---后期---
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x - 1.5F, -8) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 360, 360 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 17.5F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6.5F), new Vector2(x - 1.5F, -8) }),
            Name = "飞鸟-1",
            ShengMing = new int[] { 80, 80 },
            GongJi = 20,
            HuDun = 60,
            ModleObject = Fade.StringToTransform("ObjectModels/BR_1"),
            DuringTime = 0.2F
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, -6F), new Vector2(x, -3.6F + Random.value) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            Layer = 9,
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value + 0.3F
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value + 0.2F
        });
        x = Random.value * 7 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 6), new Vector2(x, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = Random.value + 1
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, -6F), new Vector2(x, 8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            Layer = 9,
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
        if (!ControlCenter.FinishedGuanQia.Contains("1_4"))
        {
            ControlCenter.FinishedGuanQia.Add("1_4");
            ObjectSystem.AddThings("晶石", 9);
        }

        if (!ControlCenter.CouldStartGuanQia.Contains("1_5"))
        {
            ControlCenter.CouldStartGuanQia.Add("1_5");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
