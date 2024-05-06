using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CardTextGenerator : MonoBehaviour 
{

    public static CardTextGenerator instance;
    [Header("Texts")]
    [SerializeField] string textToWrite;
    [SerializeField] TextMeshProUGUI SpaceToWrite;
    [SerializeField] float typingSpeed = 0.1f;


    [Header("Childs")]
    [SerializeField] List<GameObject> childs;
    [SerializeField] int whoCorrect;
    [SerializeField] int[] _difCorrects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            childs.Add(child.gameObject);
        }
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
        
    }
  
    public void WriteOnCall(string text)
    {
        BroadcastMessage("Active");


        textToWrite = text.Split("=")[0];
        int result = int.Parse(text.Split('=')[1]);
        WriteText(result);
        StartCoroutine("TypeText");

    }

    IEnumerator TypeText()
    {
        SpaceToWrite.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in textToWrite)
        {
            SpaceToWrite.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        StopCoroutine("TypeText");
    }
    public void WriteText(int text)
    {
        BroadcastMessage("Active");

        whoCorrect = Random.Range(0, childs.Count);

        for (int i = 0; i < childs.Count; i++) 
        { 
            if (i == whoCorrect)
            {
                childs[i].GetComponent<Card>().textToWrite = text.ToString();
                childs[i].GetComponent<Card>().IamCorrect = true;
                childs[i].GetComponent<Card>().WriteOnCall();
            }
            else
            {
                int modifier = Random.Range(0, _difCorrects.Length);
                int finalresult = int.Parse(text.ToString()) + _difCorrects[modifier];

                childs[i].GetComponent<Card>().textToWrite = finalresult.ToString();
                childs[i].GetComponent<Card>().IamCorrect = false;
                childs[i].GetComponent<Card>().WriteOnCall();
            }
        }


    }

}
