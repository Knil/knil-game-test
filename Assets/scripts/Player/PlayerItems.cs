using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int carrots;
    public float currentWater;
    public int fishes;

    [Header("Limits")]
    public float waterlimit = 50;
    public float carrotslimit = 10;
    public float woodlimit = 30;
    public float fisheslimit = 10;

    public void WaterLimit(float water)
    {
        if(currentWater < waterlimit)
        {
            currentWater += water;
        }
        

    }

}
