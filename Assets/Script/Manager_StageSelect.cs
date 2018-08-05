using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_StageSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void select_stage1()
    {
        SceneManager.LoadScene(1);
    }
    public void select_stage2()
    {
        SceneManager.LoadScene(2);
    }
    public void select_stage3()
    {
        SceneManager.LoadScene(3);
    }

}
