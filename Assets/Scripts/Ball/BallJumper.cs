using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{

    [SerializeField] private float _jumpForce;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            
        }
    }
}
