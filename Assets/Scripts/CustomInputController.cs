using System.Collections;
using UnityEngine;

using TMPro;

public class CustomInputController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    void Start()
    {
        inputField.onSubmit.AddListener(OnSubmit);
        inputField.onValidateInput += delegate(string text, int charIndex, char addedChar)
        {
            if (addedChar == '\n')
            {
                return '\0';
            }
            return addedChar;
        };
    }

    private void LateUpdate()
    {
        if (!inputField.isFocused)
        {
            inputField.ActivateInputField();
        }
    }

    void OnSubmit(string text)
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            return;

        if (!string.IsNullOrEmpty(text))
        {
            ChatManager.Instance.SendMessage(inputField.text);
            inputField.text = "";
        }
    }
}
