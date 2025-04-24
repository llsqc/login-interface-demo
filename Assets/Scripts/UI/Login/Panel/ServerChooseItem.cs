using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerChooseItem : MonoBehaviour
{
    public UIButton btnChooseServer;
    public UILabel labName;
    public UISprite sprNew;
    public UISprite sprState;

    private Server _nowInfo;

    void Start()
    {
        btnChooseServer.onClick.Add(new EventDelegate(() => { }));
    }

    public void InitInfo(Server info)
    {
        _nowInfo = info;

        labName.text = info.id + "区" + info.name;
        sprNew.gameObject.SetActive(info.isNew);
        sprState.gameObject.SetActive(true);
        switch (info.state)
        {
            case 0:
                sprState.gameObject.SetActive(false);
                break;
            case 1:
                sprState.spriteName = "ui_DL_liuchang_01";
                break;
            case 2:
                sprState.spriteName = "ui_DL_fanhua_01";
                break;
            case 3:
                sprState.spriteName = "ui_DL_huobao_01";
                break;
            case 4:
                sprState.spriteName = "ui_DL_weihu_01";
                break;
        }
    }
}