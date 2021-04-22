using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Params : MonoBehaviour
{
    [SerializeField]
    private InputField ifNbHoles;
    private int nbHoles;

    [SerializeField]
    private InputField ifDiameter;
    private double diameter;

    [SerializeField]
    private InputField ifAngleShift;
    private double angleShift;

    [SerializeField]
    private InputField ifCoordX;
    [SerializeField]
    private InputField ifCoordY;
    private System.Numerics.Vector2 FirstCoord = new System.Numerics.Vector2();

    public bool IsFirstCoord = false;

    Data Data;

    // Start is called before the first frame update
    void Start()
    {
        ifNbHoles.onEndEdit.AddListener(delegate
        {
            UpdateField<int>(ifNbHoles, ref nbHoles, (value) => { return value > 0 && value < 200; }, (text) => { return int.Parse(text); });
        });
        ifDiameter.onEndEdit.AddListener(delegate
        {
            IsFirstCoord = false;
            UpdateField<double>(ifDiameter, ref diameter, (value) => { return value > 0d && value < 10000d; }, (text) => { return double.Parse(text); });
        });
        ifAngleShift.onEndEdit.AddListener(delegate
        {
            IsFirstCoord = false;
            UpdateField<double>(ifAngleShift, ref angleShift, (value) => { return value >= 0d && value < 360; }, (text) => { return double.Parse(text); });
        });
        ifCoordX.onEndEdit.AddListener(delegate
        {
            IsFirstCoord = true;
            UpdateField<float>(ifCoordX, ref FirstCoord.X, (value) => { return value > -10000f && value < 10000f; }, (text) => { return float.Parse(text); });
            Debug.Log("FirstCoord="+FirstCoord);
        });
        ifCoordY.onEndEdit.AddListener(delegate
        {
            IsFirstCoord = true;
            UpdateField<float>(ifCoordY, ref FirstCoord.Y, (value) => { return value > -10000f && value < 10000f; }, (text) => { return float.Parse(text); });
            Debug.Log("FirstCoord=" + FirstCoord);
        });

        Data = GameObject.FindObjectOfType<Data>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateParams()
    {
        Scripts.Drillings drillings;
        if (IsFirstCoord)
        {
            Debug.Log("updated params " + nbHoles + " " + FirstCoord);
            drillings = Scripts.Drillings.DrillingsFromExistingHole((uint)nbHoles, FirstCoord);
        }
        else
        {
        Debug.Log("updated params " + nbHoles + " " + diameter + " " + angleShift);
        drillings = new Scripts.Drillings((uint)nbHoles, diameter, angleShift);
        }

        if (Data.DataChanged != null) Data.DataChanged(this, new Data.DataChangedArgs() { Drillings = drillings });
        Debug.Log(drillings.ToString());
    }

    private void UpdateField<T>(InputField inputField, ref T value, System.Func<T, bool> validateFunc, System.Func<string, T> parseFunc)
    {
        try
        {
            value = parseFunc(inputField.text);
            if (validateFunc(value))
            {
                UpdateParams();
                return;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
        Debug.LogError("Some wild errors appears;");
       // inputField.
    }
}
