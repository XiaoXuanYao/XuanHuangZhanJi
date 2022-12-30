using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_1 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        float x = Random.value * 5 - 3.5F;
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x, 8), new Vector2(x + 2, 3.5F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 175, 175 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x+0.4F, 8.6F), new Vector2(x + 2.4F, 4.1F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 175, 175 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(x - 0.4F, 8), new Vector2(x + 1.6F, 3.5F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 175, 175 },
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 0
        });

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("2_1"))
        {
            ControlCenter.FinishedGuanQia.Add("2_1");
            ObjectSystem.AddThings("晶石", 12);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_2"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_2");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
