using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSoundEffect {
    UI, Attack, ZombieSpawn, ZombieDie, GameOver, Skill
};

public class SoundController : MonoBehaviour {

    public static SoundController inst;

    [SerializeField]
    private AudioClip[] BGMList, EffectList;

    [SerializeField]
    private AudioSource BGM, Effect;

    private void Awake()
    {
        inst = this;
    }

    // Use this for initialization
    void Start () {
        BGMList = Resources.LoadAll<AudioClip>("Sounds/BGM");
        EffectList =  Resources.LoadAll<AudioClip>("Sounds/Effect");
        BGM.clip = BGMList[Random.Range(0, BGMList.Length)];
        BGM.Play();
    }

    public void PlayeEffectSound(eSoundEffect effectID)
    {
        Effect.PlayOneShot(EffectList[(int)effectID]);
    }

}