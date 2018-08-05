using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        stillplay = true;
    }
    public bool isplay()
    {
        return stillplay;
    }
}
