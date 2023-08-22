using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatScrollViewController : MonoBehaviour
{
    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private GameObject msgPrefab;

    public void AddMessage(string message)
    {
        GameObject newMsg = Instantiate(msgPrefab);
        newMsg.transform.SetParent(content);

        newMsg.GetComponent<TextMeshProUGUI>().text = message;
        StartCoroutine(ScrollToBottom());
    }

    private IEnumerator ScrollToBottom()
    {
        yield return new WaitForSeconds(0.1f);
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
