using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacles : MonoBehaviour
{
    private static int score,highScore;
    public TextMeshProUGUI scoreText, EndText, HighscoreText;

    private void Start()
    {
        score = 0;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
            HighscoreText.text = "HighScore :" + highScore.ToString();
        }
    }
    private void Update()
    {
        scoreText.text = "Your Score :" + score.ToString();
        EndText.text = "Game Over!";
    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        float xPos = Random.Range(-2f, 2f);
        float yPos = Random.Range(7f, 15f);
        if (contact.gameObject.CompareTag("cStick"))
        {
            transform.position = new Vector2(xPos, yPos);
            score += Random.Range(3, 9);
            if (score>=highScore)
            {
                highScore = score;
                HighscoreText.text="Highscore:"+highScore.ToString();
                PlayerPrefs.SetInt("Highscore", highScore);
            }
            else
            {
                //highScore = 0;
            }

        }
        else if (contact.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector2(xPos, yPos);
            Health.health--;
        }

    }
}