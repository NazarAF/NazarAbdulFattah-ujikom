using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public static class ScoreManager
{
    private static int _score;
    public static int Score {
        get { return _score; }
        set {
            _score = value;
            onSetScore?.Invoke();
        }
    }

    public static Action onSetScore;

    [RuntimeInitializeOnLoadMethod]
    public static void IntializeLoadLevel() {
        SceneManager.sceneLoaded += Restart;
    }

    public static void Restart(Scene scene, LoadSceneMode mode) { Score = 0; }
}

public static class TimeManager
{
    private static float _time;
    public static float Time {
        get { return _time; }
        set {
            _time = value;
            onSetTime?.Invoke();
        }
    }

    public static Action onSetTime;

    [RuntimeInitializeOnLoadMethod]
    public static void IntializeLoadLevel() {
        SceneManager.sceneLoaded += Restart;
    }

    public static void Restart(Scene scene, LoadSceneMode mode) { Time = 0; }
}

public class GameManager : MonoBehaviour
{
    public GameObject GameplayUI, PauseUI, GameoverUI;
    public float timer = 60.0f;
    private bool pause = false;

    public void Start() {
        TimeManager.Time = this.timer;
    }

    public void Update() {
        if (TimeManager.Time > 0) TimeManager.Time -= Time.deltaTime; else this.Gameover();

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
        ScoreManager.Score += 1;
        this.PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        this.PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Gameover() {
        this.GameoverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
