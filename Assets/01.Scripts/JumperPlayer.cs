using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumperPlayer : MonoBehaviour
{
    [SerializeField] TMP_Text playerName;
    private float speed = 0.5f;
    private Animator animator;
    private float turnSmoothVelocity = 0.1f;
    private float turnSmoothTime = 0.05f;
    private Rigidbody rb;

    private bool isGround = true;
    private bool isSliding = false;
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Start()
    {
        playerName.text = UserData.Instance.GerUserName();
    }

    void Update()
    {
        if (!rb.useGravity)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGround)
                return;
            rb.AddForce(new Vector3(0,2,0), ForceMode.Impulse);
            isGround = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(hAxis, 0f, vAxis).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (Input.GetMouseButtonDown(0) && !isGround && !isSliding)
        {
            isSliding = true;
            rb.AddForce(new Vector3(direction.x, 1.0f, direction.y), ForceMode.Impulse);
            Debug.Log("Diving");
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BasePlane>())
        {
            isGround = true;
            isSliding = false;
        }
    }


    public void SetGravity()
    {
        rb.useGravity = true;
    }
}
