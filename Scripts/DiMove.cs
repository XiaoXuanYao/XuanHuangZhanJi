using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiMove : MonoBehaviour
{
    public BezierEquation Road = new BezierEquation(new Vector2[] { new Vector2(0, 6), new Vector2(0, -6) });
    public float t = 0.00001F;
    DateTime LastTime;
    Vector2 LastPoint = Vector2.zero;
    public float Velocity = 1;
    /// <summary>
    /// 分[Repeat]段计算并取最接近的值
    /// </summary>
    [Tooltip("可以使路径更精确，但会增加计算量影响性能")]
    public int Repeat = 1;

    Vector2 FaceTo = new Vector2(0, 1); // 朝向

    void Start()
    {
        LastPoint = Road.Count(t);
        LastTime = DateTime.Now;
    }

    void Update()
    {
        float x = 0;
        Vector2 ThisPoint = LastPoint;
        /*t += FPS.FPSTime * Velocity / (Road.Points[Road.Points.Length - 1] - Road.Points[0]).magnitude / Repeat;
        Vector2 This = Road.Count(t) * 0.95F;
        float x0 = (This - Last).magnitude;
        if (x + x0 >= Velocity * FPS.FPSTime)
        {
            float x1 = x + x0 - Velocity * FPS.FPSTime;
            float t0 = x1 / x0 * FPS.FPSTime * Velocity / Repeat;
            t -= t0;
            Last += (This - Last) * t0;
            break;
        }
        else
        {
            x = x + x0;
            Last = This;
        }*/

        if (t <= 0.99F)
        {
            //------------------新算法---------------------------
            //先计算点数在曲线上等分最近的位置：
            if (ControlCenter.CalculateType == 0)
            {
                float NearlyPoint = Mathf.Round(t * Road.Points.Length) / Road.Points.Length;
                float Curvature = 1;
                if (NearlyPoint <= 0.5F)
                {
                    float p = (Road.Count(NearlyPoint) - Road.Count(NearlyPoint + 1F / (Road.Points.Length - 1))).magnitude;
                    float p0 = (Road.Count(NearlyPoint) - Road.Count(NearlyPoint + 1F / (Road.Points.Length - 1) / 2)).magnitude;
                    float p1 = (Road.Count(NearlyPoint + 1F / (Road.Points.Length - 1) / 2) - Road.Count(NearlyPoint + 1F / (Road.Points.Length - 1))).magnitude;
                    Curvature = p / (p0 + p1);
                    Curvature *= Mathf.Pow(Curvature, 0.25F);
                }
                else
                {
                    float p = (Road.Count(NearlyPoint) - Road.Count(NearlyPoint - 1F / (Road.Points.Length - 1))).magnitude;
                    float p0 = (Road.Count(NearlyPoint) - Road.Count(NearlyPoint - 1F / (Road.Points.Length - 1) / 2)).magnitude;
                    float p1 = (Road.Count(NearlyPoint - 1F / (Road.Points.Length - 1) / 2) - Road.Count(NearlyPoint - 1F / (Road.Points.Length - 1))).magnitude;
                    Curvature = p / (p0 + p1);
                    Curvature *= Mathf.Pow(Curvature, 0.25F);
                }
                float x_All = (Road.Points[0] - Road.Points[Road.Points.Length - 1]).magnitude;
                x += Velocity * FPS.FPSTime;
                float dt = x / x_All;
                float dx = (LastPoint - Road.Count(t + dt)).magnitude * Curvature;
                ThisPoint = Road.Count(t + dt * (Velocity * FPS.FPSTime / dx));
                t += dt * (Velocity * FPS.FPSTime / dx);
            }
            FaceTo = ThisPoint - LastPoint;
            this.transform.position = LastPoint;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Vector2.Angle(FaceTo, new Vector2(0, 1)) * Mathf.Sign(FaceTo.x)));
            this.transform.GetComponent<Rigidbody2D>().velocity = FaceTo / ((float)(DateTime.Now - LastTime).TotalMilliseconds / 1000);
            LastPoint = ThisPoint;
            LastTime = DateTime.Now;
        }
        else
        {
            if (this.transform.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01F)
            {
                this.transform.GetComponent<Rigidbody2D>().velocity
                    = Vector2.Lerp(this.transform.GetComponent<Rigidbody2D>().velocity, Vector2.zero, FPS.FPSTime);
            }
            else
            {
                this.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

    //----------------------自毁模块--------------------------
    bool HasDestroyed = false;
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.gameObject.layer != this.gameObject.layer && Obj.gameObject.layer != 11 && !HasDestroyed
            && Obj.gameObject.GetComponent<Inspector>())
        {
            Obj.gameObject.GetComponent<Inspector>().ShengMing[0] -= (int)(this.GetComponent<Inspector>().ShengMing[0]
                * (0.9F + UnityEngine.Random.value * 0.2F)) +
                (int)(this.GetComponent<Inspector>().GongJi * (0.9F + UnityEngine.Random.value * 0.2F));
            this.GetComponent<Inspector>().ShengMing[0] = 0;
            HasDestroyed = true;
        }
    }
    //-------------------------end----------------------------
}

[System.Serializable]
public class BezierEquation
{
    public Vector2[] Points = new Vector2[] { Vector2.zero, Vector2.zero };
    public BezierEquation(Vector2[] KeyPoints)
    {
        Points = KeyPoints;
    }

    /// <summary>
    /// 计算曲线在1/t处的位置
    /// </summary>
    /// <param name="t">t: [0,1] ，超出按端点值计算</param>
    /// <returns></returns>
    public Vector2 Count(float t)
    {
        if (Points.Length == 1)
        {
            return Points[0];
        }
        if (t <= 0)
        {
            t = 0.00001F;
        }
        if (t >= 1)
        {
            t = 0.99999F;
        }
        Vector2 B = Vector2.zero;
        int n = Points.Length - 1;
        for (int i = 0; i <= n; i++)
        {
            B += Factorial(n) / (Factorial(n - i) * Factorial(i)) * Points[i] * Mathf.Pow(1 - t, n - i) * Mathf.Pow(t, i);
        }
        return B;
    }

    /// <summary>
    /// 计算Value的阶乘
    /// </summary>
    /// <param name="BaseValue"></param>
    /// <returns></returns>
    public static int Factorial(int Value)
    {
        int k = 1;
        for (int i = Value; i > 0; i--)
        {
            k *= i;
        }
        return k;
    }
}