using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCount : MonoBehaviour
{

    public TMP_Text count;



    // Start is called before the first frame update
    void Start()
    {
        count.text = "3";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void count3() {
        count.text = "3";
        Invoke("count2", 1f);
    }

    void count2()
    {
        count.text = "2";
        Invoke("count1", 1f);
    }

    void count1()
    {
        count.text = "1";
        Invoke("countOff", 1f);
    }

    void countOff() {
        count.text = "";
    }
}
