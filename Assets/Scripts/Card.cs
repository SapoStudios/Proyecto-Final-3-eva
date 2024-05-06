using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("TextToWrite")]
    [SerializeField]public  string textToWrite;
    [SerializeField] TextMeshProUGUI SpaceToWrite;
    [SerializeField] float typingSpeed = 0.1f;
    [SerializeField] public bool IamCorrect;

    [Header("IsContacted")]
    [SerializeField] bool _IsContacted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        this.gameObject.SetActive(true);
    }

    public void WriteOnCall()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance._IsStarted)
        {
            if (!_IsContacted)
            {
                _IsContacted = true;
                StartCoroutine(RestartCollider());
                if (other != null)
                {
                    if (other.gameObject.CompareTag("Bullet"))
                    {
                        if (IamCorrect) { GameManager.instance.accertQuestion(); }
                        else { GameManager.instance.failQuestion(); }
                    }
                }
            }
        }
    }
    IEnumerator RestartCollider()
    {
        yield return new WaitForSeconds(2);
        _IsContacted = false;
        StartCoroutine(RestartCollider());
    }
}
