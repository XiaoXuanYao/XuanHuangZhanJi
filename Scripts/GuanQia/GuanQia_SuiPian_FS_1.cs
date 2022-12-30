using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQia_SuiPian_FS_1 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(Random.value * 7 - 3.5F, 6), new Vector2(0, 3), new Vector2(0, -8) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0.5F
        });
        for (int i = 1; i < 50; i++)
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
                    new ExtraPricing() { ObjectName = "FS-1碎片",BasicNum = 0, RandomNum = 0.075F + i * 0.0015F }
                }
            });
        }

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }
    static void Prizing()
    {
        ObjectSystem.AddThings("晶石", 20);
        ObjectSystem.AddThings("FS-1碎片", 3 + (int)(Random.value * 3));
    }
}
