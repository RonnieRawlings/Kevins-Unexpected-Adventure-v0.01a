// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Private fields, only available in this script.

    private Rigidbody2D playerRB; // Contains rigidbody2D, enables physics.
    private Animator playerAnim; // Contains Animator, enables animations.
    private int moveSpeed = 2; // Players max velocity.

    /// <summary> method <c>Movement</c> Moves player a direction according to related key press. </summary>
    public void Movement()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity += transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += -transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += transform.right;
        }
        
        playerRB.velocity = velocity.normalized * moveSpeed;        
    }

    /// <summary> method <c>PlayAnimation</c> Plays a specific animation, depending on direction moving. </summary>
    public void PlayAnimation()
    {
        // Checks which direction player moving, plays relevent animation.
        if (playerRB.velocity != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                playerAnim.Play("PlayerWalk (Diagonal UpRight)");
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                playerAnim.Play("PlayerWalk (Diagonal UpLeft)");
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                playerAnim.Play("PlayerWalk (Diagonal DownLeft)");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerAnim.Play("PlayerWalk (Left)"); // Plays left walk animation.
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    playerAnim.Play("PlayerWalk (Right)"); // Plays right walk animation.
                }
                else
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        playerAnim.Play("PlayerWalk (Back)"); // Plays forward walk animation.
                    }
                    else
                    {
                        playerAnim.Play("PlayerWalk (Front)"); // Plays backwards walk animation.
                    }
                }
            }          
        }
        // If velocity is zero, play idle.
        else
        {
            playerAnim.Play("PlayerIdle (Front)"); // Plays PlayerIdle animation.
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Gives vars access to player components.
        playerRB = transform.GetComponent<Rigidbody2D>();
        playerAnim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); // Calls method, allows player sprite to move.
        PlayAnimation(); // Calls method, plays animation depends on direction.
    }
}
