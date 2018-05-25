using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] Astroids;
    public GameObject Enemy;

    public int maximumEnemyCount;
    public int maximumAstroidCount;

    private float timePeriod;

    // Use this for initialization
    void Start () {
        timePeriod = 3;
    }
	
	// Update is called once per frame
	void Update () {
        if (timePeriod > 0)
        {
            timePeriod -= Time.deltaTime;
        }
        else
        {
            int astroidCount = Random.Range(1, maximumAstroidCount + 1);
            for (int i = 0; i < astroidCount; i++)
            {
                GameObject ast = Instantiate(Astroids[Random.Range(0, Astroids.Length)]);
                ast.transform.position = new Vector3(Random.Range(-5f, 5f),
                                                    ast.transform.position.y,
                                                    ast.transform.position.z); 
            }
            timePeriod = 3;
        }
	}
}
