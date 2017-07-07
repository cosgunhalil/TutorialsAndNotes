using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class NumberContainer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
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

    public void OnDrag(PointerEventData eventData)
    {
        _transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _transform.SetParent(transform.parent.parent);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _transform.parent = transform.parent.GetChild(0).transform;
    }
}
