using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    public GameObject explosionEffect;
    private GameController controller;

    private void Start()
    {
        controller = (GameObject.FindGameObjectWithTag("GameController")).GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBolt"))
        {
            GameObject explosion = Instantiate(explosionEffect);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            controller.AddScore();
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
