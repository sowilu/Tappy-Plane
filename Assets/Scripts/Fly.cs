using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Fly : MonoBehaviour
{
    public float jumpForce = 10;

    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private int points = 0;

    private void Start() 
    {
        //Get Component - access any component on the game object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.y < 0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        //animations
        if(rb.velocity.y > 0)
        {
            //quaternion is a way to represent rotation in 3D space
            //quaternion.Euler is a way to create a quaternion from euler angles
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }


    private void OnTriggerExit2D(Collider2D other) 
    {
        scoreText.text = (++points).ToString("D4");
    }
}
