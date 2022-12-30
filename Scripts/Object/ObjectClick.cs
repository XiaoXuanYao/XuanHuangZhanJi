using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public static string ChosedObjectName = "";

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        string ObjectName = ChosedObjectName = this.GetComponent<ObjectInspector>().Name;
        Fade.StringToTransform("Canvas/Object/Introduction").GetComponent<TextMeshProUGUI>().text
            = ObjectSystem.GetObjectMessage(ObjectName).Introduction;
        switch (ObjectName)
        {
            default:
                LoadButtons(new string[] { }, ObjectName);
                break;
            case "晶钻":
            case "冲子板":
            case "抵子板":
                LoadButtons(new string[] { "出售" }, ObjectName);
                break;
            case "宝箱":
                LoadButtons(new string[] { "使用" }, ObjectName);
                break;
        }
    }

    public void LoadButtons(string[] ButtonName, string ObjectName)
    {
        while(Fade.StringToTransform("Canvas/Object/ButtonGroup/Buttons").childCount > 0)
        {
            DestroyImmediate(Fade.StringToTransform("Canvas/Object/ButtonGroup/Buttons").GetChild(0).gameObject);
        }
        Transform[] Buttons = new Transform[ButtonName.Length];
        bool HasExtraButton = false;
        if (Buttons.Length > 1 && Buttons.Length % 2 != 0)
        {
            Buttons = new Transform[ButtonName.Length + 1];
            HasExtraButton = true;
        }
        for(int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i] = Instantiate(Fade.StringToTransform("Canvas/Object/ButtonGroup/ButtonModel"),
                Fade.StringToTransform("Canvas/Object/ButtonGroup/Buttons"));
            Buttons[i].gameObject.SetActive(true);
        }
        if (HasExtraButton)
        {
            Buttons[Buttons.Length - 1].gameObject.AddComponent<CanvasGroup>().alpha = 0.5F;
        }

        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons.Length > 1)
            {
                Buttons[i].transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    (i % 2 - 0.5F) * 110,
                    ((int)((float)i / 2) - (Buttons.Length / 2 - 1) / 2F) * 60
                );
            }

            if (i < ButtonName.Length)
            {
                Buttons[i].Find("Text").GetComponent<TextMeshProUGUI>().text = ButtonName[i];
                switch (ButtonName[i])
                {
                    case "使用":
                        Buttons[i].GetComponent<Button>().onClick.AddListener(() =>
                        {
                            Fade.NewFade("Canvas/Object/InputNum", 0, 1, 0.2F);
                            CheckUsingNumInput();
                            Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable = true;
                            Fade.StringToTransform("Canvas/Object/InputNum/Finish").GetComponent<Button>().onClick.RemoveAllListeners();
                            Fade.StringToTransform("Canvas/Object/InputNum/Finish").GetComponent<Button>().onClick.AddListener(() =>
                            {
                                GameObject.Find("EventSystem").GetComponent<MessageCenter>().StartCoroutine(ShiYongButtonClick(ObjectName));
                            });
                        });
                        break;
                    case "出售":
                        Buttons[i].GetComponent<Button>().onClick.AddListener(() =>
                        {
                            Fade.NewFade("Canvas/Object/InputNum", 0, 1, 0.2F);
                            Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable = true;
                            Fade.StringToTransform("Canvas/Object/InputNum/Finish").GetComponent<Button>().onClick.RemoveAllListeners();
                            Fade.StringToTransform("Canvas/Object/InputNum/Finish").GetComponent<Button>().onClick.AddListener(() =>
                            {
                                ChuShouButtonClick(ObjectName);
                            });
                        });
                        break;
                }
            }
        }
    }

    class ObjectList
    {
        public string Name = "";
        public int Number = 0;
    }

    public IEnumerator ShiYongButtonClick(string ObjectName)
    {
        int UsingNum = int.Parse(Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text);
        switch (ObjectName)
        {
            case "宝箱":
                ObjectList[] Objs = new ObjectList[]
                {
                    new ObjectList()
                    {
                        Name = "晶石",
                        Number = 5 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "晶石",
                        Number = 10 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "冲子板",
                        Number = 2 * (int)(Mathf.Pow(Random.value, 2) * 1.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "冲子板",
                        Number = 2 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "抵子板",
                        Number = 2 * (int)(Mathf.Pow(Random.value, 2) * 1.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "抵子板",
                        Number = 2 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "硅-30",
                        Number = 1 * (int)(Mathf.Pow(Random.value, 2) * 2 + 1),
                    },
                    new ObjectList()
                    {
                        Name = "构架铁",
                        Number = 1 * (int)(Mathf.Pow(Random.value, 2) * 2 + 1),
                    },
                    new ObjectList()
                    {
                        Name = "晶钻",
                        Number = 1 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "FS-1碎片",
                        Number = 3 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "TU-1碎片",
                        Number = 3 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    },
                    new ObjectList()
                    {
                        Name = "HZ-1碎片",
                        Number = 3 * (int)(Mathf.Pow(Random.value, 2) * 2.5F + 1),
                    }
                };

                int[] OrdList = new int[UsingNum];
                int Rare = 0;
                for (int i = 0; i < UsingNum; i++)
                {
                    OrdList[i] = (int)(Random.value * Objs.Length);
                    int Rare0 = ChangeColorAndHex.Colors.RareColorToRareNum(ObjectSystem.GetObjectColor(Objs[OrdList[i]].Name));
                    if (Rare0 > Rare)
                    {
                        Rare = Rare0;
                    }
                }

                Fade.NewFade("Canvas/Object/InputNum", 1, 0, 0.15F);
                Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable = false;
                Fade.StringToTransform("Canvas/Object/GiftAnimation").gameObject.SetActive(true);
                Fade.StringToTransform("Canvas/Object/GiftAnimation").GetComponent<CanvasGroup>().alpha = 1;
                Fade.StringToTransform("Canvas/Object/GiftAnimation").GetComponent<Animator>().Play(0);
                Fade.StringToTransform("Canvas/Object/GiftAnimation/Light").GetComponent<Image>().color = ChangeColorAndHex.Colors.RareNumToRareColor(Rare)
                    + new Color(0.34F, 0.28F, 0.31F);
                for (int i = Fade.StringToTransform("Canvas/Object/GiftAnimation/ObjectsShow/Main").childCount; i > 0; i--)
                {
                    Destroy(Fade.StringToTransform("Canvas/Object/GiftAnimation/ObjectsShow/Main").GetChild(i - 1).gameObject);
                }
                yield return new WaitForSeconds(2.9F);

                Fade.StringToTransform("Canvas/Object/GiftAnimation/ObjectsShow/Main").GetComponent<RectTransform>().sizeDelta = new Vector2(UsingNum * 100 + 30, 100);
                for (int i = 0; i < UsingNum; i++)
                {
                    int Ordinal = OrdList[i];
                    ObjectSystem.AddThings(Objs[Ordinal].Name, Objs[Ordinal].Number);

                    Transform Obj = Instantiate(Fade.StringToTransform("Canvas/Object/GiftAnimation/ObjectsShow/Model")
                        , Fade.StringToTransform("Canvas/Object/GiftAnimation/ObjectsShow/Main"));
                    Obj.transform.Find("Number").GetComponent<TextMeshProUGUI>().text = Objs[Ordinal].Number.ToString();
                    Obj.GetComponent<RectTransform>().anchoredPosition = new Vector2((i - UsingNum / 2F) * 100 + 50, 0);
                    Obj.transform.Find("Image").GetComponent<Image>().sprite
                        = Resources.LoadAll(ObjectSystem.GetObjectPng(Objs[Ordinal].Name).PngName
                        , typeof(Sprite))[ObjectSystem.GetObjectPng(Objs[Ordinal].Name).Value] as Sprite;
                    Color C = ObjectSystem.GetObjectColor(Objs[Ordinal].Name);
                    Obj.transform.Find("BackColor").GetComponent<Image>().color = new Color(C.r, C.g, C.b, 0.7F);
                    Obj.transform.Find("Image").GetComponent<Image>().color = new Color(C.r, C.g, C.b) * 0.2F + new Color(1, 1, 1) * 0.8F;
                    Obj.gameObject.SetActive(true);
                }
                ObjectSystem.DeleteThings("宝箱", UsingNum);

                yield return new WaitForSeconds(1.5F + UsingNum * 0.3F);
                Fade.NewFade("Canvas/Object/GiftAnimation", 1, 0, 0.6F);
                break;
        }
        if (Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable)
        {
            Fade.NewFade("Canvas/Object/InputNum", 1, 0, 0.15F);
            Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable = false;
        }
    }

    public void ChuShouButtonClick(string ObjectName)
    {
        int UsingNum = int.Parse(Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text);
        switch (ObjectName)
        {
            case "晶钻":
                ObjectSystem.DeleteThings("晶钻", UsingNum);
                ObjectSystem.AddThings("晶石", UsingNum * 20);
                break;
            case "冲子板":
                ObjectSystem.DeleteThings("冲子板", UsingNum);
                ObjectSystem.AddThings("晶石", UsingNum * 3);
                break;
            case "抵子板":
                ObjectSystem.DeleteThings("抵子板", UsingNum);
                ObjectSystem.AddThings("晶石", UsingNum * 3);
                break;
        }
        Fade.NewFade("Canvas/Object/InputNum", 1, 0, 0.15F);
        Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable = false;
    }

    public void AddUsingNum(int Num)
    {
        int Num0 = int.Parse(Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text);
        if (Num0 + Num > 0 && (ObjectSystem.HasObject(ChosedObjectName, Num0 + Num) || ChosedObjectName == ""))
        {
            Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text = (Num0 + Num).ToString();
        }
        else if (Num0 + Num <= 0)
        {
            ShowMessage.Message("选择物品数必须大于0");
        }
        else
        {
            ShowMessage.Message("所需物品不足");
        }
    }

    public void CheckUsingNumInput()
    {
        int Num = int.Parse(Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text);
        if (Num <= 0)
        {
            Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text = 1.ToString();
        }
        if (ObjectSystem.GetThingNum(ChosedObjectName) < Num || ChosedObjectName == "")
        {
            Fade.StringToTransform("Canvas/Object/InputNum/Input").GetComponent<TMP_InputField>().text
                = ObjectSystem.GetThingNum(ChosedObjectName).ToString();
        }
    }

    public void CancelInput()
    {
        Fade.NewFade("Canvas/Object/InputNum", 1, 0, 0.15F);
        Fade.StringToTransform("Canvas/Object/InputNum").GetComponent<CanvasGroup>().interactable = false;
    }
}
