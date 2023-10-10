using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODPlus;

public class SoundManager : MonoBehaviour
{
    public FMODAudioSource[] ItemSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCoffeeSound()
    {
        ItemSound[0].Play();
    }
}
