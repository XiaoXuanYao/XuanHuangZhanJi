using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeJiMes : MonoBehaviour
{
    public int Grade = 0;
    public int MaxGrade = 5;
    public string Introduction = "";
    public string Reward = $"";
    public Preposition[] Prep;

    /// <summary>
    /// 公式：  目标可达最大等级 = 前置 * Multiply + Plus
    /// </summary>
    [System.Serializable]
    public struct Preposition
    {
        public Transform PrepositionPoint;
        public float Multiply;
        public float Plus;
    }

}