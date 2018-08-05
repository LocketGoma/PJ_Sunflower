using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Starter : MonoBehaviour {
    private bool stillplay;
    public static Starter Manager_start;
    // Use this for initialization
    void Start () {
        if (Manager_start == null)
            Manager_start = this;
        else if (Manager_start != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        stillplay = false;
    }
    public void playing()
    {
        Login();
        stillplay = true;
    }
    public bool isplay()
    {
        return stillplay;
    }
    void Login()
    {
        Social.localUser.Authenticate((bool success) => { // handle success or failure 
            if (true == success)
            {
                Debug.Log("Login Success");
            }
            else { //Debug.Log("Login Fail");
                ; }
        });
    }
}
