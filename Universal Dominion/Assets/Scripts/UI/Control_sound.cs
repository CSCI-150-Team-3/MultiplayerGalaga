using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Control_sound : MonoBehaviour
{
    public AudioSource asound;
    public Slider sd;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Con_sound()
    {

        asound.volume = sd.value;

    }
}
