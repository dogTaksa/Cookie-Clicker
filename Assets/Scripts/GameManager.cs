using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int cookiesTotal;
    public int CPS;
    public TMP_Text cookiesTotalText;
    public TMP_Text cookiesPerSecondText;
    public float clickTimer = 0;
    public GameObject mainCookie;

    public GameObject grannyBtn;
    public TMP_Text grandmaCountText;
    public TMP_Text grandmaCostText;
    public int grandmaCost;
    public int grandmaBaseCost = 100;
    public int grandmaCount;
    public int grandmaCPS = 10;

    public GameObject cursorBtn;
    public TMP_Text cursorCountText;
    public TMP_Text cursorCostText;
    public int cursorCost;
    public int cursorBaseCost = 25;
    public int cursorCount;
    public int cursorCPS = 2;
    public int cursorUpgrade1_multiplier;
    public GameObject cursorUpgradeBtn;


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("cookiesTotal", Convert.ToInt32(cookiesTotal));
        PlayerPrefs.SetInt("granniesTotal", Convert.ToInt32(grandmaCount));
        PlayerPrefs.SetInt("cursorsTotal", Convert.ToInt32(cursorCount));
    }
    private void Start()
    {
        cookiesTotal = PlayerPrefs.GetInt("cookiesTotal", 0);
        grandmaCount = PlayerPrefs.GetInt("granniesTotal");
        cursorCount = PlayerPrefs.GetInt("cursorsTotal");

        cursorCountText.text = cursorCount.ToString();
        grandmaCountText.text = grandmaCount.ToString();

        NewCost();
    }

    public void BuyCursorUpgrade()
    {
        if (cookiesTotal >= 10000) 
        {
            cookiesTotal -= 10000;
            

            cursorUpgrade1_multiplier *= 2;
            NewCost();
            cursorUpgradeBtn.GetComponent<Button>().interactable = false;
        }
    }
    public void NewCost()
    {
        grandmaCost = Convert.ToInt32(Math.Round(grandmaBaseCost * Math.Pow(1.25, Convert.ToInt32(grandmaCount))));
        cursorCost = Convert.ToInt32(Math.Round(cursorBaseCost * Math.Pow(1.25, Convert.ToInt32(cursorCount))));

        cursorCostText.text = cursorCost.ToString();
        grandmaCostText.text = grandmaCost.ToString();

        CPS = cursorCount * cursorCPS * cursorUpgrade1_multiplier + grandmaCount * grandmaCPS;
        cookiesPerSecondText.text = CPS.ToString() + "c per second";
    }
    private void Update()
    {
        clickTimer += Time.deltaTime;

        if (clickTimer >= 1)
        {
            AddClickCPS();
            clickTimer = 0;
        }
        cookiesTotalText.text = cookiesTotal.ToString();

        grannyBtn.GetComponent<Button>().interactable = cookiesTotal >= grandmaCost;
        cursorBtn.GetComponent<Button>().interactable = cookiesTotal >= cursorCost;

    }
    public void AddClick()
    {
        cookiesTotal += 1 * cursorUpgrade1_multiplier;
        cookiesTotalText.text = cookiesTotal.ToString();
    }

    public void AddClickCPS()
    {
        cookiesTotal += CPS;
    }

    public void BuyGrandma()
    {
        if (cookiesTotal >= grandmaCost)
        {
            grandmaCount++;
            grandmaCountText.text = grandmaCount.ToString();

            cookiesTotal -= grandmaCost;
            cookiesTotalText.text = cookiesTotal.ToString();

            NewCost();

            grannyBtn.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void BuyCursor()
    {
        if (cookiesTotal >= cursorCost)
        {
            cursorCount++;
            cursorCountText.text = cursorCount.ToString();

            cookiesTotal -= cursorCost;
            cookiesTotalText.text = cookiesTotal.ToString();

            NewCost();

            cursorBtn.gameObject.GetComponent<AudioSource>().Play();

            cursorBtn.GetComponent<Button>().interactable = false;
        }
    }
}
