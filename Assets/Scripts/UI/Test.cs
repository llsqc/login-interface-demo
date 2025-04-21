using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TipPanel.Instance.ShowMe();
            TipPanel.Instance.ChangeInfo("123");
        }
    }
}