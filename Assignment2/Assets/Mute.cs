using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mute : MonoBehaviour
{

    
    bool muted;    
    public Text mutetext;


   
    void Start()
    {      

    }

   
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
