﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState
{
    Idle, Move, Attack, Dead
};

public class ZombieMover : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform HPLocation;

    private PlayerController player;
    [SerializeField]
    private float MaxHP;
    private float currentHP;

    private Coroutine stateMachine;

    private ZombieState state;

    [SerializeField]
    private Vector3 StartPos;
	// Use this for initialization
	void Awake () {
        StartPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = (GameObject.FindGameObjectWithTag("Player")).
                                GetComponent<PlayerController>();
        state = ZombieState.Move;
        
    }

    private void OnEnable()
    {
        currentHP = MaxHP;
        stateMachine = StartCoroutine(State());
    }

    public void Hit(float damage)
    {
        Debug.Log("zombie hit with : " + damage.ToString());
        currentHP -= damage;
        if (currentHP <= 0)
        {
            state = ZombieState.Dead;
            
        }
    }

    private IEnumerator State()
    {
        while (true)
        {
            switch(state)
            {
                case ZombieState.Move:
                    rb.velocity = transform.right * speed;
                    anim.SetBool(AnimationHashList.IsWalkAnimHash, true);
                    yield return new WaitForSeconds(.2f);
                    rb.velocity = Vector3.zero;
                    anim.SetBool(AnimationHashList.IsWalkAnimHash, false);
                    yield return new WaitForSeconds(.2f);
                    break;
                case ZombieState.Attack:
                    anim.SetBool(AnimationHashList.AttackAnimHash, true);
                    player.Hit(4.3f);
                    yield return new WaitForSeconds(1f);
                    anim.SetBool(AnimationHashList.AttackAnimHash, false);
                    yield return new WaitForSeconds(1f);
                    break;
                case ZombieState.Dead:
                    anim.SetBool(AnimationHashList.IsDeadAnimHash, true);
                    StopCoroutine(stateMachine);
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = ZombieState.Attack;
            anim.SetBool(AnimationHashList.IsWalkAnimHash, false);
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.position = StartPos;
        state = ZombieState.Move;
        anim.SetBool(AnimationHashList.IsDeadAnimHash, false);
        currentHP = MaxHP;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
