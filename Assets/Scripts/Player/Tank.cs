using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotate;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.centerOfMass = new Vector3(0, -1.5f, 0);
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
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(-transform.forward * speed, ForceMode.Acceleration);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddTorque(transform.up * -rotate, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddTorque(transform.up * rotate, ForceMode.Acceleration);
        }

        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }
}
