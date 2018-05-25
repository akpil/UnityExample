using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTrigger : MonoBehaviour {

    public Vector3 MoveAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BG"))
        {
            other.transform.position += MoveAmount;
        }
    }
}
