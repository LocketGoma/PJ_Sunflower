using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Opening : MonoBehaviour{

    private bool stillplay = false;
    private GameObject Group_Start;
    private GameObject Group_Stageselect;
    private GameObject Group_Selector;

    // Use this for initialization
    void Awake () {


        Group_Start = GameObject.FindGameObjectWithTag("StartGroup");
        Group_Stageselect = GameObject.FindGameObjectWithTag("StageSelector");
        Group_Stageselect.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Starter.Manager_start.isplay())
        {
            pustStart();
        }
	}
    public void pustStart()
    {
        Group_Start.SetActive(false);
        Group_Stageselect.SetActive(true);
        Starter.Manager_start.playing();
    }
}
