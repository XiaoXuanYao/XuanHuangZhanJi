using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnActiveCheck : MonoBehaviour
{
    DateTime L;
    int LastActiveNum = 0;
    void Start()
    {
        L = DateTime.Now;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            L = DateTime.Now;
            ControlCenter.UnActive = 0;
        }
        if ((DateTime.Now - L).TotalSeconds <= 30)
        {
            ControlCenter.UnActive = 0;
        }
        if ((DateTime.Now - L).TotalSeconds > 30)
        {
            ControlCenter.UnActive = 1;
        }
        if ((DateTime.Now - L).TotalSeconds > 45)
        {
            ControlCenter.UnActive = 2;
        }
        if ((DateTime.Now - L).TotalSeconds > 60)
        {
            ControlCenter.UnActive = 4;
        }
        if ((DateTime.Now - L).TotalSeconds > 90)
        {
            ControlCenter.UnActive = 8;
        }
        if ((DateTime.Now - L).TotalSeconds > 180)
        {
            ControlCenter.UnActive = 16;
        }
        if ((DateTime.Now - L).TotalSeconds > 300)
        {
            ControlCenter.UnActive = 64;
        }
        if ((DateTime.Now - L).TotalSeconds > 600)
        {
            ControlCenter.UnActive = 256;
        }
        if ((DateTime.Now - L).TotalSeconds > 1800)
        {
            ControlCenter.UnActive = 1024;
        }
        if ((DateTime.Now - L).TotalSeconds > 3600)
        {
            ControlCenter.UnActive = 4096;
        }
        if (LastActiveNum != ControlCenter.UnActive && ControlCenter.UnActive >= 32)
        {
            ShowMessage.Message("不活跃指数：" + ControlCenter.UnActive);
            LastActiveNum = ControlCenter.UnActive;
        }
    }
}
