using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public static int BoomNum = 0;
    public BoomType Type = BoomType.Normal;

    public static void NewBoom(Vector3 Position, BoomType Type, float Size = 0.3F)
    {
        if ((Type == BoomType.Small || Type == BoomType.Normal) && BoomNum > 12 && Random.value > 0.4F)
        {
            return;
        }
        Transform Obj = Instantiate(GameObject.Find("ObjectModels").transform.Find(Type.ToString() + "Boom"), GameObject.Find("Space").transform);
        Obj.transform.position = Position;
        Obj.transform.localScale = Vector3.one * Size;
        Boom B = Obj.gameObject.AddComponent<Boom>();
        B.Type = Type;
        Obj.gameObject.SetActive(true);
        BoomNum++;
    }

    void Start()
    {
        StartCoroutine(DestroyBoom());
    }

    IEnumerator DestroyBoom()
    {
        if (Type == BoomType.Small)
        {
            yield return new WaitForSeconds(3F);
        }
        if (Type == BoomType.Normal)
        {
            yield return new WaitForSeconds(4F);
        }
        if (Type == BoomType.MiddleLarge)
        {
            yield return new WaitForSeconds(5F);
        }
        BoomNum--;
        Destroy(this.gameObject);
    }
}

public enum BoomType
{
    Small,
    Normal,
    MiddleLarge,
    Huge
}