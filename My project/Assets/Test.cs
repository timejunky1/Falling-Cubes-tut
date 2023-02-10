using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform[] path;
    IEnumerable currentMoveCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(Transform waypoint in path)
        {
            yield return StartCoroutine(Move(waypoint.position, 8));
        }
    }

    IEnumerator Move(Vector3 destination, float speed)
    {
        while(transform.position!= destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }
}
