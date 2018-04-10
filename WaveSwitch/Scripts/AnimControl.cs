using UnityEngine;
using System.Collections;

public class AnimControl : MonoBehaviour {

    public player player;

    public playerMovement pM;

    public Animator animator;

    bool flip = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        // Animation
        if (player.rb2d.velocity.y > 1)
        {
            animator.SetBool("Jump", true);
        }
        else {
            animator.SetBool("Jump", false);
        }

        if (player.rb2d.velocity.y < -1.1)
        {
            animator.SetBool("Fall", true);
        }
        else {
            animator.SetBool("Fall", false);
        }
        if (player.rb2d.velocity.x >= 0.1)
        {
            pM.sprite.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.rb2d.velocity.x <= -0.1)
        {
            pM.sprite.transform.localScale = new Vector3(-1, 1, 1);

        }
        if (player.rb2d.velocity.x >= 0.1 || player.rb2d.velocity.x <= -0.1)
        {
            animator.SetBool("MoveRight", true);
        }
        else
        {
            animator.SetBool("MoveRight", false);
        }

        if (pM.canWallJump)
        {
            animator.SetBool("Sliding", true);
            if (pM.sprite.transform.localScale.x == -1 && flip)
            {
                pM. sprite.transform.localScale = new Vector3(1, 1, 1);
                flip = false;
            }
            else if (pM.sprite.transform.localScale.x == 1 && flip)
            {
                pM.sprite.transform.localScale = new Vector3(-1, 1, 1);
                flip = false;
            }
        }
        else if (!pM.canWallJump)
        {
            animator.SetBool("Sliding", false);
            flip = true;
        }
    }
}
