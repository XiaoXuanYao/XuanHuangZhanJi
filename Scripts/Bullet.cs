using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ZiDanKind Kind = ZiDanKind.普通子弹;
    public float RotationRectify = 0;
    public Vector2 Direction = new Vector2(0, 1);
    public float Velocity = 4;
    public float MaxAngleVelocity = 0;
    bool HasBoomed = false;

    [Tooltip("攻击修正（float[]{Min, Max}）  // 单位：倍")]
    public float[] GongJiRectify = new float[] { 1, 1 };
    public Transform Aim;

    void Start()
    {
        if (Kind == ZiDanKind.激光束)
        {
            Invoke("FadeRay", 0.3F);
            Destroy(this.gameObject, 1F);
        }
    }

    void FadeRay()
    {
        Fade.NewFade(this.transform, 1, 0, 0.24F, true, true);
    }

    void Update()
    {
        if (!HasBoomed)
        {
            if (Direction != new Vector2(0, 0))
            {
                if ((this.GetComponent<Rigidbody2D>() && this.GetComponent<Rigidbody2D>().velocity.x != 0) || Kind == ZiDanKind.激光束)
                {
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationRectify
                        - Vector2.Angle(new Vector2(0, 1), Direction) * Mathf.Sign(Direction.x)));
                }
                else
                {
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationRectify));
                }
            }
            if (Kind == ZiDanKind.追踪子弹)
            {
                if (Aim == null || !Aim)
                {
                    List<Transform> T = new List<Transform>();
                    if (GameObject.Find("MyPlane").layer != this.gameObject.layer)
                    {
                        T.Add(GameObject.Find("MyPlane").transform);
                    }
                    for (int i = 0; i < GameObject.Find("Space").transform.childCount; i++)
                    {
                        if (GameObject.Find("Space").transform.GetChild(i).GetComponent<Inspector>()
                            && !GameObject.Find("Space").transform.GetChild(i).GetComponent<Bullet>()
                            && GameObject.Find("Space").transform.GetChild(i).gameObject.layer != this.gameObject.layer)
                        {
                            T.Add(GameObject.Find("Space").transform.GetChild(i));
                        }
                    }
                    if (T.Count > 0)
                    {
                        Aim = T[(int)(Random.value * T.Count)];
                    }
                }
                if (Aim != null && Aim)
                {
                    Vector2 aimDirection = (Aim.position - this.transform.position).normalized;
                    float dAngle = Vector2.SignedAngle(Direction, aimDirection);
                    float Angle = Mathf.Acos(Direction.x) / Mathf.PI * 180 * Mathf.Sign(Direction.y);
                    float dAddAngle = MaxAngleVelocity * FPS.FPSTime;
                    if (dAddAngle < Mathf.Abs(dAngle))
                    {
                        Angle += dAddAngle * Mathf.Sign(dAngle);
                    }
                    else
                    {
                        Angle += dAngle;
                    }
                    Angle = Angle / 180F * Mathf.PI;
                    Direction = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
                    this.GetComponent<Rigidbody2D>().velocity = Direction * Mathf.Abs(Velocity);
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D Obj)
    {
        if (Obj.gameObject.layer != this.gameObject.layer && Obj.gameObject.layer != 11 && !HasBoomed)
        {
            if (Kind != ZiDanKind.激光束)
            {
                HasBoomed = true;
                Boom.NewBoom(Obj.bounds.ClosestPoint(this.transform.position), BoomType.Small);
                Invoke("DestroyThis", this.gameObject.GetComponent<Inspector>().DestroyedTime);
                if (this.GetComponent<Rigidbody2D>())
                {
                    Destroy(this.GetComponent<Rigidbody2D>(), 0.1F);
                }
                Fade.NewFade(this.transform, 1, 0, this.gameObject.GetComponent<Inspector>().DestroyedTime, true, false);
            }

            if (Obj.GetComponent<Inspector>())
            {
                int ShengMingJian = (int)(this.GetComponent<Inspector>().GongJi * Random.Range(GongJiRectify[0], GongJiRectify[1]));
                float KeJiGongJiS = int.Parse(PlanesMessage.ChuZhanPlane.Replace("FS_1", "2").Replace("TU_1", "1").Replace("HZ_1", "2")
                    .Replace("BR_1", "1").Replace("FR_1", "3"));
                ShengMingJian+= (int)(KeJiFun.GetKeJiKeyGrade(PlaneUIClick.OnChosenPlane + "Basic") * KeJiGongJiS);
                if (this.GetComponent<Inspector>().Message == "MyPlaneBullet")
                {
                    ShengMingJian += KeJiFun.GetKeJiKeyGrade("GongJi") * 2;
                    ShengMingJian = (int)(ShengMingJian * (1 + KeJiFun.GetKeJiKeyGrade("GongJiPersent") * 0.01F));
                }
                if (Obj.name == "MyPlane")
                {
                    ShengMingJian = (int)Mathf.Max((ShengMingJian - KeJiFun.GetKeJiKeyGrade("ZhanJiJianShang"))
                        * (1 - KeJiFun.GetKeJiKeyGrade("ZhanJiJianShang") * 0.01F), 1);
                }
                if (Obj.name == "HuDun")
                {
                    if (Obj.transform.parent.parent.name == "MyPlane")
                    {
                        ShengMingJian = (int)Mathf.Max((ShengMingJian - KeJiFun.GetKeJiKeyGrade("HuDunJianShang"))
                            * (1 - KeJiFun.GetKeJiKeyGrade("HuDunJianShang") * 0.01F), 1);
                    }
                    if (this.name == "MA_FR0" || this.name == "MA_FR1")
                    {
                        ShengMingJian = Mathf.Max((int)(ShengMingJian / 1.5F - 2.5F), 1);
                    }
                    if (Map.GuanQiaChoosed == "2_5")
                    {
                        if (this.name == "FS_ATS0")
                        {
                            ShengMingJian = (int)(ShengMingJian * 1.6F);
                        }
                        if (this.name == "MA_FR0" || this.name == "MA_FR1")
                        {
                            ShengMingJian = (int)(ShengMingJian / 4.2F);
                        }
                    }
                }
                if (Map.GuanQiaChoosed == "2_8")
                {
                    if (this.gameObject.layer == 9)
                    {
                        ShengMingJian = (int)(ShengMingJian * Random.value * 16);
                    }
                    if (this.gameObject.layer == 10 && (this.name == "MA_FR0" || this.name == "MA_FR1") && Obj.name == "HuDun")
                    {
                        ShengMingJian = (int)((float)ShengMingJian / 2);
                    }
                }
                Obj.GetComponent<Inspector>().ShengMing[0] -= ShengMingJian;

                #region # MyPlane被敌方命中回调
                if (Obj.name == "MyPlane")
                {
                    MyPlane.CallBack(CallBackType.PlaneWasHitten, 1);
                }
                #endregion
            }

            if (this.name == "MA_FR1")
            {
                int Num = (int)(Random.value * 3.6F + 4.2F);
                for (int i = 0; i < Num; i++)
                {
                    Transform ChildBullet = Instantiate(Fade.StringToTransform("ObjectModels/MA_FR0"), GameObject.Find("Space").transform);
                    ChildBullet.transform.position = this.transform.position;
                    ChildBullet.gameObject.layer = this.gameObject.layer;
                    GameObject.Find("EventSystem").GetComponent<OnUpdate>().StartCoroutine(this.GetComponent<Weapon>().DestroyBullet(ChildBullet));
                    ChildBullet.name = "MA_FR0";
                    ChildBullet.gameObject.SetActive(true);
                    ChildBullet.localScale = new Vector3(0.5F, 0.5F, 1);
                    float R = 360F / Num * i / 180 * Mathf.PI;
                    ChildBullet.GetComponent<Bullet>().Direction = new Vector2(Mathf.Cos(R), Mathf.Sin(R));
                    ChildBullet.GetComponent<Bullet>().Velocity = 3.5F;
                    ChildBullet.GetComponent<Rigidbody2D>().velocity = ChildBullet.GetComponent<Bullet>().Direction * 6;
                    ChildBullet.GetComponent<Inspector>().GongJi = this.GetComponent<Inspector>().GongJi;
                    ChildBullet.GetComponent<Bullet>().GongJiRectify = new float[2] { 0.35F, 0.6F };
                    ChildBullet.transform.position += new Vector3(Random.value / 2 - 0.5F, Random.value / 2 - 0.25F);
                }
            }

            #region # MyPlane子弹命中敌方回调
            if (this.GetComponent<Inspector>().Message == "MyPlaneBullet")
            {
                MyPlane.CallBack(CallBackType.BulletHitTheTarget, Obj.transform);
            }
            #endregion
        }
    }

    void DestroyThis()
    {
        if (this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}

public enum ZiDanKind
{
    普通子弹,
    追踪子弹,
    破甲弹,
    激光束,
}