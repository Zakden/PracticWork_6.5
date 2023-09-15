using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LockPick : MonoBehaviour
{
    public Image firstPin;
    public Image secondPin;
    public Image thirdPin;
    public Text firstPinText;
    public Text secondPinText;
    public Text thirdPinText;
    public Text timerText;
    public Text WinLoseText;
    public Button lockpickUpButton;
    public Button screwdriverButton;
    public Button lockpickDownButton;
    public GameObject WinLosePanel;
    private int firstPinValue = 0;
    private int secondPinValue = 0;
    private int thirdPinValue = 0;
    private float timerValue;
    private bool timerActive = false;
    // Start is called before the first frame update
    void Start()
    {
        SetDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            if (timerValue <= 0)
            {
                GameOver(true);
            }
            else if (timerValue >= 0)
            {
                timerValue -= Time.deltaTime;
                timerText.text = $"Время: {timerValue:0} секунд";
            } 
        }
        
    }
    public void SetDefault()
    {
        WinLosePanel.SetActive(false);
        firstPinValue = 1;
        secondPinValue = 3;
        thirdPinValue = 0;
        firstPinText.text = firstPinValue.ToString();
        secondPinText.text = secondPinValue.ToString();
        thirdPinText.text = thirdPinValue.ToString();
        float PosY = firstPinValue * 10;
        firstPin.transform.localPosition = new Vector3(firstPin.transform.localPosition.x, -PosY, firstPin.transform.localPosition.z);
        PosY = secondPinValue * 10;
        secondPin.transform.localPosition = new Vector3(secondPin.transform.localPosition.x, -PosY, secondPin.transform.localPosition.z);
        PosY = thirdPinValue * 10;
        thirdPin.transform.localPosition = new Vector3(thirdPin.transform.localPosition.x, -PosY, thirdPin.transform.localPosition.z);
        timerValue = 60;
        timerText.text = $"Время: {timerValue} секунд";
        timerActive = true;
    }
    public void PinValueChange(int pin, int value)
    {
        if (pin == 1)
        {
            firstPinValue += value;
            float PosY = firstPinValue * 10 + (float)value * 10f;
            firstPin.transform.localPosition = new Vector3(firstPin.transform.localPosition.x, -PosY, firstPin.transform.localPosition.z);
            if (firstPinValue <= 0)
            {
                firstPinValue = 0;
                firstPin.transform.localPosition = new Vector3(firstPin.transform.localPosition.x, 0.0f, firstPin.transform.localPosition.z);
            }
            else if (firstPinValue >= 10)
            {
                firstPinValue = 10;
                firstPin.transform.localPosition = new Vector3(firstPin.transform.localPosition.x, -100.0f, firstPin.transform.localPosition.z);
            }
            firstPinText.text = firstPinValue.ToString();
        }
        else if (pin == 2) 
        {
            secondPinValue += value;
            float PosY = secondPinValue * 10 + (float)value * 10f;
            secondPin.transform.localPosition = new Vector3(secondPin.transform.localPosition.x, -PosY, secondPin.transform.localPosition.z);
            if (secondPinValue <= 0)
            {
                secondPinValue = 0;
                secondPin.transform.localPosition = new Vector3(secondPin.transform.localPosition.x, 0.0f, secondPin.transform.localPosition.z);
            }
            else if (secondPinValue >= 10)
            {
                secondPinValue = 10;
                secondPin.transform.localPosition = new Vector3(secondPin.transform.localPosition.x, -100.0f, secondPin.transform.localPosition.z);
            }
            secondPinText.text = secondPinValue.ToString();
        }
        else if (pin == 3)
        {
            thirdPinValue += value;
            float PosY = thirdPinValue * 10 + (float)value * 10f;
            thirdPin.transform.localPosition = new Vector3(thirdPin.transform.localPosition.x, -PosY, thirdPin.transform.localPosition.z);
            if (thirdPinValue <= 0)
            {
                thirdPinValue = 0;
                thirdPin.transform.localPosition = new Vector3(thirdPin.transform.localPosition.x, 0.0f, thirdPin.transform.localPosition.z);
            }
            else if (thirdPinValue >= 10)
            {
                thirdPinValue = 10;
                thirdPin.transform.localPosition = new Vector3(thirdPin.transform.localPosition.x, -100.0f, thirdPin.transform.localPosition.z);
            }
            thirdPinText.text = thirdPinValue.ToString();
        }

        if (firstPinValue == 0 && secondPinValue == 0 && thirdPinValue == 0)
        {
            GameOver(false);
            return;
        }
    }
    public void OnButtonLockpickUpClick()
    {
        PinValueChange(1, 1);
        PinValueChange(3, -1);
    }
    public void OnButtonScrewdriverClick()
    {
        PinValueChange(1, -1);
        PinValueChange(2, -1);
    }
    public void OnButtonLockpickDownClick()
    {
        PinValueChange(2, -1);
        PinValueChange(3, 1);
    }
    public void OnReplayButtonClick()
    {
        SetDefault();
        WinLosePanel.SetActive(false);
        lockpickUpButton.interactable = true;
        lockpickDownButton.interactable= true;
        screwdriverButton.interactable = true;
    }
    public void GameOver(bool isLose)
    {
        if(isLose == true)
        {
            WinLoseText.fontSize = 48;
            WinLoseText.text = "Вы проиграли!\nПопробуйте еще раз";
        }
        else
        {
            WinLoseText.fontSize = 32;
            WinLoseText.text = $"Вы выиграли!\nСправились за {(60 - timerValue).ToString("0")} секунд(ы)\nНаучившись взламывать замки, Вы сможете начать свою преступную карьеру и входить без ключа практически в любой дом";
        }
        timerText.text = " ";
        WinLosePanel.SetActive(true);
        timerActive = false;
        lockpickUpButton.interactable = false;
        lockpickDownButton.interactable = false;
        screwdriverButton.interactable = false;
    }
}
