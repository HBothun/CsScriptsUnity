using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class SpawningObjects : MonoBehaviour
{
    public Sprite left;
    public Sprite right;
    public float street1yCord;
    public float street2yCord;
    public int streetMinX;
    public int streetMaxX;
    public int speed;
    public Vector2 size;
    public Vector2 boxOffset;
    public GameObject light;
    [HideInInspector]
    public float offset = 10f;
    

    public Car[] carsLeftToRightStreet1;
    public Car[] carsRightToLeftStreet1;
    public Car[] carsLeftToRightStreet2;
    public Car[] carsRightToLeftStreet2;

    private float iterationls1;
    private float iterationrs1;
    private float iterationls2;
    private float iterationrs2;

    void Awake()
    {
        foreach (Car c in carsLeftToRightStreet1)
        {
            c.speed = speed;
            c.c = new GameObject();
            c.c.tag = "Car";
            c.carImage = c.c.AddComponent<SpriteRenderer>();
            c.carImage.sortingLayerName = "Player";
            c.rb = c.c.AddComponent<Rigidbody2D>();
            c.bc = c.c.AddComponent<BoxCollider2D>();
            c.bc.size = size;
            c.bc.offset = boxOffset;
            c.rb.isKinematic = true;
            c.car = c.c.GetComponent<Transform>();            
            c.startingPosition = new Vector3(((streetMinX + 1) + (offset * iterationls1)), street1yCord - 1, 0f);
            c.car.position = c.startingPosition;
            c.carImage.sprite = right;
            var carLight = Instantiate(light, 
                new Vector3(((streetMinX + 1) + (offset * iterationls1) + 1.96f), street1yCord - 1, 0f), 
                Quaternion.Euler(0, 0, -90));
            carLight.transform.SetParent(c.c.transform);
            iterationls1++;
            
        }
        foreach (Car c in carsRightToLeftStreet1)
        {
            c.speed = speed;
            c.c = new GameObject();
            c.c.tag = "Car";
            c.carImage = c.c.AddComponent<SpriteRenderer>();
            c.carImage.sortingLayerName = "Player";
            c.bc = c.c.AddComponent<BoxCollider2D>();
            c.rb = c.c.AddComponent<Rigidbody2D>();
            c.bc.size = size;
            c.bc.offset = boxOffset;
            c.rb.isKinematic = true;
            c.car = c.c.GetComponent<Transform>();            
            c.startingPosition = new Vector3(((streetMaxX - 1)) - (offset * iterationrs1), (street1yCord), 0f);
            c.car.position = c.startingPosition;
            c.carImage.sprite = left;
            var carLight = Instantiate(light,
               new Vector3(((streetMaxX - 1) - (offset * iterationrs1) - 1.96f), street1yCord, 0f),
               Quaternion.Euler(0, 0, 90));
            carLight.transform.SetParent(c.c.transform);
            iterationrs1++;
        }
        foreach (Car c in carsLeftToRightStreet2)
        {
            c.speed = speed;
            c.c = new GameObject();
            c.c.tag = "Car";
            c.carImage = c.c.AddComponent<SpriteRenderer>();
            c.carImage.sortingLayerName = "Player";
            c.bc = c.c.AddComponent<BoxCollider2D>();
            c.rb = c.c.AddComponent<Rigidbody2D>();
            c.bc.size = size;
            c.bc.offset = boxOffset;
            c.rb.isKinematic = true;
            c.car = c.c.GetComponent<Transform>();           
            c.startingPosition = new Vector3(((streetMinX + 1) + (offset * iterationls2)), street2yCord - 2, 0f);
            c.car.position = c.startingPosition;
            c.carImage.sprite = right;
            var carLight = Instantiate(light,
               new Vector3(((streetMinX + 1) + (offset * iterationls2) + 1.96f), street2yCord - 2, 0f),
               Quaternion.Euler(0, 0, -90));
            carLight.transform.SetParent(c.c.transform);
            iterationls2++;
        }
        foreach (Car c in carsRightToLeftStreet2)
        {
            c.speed = speed;
            c.c = new GameObject();
            c.c.tag = "Car";
            c.carImage = c.c.AddComponent<SpriteRenderer>();
            c.carImage.sortingLayerName = "Player";
            c.bc = c.c.AddComponent<BoxCollider2D>();
            c.rb = c.c.AddComponent<Rigidbody2D>();
            c.bc.size = size;
            c.bc.offset = boxOffset;
            c.rb.isKinematic = true;
            c.car = c.c.GetComponent<Transform>();
            c.startingPosition = new Vector3(((streetMaxX - 1) - (offset * iterationrs2)), (street2yCord), 0f);
            c.car.position = c.startingPosition;
            c.carImage.sprite = left;
            var carLight = Instantiate(light,
               new Vector3(((streetMaxX - 1) - (offset * iterationrs2) - 1.96f), street2yCord, 0f),
               Quaternion.Euler(0, 0, 90));
            carLight.transform.SetParent(c.c.transform);
            iterationrs2++;
        }

    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        foreach (Car c in carsRightToLeftStreet1)
        {
            if (c.car.position.x > streetMinX)
            {
                c.rb.MovePosition(c.rb.position - new Vector2(c.speed, 0f) * Time.fixedDeltaTime);
            }
            else if (c.car.position.x < streetMinX)
            {
                c.car.position = new Vector3(streetMaxX, street1yCord, 0f);
            }
        }
        foreach (Car c in carsLeftToRightStreet1)
        {
            if (c.car.position.x < streetMaxX)
            {
                c.rb.MovePosition(c.rb.position + new Vector2(c.speed, 0f) * Time.fixedDeltaTime);
            }
            else if (c.car.position.x > streetMaxX)
            {
                c.car.position = new Vector3(streetMinX, street1yCord - 1, 0f);
            }
        }
        foreach (Car c in carsRightToLeftStreet2)
        {
            if (c.car.position.x > streetMinX)
            {
                c.rb.MovePosition(c.rb.position - new Vector2(c.speed, 0f) * Time.fixedDeltaTime);
            }
            else if (c.car.position.x < streetMinX)
            {
                c.car.position = new Vector3(streetMaxX, street2yCord, 0f);
            }
        }
        foreach (Car c in carsLeftToRightStreet2)
        {
            if (c.car.position.x < streetMaxX)
            {
                c.rb.MovePosition(c.rb.position + new Vector2(c.speed, 0f) * Time.fixedDeltaTime);
            }
            else if (c.car.position.x > streetMaxX)
            {
                c.car.position = new Vector3(streetMinX, street2yCord - 2, 0f);
            }
        }
    }
}
