using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance = null;
  
    public Transform player;
    Vector3 initPosition;
    void Awake()
    {
        if (instance == null)
        {

            //if not, set instance to this
            instance = this;

            //If instance already exists and it's not this:
        }
        else if (instance != this)
        {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

    }
    private bool isPlaying = true;
    public GameObject pauseMenu;

    public bool IsPlaying
    {
        get => isPlaying;
        set
        {
            isPlaying = value;
            PauseGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initPosition = new Vector3(7.8f,-2.2f,0);
        pauseMenu.SetActive(false);
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void PauseGame()
    {
        if (!isPlaying)
        {
            pauseMenu.SetActive(true);
            ManagerScore.instance.IsPlaying = false;
            ManagerScore.instance.isBestScore();
            return;
        }
        pauseMenu.SetActive(false);


    }

    public void StartGame()
    {
        player.transform.position = initPosition;
        GenerateTiles.instance.StartGeneration();
        player.GetComponent<Movement>().Fallen = false;
        ManagerScore.instance.IsPlaying = true;

    }
}
