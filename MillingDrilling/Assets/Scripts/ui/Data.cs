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

    public EventHandler<ParamErrorArgs> ParamError;

    public class ParamErrorArgs : EventArgs
    {
        public ParamErrorCode code;
    }

    public enum ParamErrorCode
    { 
        INVALID
        /*DIAMETER_INVALID,
        ANGLE_TOO_HIGH,
        ANGLE_TOO_LOW,
        NB_DRILLING_TOO_HIGH,
        NB_DRILLING_TOO_LOW,
        EXIST_COORD_TOO_FAR,
        EXIST_COORD_ORIGIN*/
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
