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
}