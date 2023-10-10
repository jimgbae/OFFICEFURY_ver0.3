using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBtn : MonoBehaviour
{
    public GameObject SpawnManger;
    public GameObject TutorialImage;
    public GameObject CountText;

    void Start()
    {
        SpawnManger.SetActive(false);
    }
    void Update()
    {
        
    }

    public void OnClickOkBtn() {
        SpawnManger.SetActive(true);
        TutorialImage.SetActive(false);
        CountText.SetActive(true);
    }
}
