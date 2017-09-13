using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRules : MonoBehaviour
{

    private Dictionary<EItemType[], EItemType> _itemDictionary = new Dictionary<EItemType[], EItemType>();

    public void Init()
    {
        SetupRules();
    }

    private void SetupRules()
    {
        var dactylisKey = GetCraftableItem(EItemType.arfaj, EItemType.dactylon);
        var almondKey = GetCraftableItem(EItemType.Daemonorops, EItemType.Dacrydium);
        var alnusKey = GetCraftableItem(EItemType.Dacrydium, EItemType.dacrydioides);
        var dactylonKey = GetCraftableItem(EItemType.dahlia, EItemType.cornel);
        var dacicumKey = GetCraftableItem(EItemType.crowfoot, EItemType.bindweed);

        _itemDictionary.Add(dactylisKey, EItemType.Dactylis);
        _itemDictionary.Add(almondKey, EItemType.almond);
        _itemDictionary.Add(alnusKey, EItemType.alnus);
        _itemDictionary.Add(dactylonKey, EItemType.dactylon);
        _itemDictionary.Add(dacicumKey, EItemType.dacicum);
    }

    private EItemType[] GetCraftableItem(EItemType itemA, EItemType itemB)
    {
        EItemType[] itemArray = { itemA, itemB };

        return itemArray;
    }

    private bool IsCraftable(EItemType[] itemArray)
    {
        bool isCraftable = false;

        if (_itemDictionary.ContainsKey(itemArray))
        {
            isCraftable = true;
        }

        return isCraftable;
    }

    public EItemType Craft(EItemType item1, EItemType item2)
    {
        var craftItemArray = GetCraftableItem(item1, item2);

        var isCraftable = IsCraftable(craftItemArray);

        if (isCraftable)
        {
            return _itemDictionary[craftItemArray];
        }
        else
        {
            return EItemType.useless;
        }

    }
}

public enum EItemType
{
	useless,
	alnus,
	almond,
	arfaj,
	bindweed,
	cornel,
	crowfoot,
	Daboecia,
	dacica,
	dacicum,
	Dacryanthus,
	Dacrycarpus,
	dacrydioides,
	Dacrydium,
	dactylifer,
	dactylifera,
	dactyliferum,
	dactyliferus,
	Dactylis,
	Dactyloctenium,
	dactyloides,
	dactylon,
	Dactylorhiza,
	Daemonorops,
	daghestanica,
	dahlia
}
