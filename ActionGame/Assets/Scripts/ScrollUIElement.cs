using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUIElement : MonoBehaviour {

    [SerializeField]
    Image Icon;

    [SerializeField]
    Button purchaseButton;

    [SerializeField]
    Text title, priceText, contents;

    private int price;

    [SerializeField]
    int ElementID;

    public void SetData(ref ItemData data)
    {
        purchaseButton.interactable = false;
        title.text = data.title;

        price = data.price;
        priceText.text = price.ToString();

        contents.text = data.contetns;
        ElementID = data.ElementID;
        Icon.sprite = LobbyUIController.inst.GetSprite(ElementID);

        purchaseButton.onClick.AddListener(Purcahse);
            //() => { LobbyUIController.inst.PurchaseItem(ElementID); });
    }

    public void Renew(int money)
    {
        if (price <= money)
        {
            purchaseButton.interactable = true;
        }
        else
        {
            purchaseButton.interactable = false;
        }
    }

    private void Purcahse()
    {
        purchaseButton.gameObject.SetActive(false);
        LobbyUIController.inst.PurchaseItem(ElementID);
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
