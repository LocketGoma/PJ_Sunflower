using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {
    private GameObject Player;

    private bool pressed;


    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void JumpPressed()
    {
        Player.GetComponent<PlayerMovement>().playerJump();
    }
}
