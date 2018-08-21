using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject Player;
    [Header("etc")] //여기 있으면 안됨
    public AudioSource EffectSound;
    public AudioSource SpecialSound;
    public AudioSource DeadSound;

    [Header("Speed&power")]
    public float Speed = 10f;
    private float DefaultSpeed;
    //1단계 : 66% -> 2단계 : 50%의 출력으로.
    public float JumpPowerFirst = 10f;
    public float JumpPowerSecond = 7f;


    [Header("Options")]
    public bool UsingKeyboard = true;  //디버그


    [Header("Don't Touch")]
    private uint JumpStack=0; //0~2
    private Rigidbody2D Rbody;
    private bool StillJump = false;
    private bool IsOver = false;
    private Animator Animator;


    // Use this for initialization
    void Start () {
        Rbody = Player.GetComponent<Rigidbody2D>();
        Animator = Player.GetComponentInChildren<Animator>();
        DefaultSpeed = Speed;
	}
	// Update is called once per frame
	void Update () {
      this.AutoMove();
        if (Input.GetKeyDown("x"))
        {
            this.PlayerJump();
        }
	}
    void AutoMove()
    {
        transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
        if (IsOver == true && Speed>0)
        {            
            Speed/=1.01f;
        }
    }
   public void PlayerJump()
    {
       // Debug.Log(JumpStack);
        if (this.JumpStackUp())
        {
            if(EffectSound!=null)EffectSound.Play();
          //  Debug.Log("점프 출력");
            Rbody.velocity = Vector2.zero;
            Vector2 JumpVelocity;
            if (StillJump)
                JumpVelocity = new Vector2(0, JumpPowerSecond);
            else
                JumpVelocity = new Vector2(0, JumpPowerFirst);
            Rbody.AddForce(JumpVelocity, ForceMode2D.Impulse);

            StillJump = true;            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(other.ToString());
        if (other.gameObject.tag == "BaseFloor")
        {
            StackRelease();
        }
        if (other.gameObject.tag == "DeadSpace")
        {
            DeadSound.Play();
            IsOver = true;
            this.SpeedRelease();
            JumpStack = 3;
        }
    }
    private void StackRelease()
    {
        JumpStack = 0;
        StillJump = false;
    }
    public bool JumpStackUp()
    {        
        if (JumpStack < 2) { 
        JumpStack++;
        return true;
        }
        return false;
    }    
    public float getSpeed()
    {
        return Speed;
    }
    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void SpeedUp()
    {
        SpecialSound.Play();
        Speed = DefaultSpeed*1.8f;
    }
    public void SpeedRelease()
    {
        Speed = DefaultSpeed;
    }
    public void SpeedDown()
    {
        Speed = DefaultSpeed * 0.5f;
    }
    public void SpeedZero()
    {
        Speed = 0;
    }
}
