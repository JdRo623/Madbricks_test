using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoardHandler : MonoBehaviour {
    private NumberHandler[] TempNumbers;
    private Dictionary<int, NumberHandler> numbers;
    private int tempRandom;
    private int score;
    public GameObject initImage;
    public GameObject midWinImage;
    public GameObject WinImage;
    public Text playerName;
    // Use this for initialization
    void Start () {
        TempNumbers = GetComponentsInChildren<NumberHandler>();
        numbers = new Dictionary<int, NumberHandler>();
        score = 0;
        PopulateBoardNumbers();
        initImage.SetActive(true);
        midWinImage.SetActive(false);
        WinImage.SetActive(false);
    }
	
	private void PopulateBoardNumbers()
    {
        foreach (NumberHandler number in TempNumbers) {
            PopulateParticularNumber(number);
        }
    }
    private void PopulateParticularNumber(NumberHandler number) {
        tempRandom = UnityEngine.Random.Range(1, 100);
        try
        {
            if (numbers[tempRandom] != null)
            {
                PopulateParticularNumber(number);
            }
        }
        catch (Exception e)
        {
            number.SetNumber(tempRandom);
            numbers.Add(tempRandom, number);
        }
    }
    public void CheckCurrentNumber() {
        try
        {
            (numbers[BingoGameHandler.currentNumber]).CheckNumberChoosen();
            UpScore();
        }
        catch (Exception e)
        {

        }
    }

    public int GetScore() {
        return score;
    }
    public void UpScore() {
        score++;
        if (score == 10) {
            initImage.SetActive(false);
            midWinImage.SetActive(true);
        } else if (score == 20) {
            midWinImage.SetActive(false);
            WinImage.SetActive(true);
        }
    }
    public string GetPlayerName() {
        return playerName.text;
    }
}
