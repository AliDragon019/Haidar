using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float bulletSpeedMultiplier;
    public float shootDelay;
    public float delayStep;
    float timer;
    

    Rigidbody2D rb;

    public KeyCode shootKey;
    public KeyCode[] movementKeys = new KeyCode[4];

    Transform bulletspawn;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletspawn = transform.GetChild(0).GetComponent<Transform>();
        timer = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(movementKeys[0])){
            rb.velocity = new Vector2(0, speed);
            transform.rotation = new Vector3(0,0,0);
        } else if(Input.GetKeyDown(movementKeys[1])){
            rb.velocity = new Vector2(0, speed);
            transform.rotation = new Vector3(0,0,270);
        } else if(Input.GetKeyDown(movementKeys[2])){
            rb.velocity = new Vector2(0, speed);
            transform.rotation = new Vector3(0,0,180);
        } else if(Input.GetKeyDown(movementKeys[3])){
            rb.velocity = new Vector2(0, speed);
            transform.rotation = new Vector3(0,0,90);
        }

        if(timer >= 0){
            timer -= Time.deltaTime;
        }
        if(Input.GetKey(shootKey)){
            if(timer <= 0){
                Shoot();
                timer = shootDelay;
            }
        }
    }

    public void Shoot(){
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletspawn.position;
        if(rb.velocity.x == 0 && rb.velocity.y == 0){
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeedMultiplier*speed);
        } else {
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeedMultiplier*rb.velocity;
        }
    }
    
}
