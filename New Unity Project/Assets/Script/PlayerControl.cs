using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    public Text countText;
    private Rigidbody rb;
    private int count;
    public Text endText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        endText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }
    }
    void SetCountText ()
    {
        countText.text = "Points: " + count.ToString();
        if (count >= 12)
        {
            endText.text = "YOU WIN";
        }
    }
}