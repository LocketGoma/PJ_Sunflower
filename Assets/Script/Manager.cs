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
 *      1) 메소드 명은 camelcase 변형 형태 사용. 동사/명사 순으로 사용.
 *      메소드의 시작글자는 대문자.
 *      (ex : MoveObject, JumpPlayer, EndGame 등)
 *      2) 변수 명은 명사로 구성. camelcase 사용.
 *      더 큰 범위에 속하는 명사가 앞에, 세부 항목에 속하는 명사가 뒤에 온다.
 *      (ex : power_jump, power_move)
 *      3) 태그명은 메소드명과 같은 규칙 사용.
 *  4.  클래스 네이밍은 대문자로 시작 외의 특별한 규칙 없음. 
 *      static은 꼭 필요한 경우 (Manager, PointManger 등)를 제외하고는 사용하지 말것.
 *    
 * */

public class Manager : MonoBehaviour {
    //게임 매니징 스크립트. '메인' 화면에 들어갈 예정'.
    //테스트 시에는 'Tutorial' 씬에 속함.
    GameObject RestartButton;
    GameObject HomeButton;
    GameObject ReleasePanel;
    ScoreManager SCManager;
    //GameObject HomeButtonAtPause;
    public bool IsMain = false;
    private bool IsPause = false;
    private bool IsEnd = false;

	void Awake () {
        RestartButton = GameObject.FindGameObjectWithTag("RestartButton");
        HomeButton = GameObject.FindGameObjectWithTag("HomeButton");
        ReleasePanel = GameObject.FindGameObjectWithTag("ReturnPanel");
        SCManager = GetComponent<ScoreManager>();
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
        if (ReleasePanel != null)
        {
            ReleasePanel.SetActive(false);
        }
    }
    void Update()
    {        
        if (!IsEnd&&(Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown("s")))
        {
           Debug.Log("ESC");
                if (IsMain)
                {
                    ExitGame();
                }
                else
                {
                    PauseGame();
                }
        }
        if (IsPause)
            PauseGame();
    }
    public void EndGame()       //스테이지 실패&종료 시
    {
        IsEnd = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().Shutdown();        //카메라 멈추기. 
        GameObject.FindGameObjectWithTag("SoundControl").GetComponent<VolumeControl> ().Shutdown();
        SCManager.Stoper();
        
    }
    public void ExitGame()      //게임 종료 시 <- 저장 등등
    {
            Application.Quit();
    }
    public void Select() {
        RestartButton.SetActive(true);
        HomeButton.SetActive(true);
    }
    public void Restart()
    {
        this.ReleaseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AtHome()
    {
        this.ReleaseGame();
        Starter.StartManager.Playing();
        SceneManager.LoadScene(0);        
    }
    public void PauseGame()
    {
        if (!IsEnd)
        {
            Time.timeScale = 0;
            IsPause = true;

            ReleasePanel.SetActive(true);
            Select();
            SCManager.Pause();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>().AtPause();
            GameObject.FindGameObjectWithTag("SoundControl").GetComponent<VolumeControl>().PauseSound();
            if (Input.GetKeyDown(KeyCode.Escape))
                this.ReleaseGame();
        }
    }
	public void ReleaseGame()
    {
        Time.timeScale = 1;
        IsPause = false;

        ReleasePanel.SetActive(false);
        RestartButton.SetActive(false);
        HomeButton.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>().AtRelease();
        GameObject.FindGameObjectWithTag("SoundControl").GetComponent<VolumeControl>().ReleaseSound();
        SCManager.Release();
    }

}
