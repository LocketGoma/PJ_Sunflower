using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {   //말그대로 아이템 스크립트.
    public enum itemTypes { normal, hidden }
    public itemTypes typeSelected;


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("get items");
            if (typeSelected == itemTypes.normal)
            {
                //이건 점수 올려주고
            }
            if (typeSelected == itemTypes.hidden)
            {
                //이건 특수능력 주고
            }
            Destroy(gameObject);     //수정할것.
        }
    }


}
