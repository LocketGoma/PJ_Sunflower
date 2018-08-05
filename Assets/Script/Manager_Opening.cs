using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Opening : MonoBehaviour{

    private bool stillplay = false;
    private bool lookcredit = false;
    private GameObject Group_Start;
    private GameObject Group_Stageselect;
    private GameObject Group_Selector;
    private GameObject Group_Rank;
    private GameObject Group_Credit;

    // Use this for initialization
    void Awake () {


        Group_Start = GameObject.FindGameObjectWithTag("StartGroup");
        Group_Stageselect = GameObject.FindGameObjectWithTag("StageSelector");
        Group_Rank = GameObject.FindGameObjectWithTag("Rank");
        Group_Credit = GameObject.FindGameObjectWithTag("Credit");
        Group_Stageselect.SetActive(false);
        Group_Rank.SetActive(false);
        Group_Credit.SetActive(false);
    }
	
	// Update is called once per frame
	void Start () {
        if(Starter.Manager_start != null)
        if (Starter.Manager_start.isplay())
        {
            pustStart();
        }
	}
    public void pustStart()
    {
        Group_Start.SetActive(false);
        Group_Stageselect.SetActive(true);
        Group_Rank.SetActive(true);
        Group_Credit.SetActive(true);
        Starter.Manager_start.playing();
    }
    public void pustCredit()
    {
       
        if (!lookcredit)
        {
            Group_Stageselect.SetActive(false);
            GameObject.FindGameObjectWithTag("Credit").GetComponent<Credit>().openImage();
            lookcredit = true;
        }
        else if (lookcredit)
        {
            Debug.Log("active");
            Group_Stageselect.SetActive(true);
            GameObject.FindGameObjectWithTag("Credit").GetComponent<Credit>().closeImage();
            lookcredit = false;
        }
    }
}
