using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnUpdate : MonoBehaviour
{
    public static Transform LastMingZhongDiObject = null;
    public static bool CouldChangeAim = true;
    public static float ChangeAimTimeCount = 0;

    public static HuDun MyHuDun;
    public static Transform DiHuDun;

    public List<PlaneData> P = new List<PlaneData>();

    void Awake()
    {

        Setting.ReadSettings();
        PlayerPrefs.SetInt("JingZuanAddAffirmYesAlways", 0);

        #region 首次加载新版本时触发
        if (PlayerPrefs.GetString("ProductVersion", "") != ControlCenter.ProductVersion)
        {
            //PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("ProductVersion", ControlCenter.ProductVersion);
        }
        #endregion

#if UNITY_ANDROID
        Fade.StringToTransform("Canvas/PreStartGuanQia/Skip").gameObject.SetActive(false);
        Fade.StringToTransform("Canvas/JiaoYi/JingZuanAddButton").gameObject.SetActive(false);
#endif

        Save.ReadLocalSave();
        Map.ReloadMap();
        PlanesMessage.GetPlanesData();

        if (!ControlCenter.CouldStartGuanQia.Contains("1_1"))
        {
            ControlCenter.CouldStartGuanQia.Add("1_1");
            ControlCenter.CouldStartGuanQia.Add("T_1");
            ControlCenter.CouldStartGuanQia.Add("SuiPian_FS_1");
            ControlCenter.CouldStartGuanQia.Add("SuiPian_TU_1");
            ControlCenter.CouldStartGuanQia.Add("SuiPian_HZ_1");
            ControlCenter.CouldStartGuanQia.Add("SuiPian_BR_1");
            ControlCenter.CouldStartGuanQia.Add("L_1");
        }
        if (PlanesMessage.GetPlaneDataByName("FS_1") == null)
        {
            PlanesMessage.GetNewPlaneAdd("FS_1");
        }
        StartCoroutine(MyPlaneRecover());
        StartCoroutine(MyPlaneRecover2());

        PlaneUIClick.OnChosenPlane = PlayerPrefs.GetString("DefaultOnChosenPlane", "FS_1");
        PlanesMessage.ChangePlaneChuZhan(PlaneUIClick.OnChosenPlane);
        PlaneUIClick.ChangeMessageShow();
        PlaneWuQiSetting.FinishSetting(false);

        if (!ControlCenter.FinishedGuanQia.Contains("L_1"))
        {
            Fade.NewFade("Canvas/TeachingGuanQiaShow", 0, 1, 0.5F);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1").gameObject.SetActive(true);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/LastTipButton").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/NextTipButton").gameObject.SetActive(false);
            ClickUI.ChangeShowButtons();
        }

        if (PlayerPrefs.GetString("LastDailyGift", "") == System.DateTime.Now.ToString("yyyy-MM-dd"))
        {
            Fade.StringToTransform("Canvas/HuoDong/Main/MeiRiQianDao/Button").GetComponent<CanvasGroup>().alpha = 0.5F;
        }

        System.Threading.Tasks.Task.Run(() =>
        {
            System.Threading.Thread.Sleep(2000);
            ShowMessage.Message("欢迎来到玄黄战机！");
            System.Threading.Thread.Sleep(1000);
            ShowMessage.Message("提示：游戏采用本地存档，请不要删除浏览器种本网页数据与缓存。");
        });
    }

    void Start()
    {
        //ObjectSystem.AddThings("晶钻", 100);
    }

    private void Update()
    {
        P = PlanesMessage.Planes;
        #region 己方与敌方生命值显示
        int[] ShengMing = GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing;
        ShengMing[1] += KeJiFun.GetKeJiKeyGrade("ShengMing") * 8;
        ShengMing[1] = (int)(ShengMing[1] * (1 + KeJiFun.GetKeJiKeyGrade("ExtraShengMing") * 0.02F));
        float KeJiShengMingS = int.Parse(PlanesMessage.ChuZhanPlane.Replace("FS_1", "10").Replace("TU_1", "20").Replace("HZ_1", "5")
            .Replace("BR_1", "20").Replace("FR_1", "15"));
        ShengMing[1] += (int)(KeJiFun.GetKeJiKeyGrade(PlaneUIClick.OnChosenPlane + "Basic") * KeJiShengMingS);
        Fade.StringToTransform("Canvas/InspectorMessage/JiShengMing/Text").GetComponent<TextMeshProUGUI>().text
            = ShengMing[0] + " / " + ShengMing[1];
        Fade.StringToTransform("Canvas/InspectorMessage/JiShengMing").GetComponent<Scrollbar>().size
            = Mathf.Lerp(Fade.StringToTransform("Canvas/InspectorMessage/JiShengMing").GetComponent<Scrollbar>().size
            , (float)ShengMing[0] / ShengMing[1], 7.5F * FPS.FPSTime);
        if (MyHuDun != null && MyHuDun.GetComponent<HuDun>().IsHuDunExist)
        {
            ShengMing = new int[] { MyHuDun.HuDunShengMingNow, MyHuDun.HuDunMaxShengMing };
        }
        else
        {
            ShengMing = new int[] { 0, 0 };
        }
        Fade.StringToTransform("Canvas/InspectorMessage/JiShengMing/JiHuDun").GetComponent<Scrollbar>().size
            = Mathf.Lerp(Fade.StringToTransform("Canvas/InspectorMessage/JiShengMing/JiHuDun").GetComponent<Scrollbar>().size
            , (float)ShengMing[0] / (ShengMing[1] + 0.0001F), 7.5F * FPS.FPSTime);

        if (LastMingZhongDiObject != null && LastMingZhongDiObject && !LastMingZhongDiObject.GetComponent<Bullet>()
            && LastMingZhongDiObject.GetComponent<Inspector>())
        {
            Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing").gameObject.SetActive(true);
            int[] DiShengMing = LastMingZhongDiObject.GetComponent<Inspector>().ShengMing;
            Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing/Text").GetComponent<TextMeshProUGUI>().text
                = DiShengMing[0] + " / " + DiShengMing[1];
            Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing").GetComponent<Scrollbar>().size
                = Mathf.Lerp(Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing").GetComponent<Scrollbar>().size
                , (float)DiShengMing[0] / DiShengMing[1], 7.5F * FPS.FPSTime);
            if (DiHuDun != null && DiHuDun.GetComponent<HuDun>().IsHuDunExist)
            {
                DiShengMing = new int[] { DiHuDun.GetComponent<HuDun>().HuDunShengMingNow, DiHuDun.GetComponent<HuDun>().HuDunMaxShengMing };
            }
            else
            {
                DiShengMing = new int[] { 0, 0 };
            }
            Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing/DiHuDun").GetComponent<Scrollbar>().size
                = Mathf.Lerp(Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing/DiHuDun").GetComponent<Scrollbar>().size
                , (float)DiShengMing[0] / (DiShengMing[1] + 0.0001F), 7.5F * FPS.FPSTime);
        }
        else
        {
            Fade.StringToTransform("Canvas/InspectorMessage/DiShengMing").gameObject.SetActive(false);
        }
        #endregion

#if !UNITY_WEBGL||UNITY_EDITOR
        GameObject.Find("Canvas").GetComponent<CanvasScaler>().scaleFactor = 0.8F * Mathf.Min(Screen.width / 1152F, Screen.height / 648F)
            + Screen.width / 1152F * 0.1F + Screen.height / 648F * 0.1F;
#endif
#if !(UNITY_WEBGL||UNITY_ANDROID)||UNITY_EDITOR
        Screen.SetResolution(Screen.width, (int)(Screen.width * 0.5625F), false);
#endif
    }

    IEnumerator MyPlaneRecover()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1F);
            if (!Map.IsZhanDou && GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[0]
                < GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[1])
            {
                GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[0]
                    += (int)((float)GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[1] / 50);
                GameObject.Find("MyPlane").GetComponent<Inspector>().IsDestroyed = false;
            }
        }
    }

    IEnumerator MyPlaneRecover2()
    {
        while (true)
        {
            yield return new WaitForSeconds(2F);
            if (GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[0]
                < GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[1])
            {
                GameObject.Find("MyPlane").GetComponent<Inspector>().ShengMing[0] += KeJiFun.GetKeJiKeyGrade("ShengMingHuiFu");
            }
        }
    }

    public static IEnumerator ResetCouldChangeAim()
    {
        ChangeAimTimeCount = 4;
        while (ChangeAimTimeCount > 0)
        {
            yield return new WaitForFixedUpdate();
            ChangeAimTimeCount -= FPS.FPSTime;
        }
        CouldChangeAim = true;
    }
}
