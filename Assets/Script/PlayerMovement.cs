using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    [Header("etc")] //여기 있으면 안됨
    public AudioSource effectSound;
    public AudioSource SpecialSound;
    public AudioSource DeadSound;

    [Header("speed&power")]
    public float speed = 10f;
    private float defaultspeed;
    //1단계 : 66% -> 2단계 : 50%의 출력으로.
    public float firstJumpPower = 10f;
    public float secondJumpPower = 7f;


    [Header("Options")]
    public bool useKeyboard = true;  //디버그


    [Header("Don't Touch")]
    private uint jumpStack=0; //0~2
    private Rigidbody2D rbody;
    private bool stillJump = false;
    private bool isOver = false;
    private Animator animator;


    // Use this for initialization
    void Start () {
        rbody = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponentInChildren<Animator>();
        defaultspeed = speed;
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
        if (isOver == true && speed>0)
        {            
            speed/=1.01f;
        }
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
        if (other.gameObject.tag == "deadspace")
        {
            DeadSound.Play();
            isOver = true;
            this.speedRelease();
            jumpStack = 3;
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

    public void speedUp()
    {
        SpecialSound.Play();
        speed = defaultspeed*1.8f;
    }
    public void speedRelease()
    {
        speed = defaultspeed;
    }
    public void speedDown()
    {
        speed = defaultspeed * 0.5f;
    }
}
