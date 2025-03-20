using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SmoothFollow : MonoBehaviour
{
    public List<Transform> targets; // List of target Transforms
    public float movementTime = 1;
    public float rotationSpeed = 0.1f;
    public Button ButtonStartNew; // UI Button to start movement

    private Vector3 refPos;
    private Vector3 refRot;
    private bool shouldMove = false;
    private int currentTargetIndex = 0; // Track the current target

    private void Start()
    {
        MoveToNextTarget();
    }

    void Update()
    {
        if (!shouldMove || targets.Count == 0)
            return;

        Transform target = targets[currentTargetIndex];
        if (!target) return;

        // Interpolate Position
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref refPos, movementTime);
        // Interpolate Rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);

        // Stop moving when close enough to target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            shouldMove = false; // Stop moving once the target is reached
        }
    }

    public void MoveToLastTarget()
    {
        if (targets.Count == 0) return;

        int next = (currentTargetIndex - 1);
        if(next < 0)
        {
            next = 3;
        }
        // Move to the next target in the list
        currentTargetIndex = next;
        shouldMove = true;
    }

    public void MoveToNextTarget()
    {
        if (targets.Count == 0) return;

        // Move to the next target in the list
        currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        shouldMove = true;
    }
}
