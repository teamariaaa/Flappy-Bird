using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyBird : MonoBehaviour
{
    public float gravity;
    public float gravity2;
    public float jumpForce;
    public bool isInGame;
    public bool isAfter;
    public int highscore;

    float speed;
    int score;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public Image endText;
    public GameObject restartButton;
    public GameObject startButton;

    private void Start()
    {
        isInGame = false;
        isAfter = false;

        endText.enabled = false;

        score = 0;
        scoreText.enabled = false;
        scoreText.text = score.ToString();

        highscoreText.text = "HIGHSCORE  " + PlayerPrefs.GetInt("highscore").ToString();
        highscoreText.enabled = true;

        restartButton.SetActive(false);
    }

    void Update()
    {
        if (isInGame)
        {
            highscoreText.enabled = false;
            scoreText.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speed = jumpForce;
            }
            else
            {
                speed -= Time.deltaTime * gravity;
            }

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (isAfter)
        {
            endText.enabled = true;
            speed -= Time.deltaTime * gravity2;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            restartButton.SetActive(true);
        }
    }

    public void setisInGame()
    {
        isInGame = true;
    }

    public void setIsNotInGame()
    {
        SceneManager.LoadScene("SampleScene");
        //isInGame = false;
        //isBefore = true;
        //isAfter = false;
        //startButton.SetActive(true);
        //transform.position = new Vector3(0, 0, 0);
        //speed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pipe" || collision.gameObject.tag == "limit")
        {
            if(score > PlayerPrefs.GetInt("highscore"))
                PlayerPrefs.SetInt("highscore", score);
            isInGame = false;
            isAfter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isInGame  &&  other.gameObject.tag == "pipeStructure")
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
