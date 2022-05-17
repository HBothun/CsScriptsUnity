using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

public class SceneSwitcher : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public Transform indicator;

   
    private string Label;
    private string Past = "Outside";
    private bool OnDoor;
    private Vector2 ExitPosition;
    private SceneSwitcher instance;
    private string SceneName;

    void start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        player = this.gameObject.GetComponent<Transform>();
        indicator = this.gameObject.GetComponent<Transform>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this);
        }

    }
    void OnTriggerEnter2D(Collider2D ChangerScene)
    {
        
        if (ChangerScene.gameObject.CompareTag("House1Int"))
        {
            Past = "House1";
            Label = "House1Int";
            OnDoor = true;
      
        }
        if(ChangerScene.gameObject.CompareTag("House1SF"))
        {
            Past = "Stair";
            Label = "House1SF";
        }
        if(ChangerScene.gameObject.CompareTag("House1FF"))
        {
            Past = "Stair";
            Label = "House1Int";
        }
        if (ChangerScene.gameObject.CompareTag("House2Int"))
        {
            Past = "House2";
            Label = "House2Int";
            OnDoor = true;
        }
        if (ChangerScene.gameObject.CompareTag("House3Int"))
        {
            Past = "House3";
            Label = "House3Int";
            OnDoor = true;
        }
        if(ChangerScene.gameObject.CompareTag("House3LL"))
        {
            Past = "Stair";
            Label = "House3LL";
        }
        if (ChangerScene.gameObject.CompareTag("House3FF"))
        {
            Past = "Stair";
            Label = "House3Int";
        }
        if (ChangerScene.gameObject.CompareTag("House4Int"))
        {
            Past = "House4";
            Label = "House4Int";
            OnDoor = true;
        }
        if (ChangerScene.gameObject.CompareTag("HouseTriInt"))
        {
            Past = "HouseTri";
            Label = "HouseTriInt";
            OnDoor = true;
        }
        if (ChangerScene.gameObject.CompareTag("Exit"))
        {
            Label = "Outside";
            OnDoor = true;
            if (Past == "House1")
            {
                ExitPosition = new Vector2(-23f, 26f);
            }
            else if (Past == "House2")
            {
                ExitPosition = new Vector2(-50f, 0f);
            }  
            else if (Past =="House3")
            {
                ExitPosition = new Vector2(23.5f, 26f);
            }
            else if (Past == "House4")
            {
                ExitPosition = new Vector2(1.5f, 8f);
            }
            else if (Past == "HouseTri")
            {
                ExitPosition = new Vector2(-14f, 1.5f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D Door)
    {
        OnDoor = false;
    }

    void PositionPlayer()
    {
        SceneName = SceneManager.GetActiveScene().name;

        if (SceneName == "House1Int")
        {
            if (Past == "House1")
            {
                animator.SetFloat("Vertical", 1);
                animator.SetFloat("LVertical", 1);
                indicator.localRotation = Quaternion.Euler(0, 0, 180);
                player.position = new Vector2(0.5f, -1f);
            }
            else if (Past == "")
            {
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("LHorizontal", 1);
                indicator.localRotation = Quaternion.Euler(0, 0, 90);
                player.position = new Vector2(-1f, 10.5f);
                Past = "House1";
            }
        }        
        else if (SceneName == "House1SF")
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("LVertical", 1);
            indicator.localRotation = Quaternion.Euler(0, 0, 180);
            player.position = new Vector2(-15f, -1f);
        }
        else if (SceneName == "House2Int")
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("LVertical", 1);
            indicator.localRotation = Quaternion.Euler(0, 0, 180);
            player.position = new Vector2 (0f, -1f);                        
        }
        else if (SceneName == "House3Int")
        {
            if (Past == "House3")
            {
                animator.SetFloat("Vertical", 1);
                animator.SetFloat("LVertical", 1);
                indicator.localRotation = Quaternion.Euler(0, 0, 180);
                player.position = new Vector2(-10.5f, -14f);
            }
            else if (Past == "")
            {
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("LHorizontal", 1);
                indicator.localRotation = Quaternion.Euler(0, 0, 90);
                player.position = new Vector2(-1f, 10.5f);
                Past = "House3";
            }
        }
        else if (SceneName == "House4Int")
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("LVertical", 1);
            indicator.localRotation = Quaternion.Euler(0, 0, 180);
            player.position = new Vector2(0f, -21f);
        }
        else if (SceneName == "HouseTriInt")
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("LVertical", 1);
            indicator.localRotation = Quaternion.Euler(0, 0, 180);
            player.position = new Vector2(0f, -6.5f);
        }
        else if (SceneName == "Outside")
        {
            
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("LVertical", -1);            
            indicator.localRotation = Quaternion.Euler(0, 0, 0);
            player.position = ExitPosition;
        }
       
    }
    
    void Update()
    {
        
        if (OnDoor == true & Input.GetKeyDown(KeyCode.Space))
        {
            
            SceneManager.LoadScene(Label);
            
        }
        if (Past == "Stair")
        {
            SceneManager.LoadScene(Label);
            Past = "";
        }
    }

    void OnLevelWasLoaded()
    {
        PositionPlayer();
        OnDoor = false;
    }
}
