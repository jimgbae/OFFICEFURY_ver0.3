using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODPlus;



public class FireCtrl : MonoBehaviour
{

    const float seconds = 60;

    //화염프리팹
    public GameObject fireBullet;
    public GameObject fireCliynder;

    public float maxGasGauge = 200;
    public float gasGauge = 200;

    public float reloadTime = 2.5f;
    public FMODAudioSource firesfx;
    public FMODAudioSource ReLoadsfx;

    [SerializeField] bool isReload = false;
    

    //화염이 발사되는 총구
    public Transform firePos;


    public float maxFireDelay=2.0f;
    float curFireDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        curFireDelay = 0;
        gasGauge = maxGasGauge * seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (gasGauge > 0)
        {
            //마우스 왼쪽 클릭중이면 화염발사
            if (Input.GetMouseButton(0))
            {
                Fire();
                gasGauge--;
            }
            if(Input.GetMouseButtonDown(0))
            {
                firesfx.Play();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                firesfx.Stop();
            }
        }
        else {
            if (!isReload)
            {
                firesfx.Stop();
                ReLoadsfx.Play();
                Invoke("Reload", reloadTime);
                isReload = true;
            }
        }

        //R누르면 즉시 재장전 시작
        if (Input.GetKeyDown(KeyCode.R) && !isReload && gasGauge != maxGasGauge) {
            ReLoadsfx.Play();
            isReload = true;
            gasGauge = 0;
            Invoke("Reload", reloadTime);
        }

        //Debug.Log(Time.deltaTime);
    }

    void Fire() {
        //fireCliynder.SetActive(true);

        curFireDelay += Time.deltaTime;

        if (curFireDelay < maxFireDelay) {
            return;
        }

        CreateFire();
        curFireDelay = 0;
        
    }
    //재장전
    void Reload() {
        gasGauge = maxGasGauge;
        isReload = false;
    }

    void CreateFire() {
        Instantiate(fireBullet, firePos.position, firePos.rotation);
    }
}
