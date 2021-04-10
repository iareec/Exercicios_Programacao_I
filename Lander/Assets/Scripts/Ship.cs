using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField] float turnVelocity = 0.1f; // Velocity when turning left or right
    [SerializeField] float fuel = 500f; // Amount of fuel when starting
    [SerializeField] float thrustVelocity = 200f; 
    [SerializeField] float fuelBurn = 10f; // Amount of fuel burned when not turning
    [SerializeField] float fuelBurnTorque = 5f; // Amount of fuel burned when turning
    [SerializeField] float velocityThreshold = 4f; // Maximum velocity when landing
    [SerializeField] float rotationThresholdL = 16f; // Maximum angle (left) value when landing 
    [SerializeField] float rotationThresholdR = 344f; // Maximum angle (right) value when landing 

    [SerializeField] TextMeshProUGUI txtFuel;

    Rigidbody2D rb;
    float angleRB;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        angleRB = Mathf.Abs(transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.LeftArrow) && fuel > 0)
        {
            if (angleRB < 180)
            {
                rb.AddTorque(turnVelocity * Time.deltaTime);
            } else
            {
                rb.AddTorque(turnVelocity);
            }
            fuel -= fuelBurnTorque * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow) && fuel > 0)
        {
            if (angleRB > 180 )
            {
                rb.AddTorque(-turnVelocity * Time.deltaTime);
            }
            else
            {
                rb.AddTorque(-turnVelocity);
            }
            fuel -= fuelBurnTorque * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * thrustVelocity * Time.deltaTime);
            fuel -= fuelBurn * Time.deltaTime;
        }
        txtFuel.text = "Fuel " + Mathf.RoundToInt(fuel).ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if(collision.relativeVelocity.magnitude <= velocityThreshold &&
                 (angleRB <= rotationThresholdL || angleRB >= rotationThresholdR))
            {
                Debug.Log(collision.relativeVelocity.magnitude);
                SceneManager.LoadScene("Landed");
            } else
            {
                SceneManager.LoadScene("GameOver");
            }
        } else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
