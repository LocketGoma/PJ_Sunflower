using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlling : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private bool end = false;
    private bool isup = false;
    private int icestack;

    // Use this for initialization
    void Start () {
        player = this.gameObject;
        animator = player.GetComponentInChildren<Animator>();
        //Debug.Log("this:" + player.gameObject.tag);
    }
	void OnTriggerEnter2D(Collider2D other)
    {
     //   Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "deadspace")
            this.isDead();
    }

    public void isDead()
    {
        CancelInvoke();
        player.GetComponent<PlayerMovement>().speedRelease();
        player.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("isOver", true);
        if (end == false)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().GameEnd();
            end = true;
        }
    }
    public bool isAlive()
    {
        return !end;
    }

    public void getHidden(){
        if (!isup)
        {
            CancelInvoke();
            if (!end)
            {
                isup = true;
                icestack = 0;
                this.speedUp();
                Invoke("speedRelease", 3);
            }
        }
    }
    public void getSlow()
    {
        icestack++;
        Debug.Log("iceStack:" + icestack);
        if (isup && icestack > 2)
        {
            speedRelease();
        }
            CancelInvoke();
         if (!isup&&!end)
         {
             this.speedDown();
             Invoke("speedRelease", 3);
        }
        
    }
    void speedUp()
    {        
        player.GetComponent<PlayerMovement>().speedUp();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().SetSpeedRepeat();
    }
    void speedRelease()
    {
        isup = false;
        player.GetComponent<PlayerMovement>().speedRelease();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().SetSpeedRepeat();
    }
    void speedDown()
    {
        icestack = 0;
        player.GetComponent<PlayerMovement>().speedDown();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().SetSpeedRepeat();
    }


}
