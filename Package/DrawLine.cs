using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    public Transform ModleObject;
    public Vector2 StartPoint = Vector2.zero;
    public Vector2 EndPoint = Vector2.zero;
    void DrawNewLine(Vector2 StartPoint,Vector2 EndPoint)
    {
        Vector2 Position = (StartPoint + EndPoint) / 2;
        float k = (StartPoint.y - EndPoint.y) / (StartPoint.x - EndPoint.x);
        float Rotation = Mathf.Atan(k) / Mathf.PI * 180;
        Transform Obj = Instantiate(ModleObject, Position, Quaternion.Euler(new Vector3(0, 0, Rotation)), this.transform);
        Obj.GetComponent<RectTransform>().sizeDelta = new Vector2((StartPoint - EndPoint).magnitude, 3);
        Obj.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (StartPoint == Vector2.zero)
            {
                StartPoint = Input.mousePosition;
            }
            else
            {
                EndPoint = Input.mousePosition;
                DrawNewLine(StartPoint, EndPoint);
                StartPoint = Vector2.zero;
                EndPoint = Vector2.zero;
            }
        }
    }
}
