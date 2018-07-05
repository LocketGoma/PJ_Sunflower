using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControler : MonoBehaviour {
    //점프 콜, 점프 스택 관련
    //UI에 붙습니다.
	// Use this for initialization

    [Header("초기 설정")]
    public GameObject targetPlayer;
    public int maxStack = 3;
    PlayerMovement movement;

    void Start()
    {
        movement = targetPlayer.GetComponent<PlayerMovement>();
    }

	// Update is called once per frame
	void Update () {
		
	}
    public void pushJump()
    {

    }

}
