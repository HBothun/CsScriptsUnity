using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;


public class InstructionIndicator : MonoBehaviour
{
    static InstructionIndicator instance;
    public Canvas PopUp;
    public Text Counter;
    public PlayerMovement player;
    
    
    
    public SpriteRenderer Indicator;
    private int coinCount = 0;
    private bool OnDoor = false;
    
    

    void start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        PopUp = this.gameObject.GetComponent<Canvas>();
        Indicator = this.gameObject.GetComponent<SpriteRenderer>();
       
    }
    

    void OnTriggerEnter2D(Collider2D Hit)
    {
        
        if (Hit.gameObject.CompareTag("PickUp"))
        {
            if (coinCount < 50)
            {
                coinCount++;
                Counter.text = "Pizzas " + coinCount + " / 50";
                Destroy(Hit.gameObject);
                FindObjectOfType<AudioManager>().Play("Chew");
            }
            if (coinCount == 50)
            {
                HealthIncrease();
                coinCount = 0;
                Counter.text = "Pizzas " + coinCount + " / 50";
                Destroy(Hit.gameObject);
                FindObjectOfType<AudioManager>().Play("Chew");
            }
            
            
        }

        ///DOOORSSS///
        if (Hit.gameObject.CompareTag("Enter"))
        {
            
            OnDoor = true;
            
        }
        if (Hit.gameObject.CompareTag("House1Int"))
        {

            OnDoor = true;

        }
        if (Hit.gameObject.CompareTag("House2Int"))
        {

            OnDoor = true;

        }
        if (Hit.gameObject.CompareTag("House3Int"))
        {

            OnDoor = true;

        }
        if (Hit.gameObject.CompareTag("House4Int"))
        {

            OnDoor = true;

        }
        if (Hit.gameObject.CompareTag("HouseTriInt"))
        {

            OnDoor = true;

        }
        if (Hit.gameObject.CompareTag("Exit"))
        {
            
            OnDoor = true;
           
        }               
    }

    void OnTriggerExit2D(Collider2D Door)
    {
        OnDoor = false;       
    }

   
    void PopUpindc()
    {
        if (OnDoor == true)
        {

            PopUp.enabled = true;
            Indicator.enabled = false;

        }
        else if (OnDoor == false)
        {
            PopUp.enabled = false;
            Indicator.enabled = true;
       
        }
    }
    void Update()
    {
       
        PopUpindc();
        
    }
    void OnLevelWasLoaded()
    {
        OnDoor = false;
    }

    void HealthIncrease()
    {
        player.healthPoints = player.healthPoints + 1;
        player.health.text = "Health " + player.healthPoints;
    }
}
