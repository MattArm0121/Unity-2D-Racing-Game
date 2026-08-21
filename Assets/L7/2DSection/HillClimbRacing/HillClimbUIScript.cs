using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;


public class HillClimbUIScript : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI distanceText;
    public GameObject winPanel;

    [Header("Game")]
    public Transform player;
    public Transform goal;

    private float timer = 0f;
    private bool trackFinished = false;

    private float startingDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingDistance = Vector2.Distance(player.position, goal.position);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector2.Distance(player.position, goal.position);

        if (trackFinished)
        {
            currentDistance = 0;
            return;
        }

        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1") + "s";

        // Preventing distance from going below 0
        currentDistance = Mathf.Max(0, currentDistance);

        distanceText.text = "Goal: " + Mathf.RoundToInt(currentDistance).ToString() + "m";

        if (currentDistance <= 1f)
        {
            WinRace();
        }
    }

    void WinRace()
    {
        trackFinished = true;
        winPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
