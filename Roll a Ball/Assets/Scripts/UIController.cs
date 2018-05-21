using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreText;
    public Text FinishText;

    public GameObject RestartButton;

	// Use this for initialization
	void Start () {
        FinishText.text = "";
        RestartButton.SetActive(false);
    }

    public void ShowFinish()
    {
        FinishText.text = "Finish!!!";
        RestartButton.SetActive(true);
    }

    public void ShowScore(int score)
    {
        ScoreText.text = "Score : " + score.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
