using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != waypoints[cur].position) // Si el fantasma no ha llegado al waypoint que se mueva hacia el
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else // Si ya ha llegado al waypoint selecciona el siguiente
            cur = (cur + 1) % waypoints.Length;

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        // Aqui podría enseñar un "GAME OVER"
        if (co.name == "pacman")
            Destroy(co.gameObject);
    }
}
