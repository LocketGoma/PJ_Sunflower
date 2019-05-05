using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

//#define Android_build
public class Credit : MonoBehaviour {
    public GameObject CreditImage;
	// Use this for initialization
	void Start () {
        CreditImage.SetActive(false);        
    }
    public void OpenImage()
    {
		#if Android_build
        PlayGamesPlatform.Activate();
        Social.ReportProgress("CgkI0u_Xu48EEAIQDQ", 100f, null);
		#endif

		CreditImage.SetActive(true);
    }
    public void CloseImage()
    {
        CreditImage.SetActive(false);
    }
}
