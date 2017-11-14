using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
public class ArrayFinderlHandle : MonoBehaviour {
    public Text arrayShower;
    public Text answer;
    public Text executionTime;
    public InputField inputField;
    private List<int> numberArray;
    private int numberSearched;
    private bool findFlag;
    private string array;
    private Stopwatch stopWatch;
	// Use this for initialization
	void Start () {
		numberArray = new List<int> {1,3,4,6,8,10,24};
        stopWatch = new Stopwatch();
        PrintArray();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            FindNumberInArray();
        }
	}
    private void PrintArray() {
        array = "";
        foreach (int number in numberArray)
        {
            array += " " + number + " ";
        }
        arrayShower.text = array;
    }
    public void FindNumberInArray() {
        stopWatch.Reset();
        stopWatch.Start();
        findFlag = false;
        try
        {
            numberSearched = Int32.Parse(inputField.text);
            foreach (int number in numberArray) {
                if (number.Equals(numberSearched)) {
                    findFlag = true;
                    break;
                }
            }
            if (findFlag)
            {
                answer.text = "True";
            }
            else {
                answer.text = "False";
            }
        }
        catch (FormatException e) {
            answer.text = "Not a Number: Check for letters or Spaces";
        }
        stopWatch.Stop();
        executionTime.text = "Execution Time in H/M/S.MS: " + stopWatch.Elapsed;
    }
}
