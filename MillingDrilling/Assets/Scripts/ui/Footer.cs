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
        private Button bAide;

        [SerializeField]
        private GameObject pParams, pVisu, pAide;


        // Start is called before the first frame update
        void Start()
        {
            bParams.onClick.AddListener(delegate {
                Debug.Log("button params click");
                pParams.SetActive(true);
                pVisu.SetActive(false);
                pAide.SetActive(false);
            });
            bVisu.onClick.AddListener(delegate {
                Debug.Log("button visu click");
                pParams.SetActive(false);
                pVisu.SetActive(true);
                pAide.SetActive(false);
            }); 
            bAide.onClick.AddListener(delegate {
                Debug.Log("button aide click");
                pParams.SetActive(false);
                pVisu.SetActive(false);
                pAide.SetActive(true);
            });
        }
    }
}



