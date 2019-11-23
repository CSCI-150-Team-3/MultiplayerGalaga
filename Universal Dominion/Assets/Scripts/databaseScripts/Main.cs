using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton that has a reference for all the objects which then can be accessed from other objects that need their functions.
public class Main : MonoBehaviour
{
    //access it anytime from anywhere
    public static Main Instance;

    //Object web
    public Web Web;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
    }

}
