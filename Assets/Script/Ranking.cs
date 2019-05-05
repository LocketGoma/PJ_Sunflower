#define Android_build

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class Ranking : MonoBehaviour {
    public int Stage;
    private int Score;
    private string[] LeaderBoardId;
    private string[] Achieve50k;
    private string[] Achieve100k;    
	#if Android_build
    void Awake()
    {
        LeaderBoardId = new string[3];
        LeaderBoardId[0] = "CgkI0u_Xu48EEAIQAQ";    //1스테이지
        LeaderBoardId[1] = "CgkI0u_Xu48EEAIQAg";    //2스테이지
        LeaderBoardId[2] = "CgkI0u_Xu48EEAIQAw";    //3스테이지

        Achieve50k = new string[3];
        Achieve50k[0] = "CgkI0u_Xu48EEAIQBA";
        Achieve50k[1] = "CgkI0u_Xu48EEAIQBQ";
        Achieve50k[2] = "CgkI0u_Xu48EEAIQBg";

        Achieve100k = new string[3];
        Achieve100k[0] = "CgkI0u_Xu48EEAIQBw";
        Achieve100k[1] = "CgkI0u_Xu48EEAIQCA";
        Achieve100k[2] = "CgkI0u_Xu48EEAIQCQ";

        PlayGamesPlatform.Activate();
        //DontDestroyOnLoad(this.gameObject);
    }
    public void setScore(int Score)
    {
        this.Score = Score;
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
        Social.ReportScore(Score, LeaderBoardId[Stage-1], (bool Success) =>
          {
              if (Success)
                  PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderBoardId[Stage - 1]);
          });
        AchievementManager(Score);
    }
    public void LookLeaderBoard()
    {
        Debug.Log("리더보드 시도");
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }
    public void AchievementManager(int ACScore)
    {
        if (ACScore >= 50000)
        {
            Social.ReportProgress(Achieve50k[Stage - 1], 100f, null);
        }
        if (ACScore >= 100000)
        {
            Social.ReportProgress(Achieve100k[Stage - 1], 100f, null);
        }
    }
	#endif
}
