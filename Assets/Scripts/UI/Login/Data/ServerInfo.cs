using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ServerInfo
{
    public SerizlizerDictionary<string, Server> serverDic = new SerizlizerDictionary<string, Server>();
}

public class Server
{
    [XmlAttribute] public int id;
    [XmlAttribute] public string name;
    [XmlAttribute] public int state;
    [XmlAttribute] public bool isNew;
}