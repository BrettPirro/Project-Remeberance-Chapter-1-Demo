using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]float PlatformSpeed=5f;
    [SerializeField] Transform A, B;
    Vector2 SelectedTransform;
    BoxCollider2D Collider;
    GameObject player;

    private void Start()
    {
        SelectedTransform = A.position;
        Collider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Collider.IsTouching(player.GetComponent<BoxCollider2D>()))
        {

            player.transform.parent = this.transform;
        }
        else
        {
            player.transform.parent = null;
        }


        ChangePos();
        

       

    }

    private void ChangePos()
    {
        if (Equals(transform.position, A.position))
        {
            SelectedTransform = B.position;
        }
        else if (Equals(transform.position, B.position))
        {
            SelectedTransform = A.position;
        }


        transform.position = Vector2.MoveTowards(transform.position, SelectedTransform, PlatformSpeed * Time.deltaTime);
    }
}
