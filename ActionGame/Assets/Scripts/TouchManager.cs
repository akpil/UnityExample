using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    [SerializeField]
    GameObject effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            //Vector3 ScreenPos = Input.GetTouch(0).position;
#if UNITY_EDITOR
            Vector3 ScreenPos = Input.mousePosition;
#endif
            Vector3 startPosition = 
                Camera.main.ScreenToWorldPoint(new Vector3 (
                                        ScreenPos.x,
                                        ScreenPos.y,
                                        Camera.main.nearClipPlane));
            Vector3 endPosition = 
                Camera.main.ScreenToWorldPoint(new Vector3(
                                        ScreenPos.x,
                                        ScreenPos.y,
                                        Camera.main.farClipPlane));
            Ray r = new Ray(startPosition, endPosition - startPosition);
            RaycastHit result;
            if (Physics.Raycast(r, out result))
            {
                if (this.gameObject == result.transform.gameObject)
                {
                    Debug.Log(result.point);
                    GameObject ef = Instantiate(effect);
                    ef.transform.position = result.point;
                }                
            }


        }
	}
}
