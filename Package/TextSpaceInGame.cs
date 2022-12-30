using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpaceInGame : MonoBehaviour
{
    void Update()
    {
        if (this.GetComponent<Text>())
        {
            this.GetComponent<Text>().text = this.GetComponent<Text>().text.Replace(" ", "\u00A0");
        }
    }
}
