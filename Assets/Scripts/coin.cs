using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

    public GameObject Hero;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame

    IEnumerator startmagnet()
    {
        while (true)
        {
            float angle = GetAngle();
            transform.eulerAngles = new Vector3(0, 0, angle);

            transform.Translate(10 * Time.deltaTime, 0, 0);

            yield return new WaitForEndOfFrame();
        }
    }

    

    float GetAngle()
    { 
        float xPos = Hero.transform.position.x - transform.position.x;
        float yPos = Hero.transform.position.y - transform.position.y;

        float angle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;

        return angle;
    }
}
