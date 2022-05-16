using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    private float yInput;
    private float xInput;

    [Header("Components")]
    Rigidbody2D rb;
    [HideInInspector] public StaminaController _staminaController;
    
    
    #region Defaults
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _staminaController = GetComponent<StaminaController>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Sprint();
    }
    #endregion



    #region Functions

    #region Movement
    private void GetInput()
    {
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
    }

    private void MovePlayer()
    {
        Vector2 vectorMove;
        vectorMove = new Vector2(xInput * moveSpeed, yInput * moveSpeed);
        rb.velocity = vectorMove;
    }

    public void SetRunSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _staminaController.weAreSprinting = true;
            _staminaController.Sprinting();
        }
        else
        {
            _staminaController.weAreSprinting = false;
        }
    }
    #endregion

    


    #endregion

}

   



    
    


