using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateAppearance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _topImage;
    [SerializeField] private Image _backgroundImage;

    [SerializeField] private Color _colorDefault;
    [SerializeField] private Color _colorHint;

    private char _sign;

    public void UpdateVisual()
    {
        _topImage.color = _colorHint;
        _backgroundImage.color = new Color(_colorHint.r, _colorHint.g, _colorHint.b, 0.5f);
    }

    public void PrintExpression(int number1, int randomExpression, int number2)
    {
        switch (randomExpression)
        {
            case 0:
                break;
            case 1:
                _sign = '+';
                break;
            case 2:
                _sign = '-';
                break;
            case 3:
                _sign = '*';
                break;
            case 4:
                _sign = '/';
                break;
        }

        if (randomExpression == 0)
            _text.text = number1.ToString();
        else
            _text.text = number1.ToString() + _sign + number2.ToString();
    }
}
