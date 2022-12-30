using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static bool StartOnLoad = false;
    string thisID;

    [Header("全类型通用")]
    [Tooltip("路径种类")]
    public RouteKind RouteKind = RouteKind.Line;
    [Tooltip("子弹物体标准(模板)")]
    public Transform Bullet;
    [Tooltip("子弹发射周期间隔")]
    public float IntervalTime = 1;
    [Tooltip("子弹生命周期")]
    public float BulletLiftTime = 7.5F;
    [Tooltip("子弹旋转矫正")]
    public float BulletRotationRectify = 0;
    [Tooltip("忽略父物体旋转")]
    public bool IgnoreParentRotation = false;
    [Tooltip("子弹位置矫正")]
    public Vector3 BulletPositionRectify = Vector3.zero;
    [Tooltip("子弹速度")]
    public float BulletVelocity = 2;
    [Tooltip("轨迹旋转基本量")]
    public float BasicRoadRotation = 0;
    [Tooltip("角度偏移量  |  (float) 0 ~ 1")]
    public float AngleOffset = 0;
    [Tooltip("发射数量")]
    public float BulletNum = 1;
    [Tooltip("发射间隔")]
    public float BulletDuringTime = 0;
    [Tooltip("WuQiSettingGongJiAdd：攻击百分比附加")]
    public float WuQiSettingGongJiAdd = 0;
    [Tooltip("WuQiSettingGongJiPinLv：攻击频率")]
    public float WuQiSettingGongJiPinLv = 1;
    [Tooltip("目标敌人")]
    public Transform Aim;

    [Header("扇形（Fan）")]
    [Tooltip("扇形角度    Vector2(左边界，右边界)")]
    public Vector2 FanRadius = new Vector2(0, 0);

    [Header("激光（Ray）")]
    public Vector2 Direction = new Vector2(1, 0);
    public Color RayColor = new Color(1, 1, 1, 1);
    public bool RandomAimPerAttack = false;
    public float RaySize = 1;

    public static List<string> AllLauncher = new List<string>();
    public static List<string> StopedLauncher = new List<string>();
    public delegate void LcDelegate();
    public static LcDelegate Delegates = null;
    /// <summary>
    /// 加载(并重置)全部武器（统一重新开始发射）
    /// </summary>
    public static void ReloadAll()
    {
        AllLauncher.Clear();
        StopedLauncher.Clear();
        LcDelegate Delegates0 = Delegates;
        Delegates = null;
        Delegates0();
    }

    public static void StopAll()
    {
        StopedLauncher = AllLauncher;
        StartOnLoad = false;
    }

    public static void StartAll()
    {
        StopedLauncher = new List<string>();
        StartOnLoad = true;
    }

    void Start()
    {
        LcDelegate D = new LcDelegate(this.Start);
        Delegates = (LcDelegate)System.Delegate.Combine(Delegates, D);
        if (this)
        {
            StartCoroutine(Launching());
        }
    }

    public IEnumerator Launching()
    {
        thisID = (System.DateTime.Now - System.DateTime.MinValue).Ticks.ToString() + ((int)(Random.value * 100)).ToString() + AllLauncher.Count;
        AllLauncher.Add(thisID);
        if (!StartOnLoad)
        {
            StopedLauncher.Add(thisID);
        }

        while (true)
        {
            yield return new WaitForSeconds(0.001F);  //避免陷入死循环
            while (StopedLauncher.Contains(thisID))  //暂停发射
            {
                yield return new WaitForFixedUpdate();
            }
            if (!AllLauncher.Contains(thisID))
            {
                yield break;
            }
            if (this.transform.parent.name != "MyPlane")
            {
                yield return new WaitForSeconds(IntervalTime / WuQiSettingGongJiPinLv);
            }
            else
            {
                yield return new WaitForSeconds(IntervalTime / WuQiSettingGongJiPinLv / (1 + KeJiFun.GetKeJiKeyGrade("GongJiDuringTime") * 0.03F));
            }
            if (RouteKind == RouteKind.Line)
            {
                for (int i = 0; i < BulletNum; i++)
                {
                    Transform Obj = Instantiate(Bullet, GameObject.Find("Space").transform);
                    Obj.transform.position = this.transform.position + BulletPositionRectify;
                    Obj.gameObject.layer = this.gameObject.layer;
                    StartCoroutine(DestroyBullet(Obj));
                    Obj.name = Bullet.name;
                    Obj.gameObject.SetActive(true);
                    Obj.GetComponent<Bullet>().RotationRectify = BulletRotationRectify;
                    float R;
                    if (!IgnoreParentRotation)
                    {
                        R = (this.transform.localRotation.eulerAngles.z + this.transform.parent.localRotation.eulerAngles.z
                            + 90 + (Random.value - 0.5F) * AngleOffset * 360 + BasicRoadRotation)
                            / 180 * Mathf.PI;
                    }
                    else
                    {
                        R = (this.transform.localRotation.eulerAngles.z + 90 + (Random.value - 0.5F) * AngleOffset * 360 + BasicRoadRotation)
                            / 180 * Mathf.PI;
                    }
                    Obj.GetComponent<Bullet>().Direction = new Vector2(Mathf.Cos(R), Mathf.Sin(R));
                    Obj.GetComponent<Bullet>().Velocity = BulletVelocity;
                    if (Obj.GetComponent<Rigidbody2D>())
                    {
                        Obj.GetComponent<Rigidbody2D>().velocity = Obj.GetComponent<Bullet>().Direction * BulletVelocity * 1.35F;
                    }
                    if (this.gameObject.layer == 9)
                    {
                        Obj.GetComponent<Inspector>().GongJi = (int)((Obj.GetComponent<Inspector>().GongJi + ControlCenter.GongJiAddNum)
                            * (1 + ControlCenter.GongJiAddPercent + WuQiSettingGongJiAdd / 100));
                    }

                    #region # MyPlane新发射子弹回调
                    if (this.transform.parent.name == "MyPlane")
                    {
                        Obj.GetComponent<Inspector>().Message = "MyPlaneBullet";
                        MyPlane.CallBack(CallBackType.NewBulletWasCreate, Bullet);
                    }
                    #endregion

                    if (i != BulletNum - 1)
                    {
                        yield return new WaitForSeconds(BulletDuringTime);
                    }
                }
            }
            if (RouteKind == RouteKind.Fan)
            {
                for (int i = 0; i < BulletNum; i++)
                {
                    Transform Obj = Instantiate(Bullet, GameObject.Find("Space").transform);
                    Obj.transform.position = this.transform.position + BulletPositionRectify;
                    Obj.gameObject.layer = this.gameObject.layer;
                    StartCoroutine(DestroyBullet(Obj));
                    Obj.name = Bullet.name;
                    Obj.gameObject.SetActive(true);
                    Obj.GetComponent<Bullet>().RotationRectify = BulletRotationRectify;
                    float R = (this.transform.rotation.eulerAngles.z + 90 + (Random.value - 0.5F) * AngleOffset * 360
                        + BasicRoadRotation + FanRadius.x + i * (FanRadius.y - FanRadius.x) / (BulletNum - 1))
                        / 180 * Mathf.PI;
                    Obj.GetComponent<Bullet>().Direction = new Vector2(Mathf.Cos(R), Mathf.Sin(R));
                    Obj.GetComponent<Bullet>().Velocity = BulletVelocity;
                    Obj.GetComponent<Rigidbody2D>().velocity = Obj.GetComponent<Bullet>().Direction * BulletVelocity * 1.2F;
                    if (this.gameObject.layer == 9)
                    {
                        Obj.GetComponent<Inspector>().GongJi = (int)((Obj.GetComponent<Inspector>().GongJi + ControlCenter.GongJiAddNum)
                            * (1 + ControlCenter.GongJiAddPercent + WuQiSettingGongJiAdd / 100));
                    }


                    #region # MyPlane新发射子弹回调
                    if (this.transform.parent.name == "MyPlane")
                    {
                        MyPlane.CallBack(CallBackType.NewBulletWasCreate, Bullet);
                    }
                    #endregion

                    if (i != BulletNum - 1)
                    {
                        yield return new WaitForSeconds(BulletDuringTime);
                    }
                }
            }
            if (RouteKind == RouteKind.Ray)
            {
                BulletLiftTime = 0.7F;
                ChangeAim();

                if (Vector2.Angle(new Vector2(Mathf.Cos((this.transform.rotation.eulerAngles.z + 90) / 180 * Mathf.PI)
                    , Mathf.Sin((this.transform.rotation.eulerAngles.z + 90) / 180 * Mathf.PI)), Direction) < 60)
                {
                    for (int i = 0; i < BulletNum; i++)
                    {
                        ChangeAim();
                        Transform Obj = Instantiate(Bullet, GameObject.Find("Space").transform);
                        Obj.gameObject.layer = this.gameObject.layer;
                        Obj.name = Bullet.name;

                        Direction += new Vector2(Random.value - 0.5F, Random.value - 0.5F) * AngleOffset;
                        Direction = Direction.normalized;
                        Obj.transform.position = this.transform.position + (Vector3)Direction * 8 + BulletPositionRectify + new Vector3(0, 0, -1);
                        Obj.GetComponent<SpriteRenderer>().size = new Vector3(1, 8.1F , 1);
                        Obj.GetComponent<Bullet>().Direction = Direction;
                        Obj.GetComponent<Bullet>().Velocity = 0;
                        Obj.transform.localScale *= RaySize;
                        Obj.transform.Find("Point").transform.localPosition = new Vector3(0, -4 * RaySize, 0);
                        Obj.GetComponent<SpriteRenderer>().color = RayColor;
                        Obj.GetComponent<BoxCollider2D>().size = new Vector2(0.6F, 7.6F);
                        Obj.transform.Find("Point").GetComponent<SpriteRenderer>().color = RayColor;
                        Fade.NewFade(Obj, 0, 1, 0.16F, true, true);
                        if (this.gameObject.layer == 9)
                        {
                            Obj.GetComponent<Inspector>().GongJi = (int)((Obj.GetComponent<Inspector>().GongJi + ControlCenter.GongJiAddNum)
                                * (1 + ControlCenter.GongJiAddPercent + WuQiSettingGongJiAdd / 100));
                        }

                        #region # MyPlane新发射子弹回调
                        if (this.transform.parent.name == "MyPlane")
                        {
                            Obj.GetComponent<Inspector>().Message = "MyPlaneBullet";
                            MyPlane.CallBack(CallBackType.NewBulletWasCreate, Bullet);
                        }
                        #endregion

                        yield return new WaitForSeconds(BulletDuringTime);
                    }
                }
            }
        }
    }

    void ChangeAim()
    {
        if (Aim == null || !Aim || RandomAimPerAttack)
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
        if (Aim != null)
        {
            Direction = (Aim.transform.position - this.transform.position).normalized;
        }
    }

    void OnDestroy()
    {
        AllLauncher.Remove(thisID);
    }

    public IEnumerator DestroyBullet(Transform Obj)
    {
        yield return new WaitForSeconds(BulletLiftTime);
        if (Obj)
        {
            Destroy(Obj.gameObject);
        }
    }
}

/// <summary>
/// 武器轨迹
/// </summary>
public enum RouteKind
{
    /// <summary>
    /// 直线轨迹
    /// </summary>
    Line,
    /// <summary>
    /// 扇形发散发射(多枚子弹)
    /// </summary>
    Fan,
    /// <summary>
    /// 激光
    /// </summary>
    Ray,
}