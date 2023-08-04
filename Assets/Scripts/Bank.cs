using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalacne;
    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance { get { return currentBalacne; } }


    void Awake()
    {
        currentBalacne = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount) // µ· ¹ü
    {
        if (amount <= 0)
            return;
        currentBalacne += amount;
        UpdateDisplay();
    }

    public void Withdraw(int amount) // µ· ¾¸
    {
        if (amount <= 0)
            return;
        currentBalacne -= amount;
        UpdateDisplay();
        if (currentBalacne<0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold " + currentBalacne;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
