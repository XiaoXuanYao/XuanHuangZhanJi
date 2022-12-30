using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class FPS : MonoBehaviour
{
    public static float FPSTime = 0.03F; //单位 秒
    public float FPSTime0 = 0.03F;
    DateTime ThisTime;
    DateTime LastTime;
    void Start()
    {
        ThisTime = DateTime.Now;
    }

    void Update()
    {
        LastTime = ThisTime;
        ThisTime = DateTime.Now;
        TimeSpan Time = ThisTime - LastTime;
        FPSTime = FPSTime0 = ((float)Time.TotalMilliseconds / 1000 * 3 + FPS.FPSTime) / 4;
        if (FPSTime > 0.1F)
        {
            FPSTime = 0.001F;
        }
        if (FPSTime < 0.02F)
        {
            Thread.Sleep(15);
        }
        if (ControlCenter.UnActive <= 64)
        {
            Thread.Sleep(ControlCenter.UnActive * 8);
        }
        else
        {
            Thread.Sleep(1000);
        }
    }
}
