using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firepoint;

    int isMoveForward;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.centerOfMass = new Vector3(0, -2, 0);
        isMoveForward = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            isMoveForward = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(-transform.forward * speed, ForceMode.Acceleration);
            isMoveForward = -1;
        }
        else
        {
            isMoveForward = 1;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddTorque(transform.up * -rotate * isMoveForward, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddTorque(transform.up * rotate * isMoveForward, ForceMode.Acceleration);
        }

        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion rotation = Quaternion.Euler(firepoint.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            Instantiate(projectile, firepoint.position, rotation);
        }
    }
}
