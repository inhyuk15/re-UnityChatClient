using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChatClient
{
    public abstract void Connect(string host, int port);
    public abstract void Read();
    public abstract void SendMessage(string message);
    public abstract void Close();
}
