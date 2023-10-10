using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODPlus;

public class Stage1BGM : MonoBehaviour
{
    public FMODAudioSource audio;
    public bool Chagne = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Chagne)
        { 
            audio.SetParameter("GameScene", 1);
            Chagne = false;
        }
    }

    public void ChangeBGM()
    {
        Chagne = true;
    }
}
