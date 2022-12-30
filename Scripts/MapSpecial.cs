using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpecial : MonoBehaviour
{
    public List<ObjectMes> ObjsNeed = new List<ObjectMes>();

    public bool CheckStartNeed()
    {
        foreach(ObjectMes Obj in ObjsNeed)
        {
            if (!ObjectSystem.HasObject(Obj.Name, Obj.Num))
            {
                return false;
            }
        }
        return true;
    }

    [System.Serializable]
    public struct ObjectMes
    {
        public string Name;
        public int Num;
    }
}
