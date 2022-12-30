using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia2_5 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 8), new Vector2(0, 4.2F) }),
            Name = "散花舰",
            ShengMing = new int[] { 4200, 4200 },
            GongJi = 25,
            HuDun = 800,
            ModleObject = Fade.StringToTransform("ObjectModels/Boos_3"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(3F, 9), new Vector2(3F, 5) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 480, 480 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 5
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-3F, 9), new Vector2(-3F, 5) }),
            Name = "灵龟-2",
            ShengMing = new int[] { 480, 480 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-1.5F, -6F), new Vector2(-1.5F, -3F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 675, 675 },
            Layer = 9,
            GongJi = 55,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 5
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(1.5F, -6F), new Vector2(1.5F, -3F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 675, 675 },
            Layer = 9,
            GongJi = 55,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-6, -6F), new Vector2(-3, -2.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 450, 450 },
            Layer = 9,
            GongJi = 40,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 4
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(6, -6F), new Vector2(3, -2.5F) }),
            Name = "焰火-1",
            ShengMing = new int[] { 450, 450 },
            Layer = 9,
            GongJi = 40,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(12, -4F), new Vector2(5F, 0) }),
            Name = "焰火-1",
            ShengMing = new int[] { 375, 375 },
            Layer = 9,
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 4
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-12, -4F), new Vector2(-5F, 0) }),
            Name = "焰火-1",
            ShengMing = new int[] { 375, 375 },
            Layer = 9,
            GongJi = 30,
            ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
            DuringTime = 0
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(2, -6F), new Vector2(2, -4F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 270, 270 },
            Layer = 9,
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 4
        });
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-2, -6F), new Vector2(-2, -4F) }),
            Name = "奇圆-2",
            ShengMing = new int[] { 270, 270 },
            Layer = 9,
            GongJi = 25,
            ModleObject = Fade.StringToTransform("ObjectModels/JY_2"),
            DuringTime = 0
        });

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("2_5"))
        {
            ControlCenter.FinishedGuanQia.Add("2_5");
            ObjectSystem.AddThings("晶石", 21);
            ObjectSystem.AddThings("冲子板", 6);
            ObjectSystem.AddThings("抵子板", 6);
            ObjectSystem.AddThings("HZ-1碎片", 5);
        }
        if (!ControlCenter.CouldStartGuanQia.Contains("2_6"))
        {
            ControlCenter.CouldStartGuanQia.Add("2_6");
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
