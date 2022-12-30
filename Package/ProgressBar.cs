using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float Finishing = 0;
    public float BasicFinishing = 0.1F; //初始长度值
    public Transform Scrollbar;
    void Update()
    {
        Scrollbar.GetComponent<Scrollbar>().size = Finishing * (1 - BasicFinishing) + BasicFinishing;
    }
}
