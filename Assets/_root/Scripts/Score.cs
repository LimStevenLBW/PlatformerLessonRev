using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;

    public void Increment()
    {
        score += 1;
        text.SetText(score.ToString());

    }
}
