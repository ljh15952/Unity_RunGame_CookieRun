using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public Image JumpUpIcon;
    public Image JumpPowerIcon;
    public Image magIcon;
    public AudioSource CoinEFX;
    public Text scoreText;
    public GameObject Magnet;

    int ScoreNum=0;

    public void EatJumpUpItem()
    {
        Singleton.GetInstance.MaxJumpCount = 10;
        StartCoroutine(EatJumpUp());
    }

    public void EatJumpPowerUpItem()
    {
        Singleton.GetInstance.jumpPower = 21;
        StartCoroutine(EatJumpPowerUp());
    }

    public void EatCoinEvent()
    {
        //efx on
        CoinEFX.Play();
        ScoreNum += 100;
        scoreText.text = ScoreNum.ToString();
    }

    public void EatMagEvent()
    {
        StartCoroutine(EatMagnet());
    }


    IEnumerator EatJumpUp()
    {
        int countTime = 0;
        JumpUpIcon.gameObject.SetActive(true);
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                JumpUpIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 90);
            else
                JumpUpIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.35f);
            countTime++;

        }
        Singleton.GetInstance.MaxJumpCount = 1;
        JumpUpIcon.gameObject.SetActive(false);
    }

    IEnumerator EatJumpPowerUp()
    {
        int countTime = 0;
        JumpPowerIcon.gameObject.SetActive(true);
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                JumpPowerIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 90);
            else
                JumpPowerIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.35f);
            countTime++;

        }
        Singleton.GetInstance.jumpPower = 16;
        JumpPowerIcon.gameObject.SetActive(false);
    }
    IEnumerator EatMagnet()
    {
        int countTime = 0;
        Magnet.SetActive(true);

        magIcon.gameObject.SetActive(true);
        while (countTime < 20)
        {
            if (countTime % 2 == 0)
                magIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 90);
            else
                magIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.35f);
            countTime++;

        }
        Magnet.SetActive(false);

        magIcon.gameObject.SetActive(false);
    }
}
