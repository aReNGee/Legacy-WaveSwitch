using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

    public int lives = 1;
    public bool isAlive;
    public Rigidbody2D rb2d;
    public SpriteRenderer rend;

    public Transform mainCam;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        isAlive = true;
    }

    void Update()
    {
        //mainCam.position = new Vector3(transform.position.x + 1f, transform.position.y + 1f, mainCam.position.z);
    }

    void FixedUpdate()
    {
        
    }
}
