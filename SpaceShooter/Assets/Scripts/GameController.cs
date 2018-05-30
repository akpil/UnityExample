using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] Astroids;
    public GameObject Enemy;

    public BGScroller[] BGs;

    public int maximumEnemyCount;
    public int maximumAstroidCount;

    public UIController UI;
    
    private float timePeriod;

    private Coroutine hazard;

    // Use this for initialization
    void Start () {
        timePeriod = 3;
        score = 0;
        //GameObject[] bg = GameObject.FindGameObjectsWithTag("BG");
        //BGs = new BGScroller[bg.Length];
        //for (int i = 0; i < BGs.Length; i++)
        //{
        //    BGs[i] = bg[i].GetComponent<BGScroller>();
        //}

        StartCoroutine(StartWaiting());
    }

    public float ScrollSpeed;
    private IEnumerator StartWaiting()
    {
        yield return new WaitForSeconds(timePeriod);
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetSpeed(ScrollSpeed);
        }
        hazard = StartCoroutine(SpawnHazards(0.5f));
    }

    private IEnumerator SpawnHazards(float timeP)
    {
        yield return new WaitForSeconds(timeP);
        while (true)
        {
            yield return new WaitForSeconds(timePeriod);

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

    public void GameOver()
    {
        StopCoroutine(hazard);
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetSpeed(0);
        }
        UI.GameOver();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public int score;
    public void AddScore()
    {
        score += 1;
        UI.ShowScore(score);
    }

	// Update is called once per frame
	void Update () {
        
	}
}
