﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCreator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePointIndex(int index)
    {
        text.text = "" + index;
    }
}
