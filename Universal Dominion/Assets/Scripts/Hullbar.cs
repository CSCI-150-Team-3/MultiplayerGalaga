using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hullbar : MonoBehaviour
{
    // Start is called before the first frame update
    
        public Transform hullbar;

    public void Start() 
    {
        hullbar = transform.Find("Hullbar");
    }
    public void SetHullSize(float sizeNormalized)
    {
        hullbar.localScale = new Vector3(sizeNormalized, 1f);
    } 

}
