using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningManager : MonoBehaviour{

    private bool StillPlay = false;
    private bool LookCredit = false;
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
        if(Starter.StartManager != null)
        if (Starter.StartManager.getPlayStatus())
        {
            PustStart();
        }
	}
    public void PustStart()
    {
        Group_Start.SetActive(false);
        Group_Stageselect.SetActive(true);
        Group_Rank.SetActive(true);
        Group_Credit.SetActive(true);
        Starter.StartManager.Playing();
    }
    public void PustCredit()
    {
       
        if (!LookCredit)
        {
            Group_Stageselect.SetActive(false);
            GameObject.FindGameObjectWithTag("Credit").GetComponent<Credit>().OpenImage();
            LookCredit = true;
        }
        else if (LookCredit)
        {
            //Debug.Log("active");
            Group_Stageselect.SetActive(true);
            GameObject.FindGameObjectWithTag("Credit").GetComponent<Credit>().CloseImage();
            LookCredit = false;
        }
    }
}
