using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Create public variables for player speed, and for the Text UI game objects

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public int numOfCollectible;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    //Will get initialize at the start of a scene
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);
    }

    //This is function from input controller
    private void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //FixedUpdate is called before any physics calculation.
    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")){
            Destroy(other.gameObject);
            count = count + 1;
            SetCountText();
            //Debug.Log("Total Score:" + count);
        }
    }

    public void SetCountText(){
        countText.text = "Count: " + count.ToString();

        if (count >= numOfCollectible)
            winTextObject.SetActive(true);
    }
}
