using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int Score;
    private int MaxScore;

    public UIController UIControl;

	// Use this for initialization
	void Start () {
        Score = 0;
        UIControl.ShowScore(Score);
        MaxScore =  GameObject.FindGameObjectsWithTag("Pickups").Length;
    }

    public void RestartStage()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int value)
    {
        Score += value;
        UIControl.ShowScore(Score);
        if (Score >= MaxScore)
        {
            UIControl.ShowFinish();
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
