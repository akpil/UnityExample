using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    public GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            GameObject explosion = Instantiate(explosionEffect);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            // 점수증가
        }
        else if (other.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(explosionEffect);
            explosion.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

    //private void OnDisable()
    //{
    //    GameObject explosion = Instantiate(explosionEffect);
    //    explosion.transform.position = transform.position;
    //}

    private void OnDestroy()
    {
        //GameObject explosion = Instantiate(explosionEffect);
        //explosion.transform.position = transform.position;
    }
}
