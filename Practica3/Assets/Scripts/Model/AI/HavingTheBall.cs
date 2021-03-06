﻿namespace Model.IA
{
    using UnityEngine;
    using BehaviorDesigner.Runtime.Tasks;

    // indica si el jugador tiene la pelota en este momento
    [TaskCategory("FootBall")]
    public class HavingTheBall : Conditional
    {
        private IHaveTheBall ihtb;

        public override void OnStart()
        {
            ihtb = gameObject.GetComponent<IHaveTheBall>();
        }

        public override TaskStatus OnUpdate()
        {
            if (!GameManager.instance.getPause())
            {
                if (ihtb.getBool()) return TaskStatus.Success;
                else return TaskStatus.Failure;
            }
            return TaskStatus.Running;
        }
    }
}
