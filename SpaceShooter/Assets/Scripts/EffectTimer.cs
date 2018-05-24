using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {

    public float Timeout;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = Timeout;
    }
	
	void Update () {
        if (currentTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
	}
}
