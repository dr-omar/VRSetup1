using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterManager : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_InputField confPassword;
    public TMP_InputField email;

    private string strUserName;
    private string strPassword;
    private string strConfPassword;
    private string strEmail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RegisterButton () {
        strUserName = username.text;
        strPassword = password.text;
        strConfPassword = confPassword.text;
        strEmail = email.text;
        if (strUserName != "") {
            Debug.Log ("username cannot be empty");
        }
        if (strPassword != "") {
            Debug.Log ("Password cannot be empty");
        }
        if (strEmail != "") {
            Debug.Log ("Email cannot be empty");
        }
        if (strConfPassword != strPassword) {
            Debug.Log ("Password and confirmed inputs do not match");
            return;
        }
        
        print ("Register Successfully");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Tab)) {
            if (username.isFocused) email.Select();
            else if (password.isFocused) confPassword.Select();
            else if (email.isFocused) password.Select();
        }
        if (Input.GetKeyDown (KeyCode.Return)) {
            if (strPassword != "" && strUserName != "") {
                RegisterButton();
            }
        }
    }
}
