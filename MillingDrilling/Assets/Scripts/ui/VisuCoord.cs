using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisuCoord : MonoBehaviour
{
    [SerializeField]
    private DrillingElement prefabDrillingElement;

    [SerializeField]
    private GridLayoutGroup prefabVisuGridLayout;

    [SerializeField]
    private Transform VisuPanel;

    public int NB_ROWS = 3;
    public int NB_COLUMNS = 2;

    private List<GameObject> gridParentList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Data data = GameObject.FindObjectOfType<Data>();
        data.DataChanged += Data_DataChanged;

        HoleSelected HoleSelected = GameObject.FindObjectOfType<HoleSelected>();
        HoleSelected.HoleSelectedEvent += DrillingElement_Selected;

        /*        Debug.Log("Looking in Visu.Start()");
                DisplayDrillings(data.drillings);*/
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
        Debug.Log("Selected " + args.index);
    }

    public void DisplayDrillings(Drillings drillings)
    {
        Debug.Log("Drillings (Visu)" + drillings.ToString());


        for (int i = VisuPanel.childCount - 1; i >= 0; i--)
        {
            GameObject de = VisuPanel.GetChild(i).gameObject;
            if (de.name == "SubTitle")
            {
                continue;
            }
            Destroy(de);
            if (de == null)
                de = null;
        }

        gridParentList = new List<GameObject>();

        for (int j = 0; j < drillings.AllDrillingsRounded.Count / (NB_COLUMNS * NB_ROWS) + 1; j++)
        {
            GridLayoutGroup gridParent = Instantiate<GridLayoutGroup>(prefabVisuGridLayout);
            gridParent.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridParent.constraintCount = NB_COLUMNS;
            gridParent.transform.SetParent(VisuPanel, false);
            gridParent.gameObject.SetActive(false);
            gridParentList.Add(gridParent.gameObject);

            int maxIndex = NB_COLUMNS * NB_ROWS;
            if (drillings.AllDrillingsRounded.Count < (j + 1) * maxIndex)
            {
                maxIndex = drillings.AllDrillingsRounded.Count - j * maxIndex;
            }

            for (int i = 0; i < maxIndex; i++)
            {
                Drilling d = drillings.AllDrillingsRounded[i + j * maxIndex];
                DrillingElement drillingElement = Instantiate<DrillingElement>(prefabDrillingElement);
                drillingElement.UpdateFields(i + (j * NB_COLUMNS * NB_ROWS) + 1, d.Coord);
                drillingElement.transform.SetParent(gridParent.transform, false);
            }
        }
        gridParentList[0].SetActive(true);
    }
}
