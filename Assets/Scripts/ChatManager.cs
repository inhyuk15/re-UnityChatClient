using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Instance { get; private set; }
    private ChatClient chatClient;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        string host = "localhost";
        int port = 4000;

        chatClient = new TcpChatClient();
        chatClient.Connect(host, port);
    }
}
