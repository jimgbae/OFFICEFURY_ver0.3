using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("UI/DebugTextComponentName",11)]

public class StartLodingText : MonoBehaviour
{
    public TMP_Text LodingText;

    public string[] Txt;


    private void Start()
    {
        int i = Random.Range(0, Txt.Length);
        LodingText.text = Txt[i];
    }


}
