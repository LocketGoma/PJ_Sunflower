using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour {
    //플레이 맵을 그려주는 스크립트.
    //public Sprite floor; //바닥
    [Header("Objects")]
    public GameObject floor; //바닥 (오브젝트)
    public GameObject deadspace; //낙사지점.
    public GameObject background; //배경
    public GameObject skybox; //하늘 배경
    [Header("Accessories")]
    public GameObject[] bgObject; //백그라운드 오브젝트 (게임플레이에 영향x)
    public float[] frequency;   //백그라운드 오브젝트 빈도 수, 반드시 개수 일치시킬것.

    [Header("Setdatas")]
    public int mapSize; //맵 사이즈
    public int horizentalSize; //가로길이
    public int[] deletedFloor;  //바닥을 지울 위치
    private int deletedPick;

    private Vector3 originFloorPostion;
    private Transform FloorTransform; //값이 변경될듯. 왜?
    private Vector3 originBgPostion;
    private Vector3 originSkyboxPostion;

    // Use this for initialization
    void Start() {
        originFloorPostion = new Vector3(floor.transform.position.x, floor.transform.position.y, floor.transform.position.z);
        originBgPostion = new Vector3(background.transform.position.x, background.transform.position.y, background.transform.position.z);
        originSkyboxPostion = new Vector3(skybox.transform.position.x, skybox.transform.position.y, skybox.transform.position.z);
        FloorTransform = new GameObject().transform;
        FloorTransform.position = new Vector3(floor.transform.position.x, floor.transform.position.y, floor.transform.position.z);
        deletedPick = 0;

       // Debug.Log(floor.transform.position.ToString());
       // Debug.Log(originFloorPostion.ToString());
       // Debug.Log(FloorTransform.position.ToString());

        copyFloor();
        copyBground();
        copySkybox();

        if (bgObject.Length != 0)
        {
            for (int j = 0; j < bgObject.Length; j++)
            {
                copySprites(bgObject[j],frequency[j]);
            }
        }

    }
    void copyFloor() //바닥 형성 스크립트.
    {
        /* 1. 추락구간을 위해 바닥 길이를 1/2로 감소
         * 2. 이로 인해 줄어든 1개 블럭의 길이로, 생성 개수를 2배로 늘림
         * 3. (변화 : horizentalSize -> horizentalSize/2, mapsize -> mapsize*2)
         */
        //FloorTransform.position = new Vector3(originFloorPostion.x - horizentalSize, originFloorPostion.y, 0);
        //Instantiate(floor, FloorTransform);

        for (int i = -1; i < mapSize * 2; i++) {
            //FloorTransform.position = new Vector3(originFloorPostion.x+(i * horizentalSize), FloorTransform.position.y, 0) ;
            Debug.Log(FloorTransform.position.ToString());
            if (deletedFloor.Length != 0)
            {
                if ((i == deletedFloor[deletedPick]) && (deletedPick < deletedFloor.Length))
                {    //삭제 포인트 동일시.
                    if (deletedPick + 1 != deletedFloor.Length)
                    {
                        Instantiate(deadspace, new Vector3(originFloorPostion.x + (i * horizentalSize / 2), FloorTransform.position.y-3, FloorTransform.position.z), transform.rotation);
                        deletedPick++;
                    }
                }
                else
                {
                    Instantiate(floor, new Vector3(originFloorPostion.x + (i * horizentalSize / 2), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
                }
            }
            else
            {
                Instantiate(floor, new Vector3(originFloorPostion.x + (i * horizentalSize / 2), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
            }
        }
    }
    void copyBground()
    {
        for (int i = -1; i < mapSize; i++)
        {
            Instantiate(background, new Vector3(originBgPostion.x + (i * horizentalSize), originBgPostion.y, originBgPostion.z), transform.rotation);
        }
    }
    void copySkybox()
    {
        for (int i = -1; i < mapSize; i++)
        {
            Instantiate(skybox, new Vector3(originSkyboxPostion.x + (i * horizentalSize), originSkyboxPostion.y, originSkyboxPostion.z), transform.rotation);
        }
    }
    void copySprites(GameObject SpriteObj,float frequency)  //배경 오브젝트, 플레이에 영향 x
    {
        float x = SpriteObj.transform.position.x;
        Vector3 originSpritePostion = new Vector3(SpriteObj.transform.position.x, SpriteObj.transform.position.y, SpriteObj.transform.position.z);
        for (int i = -1; i < mapSize*12; i++)
        {
            if (Random.Range(0f,1f)< frequency)
            Instantiate(SpriteObj, new Vector3(originSpritePostion.x + (i * SpriteObj.transform.localScale.x), originSpritePostion.y, originSpritePostion.z), transform.rotation);
        }

    }
}


