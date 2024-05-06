using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Time Manager")]
    [SerializeField] GameObject timeManager;
    [SerializeField] public bool _IsStarted;
    [Header("Score")]
    [SerializeField]public  int scoreCount;

    [Header("ElectionControll")]
    [SerializeField] public bool _IsElected;
    [SerializeField] public bool _IsSum;
    [SerializeField] public bool _IsSubs;
    [SerializeField] public bool _IsDiv;
    [SerializeField] public bool _IsMulty;
    [SerializeField] public bool _IsEcu;

    private void Awake()
    {
        // ----------------------------------------------------------------
        // AQUÍ ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del AudioManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void win()
    {

    }

    public void startGame()
    {
        if (!_IsStarted)
        {
            _IsStarted = true;
            timeManager.GetComponent<TimeManager>().StartCoroutine("UpdateTotalTimer");
            timeManager.GetComponent<TimeManager>().StartCoroutine("UpdateQuestionTimer");
        }
    }

    public void failQuestion()
    {
        timeManager.GetComponent<TimeManager>()._IsAnswered = true;
        scoreCount -= 20;

        timeManager.GetComponent<TimeManager>().restartQuestion();
    }
    public void accertQuestion()
    {
        timeManager.GetComponent<TimeManager>()._IsAnswered = true;
        scoreCount += 10;
        timeManager.GetComponent<TimeManager>().restartQuestion();
    }

    public void endOfGame()
    {
        Time.timeScale = 0f;
    }

    public void electQuestion()
    {
        while (!_IsElected)
        {
            switch (Random.Range(0, 5))
            {
                case 0: 
                    if (_IsSum) DictionaryManager.instance.PlaySums(); _IsElected = true;
                    break; 
                case 1:
                    if (_IsSubs) DictionaryManager.instance.PlaySubsttacts(); _IsElected = true;
                    break; 
                case 2:
                    if (_IsMulty) DictionaryManager.instance.PlayMultiplies(); _IsElected = true;
                    break;
                case 3:
                    if (_IsDiv) DictionaryManager.instance.PlayDivides(); _IsElected = true;
                    break;
                case 4:
                    if (_IsEcu) DictionaryManager.instance.PlayEcuations(); _IsElected = true;
                    break;
            }
        }
    }
}
