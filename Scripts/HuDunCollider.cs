using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuDunCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Obj)
    {
        if (Obj.gameObject.layer != this.gameObject.layer && Obj.gameObject.layer != 11 && !Obj.GetComponent<Bullet>())
        {
            float ShengMingJian = Mathf.Min(this.GetComponent<Inspector>().ShengMing[0] * (1F + Random.value * 0.1F),
                Obj.GetComponent<Inspector>().ShengMing[0] * (1F + Random.value * 0.1F));
            if (ShengMingJian > 0)
            {
                Obj.gameObject.GetComponent<Inspector>().ShengMing[0] -= (int)ShengMingJian;
                this.GetComponent<Inspector>().ShengMing[0] -= (int)ShengMingJian;
            }
        }
        if (this.transform.parent.parent.name == "MyPlane")
        {
            if (Obj.name == "HuDun")
            {
                OnUpdate.LastMingZhongDiObject = Obj.transform.parent.parent;
            }
            else if (!Obj.GetComponent<Bullet>())
            {
                OnUpdate.LastMingZhongDiObject = Obj.transform;
            }
        }
    }
}
