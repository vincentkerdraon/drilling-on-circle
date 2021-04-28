using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    void Start()
    {
        string day = System.DateTime.Now.ToString("dd-MM");
        if (day == "30-04")
        {
            Text t = gameObject.GetComponent<Text>();
            t.text += " d'annif";
            t.color = Color.red;
        }
    }

}
