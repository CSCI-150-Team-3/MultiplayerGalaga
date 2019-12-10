using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BGSoundScript : MonoBehaviour {


    private float setVol;
	public AudioSource myMusic;
    public Slider vol;

    //Play Global
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(vol);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update () {
		if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 6)
        {
            myMusic.volume = 0;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            myMusic.volume = vol.value;
        }
        else
        {
            myMusic.volume = 1f;
        }
	}
}
