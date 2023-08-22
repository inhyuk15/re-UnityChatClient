using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;

public class TcpChatClient : ChatClient
{
    private TcpClient tcpClient;
    private StreamWriter writer;
    private StreamReader reader;

    public override void Connect(string host, int port)
    {
        tcpClient = new TcpClient();
        tcpClient.Connect(host, port);

        var stream = tcpClient.GetStream();
        writer = new StreamWriter(stream) { AutoFlush = true };
        reader = new StreamReader(stream);
    }

    public override void Read() { }

    public override void SendMessage(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            writer.WriteLine(message);
        }
    }

    public override void Close() { }
}
