using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillingElement : MonoBehaviour
{
    [SerializeField]
    private Text tHoleIndex;
    [SerializeField]
    private Text tCoords;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFields(int index, System.Numerics.Vector2 coords)
    {
        tHoleIndex.text = "(" + index + ")";
        tCoords.text = "X="+coords.X+"\nY="+coords.Y;
    }
}
