using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Boos_4 : MonoBehaviour
{
    bool k0 = false;
    int StartHuDunMax = 10;
    public List<Transform> JA_1 = new List<Transform>();

    void Start()
    {
        StartHuDunMax = this.transform.Find("HuDun").GetComponent<HuDun>().HuDunMaxShengMing;
    }

    void Update()
    {
        float ShengMingElse = (float)this.GetComponent<Inspector>().ShengMing[0] / this.GetComponent<Inspector>().ShengMing[1];
        if (ShengMingElse <= 0.8F)
        {
            this.transform.Find("WuQi6").GetComponent<Weapon>().enabled = true;
        }
        if (ShengMingElse <= 0.6F)
        {
            this.transform.Find("WuQi0").GetComponent<Weapon>().enabled = true;
        }
        if (ShengMingElse <= 0.4F)
        {
            this.transform.Find("WuQi7").GetComponent<Weapon>().enabled = true;
        }
        if (ShengMingElse <= 0.1F)
        {
            this.transform.Find("WuQi6").GetComponent<Weapon>().enabled = true;
            if (!k0)
            {
                this.transform.Find("HuDun").GetComponent<HuDun>().CreateNewHuDun();
                k0 = true;
                foreach(Transform T in JA_1)
                {
                    T.transform.Find("WuQi0").GetComponent<Weapon>().IntervalTime = 0.5F;
                }
            }
        }
    }
}