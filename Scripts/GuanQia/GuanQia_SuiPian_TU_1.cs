using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia_SuiPian_TU_1 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(Random.value * 7 - 3.5F, 6), new Vector2(0, 3), new Vector2(0, -8) }),
            Name = "灵龟-1",
            ShengMing = new int[] { 275, 275 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
            DuringTime = 0.5F
        });
        for (int i = 1; i < 50; i++)
        {
            if (Random.value > 0.4F)
            {
                P.Add(new Planes
                {
                    Road = new BezierEquation(new Vector2[] { new Vector2(Random.value * 7 - 3.5F, 6), new Vector2(0, 1), new Vector2(0, -8) }),
                    Name = "普战-1",
                    ShengMing = new int[] { 100, 100 },
                    GongJi = 20,
                    ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
                    DuringTime = 3.2F - i * 0.05F,
                    extraPricings = new List<ExtraPricing>()
                    {
                        new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                        new ExtraPricing() { ObjectName = "TU-1碎片",BasicNum = 0, RandomNum = 0.025F + i * 0.001F }
                    }
                });
            }
            else
            {
                P.Add(new Planes
                {
                    Road = new BezierEquation(new Vector2[] { new Vector2(Random.value * 7 - 3.5F, 6), new Vector2(0, 1), new Vector2(0, -8) }),
                    Name = "灵龟-1",
                    ShengMing = new int[] { 275 + i * 5, 275 + i * 5 },
                    GongJi = 20 + (int)(i * 0.5F),
                    ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
                    DuringTime = 5.6F - i * 0.1F,
                    extraPricings = new List<ExtraPricing>()
                    {
                        new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                        new ExtraPricing() { ObjectName = "TU-1碎片",BasicNum = 0, RandomNum = 0.075F + i * 0.001F }
                    }
                });
            }
        }

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }
    static void Prizing()
    {
        ObjectSystem.AddThings("晶石", 20);
        ObjectSystem.AddThings("TU-1碎片", 3 + (int)(Random.value * 3));
    }
}
 