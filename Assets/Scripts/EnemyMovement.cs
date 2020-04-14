using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0.5f;
    [SerializeField] private ParticleSystem winnerParticle;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

     IEnumerator FollowPath(List<Waypoint> path)
     {
         foreach (var waypoint in path)
         {
             transform.position = waypoint.transform.position;
             yield return new WaitForSeconds(movementSpeed);
         }
         DestroyEnemy();
     }

     private void DestroyEnemy()
     {
         var vfx = Instantiate(winnerParticle, transform.position, Quaternion.identity);
         vfx.Play();

         float destroyDelay = vfx.main.duration;

         Destroy(vfx.gameObject, destroyDelay);
         Destroy(gameObject);
     }

}
