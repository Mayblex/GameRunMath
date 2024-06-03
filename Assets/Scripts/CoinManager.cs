using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCoins;

    public int NumberCoins;

    private void Start()
    {
        NumberCoins = Progress.Instance.PlayerInfo.Coins;
        _textCoins.text = NumberCoins.ToString();
    }

    public void AddOneCoin(int valueCoin)
    {
        NumberCoins += valueCoin;
        _textCoins.text = NumberCoins.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.PlayerInfo.Coins = NumberCoins;
    }

    public void SpendCoin(int value)
    {
        NumberCoins -= value;
        _textCoins.text = NumberCoins.ToString();
    }
}
