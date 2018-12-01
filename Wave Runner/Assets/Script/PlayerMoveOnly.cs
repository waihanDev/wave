using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOnly : MonoBehaviour {

    float angle = 0;
    int xSpeed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        MovePlayer();

	}

    void MovePlayer()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 2;
        pos.y = 0;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }
}
