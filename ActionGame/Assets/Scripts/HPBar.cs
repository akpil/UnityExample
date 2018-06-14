using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour {

    [SerializeField]
    Image Bar;
    [SerializeField]
    float ActiveTime;

    [SerializeField]
    GameObject BarBG, Income;

    [SerializeField]
    Text IncomeText;

    private void OnEnable()
    {
        StartCoroutine(timer());
        Income.SetActive(false);
        BarBG.SetActive(true);
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(ActiveTime);
        gameObject.SetActive(false);
    }

    public void SetBar(float amount)
    {
        Bar.fillAmount = amount;
    }

    public void SetIncome(float amount)
    {
        IncomeText.text = amount.ToString("F1");
        BarBG.gameObject.SetActive(false);
        Income.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
