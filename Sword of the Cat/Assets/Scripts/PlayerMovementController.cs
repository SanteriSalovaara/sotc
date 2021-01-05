using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Remoting.Contexts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementController : MonoBehaviour
{
    PlayerInput input;
    Vector2 movementInput;
    public float curSpeed;
    public float speed=5f;
    public float turnSpeed;
    Animator anim;
    Rigidbody rb;
    Transform cam;
    public AttackController.TagMask entityTag;
    AttackController ac;
    public EnemyAttack swordStyle;
    public EnemyAttack gunStyle;
    public EnemyAttack fistStyle;
    private float dashTime = 0f;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashCooldown;
    private bool isDashing = false;
    private bool isSprinting = false;
    public float sprintMultiplier = 1.5f;
    private bool isBoosted = false;

    void Start()
    {
        curSpeed = speed;
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        ac = GetComponent<AttackController>();
        dashCooldown = 0;
    }

    void FixedUpdate()
    {
        dashTime -= Time.deltaTime;
        dashCooldown -= Time.deltaTime;
        if (dashTime <= 0.2 && isDashing)
        {
            isDashing = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
        Vector3 dir = (cam.right * movementInput.x) + (cam.forward * movementInput.y);
        dir.y = 0;

        if(movementInput.x != 0 || movementInput.y != 0&&!isDashing)
        {
            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
            rb.velocity = transform.forward * speed;
            anim.SetBool("walk", true);
        } 
        else
        {
            anim.SetBool("walk", false);
        }
        anim.ResetTrigger("swing");
    }

    public void OnMove(CallbackContext context)
    {
        if (isDashing)
        {
            movementInput.x = movementInput.y = 0;
            return;
        }
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnFire(CallbackContext context)
    {
        if (context.performed)
        {
            anim.SetTrigger("swing");
            ac.attack = swordStyle;
            ac.Attack(true);
        }
    }
    public void OnDash(CallbackContext context)
    {
        if (movementInput.x == 0 && movementInput.y == 0)
        {
            return;
        }
        if (context.performed)
        {
            if (dashCooldown > 0)
            {
                return;
            }
            if (dashTime <= 0)
            {

                Vector3 direction = new Vector3(0, 0, movementInput.y);
                if (movementInput.y == 0)
                {
                    direction = new Vector3(0, 0, movementInput.x);
                }
                Debug.Log(direction);
                isDashing = true;
                dashTime = 0.5f;
                dashCooldown = 1;
                rb.AddRelativeForce(direction * dashSpeed, ForceMode.Impulse);
            }
            else
            {

            }
        }
    }
    public void OnSprint(CallbackContext context)
    {
        if (context.canceled)
        {
            curSpeed = speed;
            isSprinting = false;
            isBoosted = false;
        }
        if (isBoosted)
        {
            return;
        }
        isSprinting = true;
        speed *= sprintMultiplier;
        isBoosted = true;

    }
}
