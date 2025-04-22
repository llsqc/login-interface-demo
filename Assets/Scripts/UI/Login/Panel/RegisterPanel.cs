using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPanel : BasePanel<RegisterPanel>
{
    public UIInput inputUsername;
    public UIInput inputPassword;

    public UIButton btnSure;
    public UIButton btnCancel;

    public override void Init()
    {
        btnCancel.onClick.Add(new EventDelegate(() =>
        {
            HideMe();

            LoginPanel.Instance.ShowMe();
        }));

        btnSure.onClick.Add(new EventDelegate(() =>
        {
            if (inputUsername.value.Length <= 6 || inputPassword.value.Length <= 6)
            {
                TipPanel.Instance.ChangeInfo("账号和密码长度必须大于6位");
                TipPanel.Instance.ShowMe();
                return;
            }

            if (LoginMgr.Instance.RegisterUser(inputUsername.value, inputPassword.value))
            {
                LoginPanel.Instance.ShowMe();
                LoginPanel.Instance.SetInfo(inputUsername.value, inputPassword.value);
                
                HideMe();
            }
            else
            {
                TipPanel.Instance.ChangeInfo("用户名已存在");
                TipPanel.Instance.ShowMe();
            }
        }));

        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        inputUsername.value = "";
        inputPassword.value = "";
    }
}