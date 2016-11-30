using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{


    bool muted;
    public Text mutetext;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (muted)
        {
            AudioListener.volume = 0;
            mutetext.text = "Unmute";
        }
        else if (!muted)
        {
            AudioListener.volume = 1;
            mutetext.text = "Mute";
        }
    }

    public void Muted()
    {
        muted = !muted;
        
    }
}
