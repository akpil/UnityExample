using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text ScoreText;

    public Text GameOverText;

    public Button ResetButton;

	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
        GameController cont = (GameObject.FindGameObjectWithTag("GameController"))
                                .GetComponent<GameController>();
        ResetButton.onClick.AddListener(cont.Reload);
        GameOverText.text = "";
    }

    public void ShowScore(int score)
    {
        ScoreText.text = "Score : " + score.ToString();
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!!";
        ResetButton.gameObject.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
