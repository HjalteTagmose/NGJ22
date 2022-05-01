using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlaySound : MonoBehaviour
{
    public AK.Wwise.Event eventToPlay;
    public GameObject GameObjectToPlayFrom; 

    public void PlaySoundEvent()
    {
        if (GameObjectToPlayFrom == null)
        {
            eventToPlay.Post(this.gameObject);  
        }
        else
        {
            eventToPlay.Post(GameObjectToPlayFrom);       
        }
        
    }
   
}
