using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_move : MonoBehaviour
{
    int JumpCount;

    Rigidbody2D Herorb;

    public GameManager GM;
    public ItemManager IM;

    public MapObjectPool MOP;

    Sprite s;
    bool isUpBeatTime=false;

    public AudioSource JumpAudio;
    

	void Start ()
    {
        Herorb = GetComponent<Rigidbody2D>();
        JumpCount = 0;
	}
	
	void Update ()
    {
        if (Singleton.GetInstance.isGameOver)
            GetComponent<Animator>().enabled = false;


        if (!Singleton.GetInstance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && JumpCount == 0)
            {
                JumpCount++;
                Herorb.velocity = Vector3.up * Singleton.GetInstance.jumpPower;
                JumpAudio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && JumpCount <= Singleton.GetInstance.MaxJumpCount)
            {
                Herorb.velocity = Vector3.up * Singleton.GetInstance.jumpPower;
                JumpAudio.Play();
                StartCoroutine("Around");
                JumpCount++;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Ground"))
        {
            JumpCount = 0;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("pipe")&&!isUpBeatTime)
        {
            isUpBeatTime = true;
            StartCoroutine(UpBeatTime());
            GM.HitEvent();
        }

        if (collision.name == "Teduri")
        {
            GM.EndGame();
        }

        if (collision.name == "JumpUpItem")
        {
            IM.EatJumpUpItem();
            collision.gameObject.SetActive(false);
        }


        if (collision.name == "JumpPowerUpItem")
        {
            IM.EatJumpPowerUpItem();
            collision.gameObject.SetActive(false);

        }

        if (collision.name == "HealthUp")
        {
            GM.HealthUp();
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("coin"))
        {
            IM.EatCoinEvent();
            collision.gameObject.SetActive(false);

        }

        if (collision.name== "Magnet")
        {
            IM.EatMagEvent();
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("goalLine"))
        {
            MOP.RanDomMapGOGO();
        }
        StartCoroutine(itemRegen(collision.gameObject));


    }

    IEnumerator Around()
    {
        Herorb.GetComponent<Animator>().SetBool("Jump", true);
        yield return new WaitForSeconds(1);
        Herorb.GetComponent<Animator>().SetBool("Jump", false);
    }

    IEnumerator UpBeatTime()
    {
        int countTime = 0;

        while(countTime<5)
        {
            if (countTime % 2 == 0)
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
           else
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        isUpBeatTime = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    IEnumerator itemRegen(GameObject G)
    {
            yield return new WaitForSeconds(2f);
            G.gameObject.SetActive(true);
            Debug.Log("HIHI");
    }
}
