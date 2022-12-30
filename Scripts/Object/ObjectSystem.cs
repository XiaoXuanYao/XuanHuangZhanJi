using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using ChangeColorAndHex;
using System;
using TMPro;

public class ObjectSystem : MonoBehaviour
{
    #region 背包物品映射
    public class ObjectFunction
    {
        public string ObjectName;
        public string PngName;
        public int Value;
        public ObjectFunction(string ObjectName, string PngName, int Value)
        {
            this.ObjectName = ObjectName;
            this.PngName = PngName;
            this.Value = Value;
        }
    }

    static List<ObjectFunction> ObjectFunctions = new List<ObjectFunction>
    {
        new ObjectFunction("晶石", "ObjectImages0", 0),
        new ObjectFunction("冲子板", "ObjectImages0", 1),
        new ObjectFunction("抵子板", "ObjectImages0", 2),
        new ObjectFunction("FS-1碎片", "ObjectImages0", 3),
        new ObjectFunction("TU-1碎片", "ObjectImages0", 4),
        new ObjectFunction("HZ-1碎片", "ObjectImages0", 5),
        new ObjectFunction("晶钻", "ObjectImages0", 6),
        new ObjectFunction("宝箱", "ObjectImages0", 7),
        new ObjectFunction("BR-1碎片", "ObjectImages0", 8),
        new ObjectFunction("FR-1碎片", "ObjectImages0", 9),
        new ObjectFunction("通行凭证", "ObjectImages0", 10),
        new ObjectFunction("构架铁", "ObjectImages0", 11),
        new ObjectFunction("硅-30", "ObjectImages0", 12),
    };

    public static ObjectFunction GetObjectPng(string ObjectName)
    {
        foreach(ObjectFunction O in ObjectFunctions)
        {
            if (O.ObjectName == ObjectName)
            {
                return O;
            }
        }
        return null;
    }
    #endregion

    static int x = 0;
    static int y = 0;
    public static int Page = 0;
    public static List<Object> ObjectsList = new List<Object>();

    public static void AddThings(string Name, int Number, string AppendentMessage = "")
    {
        if (Number > 0)
        {
            ShowMessage.Message("获得 <color=#" + Exchange.ColorToHex(GetObjectColor(Name)) + ">" + Name + "</color> x " + Number);
            if (!HasObject(Name, 1, AppendentMessage))
            {
                Object Obj = new Object
                {
                    Name = Name,
                    Number = Number,
                    AppendantMessage = AppendentMessage
                };
                ObjectsList.Add(Obj);
            }
            else
            {
                foreach (Object O in ObjectsList)
                {
                    if (O.Name == Name && O.AppendantMessage == AppendentMessage)
                    {
                        ObjectsList.Remove(O);
                        O.Number += Number;
                        ObjectsList.Add(O);
                        break;
                    }
                }
            }
            if (AppendentMessage != "" && AppendentMessage != "Tag:Group")
            {
                AddThings(Name, Number, "Tag:Group");
            }
            ReWriteThings();
            SaveObjectInBaoGuo();
        }
    }  //添加物品

    /// <summary>
    /// 移除物品
    /// </summary>
    /// <param name="Name">物品名称</param>
    /// <param name="Number">物品数量</param>
    /// <param name="AppendantMessage">物品附加信息</param>
    /// <returns>true: 成功移除（减少）指定物品  false: 物品数量不足，移除（减少）失败</returns>
    public static bool DeleteThings(string Name, int Number, string AppendantMessage = "")
    {
        foreach (Object O in ObjectsList)
        {
            if (Name == O.Name && AppendantMessage == O.AppendantMessage && Number <= O.Number)
            {
                ObjectsList.Remove(O);
                O.Number -= Number;
                if (O.Number > 0)
                {
                    ObjectsList.Add(O);
                }
                if (AppendantMessage != "")
                {
                    DeleteThings(Name, Number);
                }
                ReWriteThings();
                SaveObjectInBaoGuo();
                return true;
            }
        }
        return false;
    }  //移除物品

