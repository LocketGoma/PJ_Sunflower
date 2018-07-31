using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using LitJson;
using System.IO;
//LitJson 이용.
//http://iflife1124.tistory.com/30
[Serializable]
class Data
{
    public int[] itemSet;
    public double VerticalSize;
    public double HorizentalSize;
}


public class ItemMapping : MonoBehaviour {
    // 맵에 아이템 까는 스크립트.
    // Use this for initialization
    // 0 : 없음 (기본)
    // -1 : ALL
    // 1~9 : 층 별 배치.
    [Header("Postions")]
    [Range (-10,10)]
    public float x_axis;
    [Range(-10,10)]
    public float y_axis;

    [Space]
    [Header("Script")]
    public TextAsset script=null;
    
    [Space]                    
    [Header("Items")]
    public GameObject items;

    private Data data;
    private bool[] formation;
    private bool maked = false;

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
        //string ItemSetString = File.ReadAllText(Application.streamingAssetsPath + "/Data/ItemMap_01.json");     //그냥 이렇게 쓰세요;
        //string ItemSetString = File.ReadAllText(Application.dataPath + "/Resources/Data/ItemMap_01.json");     //그냥 이렇게 쓰세요;

        //TextAsset LoadJson = Resources.Load<TextAsset>("Data/ItemMap_01");
        if (script == null)
        {
            LoadJson = (TextAsset)Resources.Load("Data/ItemMap_02", typeof(TextAsset));
        }
        else
        {
            LoadJson = script;
        }

        string ItemSetString = LoadJson.text;
       // Debug.Log(ItemSetString);        
        data = JsonMapper.ToObject<Data>(ItemSetString);   //타입맞춰서 불러오고
       // Debug.Log(data.HorizentalSize);
       // Debug.Log(data.itemSet[3]);

        formation = new bool[10];
        ClearSetter();
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        while (data.itemSet[i] != -2&&!maked)
        {
          //  Debug.Log(i);
            this.ArraySetter(data.itemSet[i], phaser(data.itemSet[i]));
            this.ItemSetter(i);
            this.ClearSetter();
            i++;
        }
        maked = true;
	}
    int phaser(int input)
    {
        int result=0;
        if (input < 0)
            return 0;

        int multiple = 1;
        for (int i = 0;i < 9; i++)
        {
            if (input >= multiple)   // input과 현재 자리값 비교.
                result++;
            multiple *= 10;         // 자리값 x 10
        }
        return result;
    }
	//ArraySetter : 현재 열에 해당하는 Array 값 세팅
    void ArraySetter(int input,int count)    //input된 수, input 개수.
    {                                       //배열쓸까..
        int multiple = (int)Math.Pow(10, count);
        if (count == 0)
        {
            if (input == -1)
            {
                this.AllSetter();
            }
        }
        for (int i = 0; i < count; i++)
        {
            
            formation[input / multiple]=true;       //input / 현재 배수 (몫 계산)
            input -= (input/multiple)*multiple;     //몫만큼 빼기
            multiple /= 10;                         //현재 배수 10배 감소
            if (input < 10)
                formation[input]=true;
            
        }
    }
    void ItemSetter(int count) //아이템을 깔아줍시다.
    {
        for (int i = 1; i <10; i++) {
            if (formation[i] == true) 
                Instantiate(items, new Vector3(x_axis + (float)(count * data.HorizentalSize), y_axis + (float)(data.VerticalSize * i), items.transform.position.z), transform.rotation);
            formation[i] = false;
        }
    }
    void AllSetter()
    {
        for (int i = 1; i < 10; i++)
        {
            formation[i] = true;
        }
    }
    void ClearSetter()
    {
        for (int i = 1; i < 10; i++)
        {
            formation[i] = false;
        }
    }
}
