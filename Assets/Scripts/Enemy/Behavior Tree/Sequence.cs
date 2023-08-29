using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Behavior_Tree
{
    public class Sequence : Node
    {
        public Sequence() : base(){}
        public Sequence(List<Node> children) : base(children){}

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Running:
                        anyChildIsRunning = true;
                        break;
                    case NodeState.Success:
                        continue;
                    case NodeState.Failure:
                        nodeState = NodeState.Failure;
                        return nodeState;
                    default:
                        nodeState = NodeState.Success;
                        return nodeState;
                }
            }

            nodeState = anyChildIsRunning ? NodeState.Running : NodeState.Success;
            return nodeState;
        }
    }
}
