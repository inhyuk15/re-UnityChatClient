using System;
using System.Collections;

public abstract class ChatClient
{
    public abstract void Connect(string host, int port);
    public abstract IEnumerator Read(Action<string> onReceived);
    public abstract void SendMessage(string message);
    public abstract void Close();
}
