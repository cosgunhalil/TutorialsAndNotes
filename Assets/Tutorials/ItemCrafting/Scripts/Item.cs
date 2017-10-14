using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{
    public EItemType type;
	public TextMesh Text;

    public void Init()
    {
        Text.text = type.ToString();
    }
}
