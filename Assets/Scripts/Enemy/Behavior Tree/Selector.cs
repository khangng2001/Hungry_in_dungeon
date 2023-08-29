using System.Collections.Generic;

namespace Enemy.Behavior_Tree
{
    public class Selector : Node
    {
        public Selector() : base(){}
        public Selector(List<Node> children) : base(children){}

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Running:
                        return nodeState;
                        break;
                    case NodeState.Success:
                        return NodeState.Success;
                        break;
                    case NodeState.Failure:
                        continue;
                    default:
                        continue;
                    
                }
            }

            nodeState = NodeState.Failure;
            return nodeState;
        }
    }
}
