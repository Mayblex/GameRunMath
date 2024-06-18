using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;

    public void BuyHint()
    {
        if (_coinManager.NumberCoins >= 50)
        {
            EventBus.OnBought();
        }
    }
}
