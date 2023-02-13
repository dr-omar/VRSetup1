using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public Button LoginButton;

    private string strUserName;
    private string strPassword;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() => {
            StartCoroutine(Main.Instance.web.Login(username.text, password.text));
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Tab)) {
           if (username.isFocused)
                password.Select();
        }
        if (Input.GetKeyDown (KeyCode.Return)) {
            if (strPassword != "" && strUserName != "") {
                Main.Instance.web.Login(username.text, password.text);
            }
        }
    }
}
