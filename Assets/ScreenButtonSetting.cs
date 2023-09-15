using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenButtonSetting : MonoBehaviour
{
    public Transform closeScreen;
    public Transform openScreen;

    public void CloseScreen()
    {
        closeScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpneScreen()
    {
        openScreen.gameObject.SetActive(true);
    }

    public void SetTimeScaleOne()
    {
        Time.timeScale = 1;

    }

    public void SetTimeScaleZero()
    {
        Time.timeScale = 0;
    }
}
