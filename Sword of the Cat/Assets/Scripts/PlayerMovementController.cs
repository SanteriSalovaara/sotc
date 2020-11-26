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
    public float speed;
    public float turnSpeed;
    Animator anim;
    Rigidbody rb;
    Transform cam;
    public AttackController.TagMask entityTag;
    AttackController ac;
    public EnemyAttack swordStyle;
    public EnemyAttack gunStyle;
    public EnemyAttack fistStyle;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        ac = GetComponent<AttackController>();
    }

    void FixedUpdate()
    {
        Vector3 dir = (cam.right * movementInput.x) + (cam.forward * movementInput.y);
        dir.y = 0;

        if(movementInput.x != 0 || movementInput.y != 0)
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
}
