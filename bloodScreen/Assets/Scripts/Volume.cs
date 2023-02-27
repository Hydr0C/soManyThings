using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public float volume;

    [SerializeField] Text volumeText;
    [SerializeField] Slider volumeSlide;

    // Start is called before the first frame update
    void Start()
    {
        volume = 200;
        volumeText.text = "Current noisies: " + volume;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void VolumeSlide()
    {
        volume = volumeSlide.value;
        volumeText.text = "Current noisies: " + volume;
    }
}
