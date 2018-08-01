using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_move : MonoBehaviour
{




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Singleton.GetInstance.isGameOver)
            transform.Translate(Singleton.GetInstance.map_speed, 0, 0);
    }


}
