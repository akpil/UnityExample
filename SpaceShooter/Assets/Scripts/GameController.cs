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
        StartCoroutine(SpawnHazards(timePeriod));
    }

    private IEnumerator SpawnHazards(float timeP)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeP);

            int astroidCount = Random.Range(1, maximumAstroidCount + 1);
            int enemyCount = Random.Range(1, maximumEnemyCount + 1);
            for (int i = 0; i < astroidCount; i++)
            {
                GameObject ast = Instantiate(Astroids[Random.Range(0, Astroids.Length)]);
                ast.transform.position = new Vector3(Random.Range(-5f, 5f),
                                                    ast.transform.position.y,
                                                    ast.transform.position.z);
                yield return new WaitForSeconds(Random.Range(0,.2f));
            }
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = Instantiate(Enemy);
                enemy.transform.position = new Vector3(Random.Range(-5f, 5f),
                                                    enemy.transform.position.y,
                                                    enemy.transform.position.z);
                yield return new WaitForSeconds(Random.Range(0, .2f));
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
