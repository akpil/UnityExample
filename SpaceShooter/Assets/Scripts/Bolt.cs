using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    private Rigidbody rb;
    public float velocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        // 부딪히는 모든 물체 파괴
        if (other.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
