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
    private float [] BGVolume;

    [Header("EffectSound")]
    //public EffectSound[] EffectSounds;
    public AudioSource JumpEffectSound;
    public AudioSource ItemGetEffectSound;
    public AudioSource SpecialEffectSound;
    public AudioSource DeathSound;

    private float JEVolume;
    private float IGVolume;
    private float SEVolume;
    private float DDVolume;



    [Header("Volume")]
    [Range(0,2)]
    public float BgVolume;
    [Range(0, 2)]
    public float EfVolume;

	// Update is called once per frame
	void Start () {
        Debug.Log(BackGroundSounds.Length);
        BGVolume = new float[BackGroundSounds.Length];
        for (int i = 0; i < BackGroundSounds.Length; i++)
        {
            BGVolume[i]=BackGroundSounds[i].volume;
        }
        if (JumpEffectSound != null) JEVolume = JumpEffectSound.volume;
        if (ItemGetEffectSound != null) IGVolume = ItemGetEffectSound.volume;
        if (SpecialEffectSound != null) SEVolume = SpecialEffectSound.volume;
        if (DeathSound != null) DDVolume = DeathSound.volume;
        
	}
    void Update()
    {
        volumeUpdate();
    }

    void volumeUpdate()
    {
        for(int i = 0; i < BackGroundSounds.Length; i++)
        {
            BackGroundSounds[i].volume=BGVolume[i]*BgVolume;
        }
        if(JumpEffectSound!=null)JumpEffectSound.volume = JEVolume * EfVolume;
        if(ItemGetEffectSound!=null)ItemGetEffectSound.volume = IGVolume * EfVolume;
        if(SpecialEffectSound!=null)SpecialEffectSound.volume = SEVolume * EfVolume;
        if(DeathSound!=null)DeathSound.volume = DDVolume * EfVolume;
    }
    public void Shutdown()
    {
        for (int i = 0; i < BackGroundSounds.Length; i++)
        {
            BackGroundSounds[i].Stop();
        }        
    }
    public void PauseSound()
    {
        for (int i = 0; i < BackGroundSounds.Length; i++)
        {
            BackGroundSounds[i].Pause();
        }
    }
    public void ReleaseSound()
    {
        for (int i = 0; i < BackGroundSounds.Length; i++)
        {
            BackGroundSounds[i].UnPause();
        }
    }
}
