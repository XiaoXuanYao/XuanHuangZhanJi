using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_8 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        float x = Random.value * 5 - 3.5F;

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 23.5F), new Vector2(0, 18.2F) }),
            Name = "凡却 IYN-3701N号 人造卫星",
            ShengMing = new int[] { 108000, 108000 },
            GongJi = 18,
            HuDun = 9600,
            ModleObject = Fade.StringToTransform("ObjectModels/Boos_4"),
            DuringTime = 0
        });

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("2_8"))
        {
            ControlCenter.FinishedGuanQia.Add("2_8");
            ObjectSystem.AddThings("晶石", 60);
            ObjectSystem.AddThings("HZ-1碎片", 10);
            ObjectSystem.AddThings("冲子板", 10);
            ObjectSystem.AddThings("抵子板", 10);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("3_1"))
        {
            ControlCenter.CouldStartGuanQia.Add("3_1");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
