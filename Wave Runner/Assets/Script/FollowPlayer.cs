﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject PlayerObj;
    float smoothTime = 0.15f;
    Vector3 velocity = Vector3.zero;
    public int yOffSet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        FollowPlayerObj();

	}

    void FollowPlayerObj()
    {
        Vector3 targetPosition = PlayerObj.transform.TransformPoint(new Vector3(0, yOffSet, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
