using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_T_3 : MonoBehaviour
{
    bool k = false;
    void Start()
    {
        if (!Fade.StringToTransform("Space/普战-1（镜像）"))
        {
            Invoke("Start", 0.05F);
        }
        else
        {
            Fade.StringToTransform("Space/普战-1（镜像）").GetComponent<Inspector>().ShengMing = GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing;
            Fade.StringToTransform("Space/普战-1（镜像）").GetComponent<DiMove>().t = 1;
            k = true;
        }
    }

    void Update()
    {
        if (k)
        {
            if (Fade.StringToTransform("Space/普战-1（镜像）") && Fade.StringToTransform("Space/灵龟-1"))
            {
                Transform Obj = Fade.StringToTransform("Space/普战-1（镜像）");
                Obj.position = new Vector3(GameObject.Find("MyPlane").transform.position.x, -GameObject.Find("MyPlane").transform.position.y,
                    GameObject.Find("MyPlane").transform.position.z);
                Obj.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + GameObject.Find("MyPlane").transform.rotation.eulerAngles.z));
                Obj.GetComponent<Inspector>().ShengMing[0] = Mathf.Min(Obj.GetComponent<Inspector>().ShengMing[0]
                    , GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[0]);
                GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[0] = Obj.GetComponent<Inspector>().ShengMing[0];
            }
            else if (!Fade.StringToTransform("Space/灵龟-1"))
            {
                Transform Obj = Fade.StringToTransform("Space/普战-1（镜像）");
                GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing = new int[2] { Obj.GetComponent<Inspector>().ShengMing[0],
                    Obj.GetComponent<Inspector>().ShengMing[1]};
                Obj.GetComponent<Inspector>().ShengMing[0] = 0;
                k = false;
            }
        }
    }
}
