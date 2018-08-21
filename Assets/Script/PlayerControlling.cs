using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlling : MonoBehaviour {

    private GameObject Player;
    private Animator Animator;
    private bool IsEnd = false;
    private bool IsUp = false;
    private int IceStack;

    private CameraSetting CameraStatus;

    // Use this for initialization
    void Start () {
        Player = this.gameObject;
        Animator = Player.GetComponentInChildren<Animator>();
        CameraStatus = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>();
        //Debug.Log("this:" + Player.gameObject.tag);
    }
	void OnTriggerEnter2D(Collider2D other)
    {
     //   Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "DeadSpace")
            this.IsDead();
    }

    public void IsDead()
    {
        CancelInvoke();
        Player.GetComponent<PlayerMovement>().SpeedRelease();
        Player.GetComponent<BoxCollider2D>().enabled = false;
        Animator.SetBool("isOver", true);
        if (IsEnd == false)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().EndGame();
            IsEnd = true;
        }
    }
    public bool getAliveStatus()
    {
        return !IsEnd;
    }

    public void getHidden(){
        if (!IsUp)
        {
            CancelInvoke();
            if (!IsEnd)
            {
                IsUp = true;
                IceStack = 0;
                this.SpeedUp();
                Invoke("SpeedRelease", 3);
            }
        }
    }
    public void getSlow()
    {
        IceStack++;
        Debug.Log("IceStack:" + IceStack);
        if (IsUp && IceStack > 2)
        {
            SpeedRelease();
        }
            CancelInvoke();
         if (!IsUp&&!IsEnd)
         {
             this.SpeedDown();
             Invoke("SpeedRelease", 3);
        }
        
    }
    void SpeedUp()
    {        
        Player.GetComponent<PlayerMovement>().SpeedUp();
        CameraStatus.SetSpeedRepeat();
    }
    void SpeedRelease()
    {
        IsUp = false;
        Player.GetComponent<PlayerMovement>().SpeedRelease();
        CameraStatus.SetSpeedRepeat();
    }
    void SpeedDown()
    {
        IceStack = 0;
        Player.GetComponent<PlayerMovement>().SpeedDown();
        CameraStatus.SetSpeedRepeat();
    }
    public void AtPause()
    {
        Player.GetComponent<PlayerMovement>().SpeedZero();
        CameraStatus.SetSpeedRepeat();
    }
    public void AtRelease()
    {
        this.SpeedRelease();
    }


}
