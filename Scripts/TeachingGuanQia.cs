using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeachingGuanQia : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Transform OnChosedGuanQia;
    public static int MaxTipNum = 0;
    static bool CouldClick = true;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (this.name == "LastTipButton" && CouldClick)
        {
            LastTipButtonClick();
            CouldClick = false;
            Invoke("SetCouldClickTrue", 0.31F);
        }
        if (this.name == "NextTipButton" && CouldClick)
        {
            NextTipButtonClick();
            CouldClick = false;
            Invoke("SetCouldClickTrue", 0.31F);
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {

    }

    void OnEnable()
    {
        if (this.name == "TeachingGuanQiaShow")
        {
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    void SetCouldClickTrue()
    {
        CouldClick = true;
    }

    public void LastTipButtonClick()
    {
        int OnChosedTip = 0;
        MaxTipNum = OnChosedGuanQia.childCount - 1;
        for (int i = 0; i < OnChosedGuanQia.childCount; i++)
        {
            int n = 0;
            int.TryParse(OnChosedGuanQia.GetChild(i).name, out n);

            if (OnChosedGuanQia.GetChild(i).gameObject.activeSelf)
            {
                OnChosedTip = n;
            }
        }
        if (OnChosedTip > 0)
        {
            Fade.NewFade(OnChosedGuanQia.Find(OnChosedTip.ToString()), 1, 0, 0.3F);
            Fade.NewFade(OnChosedGuanQia.Find((OnChosedTip - 1).ToString()), 0, 1, 0.3F);
        }
    }

    public void NextTipButtonClick()
    {
        int OnChosedTip = 0;
        MaxTipNum = OnChosedGuanQia.childCount - 1;
        for (int i = 0; i < OnChosedGuanQia.childCount; i++)
        {
            int n = 0;
            int.TryParse(OnChosedGuanQia.GetChild(i).name, out n);

            if (OnChosedGuanQia.GetChild(i).gameObject.activeSelf)
            {
                OnChosedTip = n;
            }
        }
        if (OnChosedTip < MaxTipNum)
        {
            Fade.NewFade(OnChosedGuanQia.Find(OnChosedTip.ToString()), 1, 0, 0.3F);
            Fade.NewFade(OnChosedGuanQia.Find((OnChosedTip + 1).ToString()), 0, 1, 0.3F);
        }
    }

    public void L_1_0_Y()
    {
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/0", 1, 0, 0.3F);
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/2", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/0").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void L_1_0_N()
    {
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/0", 1, 0, 0.3F);
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/1", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/0").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void L_1_1_Y()
    {
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/1", 1, 0, 0.3F);
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/3", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/1").GetComponent<CanvasGroup>().blocksRaycasts = false;
        Next();
    }
    public void L_1_1_N()
    {
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/1", 1, 0, 0.3F);
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/2", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/1").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void L_1_2_Y()
    {
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1", 1, 0, 0.3F);
        Fade.NewFade("Canvas/TeachingGuanQiaShow", 1, 0, 0.3F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/2").GetComponent<CanvasGroup>().blocksRaycasts = false;
        ControlCenter.CouldStartGuanQia.Add("L_1");
        ControlCenter.CouldStartGuanQia.Add("L_2");
        ControlCenter.CouldStartGuanQia.Add("L_3");
        ControlCenter.CouldStartGuanQia.Add("T_1");
        ControlCenter.CouldStartGuanQia.Add("T_2");
        ControlCenter.CouldStartGuanQia.Add("1_1");
        ControlCenter.CouldStartGuanQia.Add("1_2");
        ControlCenter.FinishedGuanQia.Add("L_1");
        ControlCenter.FinishedGuanQia.Add("L_2");
        ControlCenter.FinishedGuanQia.Add("L_3");
        ControlCenter.FinishedGuanQia.Add("T_1");
        ControlCenter.FinishedGuanQia.Add("T_2");
        ControlCenter.FinishedGuanQia.Add("1_1");
        ObjectSystem.AddThings("晶石", 18);
        ObjectSystem.AddThings("晶钻", 1);
        Map.SaveCouldStartMap();
        Map.ReloadMap();
        ClickUI.ChangeShowButtons(true);
        TeachingGuanQia.OnChosedGuanQia = Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1");
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").gameObject.SetActive(true);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/LastTipButton").gameObject.SetActive(true);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/NextTipButton").gameObject.SetActive(true);
    }
    public void L_1_2_N()
    {
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/2", 1, 0, 0.3F);
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/3", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/2").GetComponent<CanvasGroup>().blocksRaycasts = false;
        Next();
    }
    public void Next()
    {
        TeachingGuanQia.OnChosedGuanQia = Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1");
        if (Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/1").gameObject.activeSelf)
        {
            Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/1", 1, 0, 0.3F);
        }
        if (Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1/2").gameObject.activeSelf)
        {
            Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/2", 1, 0, 0.3F);
        }
        Fade.NewFade("Canvas/TeachingGuanQiaShow/L_1/3", 0, 1, 0.5F);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").gameObject.SetActive(true);
        UnityAction UA = new UnityAction(() =>
        {
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/LastTipButton").gameObject.SetActive(true);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/NextTipButton").gameObject.SetActive(true);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<CanvasGroup>().blocksRaycasts = false;
            Fade.NewFade("Canvas/TeachingGuanQiaShow", 0, 1, 0.5F);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_1").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_2").gameObject.SetActive(true);
            Invoke("AfterT_1", 0.25F);
        });
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<Button>().onClick.AddListener(UA);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<Button>().onClick.RemoveListener(UA);
        });
        ControlCenter.FinishedGuanQia.Add("L_1");
        Map.SaveCouldStartMap();
        Map.ReloadMap();
        //ClickUI.ChangeShowButtons(true);
        //Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").gameObject.SetActive(true);
    }

    public void AfterT_1()
    {
        ObjectSystem.AddThings("晶石", 3);
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<CanvasGroup>().blocksRaycasts = true;
        OnChosedGuanQia = Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_2");
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            Fade.StringToTransform("Canvas/TeachingGuanQiaShow/L_2").gameObject.SetActive(false);
            Invoke("AfterT_2", 0.25F);
        });
    }

    public void AfterT_2()
    {
        ObjectSystem.AddThings("晶石", 3);
        Map.GuanQiaChoosed = "T_1";
        Map.StartMap();
        Fade.StringToTransform("Canvas/TeachingGuanQiaShow/CloseButton").GetComponent<Button>().onClick.RemoveAllListeners();
    }

}
