using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFade : MonoBehaviour
{
    public Vector3 StartScale0 = Vector3.one;
    public Vector3 EndScale0 = Vector3.zero;
    public Vector3 OnceFadePerSecond0 = Vector3.zero;
    public float FadeTime0 = 1;
    public bool isFade = false;
    public static void NewScaleFade(string GameObjectFile, Vector3 StartScale, Vector3 EndScale, float Time)
    {
        Transform Obj = Fade.StringToTransform(GameObjectFile);
        if (Obj.GetComponent<ScaleFade>())
        {
            Destroy(Obj.GetComponent<ScaleFade>());
        }
        Obj.transform.localScale = StartScale;
        ScaleFade AddFade = Obj.gameObject.AddComponent<ScaleFade>();
        Vector3 OnceFadePerSecond = (EndScale - StartScale) / Time;

        AddFade.StartScale0 = StartScale;
        AddFade.EndScale0 = EndScale;
        AddFade.OnceFadePerSecond0 = OnceFadePerSecond;
        AddFade.FadeTime0 = Time;
    }
    void Start()
    {
        if (this.GetComponents<ScaleFade>().Length < 2)
        {
            isFade = true;
            this.transform.localScale = StartScale0;
        }
    }
    void Update()
    {
        if (this.isFade == true)
        {
            if (this.GetComponent<Transform>())
            {
                this.transform.localScale += OnceFadePerSecond0 * FPS.FPSTime;
            }
            Vector3 Space = EndScale0 - this.transform.localScale;
            if (Space.x <= 0 && Space.y <= 0 && Space.z <= 0)
            {
                this.transform.localScale = EndScale0;

                ScaleFade[] MyComponent = this.GetComponents<ScaleFade>();
                if (MyComponent.Length > 1)
                {
                    MyComponent[1].transform.localScale = MyComponent[1].StartScale0;
                    MyComponent[1].isFade = true;
                }
                Destroy(MyComponent[0]);
            }
        }
    }
}