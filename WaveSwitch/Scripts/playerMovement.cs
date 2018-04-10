using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
    public player player;

    public Animator animator;

    public GameObject sprite;

    //private float groundspeed;

    public bool grounded;

    //public Transform mainCam;
    Vector3 Velocity = Vector3.zero;
    public bool Jumping;
    public bool canWallJump;
    float groundspeed = 3.0f;
    float WallSide = 0f;
    int WJumpLockout = 0;


    //fill in these to the values you need;

    public float playerwidth = 0.1f;
    public float playerheight = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
       if (Input.GetKey(KeyCode.Z))
        {
            //sprint just doubles your ground speed
            groundspeed = 6.0f;
        }
        else
        {
            groundspeed = 3.0f;
            //your actual ground speed
        }

        //all motion

        //the primary moving line of code
        if (!Jumping)
        {
            Velocity = new Vector3(Input.GetAxis("Horizontal") * groundspeed, player.rb2d.velocity.y, 0);
            //updates the velocity so jump code works
            player.rb2d.velocity = new Vector3(Velocity.x, Velocity.y, 0);
        }
        else if (Jumping)
        {
            if (WJumpLockout <= 0)
            {
                Velocity = new Vector3(player.rb2d.velocity.x, player.rb2d.velocity.y, 0);
                //updates the velocity so jump code works
                player.rb2d.velocity = new Vector3(Velocity.x, Velocity.y, 0);
                //aerial motion
                //simulating aerial movement
                Vector3 MotionMaker = new Vector3(0.25f, 0, 0);
                if (Input.GetAxis("Horizontal") >= 0.1)
                {
                    Velocity += MotionMaker;
                    //controls excess motion
                    if (Velocity.x > 3.0f)
                    {
                        Velocity = new Vector3(3.0f, Velocity.y, 0);
                    }
                }
                else if (Input.GetAxis("Horizontal") <= -0.1)
                {
                    Velocity -= MotionMaker;
                    //controls excess motion
                    if (Velocity.x < -3.0f)
                    {
                        Velocity = new Vector3(-3.0f, Velocity.y, 0);
                    }
                }
            }
            else
            {
                WJumpLockout--;
                if (WJumpLockout <= 0)
                {
                    Debug.Log("GO");
                }
            }
        }



        //not jumping, no y motion

        if (!Jumping)
        {
            //removes the y component of velocity
            player.rb2d.velocity = new Vector3(player.rb2d.velocity.x, 0, 0);

        }
        //jumping
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //set animator to jump

            //can only jump while on the ground
            if (!Jumping)
            {
                //normal jump
                Jumping = true; //no jumping
                Velocity = new Vector3(player.rb2d.velocity.x, 5.0f, 0);
                //jumps your player (above code)
            }
            else if (canWallJump)
            {
                //walljump time
                //makes you hop off the wall at a 45 degree angle away
                if (WallSide > 0)
                {
                    Velocity = new Vector3(3.0f, 3.0f, 0);
                }
                else
                {
                    Velocity = new Vector3(-3.0f, 3.0f, 0);
                }
                canWallJump = false;
                WJumpLockout = 10;
            }
        }

        player.rb2d.velocity = new Vector3(Velocity.x, Velocity.y, 0);
        //updates velocity  (with the jump code)

        //tricks oncollisionstay
        transform.position += new Vector3(0, 0, 1);
        transform.position += new Vector3(0, 0, -1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newloc = new Vector3(transform.position.x - collision.gameObject.transform.position.x, transform.position.y - collision.gameObject.transform.position.y, 0);
        if (collision.gameObject.tag == "Floor")
        {
            if (newloc.y >= 0)
            {
                Jumping = false;
            }

        }


    }
    void OnCollisionStay2D(Collision2D col)
    {
        ///////////////////////////////////////////////////////////////

        //MOVEMENT CODE

        Vector3 newloc = new Vector3(transform.position.x - col.gameObject.transform.position.x, transform.position.y - col.gameObject.transform.position.y, 0);

        float xloc, yloc;

        xloc = newloc.x;
        yloc = newloc.y;

        if (xloc - playerwidth > 0)
        {
            //to the left of the player
            Debug.Log("to the left of the player");
            if (col.gameObject.tag == "Wall")
            {
                if (Jumping == true)
                {
                    canWallJump = true;
                }
            }
            WallSide = transform.position.x - col.transform.position.x;
        }
        else
        {
            //to the right of the player
            Debug.Log("to the right of the player");
            if (col.gameObject.tag == "Wall")
            {
                if (Jumping == true)
                {
                    canWallJump = true;
                }
            }
            WallSide = transform.position.x - col.transform.position.x;
        }

        if (col.gameObject.tag == "Floor")
        {
            if (yloc - playerheight > 0)
            {
                //above the player
                Debug.Log("above the player");

            }
            else {

                //below the player
                Debug.Log("below the player");
                Jumping = false;
            }
        }

        ///////////////////////////////////////////////////////////

    }
    void OnCollisionExit2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            canWallJump = false;
        }
        if (collision.gameObject.tag == "Floor")
        {
            Jumping = true;
        }
    }

    

}