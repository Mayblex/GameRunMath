using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    private GateManager _gateManager;

    public void BuyHint()
    {
        _gateManager = FindAnyObjectByType<GateManager>();

        if (_coinManager.NumberCoins >= 50)
        {
            _coinManager.SpendCoin(50);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberCoins;
            _gateManager.FindNearestGate();
        }
    }
}
