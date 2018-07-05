using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    public new string name;
    public EffectSound(string name) { this.name = name; }
    public AudioSource Sound;
}


public class VolumeControl : MonoBehaviour {

    [Header("Background")]
    public AudioSource[] BackGroundSounds;

    [Header("EffectSound")]
    //public EffectSound[] EffectSounds;
    public AudioSource JumpEffectSound;
    public AudioSource ItemGetEffectSound;
    public AudioSource SpecialEffectSound;
    public AudioSource DeathSound;

    [Header("Volume")]
    [Range(0,2)]
    public float BgVolume;
    [Range(0, 2)]
    public float EfVolume;

	// Update is called once per frame
	void Update () {
        volumeUpdate();	
	}

    void volumeUpdate()
    {
        for(int i = 0; i < BackGroundSounds.Length; i++)
        {
            BackGroundSounds[i].volume*=BgVolume;
        }
        if(JumpEffectSound!=null)JumpEffectSound.volume *= EfVolume;
        if(ItemGetEffectSound!=null)ItemGetEffectSound.volume *= EfVolume;
        if(SpecialEffectSound!=null)SpecialEffectSound.volume *= EfVolume;
        if(DeathSound!=null)DeathSound.volume *= EfVolume;
    }
    public void Shutdown()
    {
        for (int i = 0; i < BackGroundSounds.Length; i++)
        {
            BackGroundSounds[i].Stop();
        }        
    }

}
