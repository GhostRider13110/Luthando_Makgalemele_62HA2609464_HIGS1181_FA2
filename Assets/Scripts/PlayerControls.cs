using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 movemetInput;

    private float currentSpeed;
    private float sprintSpeed = 20f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        isShooting();

    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movemetInput = new Vector2(moveX, moveY).normalized;



        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;

        }

        else
        {
            currentSpeed = moveSpeed;
        }

        rb.linearVelocity = movemetInput * currentSpeed;
    }

    void isShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = transform.up * bulletSpeed;

        Debug.Log("Bullet Fired");
    }
}
