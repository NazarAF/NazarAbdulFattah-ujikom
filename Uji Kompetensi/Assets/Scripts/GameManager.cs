using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject GameplayUI, PauseUI, GameoverUI;
    private bool pause = false;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (this.pause) this.Resume(); else this.Pause();
        }
    }

    public void Load(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause() {
        this.PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        this.PauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
