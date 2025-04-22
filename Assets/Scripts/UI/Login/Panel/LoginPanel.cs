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
            //TODO: 注册
            HideMe();
        }));
        
        btnLogin.onClick.Add(new EventDelegate(() =>
        {
            //TODO: 登录
            LoginMgr.Instance.LoginData.username = inputUsername.value;
            LoginMgr.Instance.LoginData.password = inputPassword.value;
            LoginMgr.Instance.LoginData.bRemember = togRemember.value;
            LoginMgr.Instance.LoginData.bAutoLogin = togAutoLogin.value;
            LoginMgr.Instance.SaveLoginData();
        }));
        
        togRemember.onChange.Add(new EventDelegate(() =>
        {
            //TODO: 记住密码

            if (!togRemember.value)
            {
                togAutoLogin.value = false;
            }
        }));
        
        togAutoLogin.onChange.Add(new EventDelegate(() =>
        {
            //TODO: 自动登陆

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
            //TODO: 自动登录
        }
    }
}
