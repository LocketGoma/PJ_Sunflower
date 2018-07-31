using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlling : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private bool end = false;

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
        CancelInvoke();
        if (!end)
        {            
            this.speedUp();
            Invoke("speedRelease", 3);
        }
    }
    public void getSlow()
    {
        CancelInvoke();
        if (!end)
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
        player.GetComponent<PlayerMovement>().speedRelease();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().SetSpeedRepeat();
    }
    void speedDown()
    {
        player.GetComponent<PlayerMovement>().speedDown();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSetting>().SetSpeedRepeat();
    }


}
