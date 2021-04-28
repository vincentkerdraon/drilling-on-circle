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

    [SerializeField]
    private Button Next;
    [SerializeField]
    private Button Previous;

    public int NB_ROWS = 4;
    public int NB_COLUMNS = 2;

    private List<GameObject> gridParentList = new List<GameObject>();
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        Data data = GameObject.FindObjectOfType<Data>();
        data.DataChanged += Data_DataChanged;

        HoleSelected HoleSelected = GameObject.FindObjectOfType<HoleSelected>();
        HoleSelected.HoleSelectedEvent += DrillingElement_Selected;

        Next.onClick.AddListener(delegate
        {
            UpdateIndex(this.index + 1);
        });
        Previous.onClick.AddListener(delegate
        {
            UpdateIndex(this.index - 1);
        });

        Next.interactable = false;
        Previous.interactable = false;


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
        Debug.Log("Selected " + args.index);
        UpdateIndex((args.index - 1) / (NB_COLUMNS * NB_ROWS));
    }

    private void UpdateIndex(int newIndex)
    {
        foreach (var gridObject in gridParentList)
        {

            gridObject.SetActive(false);
        }
        if (newIndex >= 0 && newIndex < gridParentList.Count)
        {
            gridParentList[newIndex].SetActive(true);
            index = newIndex;
        }
        else
        {
            Debug.LogError("Out of bounds");
        }

        if (index > 0)
        {
            Previous.interactable = true;
        }
        else
        {
            Previous.interactable = false;
        }

        if (index < gridParentList.Count - 1)
        {
            Next.interactable = true;
        }
        else
        {
            Next.interactable = false;
        }
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
            int maxIndex = NB_COLUMNS * NB_ROWS;
            if (drillings.AllDrillingsRounded.Count < (j + 1) * maxIndex)
            {
                maxIndex = drillings.AllDrillingsRounded.Count - j * maxIndex;
            }

            if(maxIndex == 0)
            {
                continue;
            }
            GridLayoutGroup gridParent = Instantiate<GridLayoutGroup>(prefabVisuGridLayout);
            gridParent.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridParent.constraintCount = NB_COLUMNS;

            gridParent.transform.SetParent(VisuPanel, false);
            gridParentList.Add(gridParent.gameObject);

            for (int i = 0; i < maxIndex; i++)
            {
                Drilling d = drillings.AllDrillingsRounded[i + j * maxIndex];
                DrillingElement drillingElement = Instantiate<DrillingElement>(prefabDrillingElement);
                drillingElement.UpdateFields(i + (j * NB_COLUMNS * NB_ROWS) + 1, d.Coord);
                drillingElement.transform.SetParent(gridParent.transform, false);
            }
        }
        UpdateIndex(0);
    }
}
