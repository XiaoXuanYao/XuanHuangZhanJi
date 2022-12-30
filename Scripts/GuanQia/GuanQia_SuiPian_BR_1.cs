using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia_SuiPian_BR_1 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();

        for (int i = 1; i < 20; i++)
        {
            float X = Random.value * 8 - 4;
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(X, 6), new Vector2(X, -8) }),
                Name = "飞鸟-1",
                ShengMing = new int[] { 125, 125 },
                GongJi = 20,
                HuDun = 100 + i * 5,
                ModleObject = Fade.StringToTransform("ObjectModels/BR_1"),
                DuringTime = (16 - i * 0.4F) * Mathf.Min(i - 1, 1),
                extraPricings = new List<ExtraPricing>()
                {
                    new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                    new ExtraPricing() { ObjectName = "BR-1碎片",BasicNum = 0, RandomNum = 0.05F + i * 0.001F }
                }
            });
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(X - 1.3F, 7), new Vector2(X - 1.3F, -8) }),
                Name = "飞鸟-1",
                ShengMing = new int[] { 100, 100 },
                GongJi = 15,
                ModleObject = Fade.StringToTransform("ObjectModels/BR_1"),
                DuringTime = 0,
                extraPricings = new List<ExtraPricing>()
                {
                    new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                    new ExtraPricing() { ObjectName = "BR-1碎片",BasicNum = 0, RandomNum = 0.05F + i * 0.001F }
                }
            });
            P.Add(new Planes
            {
                Road = new BezierEquation(new Vector2[] { new Vector2(X + 1.3F, 7), new Vector2(X + 1.3F, -8) }),
                Name = "飞鸟-1",
                ShengMing = new int[] { 100, 100 },
                GongJi = 15,
                ModleObject = Fade.StringToTransform("ObjectModels/BR_1"),
                DuringTime = 0,
                extraPricings = new List<ExtraPricing>()
                {
                    new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                    new ExtraPricing() { ObjectName = "BR-1碎片",BasicNum = 0, RandomNum = 0.05F + i * 0.001F }
                }
            });
            if (Random.value > 0.66F)
            {
                P.Add(new Planes
                {
                    Road = new BezierEquation(new Vector2[] { new Vector2(X, 7.3F), new Vector2(X, -8) }),
                    Name = "焰火-1",
                    ShengMing = new int[] { 225 + i * 5, 225 + i * 5 },
                    GongJi = 25 + (int)(i * 0.5F),
                    ModleObject = Fade.StringToTransform("ObjectModels/FR_1"),
                    DuringTime = 0,
                    extraPricings = new List<ExtraPricing>()
                    {
                        new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                        new ExtraPricing() { ObjectName = "BR-1碎片",BasicNum = 0, RandomNum = 0.05F + i * 0.001F }
                    }
                });
            }
            else
            {
                P.Add(new Planes
                {
                    Road = new BezierEquation(new Vector2[] { new Vector2(X, 7.3F), new Vector2(X, -8) }),
                    Name = "灵龟-2",
                    ShengMing = new int[] { 325 + i * 10, 325 + i * 10 },
                    GongJi = 15 + (int)(i * 0.5F),
                    ModleObject = Fade.StringToTransform("ObjectModels/TU_2"),
                    DuringTime = 0,
                    extraPricings = new List<ExtraPricing>()
                    {
                        new ExtraPricing() { ObjectName = "晶石",BasicNum = 0, RandomNum = 0.1F + i * 0.002F },
                        new ExtraPricing() { ObjectName = "BR-1碎片",BasicNum = 0, RandomNum = 0.05F + i * 0.001F }
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
 