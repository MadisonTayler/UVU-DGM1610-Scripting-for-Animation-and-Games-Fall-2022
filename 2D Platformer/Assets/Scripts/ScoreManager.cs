using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinsText;

    public void IncreaseCoins(int amount)
    {
        coins += amount;
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "Coins: "+ coins;
    }
}
