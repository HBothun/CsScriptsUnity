using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        static PlayerMovement instance;
        public float moveSpeed = 5f;
        public float maxSpeed = 20f;
        public Rigidbody2D rb;
        public Animator animator;
        public Transform Interactor;
        public Text health;
        public int healthPoints;
        
        
        
        void Start()
        {
            rb = this.gameObject.GetComponent<Rigidbody2D>();
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if(instance != this)
            {
                Destroy(gameObject);
            }
            
           
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Car"))
            {
                if (healthPoints > 1)
                {
                    healthPoints -= 1;
                    health.text = "Health " + healthPoints;
                }
                else if (healthPoints == 1)
                {
                    SceneManager.LoadScene("DeathScreen");
                    Destroy(this.gameObject);
                }
            }
        }

        
        void Update()
        {
            Vector2 movement;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("LHorizontal", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LVertical", Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, 90);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, -90);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, 180);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") < 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, -60);
            }
            if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") > 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, 135);
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") > 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, -135);
            }
            if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") < 0)
            {
                Interactor.localRotation = Quaternion.Euler(0, 0, 60);
            }
            
        }

        void FixedUpdate()
        {

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            float z = Input.GetAxis("Horizontal");
            float w = Input.GetAxis("Vertical");
            Vector2 velocity = new Vector2(z, w);
            Vector2 movement = new Vector2(x, y);
            movement = movement.normalized;
            velocity = velocity.normalized;
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement *= 2;
            }  
            if(movement.magnitude < maxSpeed)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                rb.AddForce(velocity);
            }
            else if(movement.magnitude == maxSpeed)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }
}