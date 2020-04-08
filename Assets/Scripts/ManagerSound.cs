using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ManagerSound : MonoBehaviour
{
    bool activeBool = true;
    public AudioMixerSnapshot muted;
    public AudioMixerSnapshot active;
    public Button gameSoundButton;
    // Start is called before the first frame update
 
    public void ToggleSound()
    {
        if (activeBool)
        {
            muted.TransitionTo(0);
            activeBool = false;
            gameSoundButton.GetComponent<SoundButton>().ToggleSprite(false);
            return;
        }
        active.TransitionTo(0);
        activeBool = true;
        gameSoundButton.GetComponent<SoundButton>().ToggleSprite(true);
    }
}
