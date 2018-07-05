using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlling : MonoBehaviour {

    private GameObject player;


	// Use this for initialization
	void Start () {
        player = this.gameObject;
        //Debug.Log("this:" + player.gameObject.tag);
	}
	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "deadspace")
            this.isDead();

    }

    public void isDead()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().GameEnd();
    }

}
