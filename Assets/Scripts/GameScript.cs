using System;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject MimicHead;
    public GameObject TargetHead;
    public GameObject TextCountdown;
    public GameObject TextRoundScore;

    private TextMeshPro textMeshCountdown;
    private TextMeshPro textMeshRoundScore;

    /// <summary>
    /// What the countdown should count down from (in milliseconds).
    /// </summary>
    private float countdownMs = 4000;

    private DateTime countdownStartedTime;

    private float roundTimeMs = 2000;

    private bool isGameRunning;


    void Awake()
    {
        // Find text meshes.
        textMeshCountdown = TextCountdown.GetComponentInChildren<TextMeshPro>();
        textMeshRoundScore = TextRoundScore.GetComponentInChildren<TextMeshPro>();

        // Start the game in 4 seconds.
        StartCountdown(countdownMs);
        Invoke("StartGame", countdownMs / 1000);
    }

    void Update() {

    }

    private void OnDestroy() {
        isGameRunning = false;
    }

    void StartCountdown(float countdownTotalMs) {

        // Reset the variable to the desired milliseconds to count down from.
        countdownMs = countdownTotalMs;

        // Note the wake time.
        countdownStartedTime = DateTime.Now;

        // Update the countdown.
        InvokeRepeating("UpdateCountdown", 0, 0.02f);
    }

    private void UpdateCountdown() {
        double countdownState = countdownMs - (DateTime.Now - countdownStartedTime).TotalMilliseconds;

        if (countdownState <= 0) {

            // Prevent negative number.
            countdownState = 0;

            // Stop the InvokeRepeating.
            CancelInvoke("UpdateCountdown");
        }

        // Output as a 4-digit number.
        textMeshCountdown.text = countdownState.ToString("0000");
    }

    void StartGame() {
        isGameRunning = true;
        StartRound();
    }

    void StartRound() {
        //Debug.Log("Starting round");


        StartCountdown(roundTimeMs);

        // End the round after a set time if the game is still running.
        if (isGameRunning) {
            Invoke("EndRound", roundTimeMs / 1000);
        } 
    }

    void EndRound() {
        //Debug.Log("Ending round");

        // Measure the distance between the mimic and the target.
        Vector2 mimicV2 = new Vector2(MimicHead.transform.position.x, MimicHead.transform.position.y);
        Vector2 targetV2 = new Vector2(TargetHead.transform.position.x, TargetHead.transform.position.y);
        float distance = Vector2.Distance(mimicV2, targetV2);

        //Debug.Log("Distance is" + distance.ToString());

        int roundScore;
        if (distance < 0.05) {
            roundScore  = 4;
        } else if(distance < 0.1) {
            roundScore  = 3;
        } else if (distance < 0.2) {
            roundScore = 2;
        } else if (distance < 0.3) {
            roundScore = 1;
        } else {
            roundScore = 0;
        }

        textMeshRoundScore.text = roundScore.ToString("0.0");

        // Start a new round if the game is still running.
        if (isGameRunning) {
            StartRound();
        }
    }
}
