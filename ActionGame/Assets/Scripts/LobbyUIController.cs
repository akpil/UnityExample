using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LobbyUIController : MonoBehaviour {

    [SerializeField]
    private Button GameStartButton;


	// Use this for initialization
	void Start () {
        GameStartButton.onClick.AddListener(StartGame);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
