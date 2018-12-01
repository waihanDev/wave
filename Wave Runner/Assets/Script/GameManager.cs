using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    int currentScore;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    public GameObject GameOverPanel;

    public GameObject touchToStartText;

    public GameObject startFadeInObj;

    static int PlayCount;

    public AudioSource bgSound;

    // Use this for initialization
    void Start () {

        Application.targetFrameRate = 60;

        Time.timeScale = 1.0f;

        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        StartCoroutine(FadeIn());
       SetScore();
       
	}
	
	// Update is called once per frame
	void Update () {

        if (touchToStartText.activeSelf == false) return;
        if (Input.GetMouseButton(0))
        {
            touchToStartText.SetActive(false);
            bgSound.Play();
        }
		
	}

    IEnumerator FadeIn()
    {

        startFadeInObj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        startFadeInObj.SetActive(false);
        yield break;

    }

    public void callGameOver()
    {
        bgSound.Stop();
        StartCoroutine(GameOver());
        UnityAdManager.instance.ShowAd();
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    

    public void AddScore()
    {
        currentScore++;
        if(currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }
        SetScore();
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
