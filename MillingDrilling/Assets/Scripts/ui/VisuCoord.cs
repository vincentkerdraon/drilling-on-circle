using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuCoord : MonoBehaviour
{
    [SerializeField]
    private DrillingElement prefabDrillingElement;

    [SerializeField]
    private Transform gridParent;

    // Start is called before the first frame update
    void Start()
    {
        Data data = GameObject.FindObjectOfType<Data>();
        data.DataChanged += Data_DataChanged;

        HoleSelected HoleSelected = GameObject.FindObjectOfType<HoleSelected>();
        HoleSelected.HoleSelectedEvent += DrillingElement_Selected;

        Debug.Log("Looking in Visu.Start()");
        DisplayDrillings(data.drillings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Data_DataChanged(object sender, Data.DataChangedArgs args)
    {
        Debug.Log("Received in Visu");
        DisplayDrillings(args.Drillings);
    }

    public void DrillingElement_Selected(object sender, HoleSelected.HoleSelectedArgs args)
    {
        Debug.Log("Selected "+args.index);
    }

    public void DisplayDrillings(Drillings drillings)
    {
        Debug.Log("Drillings (Visu)" + drillings.ToString());


        for (int i = gridParent.childCount-1; i >= 0; i--)
        {
            GameObject de = gridParent.GetChild(i).gameObject;
            Destroy(de);
            if (de == null)
                de = null;
        }

        for (int i = 0; i < drillings.AllDrillingsRounded.Count; i++)
        {
            Drilling d = drillings.AllDrillingsRounded[i];
            DrillingElement drillingElement = Instantiate<DrillingElement>(prefabDrillingElement);
            drillingElement.UpdateFields(i+1, d.Coord);
            drillingElement.transform.SetParent(gridParent,false);
        }
    }
}
