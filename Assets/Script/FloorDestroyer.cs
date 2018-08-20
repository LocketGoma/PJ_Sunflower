using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyer : MonoBehaviour {

    private bool IsUse = true;

    PlayerControlling PlayerStatus;

    void Awake()
    {
        PlayerStatus=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     //   Debug.Log("hi");
        if (other.gameObject.tag == "Player")
        {
            IsUse = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
     //   Debug.Log("run?");
        if (other.gameObject.tag == "Player")
        {
            IsUse = false;
            StartCoroutine("Counter");
        }
    }
    
    void Update()
    {
        if (!PlayerStatus.getAliveStatus())
            this.isOver();
    }
    
    void isOver()
    {
        StopAllCoroutines();
    }
    IEnumerator Counter()
    {
     //   Debug.Log("run");
       yield return new WaitForSeconds(5);
       if (IsUse == false)
       {
           // Debug.Log("destroy!");
            Destroy(gameObject);            
       }
       StartCoroutine("Counter");
    }

}
