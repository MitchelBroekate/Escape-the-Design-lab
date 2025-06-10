using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerDuration = 60.0f; // Duration in seconds, adjustable in Inspector
    [SerializeField] TMP_Text timerText; // Reference to the TMP text object, assign in Inspector

    float timeRemaining;
    bool hasTriggered = false;

    void Start()
    {
        timeRemaining = timerDuration;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        }
        else if (!hasTriggered)
        {
            timeRemaining = 0;
            hasTriggered = true;
            UpdateTimerDisplay(0);
            GameOver();
        }
    }

    void UpdateTimerDisplay(float time)
    {
        if (timerText != null)
        {
            if (time > 0)
            {
                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                timerText.text = "Time's Up!";
            }
        }
    }

    void GameOver()
    {
        //Time ran out
    }
}