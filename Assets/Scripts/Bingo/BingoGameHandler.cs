using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoGameHandler : MonoBehaviour
{
    public List<int> playedNumbers;
    public static int currentNumber;
    private int tempNumber;
    private bool numberUsedFlag;
    public Text textPlayedNumbers;
    public Text textCurrentNumber;
    public Text textCurrentWinner;
    public PlayerBoardHandler[] boards;
    public PlayerBoardHandler currentWinnersBoard;
    // Use this for initialization
    void Awake()
    {
        playedNumbers = new List<int>();
        numberUsedFlag = false;
        boards = FindObjectsOfType<PlayerBoardHandler>();
        currentWinnersBoard = boards[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& currentWinnersBoard.GetScore()<20)
        {
            GenerateNewNumber();
            foreach (PlayerBoardHandler board in boards)
            {
                board.CheckCurrentNumber();
            }
            CheckCurrentWinner();

        }
    }

    private void GenerateNewNumber()
    {
        tempNumber = Random.Range(1, 100);
        foreach (int playedNumber in playedNumbers)
        {
            if (playedNumber.Equals(tempNumber))
            {
                numberUsedFlag = true;
                break;
            }
        }
        if (numberUsedFlag)
        {
            numberUsedFlag = false;
            GenerateNewNumber();
        }
        else
        {
            BingoGameHandler.currentNumber = tempNumber;
            playedNumbers.Add(tempNumber);
            UpdateNumbersList();
        }
    }
    private void UpdateNumbersList()
    {

        textCurrentNumber.text = BingoGameHandler.currentNumber.ToString();
        textPlayedNumbers.text += BingoGameHandler.currentNumber + " | ";
    }

    private void UpdateCurrentWinner()
    {
        if (currentWinnersBoard == null)
        {
            textCurrentWinner.text = "Tied";
        }
        else
        {
            textCurrentWinner.text = currentWinnersBoard.GetPlayerName();
        }
    }

    private void CheckCurrentWinner()
    {
        if (boards[0].GetScore() > boards[1].GetScore() && boards[0].GetScore() > boards[2].GetScore())
        {
            currentWinnersBoard = boards[0];
            UpdateCurrentWinner();
        }
        else if (boards[1].GetScore() > boards[0].GetScore() && boards[1].GetScore() > boards[2].GetScore())
        {
            currentWinnersBoard = boards[1];
            UpdateCurrentWinner();

        }
        else if (boards[2].GetScore() > boards[0].GetScore() && boards[2].GetScore() > boards[1].GetScore())
        {
            currentWinnersBoard = boards[2];
            UpdateCurrentWinner();
        }

    }
}