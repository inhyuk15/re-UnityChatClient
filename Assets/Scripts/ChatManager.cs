using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Instance { get; private set; }
    private ChatClient chatClient;

    [SerializeField]
    private ChatScrollViewController scrollViewController;

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
        ReadData();
    }

    private void Init()
    {
        string host = "localhost";
        int port = 4000;

        chatClient = new TcpChatClient();
        chatClient.Connect(host, port);
    }

    public void SendMessage(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            chatClient.SendMessage(message);
        }
    }

    private void ReadData()
    {
        StartCoroutine(chatClient.Read(OnReceived));
    }

    private void OnReceived(string message)
    {
        scrollViewController.AddMessage(message);
    }
}
