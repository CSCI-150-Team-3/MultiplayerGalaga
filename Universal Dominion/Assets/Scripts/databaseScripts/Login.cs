//Login.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Login : MonoBehaviour
{

    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public Button LoginButton;

    //Start is called before the first frame update
    void Start()
    {
        //LoginButton functionality
        LoginButton.onClick.AddListener(() =>
        {
            //Checks for text in both username and password field and will login with that information.
            StartCoroutine(Main.Instance.Web.Login(UsernameInput.text, PasswordInput.text));
        });
    }

}
