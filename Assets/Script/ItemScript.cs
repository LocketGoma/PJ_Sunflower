using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {   //말그대로 아이템 스크립트.
    public enum itemTypes { normal, hidden,slow }
    public itemTypes typeSelected;

    public int score;
    private bool isActive = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player" && !isActive)
        {
            Debug.Log("get items");
            //if (typeSelected == itemTypes.normal)
            //{
                GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager_score>().addScore(score);
                //이건 점수 올려주고
            //}
            if (typeSelected == itemTypes.hidden)
            {
                //이건 특수능력 주고                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>().getHidden();
            }
            if (typeSelected == itemTypes.slow)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>().getSlow();
            }
            isActive = true;
            Destroy(gameObject);     //수정할것.

        }
    }


}
