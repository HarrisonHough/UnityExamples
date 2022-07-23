﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: UI Control Class 
*/

public class UIControl : MonoBehaviour 
{
    [SerializeField]
    private Slider windSlider;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text windText;
    [SerializeField]
    private Image windArrow;

    private const string ScorePrefix = "Score\n";
    void Start () 
    {
        Wind.RandomWindStrength(true);
        UpdateWindPanel();
        GameManager.OnScoreUpdated += UpdateScore;
    }


    public void SetWind(float value)
    {
        Wind.WindSpeed = value;
    }

    public void UpdateWindSlider()
    {
        windSlider.value = Mathf.Abs( Wind.WindSpeed);
    }

    private void UpdateWindPanel()
    {
        windArrow.transform.rotation = Wind.WindSpeed < 0 ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0);
        windText.text = Wind.GetReadableWindSpeed();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = ScorePrefix + score; 
        Wind.RandomWindStrength(true);
        UpdateWindPanel();
    }
}
