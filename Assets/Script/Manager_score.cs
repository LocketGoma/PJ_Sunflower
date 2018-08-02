using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Manager_score : MonoBehaviour {
    public static int score;
    Text ScoreLabel;
    bool checker=true;

    void Awake()
    {
        score = 0;
    }

	// Use this for initialization
	void Start () {
        ScoreLabel = GameObject.FindGameObjectWithTag("ScorePanel").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (score < 0)
            score = 0;
        ScoreLabel.text = Manager_score.score.ToString();
        if (checker == true)
            score++;
	}
    public void stoper()
    {
        checker = false;
        ScoreLabel.enabled = false;
        
        GameObject.FindGameObjectWithTag("ScorePanel").SetActive(false);
        ResultScore();
    }
    public void addScore(int point)
    {
        score += point;
    }
    void ResultScore()
    {
        Text ScoreLabelFinal;
        ScoreLabelFinal = GameObject.FindGameObjectWithTag("ScorePanelFinal").GetComponent<Text>();
        ScoreLabelFinal.enabled = true;
        ScoreLabelFinal.text = "최종 스코어 : " + score + "";
    }
}
