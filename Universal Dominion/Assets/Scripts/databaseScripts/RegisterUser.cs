//RegisterUser.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RegisterUser : MonoBehaviour
{

    public TMP_InputField InputUsername; //for RegisterUser
    public TMP_InputField InputPassword; //for RegisterUser
    public TMP_InputField InputEmail; //for RegisterUser
    public Button RegisterButton;

    //Start is called before the first frame update
    void Start()
    {
        //LoginButton functionality
        RegisterButton.onClick.AddListener(() =>
        {
            //Checks for text in both username and password field and will login with that information.
            StartCoroutine(Main.Instance.Web.RegisterUser(InputUsername.text, InputPassword.text, InputEmail.text));
        });
    }

}


