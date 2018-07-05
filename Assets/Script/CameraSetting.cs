using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//http://www.devkorea.co.kr/bbs/board.php?bo_table=m03_lecture&wr_id=3046&page=0&sca=&sfl=&stx=&sst=&sod=&spt=0&page=0&currentId=42
public class CameraSetting : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed = 10f;
    public float gap_vertex = 0f;
    public float gap_horizental = 0f;
    public bool autoSync = true;
    private PlayerMovement pMoveClass;

    // Use this for initialization
    void Start () {
        pMoveClass = player.GetComponent<PlayerMovement>();
        transform.position = pMoveClass.getPosition();
        transform.position = new Vector3(transform.position.x+3+ gap_horizental, transform.position.y+(float)2.5+ gap_vertex, transform.position.z-2);
        if (autoSync)
        {
            cameraSpeed = pMoveClass.getSpeed();
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + cameraSpeed, transform.position.y, transform.position.z);
    }

    public void Shutdown()
    {
        cameraSpeed = 0;
    }
}
