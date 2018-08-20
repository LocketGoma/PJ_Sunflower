using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//http://www.devkorea.co.kr/bbs/board.php?bo_table=m03_lecture&wr_id=3046&page=0&sca=&sfl=&stx=&sst=&sod=&spt=0&page=0&currentId=42
public class CameraSetting : MonoBehaviour {

    public GameObject player;
    public float CameraSpeed = 10f;
    public float Gap_Vertex = 0f;
    public float Gap_Horizental = 0f;
    public bool AutoSync = true;
    private PlayerMovement pMoveClass;

    // Use this for initialization
    void Start () {
        pMoveClass = player.GetComponent<PlayerMovement>();
        transform.position = pMoveClass.getPosition();
        transform.position = new Vector3(transform.position.x+3+ Gap_Horizental, transform.position.y+(float)2.5+ Gap_Vertex, transform.position.z-2);
        if (AutoSync)
        {
            CameraSpeed = pMoveClass.getSpeed();
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + CameraSpeed, transform.position.y, transform.position.z);
    }

    public void Shutdown()
    {
        CameraSpeed = 0;
    }
    public void SetSpeedRepeat()
    {
        CameraSpeed=pMoveClass.getSpeed();
    }
}
