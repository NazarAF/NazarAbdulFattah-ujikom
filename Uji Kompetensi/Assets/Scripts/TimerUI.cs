using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TimerUI : MonoBehaviour
{
    public TMP_Text timerText;

    private void Update()
    {
        timerText.text = TimeSpan.FromSeconds(TimeManager.Time).ToString(@"mm\:ss");
    }
}
