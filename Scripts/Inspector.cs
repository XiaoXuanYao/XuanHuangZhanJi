using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    public int[] ShengMing = new int[] { 10, 10 };  // [0]：当前生命值   [1]：生命值上限
    public int GongJi = 5;
    public BoomType DestroyedBoom = BoomType.Normal;
    public float BoomSize = 0.3F;
    public float DestroyedTime = 1;

    public string ID = "";
    public string Message = "";
    public string PlaneNameID = "";

    public bool IsDestroyed = false;

    public List<ExtraPricing> extraPricings = new List<ExtraPricing>();

    void Update()
    {
        if (this.ShengMing[0] <= 0 && !IsDestroyed && !GetComponent<Bullet>())
        {
            ShengMing[0] = 0;
            if (this.name != "MyPlane" && this.name != "HuDun")
            {
                if (this.gameObject.layer == 10)
                {
                    MyPlane.CallBack(CallBackType.DestroyDiPlane, this.transform);
                }
                Boom.NewBoom(this.transform.position, DestroyedBoom);
                Fade.NewFade(this.transform, 1, 0, DestroyedTime, true);
                Destroy(this.gameObject, DestroyedTime);
            }
            else if (this.name == "MyPlane")
            {
                Boom.NewBoom(this.transform.position, DestroyedBoom, BoomSize);
                Fade.NewFade(this.transform, 1, 0.01F, 1, true);
                Invoke("FailedGuanQia", 2);
                Map.HasFailed = true;
            }
            else if (this.name == "HuDun")
            {
                if (this.transform.parent.GetComponent<HuDun>().IsHuDunExist)
                {
                    this.transform.parent.GetComponent<HuDun>().HuDunDisappear();
                    Boom.NewBoom(this.transform.position, BoomType.Small);
                }
            }
            IsDestroyed = true;
        }
        if (this.ShengMing[0] < 0)
        {
            this.ShengMing[0] = 0;
        }
        if (this.ShengMing[0] > this.ShengMing[1])
        {
            this.ShengMing[0] = this.ShengMing[1];
        }
    }

    void FailedGuanQia()
    {
        Map.FinishGuanQia(Map.GuanQiaChoosed, "", false);
        Fade.NewFade(this.transform, 0.01F, 1, 1, true);
    }

    void OnDestroy()
    {
        if (Map.PlanesID.Contains(ID))
        {
            Map.PlanesID.Remove(ID);
        }
    }
}

public class ExtraPricing
{
    public string ObjectName;
    public int BasicNum;
    public float RandomNum;
}
