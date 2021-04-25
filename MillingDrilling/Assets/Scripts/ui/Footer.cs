using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui {
    public class Footer : MonoBehaviour
    {
        [SerializeField]
        private Button bParams;
        [SerializeField]
        private Button bVisu;
        [SerializeField]
        private Button bHelp;

        [SerializeField]
        private GameObject pParams, pVisu, pAide;

        [SerializeField]
        private Sprite iActive, iInactive;


        // Start is called before the first frame update
        void Start()
        {
            bParams.onClick.AddListener(delegate {
                Debug.Log("button params click");
                pParams.SetActive(true);
                pVisu.SetActive(false);
                pAide.SetActive(false);
                bParams.image.sprite = iActive;
                bVisu.image.sprite = iInactive;
                bHelp.image.sprite = iInactive;
            });
            bVisu.onClick.AddListener(delegate {
                Debug.Log("button visu click");
                pParams.SetActive(false);
                pVisu.SetActive(true);
                pAide.SetActive(false);
                bParams.image.sprite = iInactive;
                bVisu.image.sprite = iActive;
                bHelp.image.sprite = iInactive;
            }); 
            bHelp.onClick.AddListener(delegate {
                Debug.Log("button help click");
                pParams.SetActive(false);
                pVisu.SetActive(false);
                pAide.SetActive(true);
                bParams.image.sprite = iInactive;
                bVisu.image.sprite = iInactive;
                bHelp.image.sprite = iActive;
            });
        }
    }
}



