using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour {

    private Rigidbody rb;
    public float velocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere;
        rb.velocity = new Vector3(0, 0, -velocity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
