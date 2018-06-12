using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// 원래 이자리에 있으면 안됨
[Serializable]
public class ItemData
{
    public int price;
    public int ElementID;
    public string title, contetns;
}

public class LobbyUIController : MonoBehaviour {
    public static LobbyUIController inst;
    [SerializeField]
    private Button GameStartButton;

    [SerializeField]
    ItemData[] ItemList;
    [SerializeField]
    Sprite[] ItemIcon;

    [SerializeField]
    ScrollUIElement[] ScrollElements;

    [SerializeField]
    private int money;

    private void Awake()
    {
        inst = this;
        // 실제론 안쓰는 코드 예제임
        ItemList = new ItemData[3];
        for (int i = 0; i < ItemList.Length; i++)
        {
            ItemList[i] = new ItemData();
        }
        ItemList[0].title = "사막";
        ItemList[1].title = "공동묘지";
        ItemList[2].title = "설원";

        ItemList[0].contetns = "사막맵입니다.";
        ItemList[1].contetns = "묘지맵입니다.";
        ItemList[2].contetns = "설원맵입니다.";

        ItemList[0].price = 100;
        ItemList[1].price = 200;
        ItemList[2].price = 300;

        ItemList[0].ElementID = 0;
        ItemList[1].ElementID = 1;
        ItemList[2].ElementID = 2;
    }

    // Use this for initialization
    void Start () {
        GameStartButton.onClick.AddListener(StartGame);
        for (int i = 0; i < ScrollElements.Length; i++)
        {
            ScrollElements[i].SetData(ref ItemList[i]);
            ScrollElements[i].Renew(money);
        }
    }

    public void AddMoney()
    {
        money += 50;
        UIRenew();
    }

    public Sprite GetSprite(int id)
    {
        return ItemIcon[id];
    }

    public void UIRenew()
    {
        for (int i = 0; i < ScrollElements.Length; i++)
        {
            ScrollElements[i].Renew(money);
        }
    }

    public void PurchaseItem(int id)
    {
        money -= ItemList[id].price;

        UIRenew();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
