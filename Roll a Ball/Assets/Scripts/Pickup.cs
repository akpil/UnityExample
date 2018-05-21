using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Vector3 RotationPerSeond;

    private GameController gameControl;

	// Use this for initialization
	void Start () {
        Debug.Log(RotationPerSeond);
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameControl = controller.GetComponent<GameController>();
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gameControl.AddScore(1);
        }
    }


    // Update is called once per frame
    void Update () {
        
	}
}
