using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Behavior_Tree.GuardAI
{
    public class GuardBT : Tree
    {
        // Start is called before the first frame update
        public Transform[] wayPoints;
        public static float speed = 1.5f;
        

        protected override Node SetupTree()
        {
            Node root = new TaskPatrol(transform, wayPoints);
            return root;
        }
        
    }
}
