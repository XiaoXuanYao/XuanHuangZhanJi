using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    public static bool LeftButtonDown = false;
    public static bool RightButtonDown = false;

    public static bool GoLeft = false;
    public static bool GoRight = false;

    void Update()
    {
        if (Mathf.Abs(GameObject.Find("MyPlane").GetComponent<Rigidbody2D>().velocity.x) < 2.8F)
        {
            if (Input.GetKey(KeyCode.A) || GoLeft)
            {
                GameObject.Find("MyPlane").GetComponent<Rigidbody2D>().AddForce(new Vector2(-800F, 0) * FPS.FPSTime);
                GameObject.Find("MyPlane").transform.rotation = Quaternion.Slerp(this.transform.rotation
                    , Quaternion.Euler(new Vector3(0, 0, 30F)), 5F * FPS.FPSTime);
            }
            else if (Input.GetKey(KeyCode.D) || GoRight)
            {
                GameObject.Find("MyPlane").GetComponent<Rigidbody2D>().AddForce(new Vector2(800F, 0) * FPS.FPSTime);
                GameObject.Find("MyPlane").transform.rotation = Quaternion.Slerp(this.transform.rotation
                    , Quaternion.Euler(new Vector3(0, 0, -30F)), 5F * FPS.FPSTime);
            }
            else if (this.transform.rotation.eulerAngles.magnitude > 0.5F)
            {
                GameObject.Find("MyPlane").transform.rotation = Quaternion.Slerp(this.transform.rotation
                    , Quaternion.Euler(new Vector3(0, 0, 0)), 5F * FPS.FPSTime);
            }
        }
    }
}
