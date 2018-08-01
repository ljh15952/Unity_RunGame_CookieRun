using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton
{
    private static Singleton _instance=null;

    public static Singleton GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public float map_speed = -0.1f;


    public float jumpPower = 16;

    public int MaxJumpCount = 1;

    public bool isGameOver = false;

    public bool isEatCoin=false;
}

