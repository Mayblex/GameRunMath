using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _effectCoin;
    [SerializeField] private float speedRotation = 180;
    [SerializeField] private int _valueCoin = 1;
    

    void Update()
    {
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOneCoin(_valueCoin);

        Destroy(gameObject);
        Instantiate(_effectCoin, transform.position, transform.rotation);
    }

    public void DestroyCoins()
    {
            Destroy(gameObject);
    }
}