    public static bool HasObject(string Name, int Number = 1, string AppendantMessage = "")
    {
        if (Number > 0)
        {
            foreach (Object O in ObjectsList)
            {
                if (O.Name == Name && O.AppendantMessage == AppendantMessage && O.Number >= Number)
                {
                    return true;
                }
            }
            return false;
        }
        else if (Number == 0)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("要求扣除的物体个数为负，将增添物品");
            return true;
        }
    }  //检测是否有（足够的）物品

    static void AddThings0(string Name, int Number, string AppendantMessage = "")  // UI界面添加物品（数据转可视化文字）
    {
        Transform Parent = GameObject.Find("Canvas").transform.Find("Object").transform.Find("Main");
        Transform Obj = Instantiate(Parent.Find("Model"), Parent.transform.Find("Objects"));
        Obj.transform.Find("Number").GetComponent<TextMeshProUGUI>().text = Number.ToString();
        Obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-15 + x * 115, -y * 115);
        Obj.transform.Find("Image").GetComponent<Image>().sprite
            = Resources.LoadAll(GetObjectPng(Name).PngName, typeof(Sprite))[GetObjectPng(Name).Value] as Sprite;
        //上行为图片格式包裹

        Color Color0 = GetObjectColor(Name);
        Obj.transform.Find("BackColor").GetComponent<Image>().color = new Color(Color0.r, Color0.g, Color0.b, 0.5F);

        /*Obj.transform.Find("Name").GetComponent<Text>().color = Color0;
        Obj.transform.Find("Number").GetComponent<Text>().color = Color0;
        Obj.transform.Find("Name").GetComponent<Text>().text = Name;*/

        ObjectInspector I = Obj.gameObject.AddComponent<ObjectInspector>();
        I.Name = Name;
        I.Number = Number;
        I.AppendantMessage = AppendantMessage;
        Obj.gameObject.SetActive(true);
        Obj.name = Name;

        x++;
        if (x == 5)
        {
            x = 0;
            y++;
            Parent.transform.Find("Objects").GetComponent<RectTransform>().sizeDelta += new Vector2(0, 115);
        }
    }

    public static void ReWriteThings()
    {
        ObjectsList.Sort();
        Transform Parent = GameObject.Find("Canvas").transform.Find("Object").transform.Find("Main").transform.Find("Objects");
        while (Parent.childCount > 0)
        {
            DestroyImmediate(Parent.transform.GetChild(0).gameObject);
        }
        x = 0;
        y = 0;
        for (int i = 0; i < ObjectsList.Count; i++)
        {
            if (ObjectsList[i].AppendantMessage == "" || ObjectsList[i].AppendantMessage == "Tag:Group")
            {
                AddThings0(ObjectsList[i].Name, ObjectsList[i].Number, ObjectsList[i].AppendantMessage);
            }
        }
        SaveObjectInBaoGuo();
    }  //整理物品顺序并重构包裹UI

    public static void ShowObjectNeed(string Name, int Number)
    {
        Color Color0 = new Color(0, 0, 0);
        string Quality = GetObjectMessage(Name).QualityColor;
        if (Quality == "Gray")
        {
            Color0 = Colors.Gray;
        }
        else if (Quality == "Green")
        {
            Color0 = Colors.Green;
        }
        else if (Quality == "Blue")
        {
            Color0 = Colors.Blue;
        }
        else if (Quality == "Purple")
        {
            Color0 = Colors.Purple;
        }
        else if (Quality == "Orange")
        {
            Color0 = Colors.Orange;
        }
        else if (Quality == "Red")
        {
            Color0 = Colors.Red;
        }
        string Color1 = Exchange.ColorToHex(Color0);
        ShowMessage.Message("缺少 [ <color=#" + Color1 + ">" + Name + "</color> ] * <color=#999999>" + Number + "</color>");
    }  //提示需要物品及个数

    public static void ShowObjectGet(string Name, int Number)
    {
        Color Color0 = new Color(0, 0, 0);
        string Quality = GetObjectMessage(Name).QualityColor;
        if (Quality == "Gray")
        {
            Color0 = Colors.Gray;
        }
        else if (Quality == "Green")
        {
            Color0 = Colors.Green;
        }
        else if (Quality == "Blue")
        {
            Color0 = Colors.Blue;
        }
        else if (Quality == "Purple")
        {
            Color0 = Colors.Purple;
        }
        else if (Quality == "Orange")
        {
            Color0 = Colors.Orange;
        }
        else if (Quality == "Red")
        {
            Color0 = Colors.Red;
        }
        string Color1 = Exchange.ColorToHex(Color0);
        ShowMessage.Message("获得 [ <color=#" + Color1 + ">" + Name + "</color> ] * <color=#999999>" + Number + "</color>");
    }  //提示物品获得

    public static int GetThingNum(string Name)
    {
        foreach (Object O in ObjectsList)
        {
            if (O.Name == Name)
            {
                return O.Number;
            }
        }
        return 0;
    }  //获取物品持有个数

    static void SaveObjectInBaoGuo()
    {
        if (ObjectsList.Count < PlayerPrefs.GetInt("ObjectInBaoGuoLength", 0))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("ObjectInBaoGuoLength", 0) - ObjectsList.Count; i++)
            {
                PlayerPrefs.DeleteKey("ObjectInBaoGuo" + (ObjectsList.Count + i));
                PlayerPrefs.DeleteKey("ObjectInBaoGuoNum" + (ObjectsList.Count + i));
            }
        }
        Save.SetInt("ObjectInBaoGuoLength", ObjectsList.Count);
        for (int i = 0; i < ObjectsList.Count; i++)
        {
            Save.SetString("ObjectInBaoGuo" + i,
                "<Name>" + ObjectsList[i].Name + "</Name>" +
                "<Number>" + ObjectsList[i].Number + "</Number>" +
                "<AppendantMessage>" + ObjectsList[i].AppendantMessage + "</AppendantMessage>");
        }
    }  //存档物品

    public static bool IsKind(string ObjectName, string Kind)
    {
        string AllKinds = "";
        foreach (ObjectMessage O in ObjectLibrary.Library)
        {
            if (O.Name == ObjectName)
            {
                AllKinds = O.Kinds;
                break;
            }
        }
        if (AllKinds.Split(',').Length > 0)
        {
            foreach (string Kind0 in AllKinds.Split(','))
            {
                if (Kind0 == Kind)
                {
                    return true;
                }
            }
        }
        else
        {
            if (AllKinds == Kind)
            {
                return true;
            }
        }
        return false;
    }  //检测物品是否属于某一种类

    public static Color GetObjectColor(string ObjectName)  //获取物品品质颜色，格式: Color(r,g,b)
    {
        Color Color0 = new Color();
        string Quality = GetObjectMessage(ObjectName).QualityColor;
        if (Quality == "Gray")
        {
            Color0 = Colors.Gray;
        }
        else if (Quality == "Green")
        {
            Color0 = Colors.Green;
        }
        else if (Quality == "Blue")
        {
            Color0 = Colors.Blue;
        }
        else if (Quality == "Purple")
        {
            Color0 = Colors.Purple;
        }
        else if (Quality == "Orange")
        {
            Color0 = Colors.Orange;
        }
        else if (Quality == "Red")
        {
            Color0 = Colors.Red;
        }
        return Color0;
    }

    /// <summary>
    /// 从Library中获取物品信息
    /// </summary>
    /// <param name="Name">物品名称</param>
    /// <returns>若存在物品则返回Object，若不存在1则返回null</returns>
    public static ObjectMessage GetObjectMessage(string Name)
    {
        foreach (ObjectMessage O in ObjectLibrary.Library)
        {
            if (O.Name == Name)
            {
                return O;
            }
        }
        return null;
    }
}

