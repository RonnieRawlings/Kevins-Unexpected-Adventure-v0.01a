// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB; // Contains rigidbody2D, enables physics.
    private Animator playerAnim; // Contains Animator, enables animations.
    private int moveSpeed = 2; // Players max velocity.

    /// <summary> method <c>Movement</c> Moves player a direction according to related key press. </summary>
    public void Movement()
    {
        // Checks for key input, moves related direction.
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = Vector3.left * moveSpeed; // Moves player to the left.
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerRB.velocity = Vector3.right * moveSpeed; // Moves player to the right.
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    playerRB.velocity = Vector3.up * moveSpeed; // Moves player up.
                }
                else
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        playerRB.velocity = Vector3.down * moveSpeed; // Moves player down.
                    }
                    else
                    {
                        playerRB.velocity = Vector3.zero; // Resets player velocity, prevents movement.
                    }
                }                               
            }                       
        }
    }

    /// <summary> method <c>PlayAnimation</c> Plays a specific animation, depending on direction moving. </summary>
    public void PlayAnimation()
    {
        // Checks which direction player moving, plays relevent animation.
        if (playerRB.velocity != Vector2.zero)
        {
            if (playerRB.velocity.x < 0f)
            {
                playerAnim.Play("PlayerWalk (Left)"); // Plays left walk animation.
            }
            else
            {
                if (playerRB.velocity.x > 0f)
                {
                    playerAnim.Play("PlayerWalk (Right)"); // Plays right walk animation.
                }
                else
                {
                    if (playerRB.velocity.y < 0f)
                    {
                        playerAnim.Play("PlayerWalk (Front)"); // Plays forward walk animation.
                    }
                    else
                    {
                        playerAnim.Play("PlayerWalk (Back)"); // Plays backwards walk animation.
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
