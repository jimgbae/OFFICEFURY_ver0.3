using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    GameObject player;
    public GameObject manager;
    

    public GameObject activeUI;
    Image activeImage;


    public GameObject[] hpUI;


    public GameObject gasGaugeUI;
    Image gasGaugeImage;


    public TMP_Text coinUI;
    


    public GameObject timerUI;
    public Image timerImage;
    public TMP_Text tiemrText;


    public GameObject gameOverUI;
    bool isOver = false;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        activeImage = activeUI.GetComponent<Image>();
        gasGaugeImage = gasGaugeUI.GetComponent<Image>();
        timerImage= timerUI.GetComponent<Image>();
    }

    private void Update()
    {
        PlayerHpUI();
        PlayerActiveUI();
        PlayerGasGaugeUI();
        PlayerTimerUI();
        PlayerCoinUI();

        //게임오버 체크
        if (isOver==true) {
            PlayerGameover();
        }
    }


    void PlayerActiveUI() {
        activeImage.fillAmount = player.GetComponent<BasePlayer>().activeGauge / player.GetComponent<BasePlayer>().maxActiveGauge;
    }

    void PlayerGasGaugeUI() {
        gasGaugeImage.fillAmount = player.GetComponent<FireCtrl>().gasGauge / (player.GetComponent<FireCtrl>().maxGasGauge);
    }

    void PlayerTimerUI() {
        timerImage.fillAmount = manager.GetComponent<Timer>().time / manager.GetComponent<Timer>().MaxTime;
        //tiemrText.text = manager.GetComponent<Timer>().time.ToString();
        tiemrText.text = string.Format("{0:N2}", manager.GetComponent<Timer>().time);


    }

    void PlayerCoinUI() {
        coinUI.text = player.GetComponent<BasePlayer>().coin.ToString();
    }

    void PlayerHpUI() {
        if (player.GetComponent<BasePlayer>().hp == 3)
        {
            hpUI[2].SetActive(true);
            hpUI[1].SetActive(true);
            hpUI[0].SetActive(true);        
        }
        else if (player.GetComponent<BasePlayer>().hp == 2)
        {
            hpUI[2].SetActive(false);
            hpUI[1].SetActive(true);
            hpUI[0].SetActive(true);
        }
        else if (player.GetComponent<BasePlayer>().hp == 1)
        {
            hpUI[2].SetActive(false);
            hpUI[1].SetActive(false);
            hpUI[0].SetActive(true);
        }
        else if (player.GetComponent<BasePlayer>().hp == 0)
        {
            hpUI[2].SetActive(false);
            hpUI[1].SetActive(false);
            hpUI[0].SetActive(false);
            isOver = true;
        }
        else {
            
        }
    }

    void PlayerGameover() {
        gameOverUI.SetActive(true);
        Invoke("SceneMove", 3f);
    }

    void SceneMove() 
    {
        LoadingSceneManager.LoadScene("StartScene");
    }
}
