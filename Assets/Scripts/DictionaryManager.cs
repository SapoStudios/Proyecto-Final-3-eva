using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;
    [Header("Dictionaries")]
    [SerializeField] public Dictionary<int, string> D_simpleSums = new Dictionary<int,string>();
    [SerializeField] public Dictionary<int, string> D_simpleSubstracs = new Dictionary<int, string>();
    [SerializeField] public Dictionary<int, string> D_simpledivides = new Dictionary<int, string>();
    [SerializeField] public Dictionary<int, string> D_simplemultiplies = new Dictionary<int, string>();
    [SerializeField] public Dictionary<int, string> D_simpleEcuations = new Dictionary<int, string>();


    [Header("Controller")]
    [SerializeField] public int _Result;

    [Header("Texts to Add")]
    [SerializeField] string _SumText;
    [SerializeField] string _SubsText;
    [SerializeField] string _DivText;
    [SerializeField] string _MulText;
    [SerializeField] string _EcuText;

    [Header("Texts Arrays")]
    [SerializeField] string[] _SumArray;
    [SerializeField] string[] _SubsArray;
    [SerializeField] string[] _DivArray;
    [SerializeField] string[] _MulArray;
    [SerializeField] string[] _EcuArray;

    // Start is called before the first frame update
    void Start()
    {
     
        D_simpleSums = new Dictionary<int, string>();
        D_simpleSums.Clear();
        D_simpleSubstracs.Clear();
        D_simpledivides.Clear();
        D_simplemultiplies.Clear();
        D_simpleEcuations.Clear();

        _SumArray = _SumText.Split(";");
        _SubsArray = _SubsText.Split(":");
        _DivArray = _DivText.Split(":");
        _MulArray = _MulText.Split(":");
        _EcuArray = _SumText.Split(":");

        Debug.Log(_SumArray.Length);
        startDiv();
        startSubstracts();
        startEcuation();
        startMultiply();
        startSums();
    }
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
    // Update is called once per frame
    void Update()
    {
;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CardTextGenerator.instance.WriteOnCall(D_simpleSums[Random.Range(0, D_simpleSums.Count)]);
        }
    }

    public void PlaySums()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpleSums[Random.Range(0, D_simpleSums.Count)]);
    }
    public void PlaySubsttacts()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpleSubstracs[Random.Range(0, D_simpleSubstracs.Count)]);
    }
    public void PlayDivides()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpledivides[Random.Range(0, D_simpledivides.Count)]);
    }
    public void PlayMultiplies()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simplemultiplies[Random.Range(0, D_simplemultiplies.Count)]);
    }
    public void PlayEcuations()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpleEcuations[Random.Range(0, D_simpleEcuations.Count)]);
    }
    void startSums()
    {
        for (int y = 0; y < _SumArray.Length; y++)
        {
            Debug.Log(y);
            D_simpleSums.Add(y, _SumArray[y]);
        }

    }
    void startSubstracts()
    {
        foreach (string s in _SubsArray)
        {
            int i = 0;
            string r = i.ToString();
            D_simpleSubstracs.Add(i, s);
            i++;
        }
    }

    void startDiv()
    {
        foreach (string s in _DivArray)
        {
            int i = 0;
            string r = i.ToString();
            D_simpledivides.Add(i, s);
            i++;
        }
    }

    void startMultiply()
    {
        foreach (string s in _MulArray)
        {
            int i = 0;

            D_simplemultiplies.Add(i, s);
            i++;
        }
    }
    void startEcuation()
    {
        foreach (string s in _EcuArray)
        {
            int i = 0;
            string r = i.ToString();
            D_simpleEcuations.Add(i, s);
            i++;
        }
    }

}
