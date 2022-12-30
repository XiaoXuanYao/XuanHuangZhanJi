using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoDong : MonoBehaviour
{
    public void DailyGift()
    {
        if (PlayerPrefs.GetString("LastDailyGift", "") != System.DateTime.Now.ToString("yyyy-MM-dd"))
        {
            ObjectSystem.AddThings("晶钻", (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1));
            ObjectSystem.AddThings("宝箱", (int)(Mathf.Pow(Random.value, 2) * 2.5F + 2));
            ObjectSystem.AddThings("通行凭证", 3);
            ObjectSystem.AddThings("晶石", (int)(Mathf.Pow(Random.value, 3) * 10F + 8));
            ObjectSystem.AddThings("冲子板", (int)(Mathf.Pow(Random.value, 3) * 3F + 2));
            ObjectSystem.AddThings("抵子板", (int)(Mathf.Pow(Random.value, 3) * 3F + 2));
            ObjectSystem.AddThings("硅-30", (int)(Mathf.Pow(Random.value, 2) * 2.2F + 1));
            ObjectSystem.AddThings("构架铁", (int)(Mathf.Pow(Random.value, 2) * 2.2F + 1));
            Save.SetString("LastDailyGift", System.DateTime.Now.ToString("yyyy-MM-dd"));
            ShowMessage.Message("签到成功");
            Fade.StringToTransform("Canvas/HuoDong/Main/MeiRiQianDao/Button").GetComponent<CanvasGroup>().alpha = 0.5F;
        }
        else
        {
            ShowMessage.Message("今日已签到");
        }
    }
}
