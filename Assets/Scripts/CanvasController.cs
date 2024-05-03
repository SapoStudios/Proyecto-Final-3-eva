using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    [Header("--Variables Serializadas--")]
    [SerializeField] GameObject[] _panels;
    //[SerializeField] GameObject[] _backButtons;


    private void Start()
    {
        PanelsToFalse();
        PanelActive(0);

    }


    public void PanelsToFalse()
    {
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
    }

    public void PanelActive(int number)
    {

        PanelsToFalse();
        _panels[number].SetActive(true);

    }

    public void ExitApplication()
    {
     #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
     #else
        Application.Quit();
     #endif
    }

}
