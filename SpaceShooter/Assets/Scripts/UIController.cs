using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text ScoreText;

	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";

    }

    public void ShowScore(int score)
    {
        ScoreText.text = "Score : " + score.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
