using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;

namespace UserMessage
{
    class GetMessage
    {
        public static string Get(string Message, string TagName)
        {
            Message = Regex.Split(Message, "<" + TagName + ">")[1];
            Message = Regex.Split(Message, "</" + TagName + ">")[0];
            return Message;
        }

        /// <summary>
        /// 获取父标签下所有子标签标题及内容
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>string[]{string[]{Tag,Message}}</returns>
        public static string[][] GetAll(string Message, bool IgnoreRichText = true)
        {
            if (IgnoreRichText)
            {
                Message = Message.Replace("<color", "[`F0]");
                foreach (Match M in Regex.Matches(Message, @"[=][#]\w*[>]"))
                {
                    Message = Message.Replace(M.Value, M.Value.Split('>')[0] + "[`F1]");
                }
                Message = Message.Replace("</color>", "[`F2]");
            }
            string[] Tags0 = Regex.Split(" " + Message + " ", "</");
            string[] Tags = new string[Tags0.Length - 1];
            for (int i = 0; i < Tags.Length; i++)
            {
                Tags[i] = Regex.Split(Tags0[i + 1], ">")[0];
            }
            string[][] ReturnMessage = new string[Tags.Length][];
            for (int i = 0; i < Tags.Length; i++)
            {
                string Message0 = UserMessage.GetMessage.Get(Message, Tags[i]);
                Message0 = Message0.Replace("[`F0]", "<color");
                Message0 = Message0.Replace("[`F1]", ">");
                Message0 = Message0.Replace("[`F2]", "</color>");
                ReturnMessage[i] = new string[] { Tags[i], Message0 };
            }
            return ReturnMessage;
        }

            public static bool Has(string Message, string Name)
        {
            string[] Message0 = Regex.Split(Message, "<" + Name + ">");
            if (Message0.Length > 1)
            {
                return true;
            }
            return false;
        }
    }
    class WriteMessage
    {
        public static void ChangeAndWriteInFile(string Message, string TagName, string Account)
        {
            StreamReader sr = new StreamReader(@"MessagesOfAllUser\" + Account + ".txt");
            string Mes = sr.ReadToEnd();
            sr.Close();
            string Message0 = Regex.Split(Mes, "<" + TagName + ">")[0];
            string Message1 = Regex.Split(Mes, "</" + TagName + ">")[1];

            StreamWriter sw = new StreamWriter(@"MessagesOfAllUser\" + Account + ".txt");
            sw.Write(Message0);
            sw.Write("<" + TagName + ">" + Message + "</" + TagName + ">");
            sw.Write(Message1);
            sw.Close();
        }
        public static void WriteNewMessageIn(string Message, string NewTagName, string ParentTagName, string Account)
        {

            StreamReader sr = new StreamReader(@"MessagesOfAllUser\" + Account + ".txt");
            string Mes = sr.ReadToEnd();
            sr.Close();
            string Message0 = Regex.Split(Mes, "<" + ParentTagName + ">")[0];
            string Message1 = Regex.Split(Mes, "</" + ParentTagName + ">")[1];
            string Message2 = Regex.Split(Regex.Split(Mes, "<" + ParentTagName + ">")[1], "</" + ParentTagName + ">")[0];

            StreamWriter sw = new StreamWriter(@"MessagesOfAllUser\" + Account + ".txt");
            sw.Write(Message0);
            sw.Write("<" + ParentTagName + ">");
            sw.Write(Message2);
            sw.Write("    <" + NewTagName + ">" + Message + "</" + NewTagName + ">" + "\r\n");
            sw.Write("</" + ParentTagName + ">");
            sw.Write(Message1);
            sw.Close();
        }
        /*public static void RemoveMessage(string TagName, string Account)
        {
            StreamReader sr = new StreamReader(@"MessagesOfAllUser\" + Account + ".txt");
            string Mes = sr.ReadToEnd();
            sr.Close();

            string[] Message0 = Regex.Split(Mes, "\r\n");
            for (int i = 0; i < Message0.Length; i++)
            {
                if (GetMessage.Has(Message0[i], TagName))
                {
                    Mes = Regex.Replace(Mes, Message0[i] + "\r\n", "");
                }
            }

            StreamWriter sw = new StreamWriter(@"MessagesOfAllUser\" + Account + ".txt");
            sw.Write(Mes);
            sw.Close();
        }*/
        public static string RemoveMessage(string TagName, string Message)
        {
            string Mes = Message;

            string[] Message0 = Regex.Split(Mes, "\r\n");
            for (int i = 0; i < Message0.Length; i++)
            {
                if (GetMessage.Has(Message0[i], TagName))
                {
                    Mes = Regex.Replace(Mes, Message0[i], "");
                }
            }

            return Mes;
        }
    }
    class Unicode
    {
        public static string ToUnicode(string String)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(String))
            {
                for (int i = 0; i < String.Length; i++)
                {
                    //將中文轉為10進制整數，然後轉為16進制unicode 
                    outStr += "\\u" + ((int)String[i]).ToString("x").PadLeft(4, '0');
                }
            }
            return outStr;
        }
    }
}