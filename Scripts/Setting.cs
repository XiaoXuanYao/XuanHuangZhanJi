using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Setting : MonoBehaviour
{

    public static int GraphicQuality = 0;
    public static float RendererQuality = 1;
    public static int BloomTimes = 2;
    public static float BloomStrength = 0.7F;
    public static int BloomWidth = 18;
    public static float BackMusicStrength = 1;
    static bool ChangeValue = true;

    public static void Reload()
    {
        if (ChangeValue)
        {
            GraphicQuality = (int)Fade.StringToTransform("Canvas/Setting/Main/Content/HuaZhi/Slider").GetComponent<Slider>().value;
            RendererQuality = Fade.StringToTransform("Canvas/Setting/Main/Content/JingDu/Slider").GetComponent<Slider>().value * 0.25F + 0.5F;
            BloomTimes = (int)Fade.StringToTransform("Canvas/Setting/Main/Content/BloomTimes/Slider").GetComponent<Slider>().value;
            BloomStrength = Fade.StringToTransform("Canvas/Setting/Main/Content/BloomStrength/Slider").GetComponent<Slider>().value;
            BloomWidth = (int)Fade.StringToTransform("Canvas/Setting/Main/Content/BloomWidth/Slider").GetComponent<Slider>().value;
            BackMusicStrength = Fade.StringToTransform("Canvas/Setting/Main/Content/BeiJingYinLiang/Slider").GetComponent<Slider>().value;
        }
        else
        {
            Fade.StringToTransform("Canvas/Setting/Main/Content/HuaZhi/Slider").GetComponent<Slider>().value = GraphicQuality;
            Fade.StringToTransform("Canvas/Setting/Main/Content/JingDu/Slider").GetComponent<Slider>().value = (RendererQuality - 0.5F) * 4;
            Fade.StringToTransform("Canvas/Setting/Main/Content/BloomTimes/Slider").GetComponent<Slider>().value = BloomTimes;
            Fade.StringToTransform("Canvas/Setting/Main/Content/BloomStrength/Slider").GetComponent<Slider>().value = BloomStrength;
            Fade.StringToTransform("Canvas/Setting/Main/Content/BloomWidth/Slider").GetComponent<Slider>().value = BloomWidth;
            Fade.StringToTransform("Canvas/Setting/Main/Content/BeiJingYinLiang/Slider").GetComponent<Slider>().value = BackMusicStrength;
        }

        QualitySettings.SetQualityLevel(GraphicQuality);
        Fade.StringToTransform("Canvas/Setting/Main/Content/HuaZhi/Value").GetComponent<TextMeshProUGUI>().text =
            GraphicQuality.ToString().Replace("0", "极低").Replace("1", "低").Replace("2", "中").Replace("3", "较高")
            .Replace("4", "高").Replace("5", "最高") + "(" + GraphicQuality + ")";

#if !PLATFORM_STANDALONE || UNITY_EDITOR
        //Screen.SetResolution((int)(1152 * RendererQuality), (int)(648 * RendererQuality), false);
#endif
        Fade.StringToTransform("Canvas/Setting/Main/Content/JingDu/Value").GetComponent<TextMeshProUGUI>().text = RendererQuality.ToString();

        GameObject.Find("MainCamera").GetComponent<Bloom>().IterativeTimes = BloomTimes;
        Fade.StringToTransform("Canvas/Setting/Main/Content/BloomTimes/Value").GetComponent<TextMeshProUGUI>().text = BloomTimes.ToString();

        GameObject.Find("MainCamera").GetComponent<Bloom>().BloomStrength = BloomStrength;
        Fade.StringToTransform("Canvas/Setting/Main/Content/BloomStrength/Value").GetComponent<TextMeshProUGUI>().text = BloomStrength.ToString("#0.00");

        GameObject.Find("MainCamera").GetComponent<Bloom>().BloomWidth = BloomWidth;
        Fade.StringToTransform("Canvas/Setting/Main/Content/BloomWidth/Value").GetComponent<TextMeshProUGUI>().text = BloomWidth.ToString();

        GameObject.Find("Music").GetComponent<AudioSource>().volume = BackMusicStrength;
        Fade.StringToTransform("Canvas/Setting/Main/Content/BeiJingYinLiang/Value").GetComponent<TextMeshProUGUI>().text = BackMusicStrength.ToString("#0.00");
    }

    public void OnSettingClose()
    {
        SaveSettings();
        Fade.NewFade("Canvas/Setting", 1, 0, 0.2F);
        ClickUI.ChangeShowButtons(true);
    }

    public static void SaveSettings()
    {
        PlayerPrefs.SetInt("Setting_GraphicQuality", GraphicQuality);
        PlayerPrefs.SetFloat("Setting_RendererQuality", RendererQuality);
        PlayerPrefs.SetInt("Setting_BloomTimes", BloomTimes);
        PlayerPrefs.SetFloat("Setting_BloomStrength", BloomStrength);
        PlayerPrefs.SetInt("Setting_BloomWidth", BloomWidth);
        PlayerPrefs.SetFloat("Setting_BackMusicStrength", BackMusicStrength);
    }

    public static void ReadSettings()
    {
        GraphicQuality = PlayerPrefs.GetInt("Setting_GraphicQuality", 1);
        RendererQuality = PlayerPrefs.GetFloat("Setting_RendererQuality", 1);
        BloomTimes = PlayerPrefs.GetInt("Setting_BloomTimes", 2);
        BloomStrength = PlayerPrefs.GetFloat("Setting_BloomStrength", 0.7F);
        BloomWidth = PlayerPrefs.GetInt("Setting_BloomWidth", 18);
        BackMusicStrength = PlayerPrefs.GetFloat("Setting_BackMusicStrength", 1);
        ChangeValue = false;
        Reload();
        ChangeValue = true;
    }
}
