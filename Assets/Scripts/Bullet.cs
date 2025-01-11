using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    void Start()
    {
         
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name[0] == 'W'){
            Destroy(gameObject);
        }
        else if(other.gameObject.name[0] == 'P'){
            other.GetComponent<Health>().ChangeHealth(damage);
            Destroy(gameObject);
        }
    }
}
