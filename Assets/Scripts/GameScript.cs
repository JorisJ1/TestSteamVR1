using System;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    /// <summary>
    /// The text object that shows the countdown.
    /// </summary>
    private TextMeshPro textMeshCountdown;

    /// <summary>
    /// How many seconds until the game starts.
    /// </summary>
    private float preparationTimeMs = 4000;

    private DateTime countdownStartedTime;

    private bool isGameStarted;

    void Awake()
    {
        // Find the mesh that shows the countdown.
        GameObject textTimer = GameObject.Find("TextTimer");
        textMeshCountdown = textTimer.GetComponentInChildren<TextMeshPro>();

        // Note the wake time.
        countdownStartedTime = DateTime.Now;

        // Update the countdown timer every 0.1 seconds.
        InvokeRepeating("UpdateCountdown", 0, 0.02f);

        // Start the game in 4 seconds.
        Invoke("StartGame", preparationTimeMs / 1000);
    }

    //void Update() {

    //}

    private void UpdateCountdown() {
        //if (isGameStarted) {
            

        //    textMeshCountdown.text = "0000";
        //} else {
        double countdownState = preparationTimeMs - (DateTime.Now - countdownStartedTime).TotalMilliseconds;

        if (countdownState <= 0) {
            countdownState = 0;
            CancelInvoke("UpdateCountdown");
        }

        textMeshCountdown.text = countdownState.ToString("0000");

            
        //}
    }

    void StartGame() {

        isGameStarted = true;

        //textMeshCountdown.text = "Game started!";

        //InvokeRepeating("StartRound", 4, 1);
    }

    void StartRound() {

    }
}
