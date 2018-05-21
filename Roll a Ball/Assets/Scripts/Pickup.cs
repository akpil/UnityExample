using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Vector3 RotationPerSeond;
    private Vector3 RotationPerFrame;

    private GameController gameControl;

	// Use this for initialization
	void Start () {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameControl = controller.GetComponent<GameController>();

        RotationPerFrame = RotationPerSeond * Time.fixedDeltaTime;
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
    //   void Update () {
    //       transform.Rotate(RotationPerSeond * Time.deltaTime);
    //}
    private void FixedUpdate()
    {
        transform.Rotate(RotationPerFrame);
    }
}
