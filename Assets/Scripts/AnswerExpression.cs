using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerExpression : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textAnswerExpression;

    public int Answer;

    public void AddNumber(int value)
    {
        Answer += value;
        _textAnswerExpression.text = Answer.ToString();
    }
}
