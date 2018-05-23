﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public float xMin, xMax, zMin, zMax;
    public float tiltAngle;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal, 0, vertical) * Speed;

        Debug.Log(horizontal);

        transform.rotation = Quaternion.Euler(0,0, -horizontal * tiltAngle);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax)
                                        ,0
                                        , Mathf.Clamp(transform.position.z, zMin, zMax));
	}
}
