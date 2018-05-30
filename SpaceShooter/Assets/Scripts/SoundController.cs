using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioSource BGM, Effect;

    public AudioClip[] EffectList, BGMList;

	// Use this for initialization
	void Start () {
	}

    public void ToggleVolume()
    {
        if (BGM.volume > 0)
        {
            BGM.volume = 0;
            Effect.volume = 0;
        }
        else
        {
            BGM.volume = 1;
            Effect.volume = 1;
        }
    }

    public void PlayEffectSound(int index)
    {
        Effect.clip = EffectList[index];
        Effect.Play();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
