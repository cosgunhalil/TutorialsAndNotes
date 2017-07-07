using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberContainer : MonoBehaviour
{

    public Text ValueText;

    public int Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
            ValueText.text = _value.ToString();
        }
    }
    private int _value;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;

    public void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

}
