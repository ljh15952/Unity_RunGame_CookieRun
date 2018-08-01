using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectPool : MonoBehaviour {



    public List<GameObject> Maps = new List<GameObject>();
    GameObject NowMap;
    int currentNum;
	// Use this for initialization
	void Start ()
    {
        currentNum = 0;
        NowMap = Maps[0];

    }
    static int RandNum;

    // Update is called once per frame
    void Update () {
		
	}


    public void RanDomMapGOGO()
    {
        GetRandNum();

        NowMap = Maps[RandNum];
        NowMap.transform.position = new Vector3(20, -3.340111f, 0);
    }

    void GetRandNum()
    {
        RandNum = Random.Range(0, 2);

        if (currentNum == RandNum)
        {
           GetRandNum();
        }
        Debug.Log(currentNum);
        Debug.Log(RandNum);
        currentNum = RandNum;
    }
}
