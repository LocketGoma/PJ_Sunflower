using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleted_floor : MonoBehaviour {

    private bool isUse = true;

    void OnTriggerEnter2D(Collider2D other)
    {
     //   Debug.Log("hi");
        if (other.gameObject.tag == "Player")
        {
            isUse = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
     //   Debug.Log("run?");
        if (other.gameObject.tag == "Player")
        {
            isUse = false;
            StartCoroutine("counter");
        }
    }
    IEnumerator counter()
    {
     //   Debug.Log("run");
       yield return new WaitForSeconds(3);
       if (isUse == false)
       {
            Debug.Log("destroy!");
            Destroy(gameObject);            
       }
       StartCoroutine("counter");
    }

}
