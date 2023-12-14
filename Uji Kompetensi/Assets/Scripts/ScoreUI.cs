using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Update() { scoreText.text = ScoreManager.Score.ToString(); }
}
