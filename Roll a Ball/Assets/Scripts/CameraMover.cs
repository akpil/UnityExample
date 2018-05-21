using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    private Transform playerTransform;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform; //player.GetComponent<Transform>();
        offset = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = offset + playerTransform.position;
	}
}
