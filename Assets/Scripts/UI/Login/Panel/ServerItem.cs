using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerItem : MonoBehaviour
{
    public UIButton btn;
    public UILabel labInfo;

    private int _beginIndex;
    private int _endIndex;

    void Start()
    {
        btn.onClick.Add(new EventDelegate(() => { SelectPanel.Instance.UpdatePanel(_beginIndex, _endIndex); }));
    }

    public void InitInfo(int beginIndex, int endIndex)
    {
        _beginIndex = beginIndex;
        _endIndex = endIndex;

        labInfo.text = $"{_beginIndex} - {_endIndex}区";
    }
}