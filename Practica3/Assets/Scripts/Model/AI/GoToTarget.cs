﻿namespace Model.IA
{
    using UnityEngine;
    using BehaviorDesigner.Runtime.Tasks;

    [TaskCategory("FootBall")]
    public class GoToTarget : Action
    {
        // The speed of the object
        public float speed = 0;
        // The transform that the object is moving towards
        public Transform target;

        public float minDistance = 0.1f;

        public override TaskStatus OnUpdate()
        {
            // Return a task status of success once we've reached the target
            if (Vector3.SqrMagnitude(transform.position - target.position) < minDistance)
            {
                return TaskStatus.Success;
            }
            // We haven't reached the target yet so keep moving towards it
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            return TaskStatus.Running;
        }
    }
}
