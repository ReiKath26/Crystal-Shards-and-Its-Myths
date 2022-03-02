using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOrUniteChecker : MonoBehaviour
{

    public GameObject destroy, unite;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("choice")==1 && destroy!=null)
        {
            destroy.SetActive(true);
        }

        else if(PlayerPrefs.GetInt("choice")==2 && unite!=null)
        {
            unite.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
