using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public long cookiesTotal;
    public TMP_Text cookiesTotalText;
    public float clickTimer = 0;

    public GameObject grannyBtn;
    public TMP_Text grandmaCountText;
    public TMP_Text grandmaCostText;
    int grandmaCount;

    public GameObject cursorBtn;
    public TMP_Text cursorCountText;
    public TMP_Text cursorCostText;
    int cursorCount;


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("cookiesTotal", Convert.ToInt32(cookiesTotal));
        PlayerPrefs.SetInt("granniesTotal", Convert.ToInt32(grandmaCount));
        PlayerPrefs.SetInt("cursorsTotal", Convert.ToInt32(cursorCount));
    }
    private void Start()
    {
        cookiesTotal = PlayerPrefs.GetInt("cookiesTotal");
        grandmaCount = PlayerPrefs.GetInt("granniesTotal");
        cursorCount = PlayerPrefs.GetInt("cursorsTotal");

        cursorCountText.text = cursorCount.ToString();
        grandmaCountText.text = grandmaCount.ToString();
    }
    private void Update()
    {
        clickTimer += Time.deltaTime;

        if (clickTimer >= 1)
        {
            AddClick(1);
            clickTimer = 0;
        }

        cookiesTotalText.text = cookiesTotal.ToString();
    }
    public void AddClick(float CPS)
    {
        cookiesTotal++;
    }

    public void BuyGrandma()
    {
        if (cookiesTotal >= Convert.ToInt64(grandmaCostText.text))
        {
            grandmaCount++;
            grandmaCountText.text = grandmaCount.ToString();
            cookiesTotal -= Convert.ToInt64(grandmaCostText.text);
            cookiesTotalText.text = cookiesTotal.ToString();
            grannyBtn.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void BuyCursor()
    {
        if (cookiesTotal >= Convert.ToInt64(cursorCostText.text))
        {
            cursorCount++;
            cursorCountText.text = cursorCount.ToString();
            cookiesTotal -= Convert.ToInt64(cursorCostText.text);
            cookiesTotalText.text = cookiesTotal.ToString();
            cursorBtn.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
