﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishedScript : MonoBehaviour
{

    public string winner,winnerScore;
    public TextMeshProUGUI winnerTxt, ScoreTxt;

    void Start()
    {
        winner = PlayerPrefs.GetString("Winner");
        winnerScore = PlayerPrefs.GetFloat("WinnerScore").ToString();

        winnerTxt.text = "Winner : " + winner;
        ScoreTxt.text = "Score : " + winnerScore;
    }

}
 