using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count; 
    private float movementX;
    private float movementY;

 
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        // Debug.Log("Start");
        rb = GetComponent<Rigidbody>();
        count = 0; 
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
   {
    // Debug.Log("OnMove");
    Vector2 movementVector = movementValue.Get<Vector2>(); 
    movementX = movementVector.x; 
    movementY = movementVector.y; 
   }

   void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 12)
       {
           winTextObject.SetActive(true);
       }
   }

   void FixedUpdate() 
   {
    // Debug.Log("FixedUpdate");
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    rb.AddForce(movement * speed); 
   }

   void OnTriggerEnter(Collider other) 
   {
    if (other.gameObject.CompareTag("PickUp")) 
       {
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
       }
   }

}