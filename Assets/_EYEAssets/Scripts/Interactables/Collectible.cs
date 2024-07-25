using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactables
{
    enum valueTypes { health, coin, experience, score };
        [SerializeField] valueTypes _valueTypes;

    [SerializeField] private int _collectibleValue;
    

    //CORE FUNCTIONS
    public override void RunParticleEffect()
    {
        base.RunParticleEffect();
    }

    public override void PlayAudioClip()
    {
        base.PlayAudioClip();
    }


    //TRIGGER FUNCTIONS
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.tag == "Player")
        {
            PlayAudioClip();

            if (_valueTypes == valueTypes.experience)
            { Debug.Log(_collectibleValue + " Experience Added"); }     //add _collectibleValue to players experience          
            else if (_valueTypes == valueTypes.coin)
            { Debug.Log(_collectibleValue + " Coin Added"); }     //add _collectibleValue to players coin
            else if (_valueTypes == valueTypes.health)
            { Debug.Log(_collectibleValue + " Health Added"); }     //add _collectibleValue to players health
            else if(_valueTypes == valueTypes.score) 
            { Debug.Log(_collectibleValue + " Score Added"); }     //add _collectibleValue to players score

            Destroy(gameObject, 1.2f);
        }
    }
}
