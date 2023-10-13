using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;  
    public float speed;
    private int count;
    private int numPickups = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI posText;
    public TextMeshProUGUI velocityText;
    private float xcount;
    private float ycount;
    private float zcount;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    } 

    void Start() {
        count = 0;
        xcount = 0;
        ycount = 0;
        zcount = 0;
        winText.text = "";
        SetCountText();
        SetPosText();
        SetVelocityText();
    }

    void FixedUpdate() { 
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
        xcount = transform.position.x;
        ycount = transform.position.y;
        zcount = transform.position.z;
        SetPosText();
        SetVelocityText();
        } 

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText(){
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups){
            winText.text = "You win!";
        }
    }

    private void SetPosText(){
        posText.text = "x: " + (xcount).ToString("0.00") + ", y: " + (ycount).ToString("0.00") + ", z: " + (zcount).ToString("0.00");
    }

    private void SetVelocityText(){
        velocityText.text = "Velocity: " + GetComponent<Rigidbody>().velocity.ToString("0.00");
    }
}