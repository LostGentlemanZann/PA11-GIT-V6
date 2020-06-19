using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float yMin = -3.8f;
    public float yMax = 3.8f; 

    public float speed;

    public Rigidbody rb;

    public float scoreValue;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if(transform.position.y >= yMax) 
        {
            speed = 0;
            if(Input.GetAxis("Vertical") <= 0) 
            {
                speed = 10;
            }
        }
        else if(transform.position.y <= yMin) 
        {
            speed = 0;
            if(Input.GetAxis("Vertical") >= 0) 
            {
                speed = 10;
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Points")) 
        {
            scoreValue += 1;
            score.text = "Score : " + scoreValue;
        }
        else if (other.gameObject.CompareTag("Obstacle")) 
        {
            SceneManager.LoadScene("End");
            Destroy(gameObject);
        }
    }
}
