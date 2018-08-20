using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour {
    public GameObject CreditImage;
	// Use this for initialization
	void Start () {
        CreditImage.SetActive(false);        
    }
    public void OpenImage()
    {
        CreditImage.SetActive(true);
    }
    public void CloseImage()
    {
        CreditImage.SetActive(false);
    }
}
