using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class Ranking : MonoBehaviour {
    public int stage;
    private int score;
    private string[] LeaderBoardId;

    void Awake()
    {
        LeaderBoardId = new string[3];
        LeaderBoardId[0] = "CgkI0u_Xu48EEAIQAQ";    //1스테이지
        LeaderBoardId[1] = "CgkI0u_Xu48EEAIQAg";    //2스테이지
        LeaderBoardId[2] = "CgkI0u_Xu48EEAIQAw";    //3스테이지
        PlayGamesPlatform.Activate();
        //DontDestroyOnLoad(this.gameObject);
    }
    public void setScore(int score)
    {
        this.score = score;
    }
    /*
    public void Login()
    {
        Social.localUser.Authenticate((bool success) => { // handle success or failure 
        if ( true == success ) { SendScore(); // 로그인과 동시에 점수 보내줌. ( 사용자가 알아서 ) ShowLeaderBoard(); // 점수 보내주고 리더보드 보여줌 . 
        } else{ Debug.Log("Login Fail"); } });            
    }
    */
    public void SendScore()
    {
        Social.ReportScore(score, LeaderBoardId[stage-1], (bool success) =>
          {
              if (success)
                  PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderBoardId[stage - 1]);
          });            
    }
    public void LookLeaderBoard()
    {
        Debug.Log("리더보드 시도");
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }
}
