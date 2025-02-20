﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;


    [Header("Tools")]
    //[SerializeField] private Image AxeUI;
    //[SerializeField] private Image ShovelUI;
    //[SerializeField] private Image BucketUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterlimit;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodlimit;
        carrotUIBar.fillAmount = playerItems.carrots / playerItems.carrotslimit;
        fishUIBar.fillAmount = playerItems.fishes / playerItems.fisheslimit;

        // toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
