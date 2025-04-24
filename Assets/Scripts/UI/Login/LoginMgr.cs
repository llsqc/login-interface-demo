using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr
{
    private static LoginMgr _instance = new LoginMgr();

    public static LoginMgr Instance => _instance;

    private LoginData _loginData;
    public LoginData LoginData => _loginData;

    private RegisterData _registerData;
    public RegisterData RegisterData => _registerData;

    private ServerInfo _serverInfo;

    public ServerInfo ServerInfo => _serverInfo;

    private LoginMgr()
    {
        _loginData = XmlDataMgr.Instance.LoadData(typeof(LoginData), "LoginData") as LoginData;
        _registerData = XmlDataMgr.Instance.LoadData(typeof(RegisterData), "RegisterData") as RegisterData;
        _serverInfo = XmlDataMgr.Instance.LoadData(typeof(ServerInfo), "ServerInfo") as ServerInfo;
    }

    public void SaveLoginData()
    {
        XmlDataMgr.Instance.SaveData(_loginData, "LoginData");
    }

    public void SaveRegisterData()
    {
        XmlDataMgr.Instance.SaveData(_registerData, "RegisterData");
    }

    public bool RegisterUser(string username, string password)
    {
        if (!_registerData.registerInfo.TryAdd(username, password))
        {
            return false;
        }

        SaveRegisterData();
        return true;
    }

    public bool CheckInfo(string username, string password)
    {
        if (!_registerData.registerInfo.TryGetValue(username, out var value)) return false;
        return value == password;
    }
}