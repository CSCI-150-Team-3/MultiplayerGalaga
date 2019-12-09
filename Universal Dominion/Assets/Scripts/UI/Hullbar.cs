﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hullbar : MonoBehaviour
{
    // Start is called before the first frame update
    
        private Transform hullbar;

    private void Start() 
    {
        hullbar = transform.Find("Hullbar");
        //bar.localScale = new Vector3(.4f, 1f);
        
    }
    public void SetHullSize(float sizeNormalized)
    {
        hullbar.localScale = new Vector3(sizeNormalized, 1f);
    } 
    // Update is called once per frame
    //void Update()
   // {
        
   // }
}