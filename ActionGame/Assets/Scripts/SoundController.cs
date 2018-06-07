using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    [SerializeField]
    private AudioClip[] BGMList, EffectList;

	// Use this for initialization
	void Start () {
        BGMList = Resources.LoadAll<AudioClip>("Sounds/BGM");
        EffectList =  Resources.LoadAll<AudioClip>("Sounds/Effect");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}