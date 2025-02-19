using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI QuestText;
    [SerializeField] private TextMeshProUGUI ShadowText;

    private float timerDisplay;
    private int countRobotLeft;
    void Start()
    {
        dialogBox.SetActive(false);   
        timerDisplay = -1.0f;
        countRobotLeft = GameObject.FindGameObjectsWithTag("BOT").Length;
        SetDisplayText(false);
        dialogBox.SetActive(false);
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }   
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
    public void NoticeRobotFixed()
    {
        countRobotLeft--;
        if(countRobotLeft <= 0 )
        {
            SetDisplayText(true);
        }
        else
        {
            SetDisplayText(false);
        }
    }
    private void SetDisplayText(bool isCompleted = false)
    {
        if (isCompleted)
        {
            QuestText.text = ShadowText.text =
            $"Help! \n Fix the Robots! \nLeft:{countRobotLeft}";
        }
        else
        {
            QuestText.text = ShadowText.text =
            $"Good job! \n Thank you for your help!";
        }

    }
}