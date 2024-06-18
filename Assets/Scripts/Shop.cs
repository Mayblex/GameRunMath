using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;

    public void BuyHint()
    {
        if (_coinManager.NumberCoins >= 50)
        {
            _coinManager.SpendCoin(50);
            EventBus.OnBought();
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberCoins;
        }
    }
}