public class Object : IComparable<Object>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 数量
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// 附加信息（字符串值）
    /// </summary>
    public string AppendantMessage { get; set; }
    int QualityNumber = -1;

    public int CompareTo(Object other) //重写 CompareTo
    {
        if (null == other)
        {
            return -1;//空值返回-1
        }
        other.QualityNumber = ObjectSystem.GetObjectMessage(other.Name).QualityNumber;
        this.QualityNumber = ObjectSystem.GetObjectMessage(this.Name).QualityNumber;
        //return this.QualityNumber.CompareTo(other.QualityNumber); //升序
        return other.QualityNumber.CompareTo(this.QualityNumber); //降序
    }
}

namespace ChangeColorAndHex
{
    public class Colors
    {
        public static Color Gray = new Color(0.60F, 0.60F, 0.60F);
        public static Color Green = new Color(0.33F, 0.73F, 0.47F);
        public static Color Blue = new Color(0.33F, 0.57F, 0.73F);
        public static Color Purple = new Color(0.66F, 0.33F, 0.73F);
        public static Color Orange = new Color(0.78F, 0.57F, 0.09F);
        public static Color Red = new Color(0.65F, 0.43F, 0.35F);

        public static int RareColorToRareNum(Color RareColor)
        {
            if (RareColor == Gray)
            {
                return 0;
            }
            else if (RareColor == Green)
            {
                return 1;
            }
            else if (RareColor == Blue)
            {
                return 2;
            }
            else if (RareColor == Purple)
            {
                return 3;
            }
            else if (RareColor == Orange)
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }

