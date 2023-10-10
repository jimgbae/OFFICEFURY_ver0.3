using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneSc : MonoBehaviour
{
    public string SceneName;

    private void Update()
    {
        if (Input.GetMouseButton(0)) {
            LoadingSceneManager.LoadScene(SceneName);
        }
    }


}
