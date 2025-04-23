using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimePlayed : MonoBehaviour
{
    private float ElapsedTime = 0;
    public TextMeshProUGUI TimeText;

    void Update()
    {
        ElapsedTime += Time.deltaTime;

        TimeText.text = Mathf.RoundToInt(ElapsedTime).ToString();
    }
}
