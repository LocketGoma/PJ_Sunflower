using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Rule
 * 1.   폴더는 StaticObject (화면이 이동해도 움직이지 않는 오브젝트들)
 *      DynamicObject (화면이 이동하면 조금이라도 움직이는 오브젝트들)
 *      로 나뉜다.
 *      Static : UI / 배경 (백그라운드)
 *      Dynamic : 배경 (foreground, 앞부분 위치) / 장애물 등
 *  2.  Player 관련은 Player 폴더를 따로 만들어 사용한다.
 *  3.  네이밍.
 *      1) 메소드 명은 camelcase 변형 형태 사용. 명사/동사 순으로 사용.
 *      메소드의 시작글자는 소문자.
 *      (ex : moveObject, jumpPlayer, endGame 등)
 *      2) 변수 명은 명사로 구성. 간격은 아래첨자 ('_') 를 사용
 *      더 큰 범위에 속하는 명사가 앞에, 세부 항목에 속하는 명사가 뒤에 온다.
 *      (ex : power_jump, power_move)
 *  4.  클래스 네이밍은 대문자로 시작 외의 특별한 규칙 없음. 
 *      static은 꼭 필요한 경우 (Manager, PointManger 등)를 제외하고는 사용하지 말것.
 *  5.  정해지지 않은 부분에 대해서는 서로 확인 후 진행하도록 한다.    
 * 
 * 
 * */

public class Manager : MonoBehaviour {
    //게임 매니징 스크립트. '메인' 화면에 들어갈 예정'.
    //테스트 시에는 'Tutorial' 씬에 속함.
    GameObject RestartButton;
    GameObject HomeButton;
	void Awake () {
        RestartButton = GameObject.FindGameObjectWithTag("RestartButton");
        HomeButton = GameObject.FindGameObjectWithTag("HomeButton");
        
        if (RestartButton != null)
        {
            RestartButton.transform.position = GameObject.FindGameObjectWithTag("JumpButton").transform.position;
            RestartButton.SetActive(false);
        }
        if (HomeButton != null)
        {
            HomeButton.transform.position = new Vector2(RestartButton.transform.position.x+200,RestartButton.transform.position.y);
            HomeButton.SetActive(false);
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }
    public void GameEnd()       //스테이지 실패&종료 시
    {        
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().Shutdown();        //카메라 멈추기. 
        GameObject.FindGameObjectWithTag("SoundControl").GetComponent<VolumeControl> ().Shutdown();
        GetComponent<Manager_score>().stoper();
        Select();
    }
    public void ExitGame()      //게임 종료 시 <- 저장 등등
    {
            Application.Quit();
    }
    void Select() {
        RestartButton.SetActive(true);
        HomeButton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AtHome()
    {
        Starter.Manager_start.playing();
        SceneManager.LoadScene(0);
        
    }
	

}
