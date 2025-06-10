using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerMovement;

public class ShadowFollow : MonoBehaviour
{

    public Transform player;
    public float delay = 0.5f;

    private List<Vector3> positions = new List<Vector3>();
    private List<Quaternion> rotations = new List<Quaternion>();

    private float recordInterval = 0.02f;
    private float recordTimer = 0f;

    private Animator shadowAnimator;
    private PlayerMovement playerMovement;

    private float currentSpeed;
    private float targetSpeed;

    private float catchUpSpeed = 2f;

    private int playbackIndex = 0;

    public Image blackI;

    void Start()
    {
        shadowAnimator = GetComponent<Animator>();
        if (player == null)
        {
            Debug.LogError("No se asignó el transform del jugador.");
            enabled = false;
            return;
        }

        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float aux = Vector3.Distance(transform.position, player.transform.position) / 10;

        blackI.color = new Color (blackI.color.r, blackI.color.g, blackI.color.b, aux * 250);


        recordTimer += Time.deltaTime;
        if (recordTimer >= recordInterval)
        {
            recordTimer = 0f;
            positions.Add(player.position);
            rotations.Add(player.rotation);
        }

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * 10);
        shadowAnimator.SetFloat("Speed", currentSpeed);
        Debug.Log(currentSpeed);

        int delayFrames = Mathf.FloorToInt(delay / recordInterval);

        playbackIndex = positions.Count - 1 - delayFrames;

        if (playbackIndex >= 0 && playbackIndex < positions.Count)
        {
            transform.position = positions[playbackIndex];

            Vector3 lookDir = player.position - transform.position;
            lookDir.y = 0;

            if (lookDir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), catchUpSpeed * Time.deltaTime);
        }

        if (playerMovement != null)
            UpdateShadowAnimation(playerMovement.GetCurrentMovementState());
    }

    void UpdateShadowAnimation(PlayerMovement.MovementState state)
    {
        switch (state)
        {
            case PlayerMovement.MovementState.walking:
                targetSpeed = 0.5f;
                break;
            case PlayerMovement.MovementState.sprinting:
                targetSpeed = 1f;
                break;
            case PlayerMovement.MovementState.idle:
                targetSpeed = 0f; 
                break;
            case PlayerMovement.MovementState.crouching:
                shadowAnimator.Play("Crouch");
                break;
            case PlayerMovement.MovementState.sliding:
                shadowAnimator.Play("Slide");
                break;
            case PlayerMovement.MovementState.wallrunning:
                shadowAnimator.Play("Wallrun");
                break;
            case PlayerMovement.MovementState.climbing:
                shadowAnimator.Play("Climb");
                break;
            default:
                targetSpeed = 0;
                break;
        }
    }
}
