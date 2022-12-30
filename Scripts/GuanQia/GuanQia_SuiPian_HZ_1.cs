using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia_SuiPian_HZ_1 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(Random.value * 7 - 3.5F, 6), new Vector2(0, 3), new Vector2(0, -8) }),
            Name = "银叶-1",
            ShengMing = new int[] { 275, 275 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
            DuringTime = 0.5F
        });
        for (int i = 1; i < 50; i++)
        {
            float R = Random.value;
            Vector2 StartPoint = new Vector2(Random.value, 6);
            if (R > 0.8F)
            {
                StartPoint = new Vector2(Random.value + 5.5F, 6);
            }
            else if (R < 0.2F)
            {
                StartPoint = new Vector2(Random.value - 6.5F, 6);
            }
            if (Random.value > 0.6F)
            {
                P.Add(new Planes
                {
                    Road = new BezierEquation(new Vector2[] { StartPoint, new Vector2(0, -8) }),
                    Name = "银叶-1",
                    ShengMing = new int[] { 100, 100 },
                    GongJi = 20,
                    ModleObject = Fade.StringToTransform("ObjectModels/HZ_1"),
                    DuringTime = 2.4F - i * 0.032F,
                    extraPricings = new List<ExtraPricing>()
                    {
                        new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                        new ExtraPricing() { ObjectName = "HZ-1碎片",BasicNum = 0, RandomNum = 0.05F + i * 0.001F }
                    }
                });
            }
            else
            {
                P.Add(new Planes
                {
                    Road = new BezierEquation(new Vector2[] { StartPoint, new Vector2(0, -8) }),
                    Name = "普战-1",
                    ShengMing = new int[] { 275 + i * 5, 275 + i * 5 },
                    GongJi = 20 + (int)(i * 0.5F),
                    ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
                    DuringTime = 5.6F - i * 0.1F,
                    extraPricings = new List<ExtraPricing>()
                    {
                        new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                        new ExtraPricing() { ObjectName = "HZ-1碎片",BasicNum = 0, RandomNum = 0.025F + i * 0.0005F }
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
 