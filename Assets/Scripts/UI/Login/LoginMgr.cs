using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr
{
    private static LoginMgr _instance = new LoginMgr();

    public static LoginMgr Instance => _instance;

    private LoginData _loginData;
    
    public LoginData LoginData => _loginData;
    private LoginMgr()
    {
        _loginData = XmlDataMgr.Instance.LoadData(typeof(LoginData), "LoginData") as LoginData;
    }

    public void SaveLoginData()
    {
        XmlDataMgr.Instance.SaveData(_loginData, "LoginData");
    }
}