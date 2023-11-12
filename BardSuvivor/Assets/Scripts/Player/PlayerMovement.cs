using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector2 moveDir;
     [HideInInspector]
    public float lastVerticalVector;
     [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;

    Rigidbody2D characterBody;
    PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerStats>();
        characterBody = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2 (1,0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputManegement();
    }
   
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        characterBody.velocity = new Vector2(moveDir.x * player.currentMoveSpeed, moveDir.y * player.currentMoveSpeed);
    }

    void InputManegement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }
        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }

        
    }


}
