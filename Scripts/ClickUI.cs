using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using UserMessage;

public class ClickUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static int MapPageNow = 1;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (Fade.TransformToString(this.transform) == "Canvas/ControlButtons/GoLeft")
        {
            Move.LeftButtonDown = true;
            StartCoroutine(SetControlButtonCommand("GoLeft"));
        }
        if (Fade.TransformToString(this.transform) == "Canvas/ControlButtons/GoRight")
        {
            Move.RightButtonDown = true;
            StartCoroutine(SetControlButtonCommand("GoRight"));
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        #region 战机移动控制
        if (Fade.TransformToString(this.transform) == "Canvas/ControlButtons/GoLeft")
        {
            Move.LeftButtonDown = false;
            Move.GoLeft = false;
        }
        if (Fade.TransformToString(this.transform) == "Canvas/ControlButtons/GoRight")
        {
            Move.RightButtonDown = false;
            Move.GoRight = false;
        }
        #endregion
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (Fade.TransformToString(this.transform) == "Canvas/FunctionButtons/Map")
        {
            Fade.NewFade("Canvas/Map", 0, 1, 0.4F);
            ChangeShowButtons(false);
            if (Fade.StringToTransform("Canvas/MainButtons").gameObject.activeSelf)
            {
                ShowMainButtons(false);
            }
        } //主界面地图点击（打开地图面板）

        if (Fade.TransformToString(this.transform) == "Canvas/Map/CloseButton")
        {
            Fade.NewFade("Canvas/Map", 1, 0, 0.3F);
            ChangeShowButtons(true);
        } //地图关闭按钮点击（关闭地图面板）

        if (Fade.TransformToString(this.transform) == "Canvas/Map/LastMapButton")
        {
            if (MapPageNow > 0)
            {
                Fade.NewFade("Canvas/Map/" + MapPageNow, 1, 0, 0.4F);
                Fade.NewFade("Canvas/Map/" + (MapPageNow - 1), 0, 1, 0.6F);
                MapPageNow--;
            }
            else
            {
                ShowMessage.Message("前面没有章节了");
            }
        } //地图上一章

        if (Fade.TransformToString(this.transform) == "Canvas/Map/NextMapButton")
        {
            if (MapPageNow < 2)
            {
                Fade.NewFade("Canvas/Map/" + MapPageNow, 1, 0, 0.4F);
                Fade.NewFade("Canvas/Map/" + (MapPageNow + 1), 0, 1, 0.6F);
                MapPageNow++;
            }
            else
            {
                ShowMessage.Message("后续章节敬请期待");
            }
        } //地图下一章

        if (this.CompareTag("ChooseGuanQia"))
        {
            if (this.GetComponent<MapSpecial>())
            {
                if (this.GetComponent<MapSpecial>().CheckStartNeed())
                {
                    Map.PreStart(this.name);
                    Map.ObjsNeed = this.GetComponent<MapSpecial>();
                }
                else
                {
                    ShowMessage.Message("开启关卡所需物品不足");
                }
            }
            else
            {
                Map.PreStart(this.name);
            }
        } //地图选择并打开预开始界面

        if (Fade.TransformToString(this.transform) == "Canvas/PreStartGuanQia/CloseButton")
        {
            Fade.NewFade("Canvas/PreStartGuanQia", 1, 0, 0.3F);
            ChangeShowButtons(true);
        } //地图关闭按钮点击（关闭地图面板）

        if (Fade.TransformToString(this.transform) == "Canvas/FinishGuanQia/CloseButton")
        {
            Fade.NewFade("Canvas/FinishGuanQia", 1, 0, 0.3F);
            ChangeShowButtons(true);
        } //关卡结算关闭按钮点击（关闭关卡结算面板）

        if (Fade.TransformToString(this.transform) == "Canvas/FunctionButtons/ShowMainButtons")
        {
            ShowMainButtons(true);
        } //更多按钮展开点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/CloseMainButtons")
        {
            ShowMainButtons(false);
        } //关闭更多按钮界面关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/ObjectButton")
        {
            Fade.NewFade("Canvas/Object", 0, 1, 0.3F);
            ChangeShowButtons(false);
            ShowMainButtons(false);
        } //仓库（包裹）打开按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/Object/CloseButton")
        {
            Fade.NewFade("Canvas/Object", 1, 0, 0.2F);
            ChangeShowButtons(true);
        } //仓库（包裹）关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/PlanesButton")
        {
            Fade.NewFade("Canvas/Planes", 0, 1, 0.3F);
            ChangeShowButtons(false);
            ShowMainButtons(false);
        } //战机打开按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/Planes/CloseButton")
        {
            Fade.NewFade("Canvas/Planes", 1, 0, 0.2F);
            Fade.StringToTransform("Canvas/Planes/HelpContent").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/Planes/QiangHua").gameObject.SetActive(false);
            Fade.StringToTransform("Canvas/Planes/WuQiSetting").gameObject.SetActive(false);
            ChangeShowButtons(true);
        } //战机关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/SettingButton")
        {
            Fade.NewFade("Canvas/Setting", 0, 1, 0.3F);
            ChangeShowButtons(false);
            ShowMainButtons(false);
        } //设置打开按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/JiaoYiButton")
        {
            Fade.NewFade("Canvas/JiaoYi", 0, 1, 0.3F);
            ChangeShowButtons(false);
            ShowMainButtons(false);
        } //交易打开按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/JiaoYi/CloseButton")
        {
            Fade.NewFade("Canvas/JiaoYi", 1, 0, 0.2F);
            ChangeShowButtons(true);
        } //交易关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/HuoDongButton")
        {
            Fade.NewFade("Canvas/HuoDong", 0, 1, 0.3F);
            ChangeShowButtons(false);
            ShowMainButtons(false);
        } //活动打开按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/HuoDong/CloseButton")
        {
            Fade.NewFade("Canvas/HuoDong", 1, 0, 0.2F);
            ChangeShowButtons(true);
        } //活动关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/MainButtons/KeJiButton")
        {
            Fade.NewFade("Canvas/KeJi", 0, 1, 0.3F);
            ChangeShowButtons(false);
            ShowMainButtons(false);
        } //科技打开按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/KeJi/CloseButton")
        {
            Fade.NewFade("Canvas/KeJi", 1, 0, 0.2F);
            ChangeShowButtons(true);
        } //科技关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/TeachingGuanQiaShow/CloseButton")
        {
            Fade.NewFade("Canvas/TeachingGuanQiaShow", 1, 0, 0.2F);
            Map.StopPutPlanes = false;
            Invoke("JiaoChengClose", 0.18F);
        } //游戏教程界面关闭按钮点击

        if (Fade.TransformToString(this.transform) == "Canvas/PreStartGuanQia/Skip")
        {
            Fade.NewFade("Canvas/PreStartGuanQia/Affirm", 0, 1, 0.3F);
            Fade.StringToTransform("Canvas/PreStartGuanQia/Affirm").GetComponent<CanvasGroup>().blocksRaycasts = true;
        } //看广告跳过关卡按钮点击打开确认面板

    }

    public static void ChangeShowButtons(bool IsShow = false)
    {
        float FadeTime = 0.5F;
        if (IsShow)
        {
            Fade.NewFade("Canvas/ControlButtons", 0, 1, FadeTime);
            Fade.NewFade("Canvas/FunctionButtons", 0, 1, FadeTime);
            Fade.StringToTransform("Canvas/ControlButtons").GetComponent<CanvasGroup>().blocksRaycasts = true;
            Fade.StringToTransform("Canvas/FunctionButtons").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            Fade.NewFade("Canvas/ControlButtons", 1, 0, FadeTime);
            Fade.NewFade("Canvas/FunctionButtons", 1, 0, FadeTime);
            Fade.StringToTransform("Canvas/ControlButtons").GetComponent<CanvasGroup>().blocksRaycasts = false;
            Fade.StringToTransform("Canvas/FunctionButtons").GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public static void ShowMainButtons(bool IsShow = false)
    {
        if (IsShow)
        {
            Fade.NewFade("Canvas/MainButtons", 0, 1, 0.3F);
            Fade.NewFade("Canvas/FunctionButtons/ShowMainButtons", 1, 0, 0.3F);
            Fade.StringToTransform("Canvas/FunctionButtons/ShowMainButtons").GetComponent<CanvasGroup>().blocksRaycasts = false;
            Fade.StringToTransform("Canvas/MainButtons/CloseMainButtons").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            Fade.NewFade("Canvas/MainButtons", 1, 0, 0.2F);
            Fade.NewFade("Canvas/FunctionButtons/ShowMainButtons", 0, 1, 0.3F);
            Fade.StringToTransform("Canvas/FunctionButtons/ShowMainButtons").GetComponent<CanvasGroup>().blocksRaycasts = true;
            Fade.StringToTransform("Canvas/MainButtons/CloseMainButtons").GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    IEnumerator SetControlButtonCommand(string Button)
    {
        yield return new WaitForSeconds(0.025F);
        if (Button == "GoLeft" && Move.LeftButtonDown)
        {
            Move.GoLeft = true;
        }
        if (Button == "GoRight" && Move.RightButtonDown)
        {
            Move.GoRight = true;
        }
    }

    void JiaoChengClose()
    {
        if (TeachingGuanQia.OnChosedGuanQia)
        {
            TeachingGuanQia.OnChosedGuanQia.gameObject.SetActive(false);
        }
    }

    public void SkipGuanQiaAffirmYes()
    {
        Fade.NewFade("Canvas/PreStartGuanQia", 1, 0, 0.3F);
        Fade.StringToTransform("Canvas/PreStartGuanQia/Affirm").gameObject.SetActive(false);
        Fade.StringToTransform("Canvas/PreStartGuanQia/Affirm").GetComponent<CanvasGroup>().blocksRaycasts = false;
        Unity_Js.UnityToJs("PlayAd", "SkipGuanQia");
    }

    public void SkipGuanQiaAffirmNo()
    {
        Fade.NewFade("Canvas/PreStartGuanQia/Affirm", 1, 0, 0.3F);
        Fade.StringToTransform("Canvas/PreStartGuanQia/Affirm").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
