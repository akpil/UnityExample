using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int Score;

    public UIController UIControl;

	// Use this for initialization
	void Start () {
        Score = 0;
        UIControl.ShowScore(Score);
    }

    public void AddScore(int value)
    {
        Score += value;
        UIControl.ShowScore(Score);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
