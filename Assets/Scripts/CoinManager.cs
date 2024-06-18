using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCoins;

    public int NumberCoins;

    private void Start()
    {
        EventBus.Bought += OnBought;
        NumberCoins = Progress.Instance.PlayerInfo.Coins;
        _textCoins.text = NumberCoins.ToString();
    }

    private void OnBought()
    {
        if(NumberCoins > 50)
            SpendCoin(50);
    }

    private void OnDestroy()
    {
        EventBus.Bought -= OnBought;
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