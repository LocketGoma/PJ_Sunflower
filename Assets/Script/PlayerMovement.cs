using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    [Header("etc")] //여기 있으면 안됨
    public AudioSource effectSound;

    [Header("speed&power")]
    public float speed = 10f;
    //1단계 : 66% -> 2단계 : 50%의 출력으로.
    public float firstJumpPower = 10f;
    public float secondJumpPower = 7f;


    [Header("Options")]
    public bool useKeyboard = true;  //디버그


    [Header("Don't Touch")]
    private uint jumpStack=0; //0~2
    private Rigidbody2D rbody;
    private bool stillJump = false;

	// Use this for initialization
	void Start () {
        rbody = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        this.autoMove();
        if (Input.GetKeyDown("x"))
        {
            
            this.playerJump();
        }
	}
    void autoMove()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }
   public void playerJump()
    {
       // Debug.Log(jumpStack);
        if (this.jumpStackUp())
        {
            effectSound.Play();
          //  Debug.Log("점프 출력");
            rbody.velocity = Vector2.zero;
            Vector2 jumpVelocity;
            if (stillJump)
                jumpVelocity = new Vector2(0, secondJumpPower);
            else
                jumpVelocity = new Vector2(0, firstJumpPower);
            rbody.AddForce(jumpVelocity, ForceMode2D.Impulse);

            stillJump = true;
        
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(other.ToString());
        if (other.gameObject.tag == "baseFloor")
        {
            stackRelease();
        }
    }


    private void stackRelease()
    {
        jumpStack = 0;
        stillJump = false;
    }
    public bool jumpStackUp()
    {
        if (jumpStack < 2) { 
        jumpStack++;
        return true;
        }
        return false;
    }    
    public float getSpeed()
    {
        return speed;
    }
    public Vector3 getPosition()
    {
        return transform.position;
    }
}
