using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour {
    //플레이 맵을 그려주는 스크립트.
    //public Sprite Floor; //바닥
    [Header("Objects")]
    public GameObject Floor; //바닥 (오브젝트)
    public GameObject DeadSpace; //낙사지점.
    public GameObject BackGround; //배경
    public GameObject Skybox; //하늘 배경
    [Header("Accessories")]
    public bool IsShort = true;
    public GameObject[] BgObject; //백그라운드 오브젝트 (게임플레이에 영향x)
    public float[] Frequency;   //백그라운드 오브젝트 빈도 수, 반드시 개수 일치시킬것.

    [Header("Setdatas")]
    public int MapSize; //맵 사이즈
    public int HorizentalSize; //가로길이
    public int EndPostion;
    public int[] DeletedFloor;  //바닥을 지울 위치    
    private int DeletedPick;

    private Vector3 OriginFloorPostion;
    private Transform FloorTransform; //값이 변경될듯. 왜?
    private Vector3 OriginBgPostion;
    private Vector3 OriginSkyboxPostion;

    // Use this for initialization
    void Start() {
        OriginFloorPostion = new Vector3(Floor.transform.position.x, Floor.transform.position.y, Floor.transform.position.z);
        OriginBgPostion = new Vector3(BackGround.transform.position.x, BackGround.transform.position.y, BackGround.transform.position.z);
        OriginSkyboxPostion = new Vector3(Skybox.transform.position.x, Skybox.transform.position.y, Skybox.transform.position.z);
        FloorTransform = new GameObject().transform;
        FloorTransform.position = new Vector3(Floor.transform.position.x, Floor.transform.position.y, Floor.transform.position.z);
        DeletedPick = 0;

        if (EndPostion == 0)
            EndPostion = MapSize;

        // Debug.Log(Floor.transform.position.ToString());
        // Debug.Log(OriginFloorPostion.ToString());
        // Debug.Log(FloorTransform.position.ToString());

        if (IsShort) CopyFloorA2();
        else { CopyFloor(); }
        CopyBground();
        CopySkybox();
        SettingEndline();

        if (BgObject.Length != 0)
        {
            for (int j = 0; j < BgObject.Length; j++)
            {
                copySprites(BgObject[j],Frequency[j]);
            }
        }

    }
    void CopyFloor() //바닥 형성 스크립트.
    {
        /* 1. 추락구간 미 형성 스크립트
         */
        //FloorTransform.position = new Vector3(OriginFloorPostion.x - HorizentalSize, OriginFloorPostion.y, 0);
        //Instantiate(Floor, FloorTransform);

        for (int i = -1; i < MapSize; i++) {
            //FloorTransform.position = new Vector3(OriginFloorPostion.x+(i * HorizentalSize), FloorTransform.position.y, 0) ;
            //Debug.Log(FloorTransform.position.ToString());
            if (DeletedFloor.Length != 0)
            {
                if ((i == DeletedFloor[DeletedPick]) && (DeletedPick < DeletedFloor.Length))
                {    //삭제 포인트 동일시.
                    if (DeletedPick + 1 != DeletedFloor.Length)
                    {
                        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (i * HorizentalSize ), FloorTransform.position.y-3, FloorTransform.position.z), transform.rotation);
                        DeletedPick++;
                    }
                }
                else
                {
                    Instantiate(Floor, new Vector3(OriginFloorPostion.x + (i * HorizentalSize ), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
                }
            }
            else
            {
                Instantiate(Floor, new Vector3(OriginFloorPostion.x + (i * HorizentalSize ), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
            }
        }
    }
    void CopyFloorA2() //추락구간 포함 바닥 형성 스크립트.
    {
        /* 1. 추락구간을 위해 바닥 길이를 1/2로 감소
         * 2. 이로 인해 줄어든 1개 블럭의 길이로, 생성 개수를 2배로 늘림
         * 3. (변화 : HorizentalSize -> HorizentalSize/2, MapSize -> MapSize*2)
         */
        //FloorTransform.position = new Vector3(OriginFloorPostion.x - HorizentalSize, OriginFloorPostion.y, 0);
        //Instantiate(Floor, FloorTransform);
        Debug.Log(DeletedFloor.Length);
        for (int i = -1; i < MapSize * 2; i++)
        {
            //FloorTransform.position = new Vector3(OriginFloorPostion.x+(i * HorizentalSize), FloorTransform.position.y, 0) ;
            //Debug.Log(FloorTransform.position.ToString());
            if (DeletedFloor.Length != 0)
            {
                
                if ((DeletedPick < DeletedFloor.Length)&&(i == DeletedFloor[DeletedPick]))
                {    //삭제 포인트 동일시.
                   // Debug.Log(i + ", " + DeletedFloor[DeletedPick] + ", " + DeletedPick);
                    if (DeletedPick < DeletedFloor.Length)
                    {
                 
                        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (i * HorizentalSize / 2), FloorTransform.position.y - 5, FloorTransform.position.z), transform.rotation);
                        DeletedPick++;
                    }
                }
                else
                {
                    Instantiate(Floor, new Vector3(OriginFloorPostion.x + (i * HorizentalSize / 2), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
                }
            }
            else
            {
                Instantiate(Floor, new Vector3(OriginFloorPostion.x + (i * HorizentalSize / 2), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
            }
        }
    }
    void CopyBground()
    {
        for (int i = -1; i < MapSize; i++)
        {
            Instantiate(BackGround, new Vector3(OriginBgPostion.x + (i * HorizentalSize), OriginBgPostion.y, OriginBgPostion.z), transform.rotation);
        }
    }
    void CopySkybox()
    {
        for (int i = -1; i < MapSize; i++)
        {
            Instantiate(Skybox, new Vector3(OriginSkyboxPostion.x + (i * HorizentalSize), OriginSkyboxPostion.y, OriginSkyboxPostion.z), transform.rotation);
        }
    }
    void copySprites(GameObject SpriteObj,float Frequency)  //배경 오브젝트, 플레이에 영향 x
    {
        float x = SpriteObj.transform.position.x;
        Vector3 originSpritePostion = new Vector3(SpriteObj.transform.position.x, SpriteObj.transform.position.y, SpriteObj.transform.position.z);
        for (int i = -1; i < MapSize*12; i++)
        {
            if (Random.Range(0f,1f)< Frequency)
            Instantiate(SpriteObj, new Vector3(originSpritePostion.x + (i * SpriteObj.transform.localScale.x), originSpritePostion.y, originSpritePostion.z), transform.rotation);
        }

    }
    void SettingEndline()
    {
        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (EndPostion * HorizentalSize / 2), FloorTransform.position.y, FloorTransform.position.z), transform.rotation);
        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (EndPostion * HorizentalSize / 2), FloorTransform.position.y+1, FloorTransform.position.z), transform.rotation);
        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (EndPostion * HorizentalSize / 2), FloorTransform.position.y + 3, FloorTransform.position.z), transform.rotation);
        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (EndPostion * HorizentalSize / 2), FloorTransform.position.y + 5, FloorTransform.position.z), transform.rotation);
        Instantiate(DeadSpace, new Vector3(OriginFloorPostion.x + (EndPostion * HorizentalSize / 2), FloorTransform.position.y + 7, FloorTransform.position.z), transform.rotation);
    }

}


