using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HuDun : MonoBehaviour
{
    public Transform Object = null;
    public Transform ModelObject = null;

    public int HuDunShengMingNow = 50;
    public int HuDunMaxShengMing = 50;

    public float HuDunHuiFuSpeed = 1;   // 单位：点生命/秒
    public float HuDunChongZhiShiJian = 30;   //护盾被破坏后重置时间
    public bool IsHuDunExist = false;
    public float HuDunScale = 1;
    public float StartRotation = 0;

    void Start()
    {
        CreateNewHuDun();
        StartCoroutine(HuDunHuiFu());
        if (this.transform.parent.name == "MyPlane")
        {
            StartCoroutine(HuDunHuiFu2());
        }
    }

    void Update()
    {
        if (this.transform.Find("HuDun"))
        {
            HuDunShengMingNow = this.transform.Find("HuDun").GetComponent<Inspector>().ShengMing[0];
        }
    }

    public void CreateNewHuDun()
    {
        CreateNewHuDun(-1);
    }

    public void CreateNewHuDun(int SettingHuDunShengMingNow = -1)
    {
        Transform Obj;
        if (!IsHuDunExist)
        {
            Obj = Instantiate(ModelObject, this.transform);
        }
        else
        {
            Obj = Object;
        }
        Obj.position = this.transform.position;
        Obj.GetComponent<Inspector>().ShengMing = new int[] { HuDunMaxShengMing, HuDunMaxShengMing };
        Obj.name = "HuDun";
        Obj.gameObject.SetActive(true);
        Obj.gameObject.layer = this.gameObject.layer;
        Obj.localScale = Vector3.one * HuDunScale;
        Obj.rotation = Quaternion.Euler(new Vector3(0, 0, StartRotation));
        Object = Obj;
        if (SettingHuDunShengMingNow != -1)
        {
            Obj.GetComponent<Inspector>().ShengMing[0] = SettingHuDunShengMingNow;
        }
        IsHuDunExist = true;
        CancelInvoke();
    }

    public void HuDunDisappear()
    {
        Object.GetComponent<Animator>().enabled = false;
        Fade.NewFade(Object, 1, 0.01F, 0.8F, true, false);
        Object.transform.Find("Break").gameObject.SetActive(true);
        Object.transform.Find("Break").GetComponent<ParticleSystem>().Play();
        Destroy(Object.transform.Find("Break").gameObject, 3F);
        Object.transform.Find("Break").parent = this.transform;
        Destroy(Object.GetComponent<Collider2D>());
        Destroy(Object.gameObject, 0.8F);
        IsHuDunExist = false;

        Invoke("CreateNewHuDun", HuDunChongZhiShiJian);
    }

    public IEnumerator HuDunHuiFu()
    {
        while (true)
        {
            if (Map.IsZhanDou)
            {
                yield return new WaitForSeconds(1F / HuDunHuiFuSpeed * 2);
            }
            else
            {
                yield return new WaitForSeconds(1F / HuDunHuiFuSpeed * 2 / 10);
            }
            if (IsHuDunExist && Object && Object.GetComponent<Inspector>().ShengMing[0] > 0)
            {
                if (Object.GetComponent<Inspector>().ShengMing[0] < Object.GetComponent<Inspector>().ShengMing[1])
                {
                    Object.GetComponent<Inspector>().ShengMing[0] += 2;
                }
                if (Object.GetComponent<Inspector>().ShengMing[0] > Object.GetComponent<Inspector>().ShengMing[0])
                {
                    Object.GetComponent<Inspector>().ShengMing[0] = Object.GetComponent<Inspector>().ShengMing[1];
                }
            }
        }
    }
    IEnumerator HuDunHuiFu2()
    {
        while (true)
        {
            float HuDunHuiFuNum = Mathf.Pow(KeJiFun.GetKeJiKeyGrade("HuDunHuiFu"), 0.8F) * 0.8F;
            yield return new WaitForSeconds(1 / HuDunHuiFuNum);
            Object.GetComponent<Inspector>().ShengMing[0] += 1;
        }
    }
}

public enum HuDunKind
{
    循环高压气体流护盾,
    重组晶体护盾,
    中子团护盾,
    强电子束护盾,
    斥力场护盾,
    反物质护盾,
}