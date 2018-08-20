using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {   //말그대로 아이템 스크립트.
    public enum itemTypes {Normal, Hidden,Slow }
    public itemTypes TypeSelected;

    public int Score;
    private bool IsActive = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player" && !IsActive)
        {
            //Debug.Log("get items");
            //if (typeSelected == itemTypes.normal)
            //{
                GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreManager>().AddScore(Score);
                //이건 점수 올려주고
            //}
            if (TypeSelected == itemTypes.Hidden)
            {
                //이건 특수능력 주고                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>().getHidden();
            }
            if (TypeSelected == itemTypes.Slow)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlling>().getSlow();
            }
            IsActive = true;
            Destroy(gameObject);     //수정할것.

        }
    }


}
