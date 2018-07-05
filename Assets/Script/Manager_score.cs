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
        ScoreLabel.text = Manager_score.score.ToString();

        if (checker == true)
            score++;
	}
    public void stoper()
    {
        checker = false;
    }
}
