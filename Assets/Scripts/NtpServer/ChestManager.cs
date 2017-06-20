using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour {

    public List<Chest> Chests;
    public DataManager DataController;

    private DateTime _appLastClosingTime;
    private DateTime _appCurrentOpeningTime;

    public void Start()
    {
        DataController.Init();
        SetAppLastClosingTime();
    }

    private void SetAppLastClosingTime()
    {
        _appLastClosingTime = DataController.GetAppLastClosingTime();

        if (_appLastClosingTime == DateTime.MinValue)
        {
            _appLastClosingTime = NtpServerConnectionManager.Instance.GetTime();
        }
    }

    public void OnDestroy()
    {
        DataController.SaveAppLastClosingTime();
    }
}
