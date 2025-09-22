using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private float timeRemaining = 0f;
    private bool timeRunning;
    [SerializeField] private TMP_Text timeText;

    void Start()
    {
        timeRunning = true;
        timeRemaining = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            if(timeRemaining >= 0f)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }

    private void DisplayTime(float timeDisplay)
    {
        timeDisplay += 1;
        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void SetTimeRunning(bool isRunning)
    {
        timeRunning = isRunning;
    }

    public bool GetTimeRunning()
    {
        return this.timeRunning;
    }
}
