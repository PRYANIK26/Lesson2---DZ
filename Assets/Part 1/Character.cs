using System.Collections.Generic;
using UnityEngine;

namespace Part1
{
    public class Character : MonoBehaviour
    {
        public List<Transform> WalkPoints;
        public float Speed;
        public float WorkTime;
        private CharacterStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new CharacterStateMachine(this);
        }

        void Update()
        {
            _stateMachine.Update();
        }
    }
}
