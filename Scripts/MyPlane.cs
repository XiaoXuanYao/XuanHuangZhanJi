using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlane : MonoBehaviour
{
    public static int TotalBulletUse = 0;
    public static int TotalBulletHit = 0;
    public static int MyPlaneWasHit = 0;
    public static int DestroyDiPlane = 0;
    public static int DiPlanePassed = 0;

    public static void CallBack(CallBackType C, int Value)
    {
        if (C == CallBackType.PlaneWasHitten)
        {
            MyPlaneWasHit += 1;
        }
        if (C == CallBackType.DiPlanePassed)
        {
            DiPlanePassed += 1;
        }
    }
    public static void CallBack(CallBackType C, Transform Value)
    {
        if (C == CallBackType.NewBulletWasCreate)
        {
            TotalBulletUse += 1;
        }
        if (C == CallBackType.BulletHitTheTarget)
        {
            TotalBulletHit += 1;
            if (((OnUpdate.LastMingZhongDiObject != Value && !Value.GetComponent<Bullet>()
                && OnUpdate.CouldChangeAim) || OnUpdate.LastMingZhongDiObject == null || !OnUpdate.LastMingZhongDiObject)
                && Value.name != "HuDun" && Value.gameObject.layer != 11)
            {
                OnUpdate.LastMingZhongDiObject = Value;
                OnUpdate.CouldChangeAim = false;
                GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(OnUpdate.ResetCouldChangeAim());
            }
            else if (Value.name == "HuDun" && Value.gameObject.layer != 11)
            {
                OnUpdate.DiHuDun = Value.parent;
                OnUpdate.LastMingZhongDiObject = Value.parent.parent;
                OnUpdate.CouldChangeAim = false;
                GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(OnUpdate.ResetCouldChangeAim());
            }
            else if (OnUpdate.LastMingZhongDiObject == Value)
            {
                OnUpdate.ChangeAimTimeCount = 6.5F;
            }
        }
        if (C == CallBackType.DestroyDiPlane)
        {
            DestroyDiPlane += 1;
            switch (Value.GetComponent<Inspector>().PlaneNameID)
            {
                #region FS_1
                case "FS_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.1F));
                    ObjectSystem.AddThings("FS-1碎片", (int)(Random.value * 1.012F));
                    break;
                #endregion
                
                #region TU_1
                case "TU_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.33F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.075F));
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.166F));
                    ObjectSystem.AddThings("TU-1碎片", (int)(Random.value * 1.01F));
                    break;
                #endregion

                #region LS_1
                case "LS_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 2.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.33F));
                    break;
                #endregion

                #region BR_1
                case "BR_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.33F));
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.2));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.05F));
                    break;
                #endregion

                #region FS_2
                case "FS_2":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 2.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.5F));
                    ObjectSystem.AddThings("硅-30", (int)(Random.value * 1.1F));
                    break;
                #endregion

                #region TU_2
                case "TU_2":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 2.75F));
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.33F));
                    ObjectSystem.AddThings("构架铁", (int)(Random.value * 1.125F));
                    break;
                #endregion

                #region HZ_1
                case "HZ_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.75F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.125F));
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.125F));
                    ObjectSystem.AddThings("HZ-1碎片", (int)(Random.value * 1.005F));
                    break;
                #endregion

                #region Boos_1
                case "Boos_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 2.75F + 2.5F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.125F + 1));
                    break;
                #endregion

                #region SQ_1
                case "SQ_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.15F));
                    break;
                #endregion

                #region BOOS_2
                case "BOOS_2":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 2.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.3F) + 1);
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.3F));
                    break;
                #endregion

                #region JY_1
                case "JY_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.15F));
                    break;
                #endregion

                #region JY_2
                case "JY_2":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.25F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.15F));
                    break;
                #endregion

                #region FR_1
                case "FR_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.33F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.18F));
                    break;
                #endregion

                #region JA_1
                case "JA_1":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.33F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.18F));
                    break;
                #endregion

                #region BOOS_3
                case "BOOS_3":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 1.66F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.25F));
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.25F));
                    break;
                #endregion

                #region BOOS_4
                case "BOOS_4":
                    ObjectSystem.AddThings("晶石", (int)(Random.value * 2.66F));
                    ObjectSystem.AddThings("冲子板", (int)(Random.value * 1.33F));
                    ObjectSystem.AddThings("抵子板", (int)(Random.value * 1.33F));
                    break;
                    #endregion
            }
            foreach (ExtraPricing P in Value.GetComponent<Inspector>().extraPricings)
            {
                ObjectSystem.AddThings(P.ObjectName, P.BasicNum + (int)(Random.value * (P.RandomNum + 1)));
            }
        }
    }
}

public enum CallBackType
{
    NewBulletWasCreate,
    BulletHitTheTarget,
    PlaneWasHitten,
    BulletLifetimeOver,
    DestroyDiPlane,
    DiPlanePassed,
}
