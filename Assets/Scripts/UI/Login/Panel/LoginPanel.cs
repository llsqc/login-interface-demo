using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : BasePanel<LoginPanel>
{
    public UIInput inputUsername;
    public UIInput inputPassword;

    public UIButton btnRegister;
    public UIButton btnLogin;

    public UIToggle togRemember;
    public UIToggle togAutoLogin;

    public override void Init()
    {
        btnRegister.onClick.Add(new EventDelegate(() =>
        {
            HideMe();
            RegisterPanel.Instance.ShowMe();
        }));

        btnLogin.onClick.Add(new EventDelegate(() =>
        {
            if (LoginMgr.Instance.CheckInfo(inputUsername.value, inputPassword.value))
            {
                LoginMgr.Instance.LoginData.username = inputUsername.value;
                LoginMgr.Instance.LoginData.password = inputPassword.value;
                LoginMgr.Instance.LoginData.bRemember = togRemember.value;
                LoginMgr.Instance.LoginData.bAutoLogin = togAutoLogin.value;
                LoginMgr.Instance.SaveLoginData();

                if (LoginMgr.Instance.LoginData.lastServerID == 0)
                {
                    SelectPanel.Instance.ShowMe();
                }
                else
                {
                    ServerPanel.Instance.ShowMe();
                }

                HideMe();
            }

            else
            {
                TipPanel.Instance.ShowMe();
                TipPanel.Instance.ChangeInfo("用户名或密码错误");
            }
        }));

        togRemember.onChange.Add(new EventDelegate(() =>
        {
            if (!togRemember.value)
            {
                togAutoLogin.value = false;
            }
        }));

        togAutoLogin.onChange.Add(new EventDelegate(() =>
        {
            if (togAutoLogin.value)
            {
                togRemember.value = true;
            }
        }));

        LoginData loginData = LoginMgr.Instance.LoginData;

        togRemember.value = loginData.bRemember;
        togAutoLogin.value = loginData.bAutoLogin;

        if (loginData.username != "")
        {
            inputUsername.value = loginData.username;
        }

        if (loginData.bRemember)
        {
            inputPassword.value = loginData.password;
        }

        if (loginData.bAutoLogin)
        {
            if (LoginMgr.Instance.CheckInfo(inputUsername.value, inputPassword.value))
            {
                if (LoginMgr.Instance.LoginData.lastServerID == 0)
                {
                    SelectPanel.Instance.ShowMe();
                }
                else
                {
                    ServerPanel.Instance.ShowMe();
                }

                HideMe();
            }

            else
            {
                TipPanel.Instance.ShowMe();
                TipPanel.Instance.ChangeInfo("用户名或密码错误");
            }
        }
    }

    public void SetInfo(string username, string password)
    {
        inputUsername.value = username;
        inputPassword.value = password;
    }
}