using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class mouvement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 200f;
    public float force = 10;
    public float rotationSpeed = 100f;
    bool isGrounded;
    public static int score = 0; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float Horz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");
        Vector3 mvt = new Vector3(Horz, 0f, Vert);
        rb.velocity = (mvt * speed * Time.deltaTime);

        // Find all GameObjects with the "bonus" tag
        GameObject[] bonusObjects = GameObject.FindGameObjectsWithTag("bonus");
        GameObject[] powerObjects = GameObject.FindGameObjectsWithTag("power");

        foreach (GameObject bonusObject in bonusObjects)
        {
            bonusObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        foreach (GameObject powerObject in powerObjects)
        {
            powerObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
            
        }
        if (collision.gameObject.tag.Equals("bonus"))
        {
            Destroy(collision.gameObject);
            score += 10;
            Debug.Log("Score: "+score);

        }
        if (collision.gameObject.tag.Equals("power"))
        {
            Destroy(collision.gameObject);
            score += 50;
            Debug.Log("Score: " + score);

        }
    }
}