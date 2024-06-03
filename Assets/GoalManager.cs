using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    [SerializeField] GameObject GoalUI;
    [SerializeField] TextMeshProUGUI ScoreText;

    void Start()
    {
        GoalUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreText.text = $"Score : {TargetManager.Score}";

            GoalUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Replay()
    {
        TargetManager.Score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
