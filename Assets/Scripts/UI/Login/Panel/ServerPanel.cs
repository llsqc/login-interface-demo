using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerPanel : BasePanel<ServerPanel>
{
    public UILabel labInfo;

    public UIButton btnBegin;
    public UIButton btnChange;

    public override void Init()
    {
        btnChange.onClick.Add(new EventDelegate(() =>
        {
            //TODO
            HideMe();
        }));
        btnBegin.onClick.Add(new EventDelegate(() =>
        {
            //TODO
            SceneManager.LoadScene("GameScene");
        }));
        
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //TODO
    }
}