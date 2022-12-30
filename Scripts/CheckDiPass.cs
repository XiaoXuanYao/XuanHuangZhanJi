using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDiPass : MonoBehaviour
{
    public static int DiPass = 0;

    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.gameObject.layer == 10 && !Obj.transform.GetComponent<Bullet>() && !Obj.transform.GetComponent<HuDun>())
        {
            DiPass++;
            if (DiPass >= 3)
            {
                Map.FinishGuanQia(Map.GuanQiaChoosed, "", false);
            }
            Destroy(Obj.gameObject);
        }
    }
}
