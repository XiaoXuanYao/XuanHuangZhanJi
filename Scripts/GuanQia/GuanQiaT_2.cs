using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanQiaT_2 : MonoBehaviour
{
    public static List<Planes> CreateMap()
    {
        List<Planes> P = new List<Planes>();
        #region ---前期---
        P.Add(new Planes
        {
            Road = new BezierEquation(new Vector2[] { new Vector2(3.2F, 7F), new Vector2(3.2F, 2F) }),
            Name = "普战-1",
            ShengMing = new int[] { 100, 100 },
            GongJi = 20,
            ModleObject = Fade.StringToTransform("ObjectModels/FS_1"),
            DuringTime = 0
        });
        #endregion

        Fade.NewFade("Canvas/TeachingGuanQiaShow", 0, 1, 0.3F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/T_2").gameObject.SetActive(true);
        TeachingGuanQia.OnChosedGuanQia = Fade.StringToTransform("Canvas/TeachingGuanQiaShow/T_2");

        Map.FGDelegate D = new Map.FGDelegate(Prizing);
        Map.Delegates = (Map.FGDelegate)System.Delegate.Combine(Map.Delegates, D);

        return P;
    }

    static void Prizing()
    {
        if (!ControlCenter.FinishedGuanQia.Contains("T_2"))
        {
            ControlCenter.FinishedGuanQia.Add("T_2");
            ObjectSystem.AddThings("晶石", 3);
        }

        if (ControlCenter.FinishedGuanQia.Contains("T_2") && ControlCenter.FinishedGuanQia.Contains("1_2"))
        {
            if (!ControlCenter.CouldStartGuanQia.Contains("1_3"))
            {
                ControlCenter.CouldStartGuanQia.Add("1_3");
            }
        }
        Map.ReloadMap();
        Map.SaveCouldStartMap();
    }
}
