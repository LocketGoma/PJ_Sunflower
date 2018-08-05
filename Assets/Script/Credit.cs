using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour {
    public GameObject creditimage;
	// Use this for initialization
	void Start () {
        creditimage.SetActive(false);
        
    }
	
	// Update is called once per frame

    public void openImage()
    {
        creditimage.SetActive(true);
    }
    public void closeImage()
    {
        creditimage.SetActive(false);
    }
}