        public static Color RareNumToRareColor(int RareNum)
        {
            switch (RareNum)
            {
                case 0:
                    return Gray;
                case 1:
                    return Green;
                case 2:
                    return Blue;
                case 3:
                    return Purple;
                case 4:
                    return Orange;
            }
            return Color.white;
        }
    }
    public class Exchange
    {
        /// <summary>
        /// rgb(1,1,1,1)转(#)xxxxxxxx
        /// </summary>
        /// <param name="color">需转化的颜色</param>
        /// <returns></returns>
        public static string ColorToHex(Color color) // rgb(1,1,1,1)转(#)xxxxxxxx
        {
            int r = Mathf.RoundToInt(color.r * 255.0f);
            int g = Mathf.RoundToInt(color.g * 255.0f);
            int b = Mathf.RoundToInt(color.b * 255.0f);
            int a = Mathf.RoundToInt(color.a * 255.0f);
            string hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
            return hex;
        }

        public static Color HexToColor(string hex) // #xxxxxx转rgb(1,1,1)
        {
            byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            float r = br / 255f;
            float g = bg / 255f;
            float b = bb / 255f;
            float a = cc / 255f;
            return new Color(r, g, b, a);
        }
    }
}

public class ObjectMessage
{
    public string Name { get; set; }
    public string Introduction { get; set; }
    public string Story { get; set; }
    public string QualityColor { get; set; }
    public int QualityNumber { get; set; }
    public string Kinds { get; set; }
    public string Buttons { get; set; }

    public int ID { get; set; }
}

