using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMover : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(WalkState());
	}

    private IEnumerator WalkState()
    {
        while (true)
        {
            rb.velocity = transform.right * speed;
            anim.SetBool(AnimationHashList.IsWalkAnimHash, true);
            yield return new WaitForSeconds(.2f);
            rb.velocity = Vector3.zero;
            anim.SetBool(AnimationHashList.IsWalkAnimHash, false);
            yield return new WaitForSeconds(.2f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
