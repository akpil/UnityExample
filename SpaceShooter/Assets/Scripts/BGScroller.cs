using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
	}

    public void SetSpeed(float speed)
    {
        rb.velocity = new Vector3(0, 0, -speed);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
