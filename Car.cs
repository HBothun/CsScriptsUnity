using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[System.Serializable]
public class Car
{
   /* [HideInInspector]
    public int offset = 10f;*/
    [HideInInspector]
    public GameObject c;
    //public Sprite carDirectionImage;
    [HideInInspector]
    public bool movesLeft;
    [HideInInspector]
    public SpriteRenderer carImage;
    /*[HideInInspector]
    public GameObject headLight;
*/
    /*[HideInInspector]
    public Light rearLight;*/
    [HideInInspector]
    public BoxCollider2D bc;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Transform car;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public Vector3 startingPosition;
    [HideInInspector]
    public float streetMinX;
    [HideInInspector]
    public float streetMaxX;
    
}   
    
