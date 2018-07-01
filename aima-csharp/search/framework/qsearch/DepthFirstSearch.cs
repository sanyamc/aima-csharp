using System.Collections.Generic;
using aima.core.agent;
using aima.core.search.framework;
using aima.core.search.framework.problem;
using aima.core.util;

namespace aima.core.search.framework.qsearch
{
    public class DepthFirstSearch : QueueSearch
    {

        private HashSet<object> explored = new HashSet<object>();
        private HashSet<object> frontierStates = new HashSet<object>();

        public DepthFirstSearch() : this(new NodeExpander())
        {

        }

        public DepthFirstSearch(NodeExpander nodeExpander) : base(nodeExpander)
        {

        }

        /**
         * Clears the set of explored states and calls the search implementation of
         * <code>QueSearch</code>
         */
        public override List<Action> search(Problem problem, List<Node> frontier)
        {
            // Initialize the explored set to be empty
            explored.Clear();
            frontierStates.Clear();
            return base.search(problem, frontier);
        }

        /**
         * Inserts the node at the front of the frontier if the corresponding state
         * is not already a frontier state and was not yet explored.
         */
        protected override void addToFrontier(Node node)
        {
            if (!explored.Contains(node.State) && !frontierStates.Contains(node.State))
            {
                frontier.Insert(0, node);
                frontierStates.Add(node.State);
                updateMetrics(frontier.Count);
            }
        }

        /**
         * Removes the node at the front of the frontier, adds the corresponding
         * state to the explored set, and returns the node.
         * 
         * @return the node at the head of the frontier.
         */
        protected override Node removeFromFrontier()
        {
            Node result = frontier.PopAt(0);
            explored.Add(result.State);
            frontierStates.Remove(result.State);
            updateMetrics(frontier.Count);
            return result;
        }

        /**
         * Checks whether there are still some nodes left.
         */
        protected override bool isFrontierEmpty()
        {
            if (frontier.Count == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
