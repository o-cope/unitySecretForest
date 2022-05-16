using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public
    #endregion
    #region Serialize Field
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeedModifier;
    #endregion
    #region Private

    #region Movements
    private float yInput;
    private float xInput;
    private float oldSpeed;
    private float sprintSpeed;
    #endregion

    private bool sprintActive;

    #endregion
    #region Compononent
    Rigidbody2D rb;
    #endregion



    #region Defaults
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GetSprintSpeed();
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

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
            sprintActive = true;
        }
        else
        {
            moveSpeed = oldSpeed;
            sprintActive = false;
        }
    }
    private void GetSprintSpeed()
    {
        oldSpeed = moveSpeed;
        sprintSpeed = moveSpeed * sprintSpeedModifier;
    }

    #endregion

}
