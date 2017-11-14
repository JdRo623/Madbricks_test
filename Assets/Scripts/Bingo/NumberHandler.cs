using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberHandler : MonoBehaviour {
    private int number;
    private bool numberCheckState;
    public Image imageCheck;
    private Text numberText;
    private PlayerBoardHandler board;
	// Use this for initialization
	void Awake () {
        numberCheckState = false;
        numberText = GetComponentInChildren<Text>();
        board = GetComponentInParent<PlayerBoardHandler>();
       imageCheck.gameObject.SetActive(false);
	}
	
    public void CheckNumberChoosen() {
            imageCheck.gameObject.SetActive(true);
    }
    public void CheckNumberManual() {
        if (number.Equals(BingoGameHandler.currentNumber)) {
            imageCheck.gameObject.SetActive(true);
            board.UpScore();
        }
    }
    public void SetNumber(int number) {
        this.number = number;
        numberText.text = number.ToString();
    }
    public int GetNumber() {
        return number;
    }
}
