using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario4Script : MonoBehaviour
{

    public FixedJoystick joystick;
    public float moveSpeed;

    float hInput, vInput;

    int score = 0;

    public GameObject winText;

    public GameObject objective;

    public int winScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Carrot")
        {
            score = score + 1;

            Destroy(collision.gameObject);

            if(score >= 1)
            {
                objective.SetActive(false);
            }

            if(score >= winScore)
            {
                winText.SetActive(true);
            }

        }



    }

}
