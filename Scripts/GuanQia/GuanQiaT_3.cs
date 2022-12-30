using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQiaT_3 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        #region ---前期---
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(0, 7F), new Vector2(0, 5F) }),
            Name = "灵龟-1",
            ShengMing = new int[] { 60, 60 },
            GongJi = 10,
            ModleObject = Fade.StringToTransform("ObjectModels/TU_1"),
            DuringTime = 0
        });

        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(-1, 8.5F), new Vector2(-1, 3.2F) }),
            Name = "普战-1（镜像）",
            ShengMing = new int[] { 100, 100 },
            GongJi = 100,
            ModleObject = Fade.StringToTransform("MyPlane"),
            DuringTime = 0
        });
        #endregion

        Fade.NewFade("Canvas/TeachingGuanQiaShow", 0, 1, 0.3F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/T_3").gameObject.SetActive(true);
        TeachingGuanQia.OnChosedGuanQia = Fade.StringToTransform("Canvas/TeachingGuanQiaShow/T_3");

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("T_3"))
        {
            ControlCenter.FinishedGuanQia.Add("T_3");
            ObjectSystem.AddThings("晶石", 7);
        }

        if (ControlCenter.FinishedGuanQia.Contains("T_3") && ControlCenter.FinishedGuanQia.Contains("1_7"))
        {
            if (!ControlCenter.CouldStartGuanQia.Contains("1_8"))
            {
                ControlCenter.CouldStartGuanQia.Add("1_8");
            }
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
