using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using LitJson;
using System.IO;
//LitJson 이용.
//http://iflife1124.tistory.com/30
public class ItemMapping : MonoBehaviour {
    // 맵에 아이템 까는 스크립트.
    // Use this for initialization
    // 0 : 없음 (기본)
    // -1 : ALL
    // 1~9 : 층 별 배치.
    [Serializable]
    class Data
    {
        public int[] itemSet;
        public double VerticalSize;
        public double HorizentalSize;
    }

    [Header("Postions")]
    [Range (-10,10)]
    public float X_Axis;
    [Range(-10,10)]
    public float Y_Axis;

    [Space]
    [Header("Script")]
    public TextAsset Script=null;
    
    [Space]                    
    [Header("Items")]
    public GameObject Items;

    private Data DataObject;
    private bool[] Formation;
    private bool Marked = false;

    private TextAsset LoadJson;

    /*아이템 위치 뽑아내는 방법.
     * 1. itemMap 개수 설정 (좀 많이)
     * 2. 각 itemMap별로 length 추출
     * 3. ToCharArray 이용.
     * 4. 각 itemMap의 length만큼 for문을 돌려서 ToCharArray에서 문자 하나씩 뽑아냄
     * 5. 추출된 문자를 숫자로 변환
     * 6. 변환된 숫자에 맞는 위치에 아이템 배치
     * 7. 2~6 반복    
     */

    void Start () {
        if (Script == null)
        {
            LoadJson = (TextAsset)Resources.Load("Data/ItemMap_02", typeof(TextAsset));
        }
        else
        {
            LoadJson = Script;
        }
        string ItemSetString = LoadJson.text;
        DataObject = JsonMapper.ToObject<Data>(ItemSetString);   //타입맞춰서 불러오고

        Formation = new bool[10];
        ClearSetter();
    }
	
	void Update () {
        int i = 0;
        while (DataObject.itemSet[i] != -2&&!Marked)
        {
            this.ArraySetter(DataObject.itemSet[i], Phaser(DataObject.itemSet[i]));
            this.ItemSetter(i);
            this.ClearSetter();
            i++;
        }
        Marked = true;
	}
    int Phaser(int Input)
    {
        int result=0;
        if (Input < 0)
            return 0;

        int multiple = 1;
        for (int i = 0;i < 9; i++)
        {
            if (Input >= multiple)   // Input과 현재 자리값 비교.
                result++;
            multiple *= 10;         // 자리값 x 10
        }
        return result;
    }
	//ArraySetter : 현재 열에 해당하는 Array 값 세팅
    void ArraySetter(int Input,int Count)    //Input된 수, Input 개수.
    {                                       //배열쓸까..
        int Multiple = (int)Math.Pow(10, Count);
        if (Count == 0)
        {
            if (Input == -1)
            {
                this.AllSetter();
            }
        }
        for (int i = 0; i < Count; i++)
        {
            
            Formation[Input / Multiple]=true;       //Input / 현재 배수 (몫 계산)
            Input -= (Input/Multiple)*Multiple;     //몫만큼 빼기
            Multiple /= 10;                         //현재 배수 10배 감소
            if (Input < 10)
                Formation[Input]=true;
            
        }
    }
    void ItemSetter(int Count) //아이템을 깔아줍시다.
    {
        for (int i = 1; i <10; i++) {
            if (Formation[i] == true) 
                Instantiate(Items, new Vector3(X_Axis + (float)(Count * DataObject.HorizentalSize), Y_Axis + (float)(DataObject.VerticalSize * i), Items.transform.position.z), transform.rotation);
            Formation[i] = false;
        }
    }
    void AllSetter()
    {
        for (int i = 1; i < 10; i++)
        {
            Formation[i] = true;
        }
    }
    void ClearSetter()
    {
        for (int i = 1; i < 10; i++)
        {
            Formation[i] = false;
        }
    }
}
