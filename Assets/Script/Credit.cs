using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Credit : MonoBehaviour {
    public GameObject CreditImage;
	// Use this for initialization
	void Start () {
        CreditImage.SetActive(false);        
    }
    public void OpenImage()
    {
        PlayGamesPlatform.Activate();
        CreditImage.SetActive(true);
        Social.ReportProgress("CgkI0u_Xu48EEAIQDQ", 100f, null);
    }
    public void CloseImage()
    {
        CreditImage.SetActive(false);
    }
}
