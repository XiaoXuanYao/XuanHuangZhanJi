using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_3 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        float x = Random.value * 5 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 1, 8), new Vector2(x - 1, 3.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 400, 400 },
            GongJi = 50,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x + 1, 8), new Vector2(x + 1, 3.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 400, 400 },
            GongJi = 50,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 3
        });

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("2_3"))
        {
            ControlCenter.FinishedGuanQia.Add("2_3");
            ObjectSystem.AddThings("晶石", 15);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_4"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_4");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
