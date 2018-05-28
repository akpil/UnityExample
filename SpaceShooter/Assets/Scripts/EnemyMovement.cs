using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform BoltPos;
    private Rigidbody rb;
    public float Speed;
    public Transform bolt;

    public float maximumShootPeriod;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
        StartCoroutine(Shoot());
        StartCoroutine(Tilt());
	}

    private IEnumerator Tilt()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, .3f));
        float verticalSpeed = transform.position.x * -2;
        rb.velocity = new Vector3(verticalSpeed, rb.velocity.y, rb.velocity.z);
        transform.rotation = Quaternion.Euler(0, 180, verticalSpeed  * 6);

        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        //rb.velocity = transform.forward * Speed;
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, maximumShootPeriod));
            Transform newBolt = Instantiate(bolt);
            newBolt.position = BoltPos.position;
            newBolt.rotation = BoltPos.rotation;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
