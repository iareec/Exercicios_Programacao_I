using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float force = 500f;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }
}
