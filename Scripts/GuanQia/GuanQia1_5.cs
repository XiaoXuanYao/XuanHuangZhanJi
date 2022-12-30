using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_5 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        #region ---Boos1---
        float x = Random.value * 7 - 3.5F;
        float y = Random.value;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 8), new Vector2(0, 4.5F) }),
            Name = "星壹舰",
            ShengMing = new int[] { 800, 800 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/Boos_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, -6F), new Vector2(0, -2F) }),
            Name = "普战-1",
            ShengMing = new int[] { 150, 150 },
            Layer = 9,
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(1.3F, -6F), new Vector2(1.3F, -3.3F) }),
            Name = "普战-1",
            ShengMing = new int[] { 150, 150 },
            Layer = 9,
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 2
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-1.3F, -6F), new Vector2(-1.3F, -3.3F) }),
            Name = "普战-1",
            ShengMing = new int[] { 150, 150 },
            Layer = 9,
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 1
        });
        #endregion

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("1_5"))
        {
            ControlCenter.FinishedGuanQia.Add("1_5");
            ObjectSystem.AddThings("晶石", 12);
            ObjectSystem.AddThings("TU-1碎片", 5);
        }

        if (!ControlCenter.CouldStartGuanQia.Contains("1_6"))
        {
            ControlCenter.CouldStartGuanQia.Add("1_6");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
