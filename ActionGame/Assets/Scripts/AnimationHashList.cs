using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHashList : MonoBehaviour {

    public static int IsWalkAnimHash;
    public static int IsDeadAnimHash;
    public static int AttackAnimHash;

    private void Awake()
    {
        IsDeadAnimHash = Animator.StringToHash("IsDead");
        IsWalkAnimHash = Animator.StringToHash("IsWalk");
        AttackAnimHash = Animator.StringToHash("Attack");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
