using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void LeftClick()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    public void RightClick()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftClick();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightClick();
        }
	}
}
