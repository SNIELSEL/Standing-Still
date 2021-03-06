using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class App_Initialize : MonoBehaviour
{
    public GameObject InMenuUi;
    public GameObject InGameUI;
    public GameObject gameOverUI;
    public GameObject adButton;
    public GameObject player;
    private bool hasGameStarted = false;
    private bool hasSeenRewardedAd = false;

    private void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenuUi.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        if (hasGameStarted == true)
        {
            StartCoroutine(StartGame(1.0f));
        }
        else
            {
                StartCoroutine(StartGame(0.0f));
            }
    }

    public void PauseGame()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        hasGameStarted = true;
        InMenuUi.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        hasGameStarted = true;
        InMenuUi.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        if (hasSeenRewardedAd == true)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    IEnumerator StartGame(float waitTime)
    {
        InMenuUi.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
}
