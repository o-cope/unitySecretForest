using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parametres")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float minStamina = 0.0f;
    [SerializeField] private float hitCost = 20.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parametres")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina Speed Parametres")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float runSpeed = 10.0f;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;




    private Player playerController;


    private void Start()
    {
        playerController = GetComponent<Player>();
    }

    private void Update()
    {
        if (!weAreSprinting)
        {
            playerController.SetRunSpeed(moveSpeed);
            if(playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina();

                if (playerStamina >= minStamina)
                {
                    hasRegenerated = true;
                }
            }
        }
    }


    public void Sprinting()
    {
        if (hasRegenerated)
        {
            weAreSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            playerController.SetRunSpeed(runSpeed);
            UpdateStamina();


            if (playerStamina <= 0)
            {
                hasRegenerated = false;
                playerController.SetRunSpeed(moveSpeed);
            }
        }
    }

    public void StaminaHit()
    {
        if(playerStamina >= (maxStamina * hitCost / maxStamina))
        {
            playerStamina -= hitCost;
            //allow 
            UpdateStamina();
        }
    }

    private void UpdateStamina()
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

    }
}
