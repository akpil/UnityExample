using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
    public void LeftClick()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    public void RightClick()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void Attack()
    {
        SoundController.inst.PlayeEffectSound(eSoundEffect.Attack);
        anim.SetBool(AnimationHashList.AttackAnimHash, true);
    }

    public void SetAttackFalse()
    {
        anim.SetBool(AnimationHashList.AttackAnimHash, false);
        
    }

    public void Hit(float damage)
    {
        //Debug.Log("zombie attack palyer with damage : " + damage.ToString());
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftClick();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightClick();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
	}
}
