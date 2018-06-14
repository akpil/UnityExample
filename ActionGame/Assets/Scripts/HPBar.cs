using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour {

    [SerializeField]
    Image Bar;
    [SerializeField]
    float ActiveTime;

    private void OnEnable()
    {
        StartCoroutine(timer());
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
