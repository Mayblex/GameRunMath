using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gate : MonoBehaviour
{
    [SerializeField] private GateAppearance _gateAppearance;
    [SerializeField] private GateManager _gateManager;
    [SerializeField] private AnswerExpression _answerExpression;

    [SerializeField] private AudioSource _soundCorrectChoice;
    [SerializeField] private AudioSource _soundWrongChoice;

    [SerializeField] private List<Coin> _coinsBehindGate;

    //setting up the generation of a mathematical expression
    [SerializeField] public bool IsRightGate = true;

    [SerializeField] private int _minValueMistake = 1;
    [SerializeField] private int _maxValueMistake = 2;
    [SerializeField] private int _appendixNumber = 5;

    [SerializeField] private int _fromWhatExpression = 0;
    [SerializeField] private int _toWhatExpression = 1;

    [SerializeField] private int _minNumberForPlusAnswer = 2;
    [SerializeField] private int _maxNumberForPlusAnswer = 4;

    private int _numberForPlusAnswer;
    private int _answer;
    private int _number1, _number2;
    private int _randomExpression;
    private int _appendixForMistake;

    private void Start()
    {
        _gateManager = GameObject.FindObjectOfType<GateManager>();
        _answerExpression = GameObject.FindObjectOfType<AnswerExpression>();

        if (_fromWhatExpression > _toWhatExpression)
            _fromWhatExpression = _toWhatExpression;

        _randomExpression = Random.Range(_fromWhatExpression, _toWhatExpression + 1);
        MakeExpression();
    }

    //method for setting mathematical expressions
    public void MakeExpression()
    {
        _answer = _answerExpression.Answer;

        if (IsRightGate == true)
        {
            switch (_randomExpression)
            {
                case 0:
                    _number1 = _answer;
                    break;
                case 1:
                    _number1 = Random.Range(0, _answer + 1);
                    _number2 = _answer - _number1;
                    break;
                case 2:
                    _number1 = Random.Range(_answer, _answer + _appendixNumber + 1);
                    _number2 = _number1 - _answer;
                    break;
                case 3:
                    while (_number1 * _number2 != _answer)
                    {
                        _number1 = Random.Range(0, _answer + 1);
                        _number2 = Random.Range(0, _answer + 1);
                    }
                    break;
                case 4:
                    if (_answer == 0)
                    {
                        _number1 = 0;
                        _number2 = Random.Range(0, _appendixNumber + 1);
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                            _number1 = Random.Range(_answer, _answer + _appendixNumber + 1);
                            _number2 = Random.Range(1, _number1 + 1);
                            if (_number1 / (float)_number2 == _answer)
                                break;
                        }
                        break;
                    }
            }
        }
        else
        {
            switch (_randomExpression)
            {
                case 0:
                    while (true)
                    {
                        _number1 = ExpandRangeMistake(_answer);
                        if (_number1 != _answer && _number1 >= 0)
                            break;
                    }
                    break;
                case 1:
                    while (true)
                    {
                        _number1 = Random.Range(0, _answer + 1);
                        _number1 = ExpandRangeMistake(_number1);
                        _number2 = ExpandRangeMistake(_answer - _number1);
                        if (_number1 + _number2 != _answer && _number1 >= 0 && _number2 >= 0)
                            break;
                    }
                    break;
                case 2:
                    while (true)
                    {
                        _number1 = Random.Range(_answer, _answer + _appendixNumber + 1);
                        _number1 = ExpandRangeMistake(_number1);
                        _number2 = ExpandRangeMistake(_number1 - _answer);
                        if (_number1 - _number2 != _answer && _number1 - _number2 >= 0 && _number1 >= 0 && _number2 >= 0)
                            break;
                    }
                    break;
                case 3:
                    while (_number1 * _number2 != _answer)
                    {
                        _number1 = Random.Range(0, _answer + 1);
                        _number2 = Random.Range(0, _answer + 1);
                    }

                    while (true)
                    {
                        _number1 = ExpandRangeMistake(_number1);
                        if (_answer == 0)
                            _number2 = 1;

                        if (_number1 > 0 && _number1 * _number2 != _answer)
                            break;
                    }
                    break;
                case 4:
                    if (_answer == 0)
                    {
                        _number1 = Random.Range(0, _appendixNumber + 1);
                        _number2 = _number1;
                        break;
                    }
                    else
                    {
                        do
                        {
                            _number1 = Random.Range(_answer, _answer + _appendixNumber + 1);
                            _number2 = Random.Range(1, _number1 + 1);
                        } while (_number1 / _number2 == _answer);

                        while (true)
                        {
                            _number2 = ExpandRangeMistake(_number2);
                            if (_number2 > 0 && _number1 / (float)_number2 != _answer)
                                break;
                        }
                        break;
                    }
            }
        }

        _gateAppearance.PrintExpression(_number1, _randomExpression, _number2);
    }

    //method for setting the mistake in mathematical expressions
    private int ExpandRangeMistake(int number)
    {
        _appendixForMistake = Random.Range(_minValueMistake, _maxValueMistake + 1);
        number = Random.Range(number - _appendixForMistake, number + _appendixForMistake + 1);
        return number;
    }

    private void OnTriggerEnter(Collider other)
    {
        _numberForPlusAnswer = Random.Range(_minNumberForPlusAnswer, _maxNumberForPlusAnswer + 1);
        _answerExpression.AddNumber(_numberForPlusAnswer);

        _gateManager.GatesList.Remove(this);

        if (IsRightGate)
        {
            _soundCorrectChoice.Play();
            Destroy(gameObject, _soundCorrectChoice.clip.length);
        }
        else
        {
            _soundWrongChoice.Play();
            foreach (Coin coin in _coinsBehindGate)
                coin.DestroyCoins();
            Destroy(gameObject, _soundWrongChoice.clip.length);
        }

        FindObjectOfType<GateManager>().UpdateAllGates();
    }
}
