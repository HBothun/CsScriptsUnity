using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenue : MonoBehaviour
{
    static PauseMenue instance;
    public Canvas menue;
    //public Button resume;
    public Button exit;
    private bool on = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        menue = GetComponent<Canvas>();
        //resume = GetComponent<Button>();
        exit = GetComponent<Button>();
        

    }

    void Start()
    {
        
        menue.enabled = false;
        

    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(on == true)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }
            
        
    }

    void Pause()
    {
        menue.enabled = (true);
        Time.timeScale = 0f;
        on = true;
    }
    
    void Resume()
    {
        menue.enabled = (false);
        Time.timeScale = 1f;
        on = false;
               
    }
    public void Quit()
    {
        Debug.Log("Button Click");
        Application.Quit();
    }
}