public class ObjectLibrary
{
    public static List<ObjectMessage> Library = new List<ObjectMessage>
    {
        new ObjectMessage
        {
            Name = "晶石",
            Introduction = "晶石是从宇宙中某些陨石块中获取的蕴含神秘能量的固体物质。",
            Story = "",
            QualityColor = "Blue",
            QualityNumber = 999,
            Kinds = "货币,矿物",
            Buttons = "交易",
            ID = 0
        },
        new ObjectMessage
        {
            Name = "冲子板",
            Introduction = "击败敌机后获取到的一种科技材料，装配至战机武器上可以增加速度和攻击力。",
            Story = "",
            QualityColor = "Green",
            QualityNumber = 17,
            Kinds = "芯片",
            Buttons = "",
            ID = 1
        },
        new ObjectMessage
        {
            Name = "抵子板",
            Introduction = "击败敌机后获取到的一种科技材料，装配至战机武器上可以增加防御相关能力。",
            Story = "",
            QualityColor = "Green",
            QualityNumber = 19,
            Kinds = "芯片",
            Buttons = "",
            ID = 2
        },
        new ObjectMessage
        {
            Name = "FS-1碎片",
            Introduction = "从敌机残骸中找到的相对完整的部分材料。对研究有重要意义。",
            Story = "",
            QualityColor = "Blue",
            QualityNumber = 36,
            Kinds = "碎片",
            Buttons = "",
            ID = 3
        },
        new ObjectMessage
        {
            Name = "TU-1碎片",
            Introduction = "从敌机残骸中找到的相对完整的部分材料。对研究有重要意义。",
            Story = "",
            QualityColor = "Blue",
            QualityNumber = 36,
            Kinds = "碎片",
            Buttons = "",
            ID = 4
        },
        new ObjectMessage
        {
            Name = "HZ-1碎片",
            Introduction = "从敌机残骸中找到的相对完整的部分材料。对研究有重要意义。",
            Story = "",
            QualityColor = "Blue",
            QualityNumber = 36,
            Kinds = "碎片",
            Buttons = "",
            ID = 5
        },
        new ObjectMessage
        {
            Name = "晶钻",
            Introduction = "高纯度晶石的天然结晶体，蕴含大量能量。",
            Story = "",
            QualityColor = "Orange",
            QualityNumber = 1000,
            Kinds = "货币,矿物",
            Buttons = "",
            ID = 6
        },
        new ObjectMessage
        {
            Name = "宝箱",
            Introduction = "由各种活动获得的宝箱，可以开出不同数量、不同稀有度的各种物品。",
            Story = "",
            QualityColor = "Purple",
            QualityNumber = 78,
            Kinds = "宝箱",
            Buttons = "",
            ID = 7
        },
        new ObjectMessage
        {
            Name = "BR-1碎片",
            Introduction = "从敌机残骸中找到的相对完整的部分材料。对研究有重要意义。",
            Story = "",
            QualityColor = "Blue",
            QualityNumber = 36,
            Kinds = "碎片",
            Buttons = "",
            ID = 8
        },
        new ObjectMessage
        {
            Name = "FR-1碎片",
            Introduction = "从敌机残骸中找到的相对完整的部分材料。对研究有重要意义。",
            Story = "",
            QualityColor = "Purple",
            QualityNumber = 56,
            Kinds = "碎片",
            Buttons = "",
            ID = 9
        },
        new ObjectMessage
        {
            Name = "通行凭证",
            Introduction = "由上级发放的凭证，持有才能前往某些限定或危险的区域。\n活动关卡会消耗凭证。\n<color=#999>可在<交易>中获取</color>",
            Story = "",
            QualityColor = "Purple",
            QualityNumber = 45,
            Kinds = "消耗品",
            Buttons = "",
            ID = 10
        },
        new ObjectMessage
        {
            Name = "构架铁",
            Introduction = "铁的一种非常稳定坚固的晶体物质",
            Story = "",
            QualityColor = "Green",
            QualityNumber = 20,
            Kinds = "消耗品",
            Buttons = "",
            ID = 10
        },
        new ObjectMessage
        {
            Name = "硅-30",
            Introduction = "（极高纯度的、压缩的）较常见的一种硅的同位素，用于聚变产能量。\n<color=#999>Si+7He—>Ni ,Δm=0.053u</color>",
            Story = "",
            QualityColor = "Green",
            QualityNumber = 21,
            Kinds = "消耗品",
            Buttons = "",
            ID = 10
        }
    };
    //Gray:0~9  Green:10~24  Blue:25~44  Purple:45~79  Orange:80~124  Red:125~200
}