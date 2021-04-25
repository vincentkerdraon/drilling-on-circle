using System;
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

    private int index;

    private HoleSelected HoleSelected;


    [SerializeField]
    private Sprite iActive, iInactive;

    [SerializeField]
    private Image current;

    // Start is called before the first frame update
    void Start()
    {
        HoleSelected = GameObject.FindObjectOfType<HoleSelected>();
        HoleSelected.HoleSelectedEvent += HoleSelected_OnEvent;

        current = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFields(int index, System.Numerics.Vector2 coords)
    {
        tHoleIndex.text = "(" + index + ")";
        this.index = index;
        tCoords.text = "X="+coords.X+"\nY="+coords.Y;

        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (HoleSelected.HoleSelectedEvent != null) HoleSelected.HoleSelectedEvent(this, new HoleSelected.HoleSelectedArgs() { index = index });
        });
    }

    public void HoleSelected_OnEvent(object sender, HoleSelected.HoleSelectedArgs args)
    {
        if(current == null)
        {
            return;
        }
        if (args.index == index)
        {
            current.sprite = iActive;
        }
        else
        {
            current.sprite = iInactive;
        }
    }

}
