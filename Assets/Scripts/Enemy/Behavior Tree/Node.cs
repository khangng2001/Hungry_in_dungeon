using System.Collections.Generic;

namespace Enemy.Behavior_Tree
{

    public enum NodeState
    {
        Running,
        Success,
        Failure
        
    }
    
    public class Node
    {
        protected NodeState nodeState;

        public Node parent;
        protected List<Node> children = new List<Node>();


        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                Attach(child);
            }
        }

        private void Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate()
        {
            return NodeState.Failure;
        }

        
        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object val = null;
            if (dataContext.TryGetValue(key, out val))
                return val;

            Node node = parent;
            if (node != null)
            {
                val = node.GetData(key);
            }

            return val;
        }

        public bool ClearData(string key)
        {
            bool cleared = false;
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            if (node != null)
            {
                cleared = node.ClearData(key);
            }

            return cleared;
        }
    }
}
