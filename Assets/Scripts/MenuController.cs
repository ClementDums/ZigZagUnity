using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button restart;
    public GameObject menu;
    Animator menuAnimator;
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(HideButton);
        menuAnimator = menu.GetComponent<Animator>();

    }

    void HideButton()
    {
        menuAnimator.SetTrigger("Close");
        StartCoroutine(RestartGame());

    }
    IEnumerator RestartGame()
    {
        ManagerGame.instance.StartGame();
        yield return new WaitForSeconds(0.30f);
        ManagerGame.instance.IsPlaying = true;
        ManagerScore.instance.ResetScore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
