using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanel : BasePanel<SelectPanel>
{
    public Transform svLeft;
    public Transform svRight;

    public UILabel labName;
    public UISprite sprState;

    public UILabel labNowServer;

    private List<GameObject> _itemList = new List<GameObject>();

    public override void Init()
    {
        ServerInfo info = LoginMgr.Instance.ServerInfo;

        int num = info.serverDic.Count / 5 + 1;

        for (int i = 0; i < num; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/btnServer"), svLeft, false);
            item.transform.localPosition = new Vector3(-52, 58, 0) + new Vector3(0, -i * 65, 0);

            ServerItem serverItem = item.GetComponent<ServerItem>();
            int beginIndex = i * 5 + 1;
            int endIndex = Mathf.Min(beginIndex + 4, info.serverDic.Count);

            serverItem.InitInfo(beginIndex, endIndex);
        }

        HideMe();
    }

    public void UpdatePanel(int beginIndex, int endIndex)
    {
        labNowServer.text = $"服务器  {beginIndex}—{endIndex}";

        foreach (var t in _itemList)
        {
            Destroy(t.gameObject);
        }

        _itemList.Clear();

        for (int i = beginIndex; i <= endIndex; i++)
        {
            var nowInfo = LoginMgr.Instance.ServerInfo.serverDic[i];

            GameObject serverItem = Instantiate(Resources.Load<GameObject>("UI/btnChooseServer"), svRight, false);
            serverItem.transform.localPosition = new Vector3(8, 58, 0) + new Vector3((i - 1) % 5 % 2 * 300, (i - 1) % 5 / 2 * -80, 0);

            ServerChooseItem chooseItem = serverItem.GetComponent<ServerChooseItem>();
            chooseItem.InitInfo(nowInfo);
            _itemList.Add(serverItem);
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();
        if (LoginMgr.Instance.LoginData.lastServerID == 0)
        {
            labName.text = "请选择服务器";
            sprState.gameObject.SetActive(false);
        }
        else
        {
            LoginMgr.Instance.ServerInfo.serverDic.TryGetValue(LoginMgr.Instance.LoginData.lastServerID, out Server info);

            labName.text = $"{info.id}区 {info.name}";
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

        UpdatePanel(1, 5 > LoginMgr.Instance.ServerInfo.serverDic.Count ? LoginMgr.Instance.ServerInfo.serverDic.Count : 5);
    }
}