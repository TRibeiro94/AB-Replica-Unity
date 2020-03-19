//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
/*
* @author Tiago Ribeiro (www.github.com/TRibeiro94)
**/
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemyHit = collision.collider.GetComponent<Bird>() != null;        //if it collides with the bird
        bool enemyKnocked = collision.collider.GetComponent<Floor>() != null;   //or it touches the floor

        if (enemyHit || enemyKnocked)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        /* OR
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Destroy(gameObject);
        }
         **/
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5)                       //if he gets hit from above
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
