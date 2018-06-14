using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private ZombieMover[] enemyArr;

    [SerializeField]
    private List<ZombieMover> zombieList;

    [SerializeField]
    private HPBar barPrefeb;

    [SerializeField]
    private Transform UI;

    [SerializeField]
    private List<HPBar> HPBarList;

    private Coroutine enemySpawn;

    [SerializeField]
    private float money;

    public static GameController inst;

    private void Awake()
    {
        zombieList = new List<ZombieMover>();
        HPBarList = new List<HPBar>();
        if (inst == null)
        {
            DontDestroyOnLoad(gameObject);
            inst = this;
        }
        else
        {
            if (inst != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(0);
    }

    public void AddMoney()
    {
        money += 10;
    }

    // Use this for initialization
    void Start () {
        enemyArr = Resources.LoadAll<ZombieMover>("Enemy");
        enemySpawn = StartCoroutine(SpawnEnemy());

        string da = (Resources.Load<TextAsset>("Data/Sample")).text;
        Debug.Log(da);
        money = 0;
    }

    public void Save()
    {
        Debug.Log("Save!!!!!!");
        PlayerPrefs.SetInt("money", 100);
    }

    public void Load()
    {
        Debug.Log("Load!!!!!!");
        Debug.Log(PlayerPrefs.GetInt("money"));
    }

    public HPBar GetHPBar()
    {
        for (int i = 0; i < HPBarList.Count; i++)
        {
            if (!HPBarList[i].gameObject.activeInHierarchy)
            {
                HPBarList[i].gameObject.SetActive(true);
                return HPBarList[i];
            }
        }
        HPBar newone = Instantiate(barPrefeb);
        HPBarList.Add(newone);
        newone.transform.parent = UI;
        newone.transform.localScale = Vector3.one;
        return newone;
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
