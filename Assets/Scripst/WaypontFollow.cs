using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypontFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentwaypointIndex = 0;
    private Animator anim;

    [SerializeField] private float speed = 5.0f;

    private void Start()
    {
        // Obtén el componente Animator del objeto
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentwaypointIndex].transform.position, transform.position) < .1f)
        {
            currentwaypointIndex++;
            if (currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 0;
            }
        }
        //anim.SetTrigger("Plataforma");
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * speed);
   
    }
}
