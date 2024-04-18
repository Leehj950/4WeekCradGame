using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    public GameObject successTxt;
    public GameObject failureTxt;

    public Text CountTxt;

    public int cardCount = 0;
    public int cardcheckCount = 0;
    float time = 0.0f;

    float timedeltatime;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timedeltatime += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        
        if (time > 0.0f && time < 10.0f)
        {
            timeTxt.color = Color.green;
        }
        else if (time > 10.0f && time <20.0f)
        {
            timeTxt.color = Color.yellow;
        }
        else if (time > 20.0f && time < 30.0f)
        {
            timeTxt.color = Color.red;
        }
        else if (time >= 30.0f)
        {
            GameEnd();
        }  
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            Succes();
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            cardcheckCount++;

            if (cardCount == 0)
            {
                GameEnd();
            }
           
        }
        else
        {
            Failed();
            firstCard.CloseCard();
            secondCard.CloseCard();
            firstCard.Colorchage();
            secondCard.Colorchage();
            cardcheckCount++;
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        CloseTxt();
        Time.timeScale = 0.0f;
        endTxt.SetActive(true);
        CountTxt.text = cardcheckCount.ToString();
        AudioManager.instance.EndSoundPlay();
    }

    void Succes()
    {
        successTxt.SetActive(true);
        AudioManager.instance.SuccessSoundPlay();
    }

    void Failed()
    {
        failureTxt.SetActive(true);
       AudioManager.instance.FailureSoundPlay();
    }

    public void CloseTxt()
    {
        successTxt.SetActive(false);
        failureTxt.SetActive(false);
    }
}
