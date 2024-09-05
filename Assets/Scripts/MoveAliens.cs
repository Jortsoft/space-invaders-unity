using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MoveAliens : MonoBehaviour
{
    public List<Transform> targetTransforms; // List of transforms to move to
    public float moveSpeed = 5f; // Speed of movement
    public float stayDuration = 2f; // Duration to stay at each target

    private int currentIndex = 0; // Index to track the current target
    private bool isMoving = true; // Flag to control movement state

    void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveToTargets());
    }

    IEnumerator MoveToTargets()
    {
        while (true)
        {
            if (targetTransforms.Count == 0) yield break; // Exit if the list is empty

            Transform target = targetTransforms[currentIndex];

            // Move towards the target position
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                yield return null; // Wait until the next frame
            }

            // Wait for the specified duration at the target position
            yield return new WaitForSeconds(stayDuration);

            // Move to the next target
            currentIndex = (currentIndex + 1) % targetTransforms.Count;
        }
    }
}
