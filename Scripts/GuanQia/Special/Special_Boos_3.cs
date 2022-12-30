using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Boos_3 : MonoBehaviour
{
    bool k0 = false;
    bool k1 = false;
    int StartHuDunMax = 10;

    void Start()
    {
        StartHuDunMax = this.transform.Find("HuDun").GetComponent<HuDun>().HuDunMaxShengMing;
    }

    void Update()
    {
        float ShengMingElse = (float)this.GetComponent<Inspector>().ShengMing[0] / this.GetComponent<Inspector>().ShengMing[1];
        if (ShengMingElse <= 0.8F)
        {
            this.transform.Find("WuQi4").GetComponent<Weapon>().enabled = true;
            this.transform.Find("WuQi5").GetComponent<Weapon>().enabled = true;
            this.transform.Find("WuQi6").GetComponent<Weapon>().enabled = true;
            this.transform.Find("WuQi7").GetComponent<Weapon>().enabled = true;
        }
        if (ShengMingElse <= 0.66F)
        {
            this.transform.Find("WuQi8").GetComponent<Weapon>().enabled = true;
            this.transform.Find("WuQi9").GetComponent<Weapon>().enabled = true;
            this.transform.Find("WuQi0").GetComponent<Weapon>().IntervalTime = 4.9F;
        }
        if (ShengMingElse <= 0.33F)
        {
            this.transform.Find("WuQi10").GetComponent<Weapon>().enabled = true;
            this.transform.Find("WuQi0").GetComponent<Weapon>().IntervalTime = 3.75F;
            if (!this.transform.Find("HuDun").GetComponent<HuDun>().IsHuDunExist && !k0)
            {
                this.transform.Find("HuDun").GetComponent<HuDun>().CreateNewHuDun();
                k0 = true;
            }
        }
        if (ShengMingElse <= 0.08F)
        {
            this.transform.Find("WuQi0").GetComponent<Weapon>().IntervalTime = 1.25F;
            if (!k1)
            {
                this.transform.Find("WuQi0").GetComponent<Weapon>().BulletNum = 2;
                this.transform.Find("HuDun").GetComponent<HuDun>().HuDunMaxShengMing = (int)(StartHuDunMax * 1.5F);
                this.transform.Find("HuDun").GetComponent<HuDun>().CreateNewHuDun();
                k1 = true;
            }
        }
    }
}
