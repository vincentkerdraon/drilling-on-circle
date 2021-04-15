using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public EventHandler<DataChangedArgs> DataChanged;

    public class DataChangedArgs : EventArgs
    {
        public Drillings Drillings;   
    }

    public Drillings drillings;

    // Start is called before the first frame update
    void Start()
    {
        DataChanged += Data_DataChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Data_DataChanged(object sender, DataChangedArgs args)
    {
        drillings = args.Drillings;
        Debug.Log("Data has received");
    }
}
