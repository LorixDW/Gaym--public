using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Ver, Hor;
    public float speed = 2;
    float rotateSpeed = 10f;
    Transform modelTransform;
    float rotation;
    public Vector3 direction;
    Animator animator;
    Rigidbody rigidbody;
    bool isRuning = false;
    //рывок
    public bool dashActive = false;
    bool dashCooldown = false;
    public int dashCooldownTimer;
    public int dashActiveTimer;
    //ограничения передвижения
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
		modelTransform = transform.Find("human-with-hands");
		modelTransform.eulerAngles = new Vector3(0, 90, 0);
        animator = modelTransform.GetComponent<Animator>();
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ver = Input.GetAxis("Vertical");
        Hor = Input.GetAxis("Horizontal");
        direction = new Vector3(Hor, 0, Ver);

		if (isAlive)
        {
            animator.SetFloat("Speed", Vector3.ClampMagnitude(direction, 1).magnitude * speed / 10);
            if(direction.magnitude > 0)
            {

                modelTransform.rotation = Quaternion.Lerp(modelTransform.rotation,
                    Quaternion.LookRotation(direction), Time.deltaTime * rotateSpeed);
                //modelTransform.rotation = Quaternion.LookRotation(direction);

                rigidbody.velocity = Vector3.ClampMagnitude(direction, 1) * speed;
            }
            if (Input.GetKeyDown(KeyCode.Space) & !dashCooldown)
            {
                speed = 20;
                dashActive = true;
                dashActiveTimer = 25;
                dashCooldown = true;
                dashCooldownTimer = 300;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {

        }



		//     Ver = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		//     Hor = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		//     direction = new Vector3(Ver, 0, Hor);
		//     isRuning = false;
		//     if (isAlive)
		//     {
		//         if(direction.magnitude > 0.00) 
		//         {
		//             isRuning = true;
		//             transform.Translate(new Vector3(Hor, 0, Ver));
		//             CheckRotate();
		//             modelTransform.eulerAngles = new Vector3(0, rotation, 0);animator.SetTrigger("Idle");
		//         }
		//         if (!dashActive)
		//         {
		//             animator.SetBool("RunBool", isRuning);
		//	animator.SetBool("FastRun", false);
		//}
		//         else
		//         {
		//	animator.SetBool("FastRun", isRuning);
		//}

		//         if (Input.GetKeyDown(KeyCode.Space) & !dashCooldown)
		//         {
		//             speed = 20;
		//             dashActive = true;
		//             dashActiveTimer = 25;
		//             dashCooldown = true;
		//             dashCooldownTimer = 300;
		//         }
		//     }
		//     else
		//     {
		//modelTransform.eulerAngles = new Vector3(0, 0, 90);
		//     }
	}
	private void FixedUpdate()
	{
        if(dashCooldownTimer > 0)
        {
            dashCooldownTimer -= 1;
        }
        else
        {
            dashCooldown = false;
        }
        if(dashActiveTimer > 0)
        {
            dashActiveTimer -= 1;
        }
        else
        {
            dashActive = false;
            speed = 10;
        }
	}
	void CheckRotate()
    {
        if(Ver > 0 & Hor == 0)
        {
            rotation = 0;
        }
        if(Ver < 0 & Hor == 0)
        {
            rotation = 180;
        }
        if(Hor > 0 & Ver == 0)
        {
            rotation = 90;
        }
		if(Hor < 0 & Ver == 0)
		{
			rotation = -90;
		}
        if(Hor > 0 & Ver > 0)
        {
            rotation = 45;
        }
		if (Hor > 0 & Ver < 0)
		{
			rotation = 135;
		}
		if (Hor < 0 & Ver < 0)
		{
			rotation = -135;
		}
		if (Hor < 0 & Ver > 0)
		{
			rotation = -45;
		}
	}
}
