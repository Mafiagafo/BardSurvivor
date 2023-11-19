using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using FMOD.Studio;

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

    //Audio
    private EventInstance playerFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerStats>();
        characterBody = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2 (1,0f);
        playerFootsteps = AudioManager.instance.CreaterEventInstance(FMODEvents.instance.playerFootsteps);
    }

    // Update is called once per frame
    void Update()
    {
        InputManegement();
    }
   
    void FixedUpdate()
    {
        Move();
        UpdateSound();
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

    private void UpdateSound()
    {
        if (characterBody.velocity.x !=0 || characterBody.velocity.y != 0)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }


}
