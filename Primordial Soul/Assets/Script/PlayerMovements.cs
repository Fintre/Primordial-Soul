using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public Vector2 CurrentPos;
    public Joystick joystick;
    public float RunSpeed = 1f;
    float HorizontalMove = 0f;
    float VerticalMove = 0f;
    public float DashRange;
    private Vector2 TargetPos;
    
    public enum Facing  { UP,DOWN,RIGHT,LEFT};
    
    public Facing FacingDir = Facing.DOWN;
    public bool ButtonClicked;

    

    void Start()
    {
        ButtonClicked = false;
    }

    
    void Update()
    {
       if (joystick.Horizontal >= 0.3f)
        {
            HorizontalMove = RunSpeed;
            FacingDir = Facing.RIGHT;

        }else if (joystick.Horizontal <= -0.3f)
        {
            HorizontalMove = -RunSpeed;
            FacingDir = Facing.LEFT;
        }
        else
        {
            HorizontalMove = 0f; 
        }

        if (joystick.Vertical >= 0.3f)
        {
            VerticalMove = RunSpeed;
            FacingDir = Facing.UP;

        }
        else if (joystick.Vertical <= -0.3f)
        {
            VerticalMove = -RunSpeed;
            FacingDir = Facing.DOWN;
        }
        else
        {
            VerticalMove = 0f;
        }

       
            
            
    }

    public void Dash()
    {

        if (GameObject.FindGameObjectWithTag("PLayer") != null)
        {
             
            
                        CurrentPos = transform.position;
                        TargetPos = Vector2.zero;
                        if(FacingDir == Facing.UP)
                        {
                            TargetPos.y = 1;
                        }else if (FacingDir == Facing.DOWN)
                        {
                            TargetPos.y = -1;
                        }else if (FacingDir == Facing.RIGHT)
                        {
                            TargetPos.x = 1;
                        }else if (FacingDir == Facing.LEFT)
                        {
                            TargetPos.x = -1;
                        }

            
                    transform.Translate(TargetPos* DashRange);
        }
           


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            transform.position = CurrentPos;
        }
    }
    private void FixedUpdate()
    {   
        transform.position += new Vector3(HorizontalMove, 0,0) * Time.deltaTime * RunSpeed;
        transform.position += new Vector3(0, VerticalMove, 0) * Time.deltaTime * RunSpeed;
    }
}
