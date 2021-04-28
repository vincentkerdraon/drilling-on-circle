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

    private bool ValidateNBHole(int value){ return value > 0 && value < 200; }
    private bool ValidateDiameter(double value){ return value > 0d && value < 10000d; }
    private bool ValidateAngleShift(double value) { return value >= 0d && value < 360; }
    private bool ValidateCoordSingle(double value) { return value > -10000f && value < 10000f; }

    // Start is called before the first frame update
    void Start()
    {
        ifNbHoles.onValueChanged.AddListener(delegate
        {
            UpdateField<int>(ifNbHoles, ref nbHoles, (value) => ValidateNBHole(value), (text) => { return int.Parse(text); });
        });
        ifDiameter.onValueChanged.AddListener(delegate
        {
            IsFirstCoord = false;
            UpdateField<double>(ifDiameter, ref diameter, (value) => ValidateDiameter(value), (text) => { return double.Parse(text); });
        });
        ifAngleShift.onValueChanged.AddListener(delegate
        {
            IsFirstCoord = false;
            UpdateField<double>(ifAngleShift, ref angleShift, (value) => ValidateAngleShift(value), (text) => { return double.Parse(text); });
        });
        ifCoordX.onValueChanged.AddListener(delegate
        {
            IsFirstCoord = true;
            UpdateField<float>(ifCoordX, ref FirstCoord.X, (value) => ValidateCoordSingle(value), (text) => { return float.Parse(text); });
            Debug.Log("FirstCoord="+FirstCoord);
        });
        ifCoordY.onValueChanged.AddListener(delegate
        {
            IsFirstCoord = true;
            UpdateField<float>(ifCoordY, ref FirstCoord.Y, (value) => ValidateCoordSingle(value), (text) => { return float.Parse(text); });
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
        if (!ValidateNBHole(nbHoles))
        {
            throw new System.ArgumentException();
        }
        Scripts.Drillings drillings;
        if (IsFirstCoord)
        {
            if(!ValidateCoordSingle(FirstCoord.X) || !ValidateCoordSingle(FirstCoord.Y) || (FirstCoord.X == 0d && FirstCoord.Y == 0d))
            {
                throw new System.ArgumentException();
            }
            Debug.Log("updated params " + nbHoles + " " + FirstCoord);
            drillings = Scripts.Drillings.DrillingsFromExistingHole((uint)nbHoles, FirstCoord);
        }
        else
        {
            if(!ValidateAngleShift(angleShift) || !ValidateDiameter(diameter))
            {
                throw new System.ArgumentException();
            }
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
                inputField.colors = ColorBlock.defaultColorBlock;
                UpdateParams();
                return;
            }
        }
        catch (System.Exception e)
        {
            if (Data.ParamError != null) Data.ParamError(this, new Data.ParamErrorArgs() { code = Data.ParamErrorCode.INVALID });
            Debug.LogError(e);
            return;
        }
        if (Data.ParamError != null) Data.ParamError(this, new Data.ParamErrorArgs() { code = Data.ParamErrorCode.INVALID });
        ColorBlock colorBlock = ColorBlock.defaultColorBlock;
        colorBlock.normalColor = Color.red;
        inputField.colors = colorBlock;
    }
}
