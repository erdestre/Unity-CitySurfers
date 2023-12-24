using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject endGameCanvas, startGameCanvas;
    public GameObject idlePlayer, Player;
    public ParticleSystem startEffect;

    private void ActivateMenu()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void ActivateGame()
    {
        startGameCanvas.SetActive(false);
        idlePlayer.SetActive(false);
        Player.SetActive(true);
        startEffect.Play();

    }
    public void ActivateEnd()
    {
        endGameCanvas.SetActive(true);
        StartCoroutine(StartAgain());
    }

    IEnumerator StartAgain()
    {
        yield return new WaitForSeconds(10f);
        ActivateMenu();
    }

}
