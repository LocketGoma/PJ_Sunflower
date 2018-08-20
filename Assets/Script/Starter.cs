using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Starter : MonoBehaviour {
    private bool StillPlay;
    public static Starter StartManager;
    // Use this for initialization
    void Start () {
        if (StartManager == null)
            StartManager = this;
        else if (StartManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        StillPlay = false;
    }
    public void Playing()
    {
        Login();
        StillPlay = true;
    }
    public bool getPlayStatus()
    {
        return StillPlay;
    }
    void Login()
    {
        Social.localUser.Authenticate((bool Success) => { // handle success or failure 
            if (true == Success)
            {
                Debug.Log("Login Success");
            }
            else { //Debug.Log("Login Fail");
                ; }
        });
    }
}
