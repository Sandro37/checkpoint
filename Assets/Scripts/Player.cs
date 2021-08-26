using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float forceJump = 10;
    public float speed = 10;
    Rigidbody2D rig;
    private float direction;

    private GameController gameController;


    [SerializeField] private Transform posInit;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if(!(gameController.lastCheckPoint == new Vector2(0, 0)))
        {
            transform.position = gameController.lastCheckPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -8f)
        {
            
            if (!(gameController.lastCheckPoint == new Vector2(0, 0)))
            {
                transform.position = gameController.lastCheckPoint;
            }
            else
            {
                Debug.Log("Cheguei aqui");
                transform.position = posInit.position;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("CAIII AQUI");
            rig.velocity = Vector2.zero;
            rig.AddForce(forceJump * Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, rig.velocity.y);
    }
}
