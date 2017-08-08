using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{
    public EItemType type;
}

public enum EItemType
{
    alnus,
    almond,
    arfaj,
    bindweed,
    cornel,
    crowfoot,
}
