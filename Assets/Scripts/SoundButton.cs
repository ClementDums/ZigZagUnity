using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite muteSprite;
    public Sprite activeSprite;
    void Start()
    {

    }
    public void ToggleSprite(bool active)
    {
        if (active)
        {
            GetComponent<Image>().sprite = activeSprite;
            return;
        }
        GetComponent<Image>().sprite = muteSprite;

    }
}
