using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public float xMin, xMax, zMin, zMax;
    public float tiltAngle;

    public Transform Bolt;
    public Transform BoltPosition;
    public float firePeriod;
    private float nextFireTime;

    public GameObject dieEffect;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal, 0, vertical) * Speed;

        transform.rotation = Quaternion.Euler(0,0, -horizontal * tiltAngle);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax)
                                        ,0
                                        , Mathf.Clamp(transform.position.z, zMin, zMax));

        if (Input.GetButton("Fire1"))
        {
            if (nextFireTime <= 0)
            {
                Transform newBolt = Instantiate(Bolt);
                newBolt.position = BoltPosition.position;
                nextFireTime = firePeriod;
                //GameObject newBolt = Instantiate(Bolt);
                //newBolt.transform.position = BoltPosition.position;
                //nextFireTime = firePeriod;
            }
            
        }
        nextFireTime -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(dieEffect);
        effect.transform.position = transform.position;
    }
}
