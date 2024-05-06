using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] float totalTime;
    [SerializeField] float questionTime;

    [Header("SpacesToWrite")]
    [SerializeField] TextMeshProUGUI totalTimeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI QuestionTime;

    [Header("Is Ansewerd Controll")]
    [SerializeField]public bool _IsAnswered;

    [Header("localTimes")]
    [SerializeField] float localTotalTime;
    [SerializeField] float LocalQuestionTime;

    // Start is called before the first frame update
    void Start()
    {
        localTotalTime = totalTime;
        LocalQuestionTime = questionTime;
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.scoreCount.ToString(); 
    }

    public void restartQuestion()
    {
        LocalQuestionTime = questionTime;
        StopCoroutine(UpdateQuestionTimer());
        StartCoroutine(UpdateQuestionTimer());
    }

    IEnumerator UpdateTotalTimer()
    {    // Tiempo de la misión en segundos
        while (localTotalTime > 0)
        {
            localTotalTime -= 0.01f; // Resta 0.01 segundos de la variable tiempoMision

            int minutes = (int)(localTotalTime / 60);
            int seconds = (int)(localTotalTime % 60);
            int milliseconds = (int)((localTotalTime - (int)localTotalTime) * 1000);

            string minutesString = minutes.ToString("00");
            string secondsString = seconds.ToString("00");

            totalTimeText.text = minutesString + ":" + secondsString + ":" + milliseconds.ToString("000");

            yield return new WaitForSeconds(0.01f); // Actualiza el temporizador cada centésima de segundo
        }
        GameManager.instance.endOfGame();
    }
    IEnumerator UpdateQuestionTimer()
    {

        _IsAnswered = false;
        Debug.Log("prueba1");
        GameManager.instance.electQuestion();
        // Tiempo de la misión en segundos
        while (LocalQuestionTime > 0)
        {
            LocalQuestionTime -= 0.01f; // Resta 0.01 segundos de la variable tiempoMision

            int minutes = (int)(LocalQuestionTime / 60);
            int seconds = (int)(LocalQuestionTime % 60);
            int milliseconds = (int)((LocalQuestionTime - (int)LocalQuestionTime) * 1000);

            string minutesString = minutes.ToString("00");
            string secondsString = seconds.ToString("00");

            QuestionTime.text = minutesString + ":" + secondsString + ":" + milliseconds.ToString("000");

            yield return new WaitForSeconds(0.01f); // Actualiza el temporizador cada centésima de segundo
        }

        if (!_IsAnswered) { GameManager.instance.scoreCount -= 20; }
        restartQuestion();
    }
}
