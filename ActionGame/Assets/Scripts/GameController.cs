using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private ZombieMover[] enemyArr;

    [SerializeField]
    private List<ZombieMover> zombieList;

    private Coroutine enemySpawn;

    private void Awake()
    {
        zombieList = new List<ZombieMover>();
    }

    // Use this for initialization
    void Start () {
        enemyArr = Resources.LoadAll<ZombieMover>("Enemy");
        enemySpawn = StartCoroutine(SpawnEnemy());
	}

    private IEnumerator SpawnEnemy()
    {
        bool SpawnFlag = true;
        while (true)
        {
            yield return new WaitForSeconds(2);
            for (int i = 0; i < zombieList.Count; i++)
            {
                if (!zombieList[i].gameObject.activeInHierarchy)
                {
                    zombieList[i].gameObject.SetActive(true);
                    SpawnFlag = false;
                    break;
                }
            }
            if (SpawnFlag)
            {
                zombieList.Add(Instantiate(enemyArr[Random.Range(0, enemyArr.Length)]));
            }
            SpawnFlag = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
