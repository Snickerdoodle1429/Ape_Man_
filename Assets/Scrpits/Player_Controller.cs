using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
  public float speed = 0.4f;
  Vector2 dest = Vector2.zero;

  void start(){
    dest = transform.position;

  }

  void FixedUpdate(){
    // Move closer to Destination
    Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
    GetComponent<Rigidbody2D>().MovePosition(p);

    // Check for Input if not moving
    if ((Vector2)transform.position == dest){
        if(Input.GetKey(KeyCode.W) && valid(Vector2.up))
            dest = (Vector2)transform.position + Vector2.up;
        if(Input.GetKey(KeyCode.D) && valid(Vector2.right))
            dest = (Vector2)transform.position + Vector2.right;
        if(Input.GetKey(KeyCode.S) && valid(Vector2.down))
            dest = (Vector2)transform.position - Vector2.up;
        if(Input.GetKey(KeyCode.A) && valid(Vector2.left))
            dest = (Vector2)transform.position - Vector2.right;
    }
  }

  bool valid(Vector2 dir){
    // Cast line from 'next to Pac-Man' to 'Pac-Man'
    Vector2 pos = transform.position;
    RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
    return (hit.collider == GetComponent<Collider2D>());
  }
}