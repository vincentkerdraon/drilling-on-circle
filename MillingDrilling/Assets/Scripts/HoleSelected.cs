using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSelected : MonoBehaviour
{
    public EventHandler<HoleSelectedArgs> HoleSelectedEvent;
    public class HoleSelectedArgs : EventArgs
    {
        public int index;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
