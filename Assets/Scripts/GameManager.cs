using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public Image Hp_bar;


    private void Update()
    {
        if(Hp_bar.fillAmount==0)
        {
            Singleton.GetInstance.isGameOver = true;
        }
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }


    public void EndGame()
    {
        Singleton.GetInstance.isGameOver = true;
        Singleton.GetInstance.map_speed = 0;
    }
    public void HitEvent()
    {
        StartCoroutine(Hit());
    }

    public void HealthUp()
    {
        Hp_bar.fillAmount += 0.4f;
    }


    IEnumerator Hit()
    {
        Hp_bar.fillAmount -= 0.2f;
        yield return new WaitForSeconds(2);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (!Singleton.GetInstance.isGameOver)
                Hp_bar.fillAmount -= 0.005f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
