using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnProgress : MonoBehaviour
{

    public void OnBtnClick()
    {
        Debug.Log("clicked");
        Globe.nextSceneName = "GameScene";
        SceneManager.LoadScene("Loading");
    }
}