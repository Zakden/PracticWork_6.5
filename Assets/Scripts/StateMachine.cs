using UnityEngine;
using UnityEngine.UI;
using System;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject calculatorScreen;
    [SerializeField] private GameObject comparingScreen;

    private GameObject currentScreen = null;

    void Start()
    {
        mainScreen.SetActive(true);
        currentScreen = mainScreen;
    }

    public void onClickChangeState(GameObject obj)
    {
        if (currentScreen != null && obj != null)
        {
            currentScreen.SetActive(false);
            obj.SetActive(true);
            currentScreen = obj;
        }
    }
}