using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private ZombieMover[] enemyArr;

    private Coroutine enemySpawn;

	// Use this for initialization
	void Start () {
        enemyArr = Resources.LoadAll<ZombieMover>("Enemy");
        enemySpawn = StartCoroutine(SpawnEnemy());
	}

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(enemyArr[Random.Range(0, enemyArr.Length)]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
