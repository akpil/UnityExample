using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    public GameObject explosionEffect;
    private GameController controller;
    private SoundController audio;
    private void Start()
    {
        controller = (GameObject.FindGameObjectWithTag("GameController")).GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBolt"))
        {
            if (audio == null)
            {
                audio = (GameObject.FindGameObjectWithTag("Audio")).GetComponent<SoundController>();
            }
            if (gameObject.CompareTag("Enemy"))
            {
                audio.PlayEffectSound(0);
            }
            else
            {
                audio.PlayEffectSound(1);
            }

            GameObject explosion = Instantiate(explosionEffect);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(other.gameObject);
            controller.AddScore();
        }
        else if (other.CompareTag("Player"))
        {
            if (audio == null)
            {
                audio = (GameObject.FindGameObjectWithTag("Audio")).GetComponent<SoundController>();
            }
            if (gameObject.CompareTag("Enemy"))
            {
                audio.PlayEffectSound(0);
            }
            else
            {
                audio.PlayEffectSound(1);
            }
            audio.PlayEffectSound(2);

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
