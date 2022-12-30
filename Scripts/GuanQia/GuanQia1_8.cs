using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia1_8 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 8), new Vector2(0, 3.5F) }),
            Name = "奇圆舰",
            ShengMing = new int[] { 300, 300 },
            GongJi = 35,
            ModleObject = Fade.StringToTransform("ObjectModels/Boos_2"),
            DuringTime = 0
        });

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("1_8"))
        {
            ControlCenter.FinishedGuanQia.Add("1_8");
            ObjectSystem.AddThings("晶石", 30);
            ObjectSystem.AddThings("冲子板", 5);
            ObjectSystem.AddThings("抵子板", 5);
            ObjectSystem.AddThings("TU-1碎片", 10);
        }

        if (!ControlCenter.CouldStartGuanQia.Contains("2_1"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_1");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
