using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static int Score;
    Text ScoreLabel;
    Ranking RankManager;
    bool Checker=true;

    void Awake()
    {
        Score = 0;
    }

	// Use this for initialization
	void Start () {
        ScoreLabel = GameObject.FindGameObjectWithTag("ScorePanel").GetComponent<Text>();
        RankManager = GameObject.FindGameObjectWithTag("Rank").GetComponent<Ranking>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Score < 0)
            Score = 0;
        ScoreLabel.text = ScoreManager.Score.ToString();
        if (Checker == true)
            Score++;
	}
    public void Stoper()
    {
        Checker = false;
        ScoreLabel.enabled = false;
        
        GameObject.FindGameObjectWithTag("ScorePanel").SetActive(false);
        ResultScore();
    }
    public void AddScore(int Point)
    {
        Score += Point;
    }
    public void Pause()
    {
        Checker = false;
    }
    public void Release()
    {
        Checker = true;
    }
    void ResultScore()
    {
        Text ScoreLabelFinal;
        ScoreLabelFinal = GameObject.FindGameObjectWithTag("ScorePanelFinal").GetComponent<Text>();
        ScoreLabelFinal.enabled = true;
        ScoreLabelFinal.text = "최종 스코어 : " + Score + "";        
        Invoke("Popup", 2);        
    }
    void Popup()
    {
        RankManager.setScore(Score);
        //RankManager.Login();
        RankManager.SendScore();
        // Manager_Rank.AddNewHighScore(Score);

        GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().Select();        
    }
}
