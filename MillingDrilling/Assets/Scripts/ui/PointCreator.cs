using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PointCreator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TMP_Text text;

    private int index;

    private HoleSelected HoleSelected;

    // Start is called before the first frame update
    void Start()
    {
        HoleSelected = GameObject.FindObjectOfType<HoleSelected>();
        HoleSelected.HoleSelectedEvent += HoleSelected_OnEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePointIndex(int index)
    {
        text.text = "" + index;
        this.index = index;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (HoleSelected.HoleSelectedEvent != null) HoleSelected.HoleSelectedEvent(this, new HoleSelected.HoleSelectedArgs() { index = index });
    }

    public void HoleSelected_OnEvent(object sender, HoleSelected.HoleSelectedArgs args)
    {
        if(args.index == index)
        {
            //text.color = new Color(0x35,0xE3,0xDA);
            text.color = new Color32(125, 125, 125, 255);
        }
        else
        {
            text.color = new Color32(255, 255, 255, 255);
        }
    }
}
