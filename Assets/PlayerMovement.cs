using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //serialized field --> jij kan het editen met je script editor maar andere scripts kan er niet aan omdat ze private zijn

    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        // movement dat al voor je gemaakt is eerste input is op de x-as (omhoog) 2de is movement op de Y-as
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));

    }

    private void AIControl()
    {
        //als de bal van y positie veranderd (hoger of lager) dan beweeg (de 0,5f is om ervoor te zorgen dat het niet accuraat is)
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1); //beweeg omhoog
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1); //beweeg omlaag
        }
        else
        {
            //voorbeeld deed else       
            playerMove = new Vector2(0, 0);
        }
       
    }

    /// <summary>
    /// Unity functie
    /// private is niet nodig
    /// belangrijk om te gebruiken
    /// wordt gecalled wat gebeurd elke seconde
    /// wordt niet gebruikt op fps maw nodig anders een persoon met meer frame rate dan mensen met high fps hebben slower movement.
    /// </summary>

    private void FixedUpdate() {
    
        rb.velocity = playerMove * movementSpeed; 
    }

}
