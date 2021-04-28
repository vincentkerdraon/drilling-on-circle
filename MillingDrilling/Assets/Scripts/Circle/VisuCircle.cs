using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuCircle : MonoBehaviour
{
    const float NORMA_RADIUS = 0.37f;// = 375/980

    [SerializeField]
    private PointCreator prefabPoint;

    [SerializeField]
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        Data data = GameObject.FindObjectOfType<Data>();
        data.DataChanged += Data_DataChanged;

        float ratio = (float)Screen.height / (float)Screen.width;

       
        /**
         * X RATIO
         * X1 = 1.77 
         * X2 = 2
         * 
         * Z SCALE for Background image
         * Z1 = 450
         * Z2 = 400
         * 
         * Y Y shift for placing Background image
         * Y1 = -110
         * Y2 = -150
         * */
        float scale = -217.4f * ratio + 834.8f;
        Debug.Log("ratio=" + ratio + " scale=" + scale);
        parent.localScale = new Vector3(scale, scale);

        if (ratio > 1.9)
        {
            parent.localPosition = new Vector3(parent.localPosition.x, -150, parent.localPosition.z);
        }
        else
        {
            parent.localPosition = new Vector3(parent.localPosition.x, -110, parent.localPosition.z);
        }


/*
        Drillings drillings = new Drillings(4,10,0);
        DisplayDrillings(drillings);*/
    }

    public void Data_DataChanged(object sender, Data.DataChangedArgs args)
    {
        Debug.Log("Received in Visu Circle");
        DisplayDrillings(args.Drillings);
    }

    private void DisplayDrillings(Drillings drillings)
    {

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        for (int i = 0; i < drillings.AllDrillingsRounded.Count; i++)
        {
            Drilling d = drillings.AllDrillingsRounded[i];
            PointCreator point = Instantiate<PointCreator>(prefabPoint);
            point.CreatePointIndex(i+1);

            float x = (float)(d.Coord.X * 2 * NORMA_RADIUS / drillings.Diameter);
            float y = (float)(d.Coord.Y * 2 * NORMA_RADIUS / drillings.Diameter);

            point.transform.SetParent(parent);
            point.transform.localPosition = new Vector3(x, y, -20);
            point.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }
    }

}
