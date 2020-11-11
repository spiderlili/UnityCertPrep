using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Graphs
{
    //Generic class: type of values stored in graph
    public class Graph<T>
    {
        #region Fields
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();

        #endregion

        #region Constructor
        //constructor doesn't do anything
        public Graph()
        {

        }
        #endregion

        //get the number of nodes in the graph
        #region Properties
        public int Count
        {
            get
            {
                return nodes.Count;
            }
        }

        //Gets a read-only list of the nodes in the graph => consumer of the graph can't change the nodes in the graph, they need to use AddNode()/RemoveNode() to manipulate nodes
        public IList<GraphNode<T>> Nodes
        {
            get
            {
                return nodes.AsReadOnly();
            }
        }
        #endregion

        #region Methods
        //clears all the nodes from the graph: disconnect all nodes from each other & remove them
        public void Clear()
        {
            //remove all the neighbours from each node so nodes can be garbage collected
            foreach (GraphNode<T> node in nodes)
            {
                node.RemoveAllNeighbours();
            }

            //remove all the nodes from the graph
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes.RemoveAt(i);
            }
        }

        //add a node with the given value to the graph.
        //if a node with the same value is in the graph: the value is not added & the method returns false
        public bool AddNode(T value)
        {
            //check to see if the graph already has that node: prevent duplicate value
            if (Find(value) != null)
            {
                return false;
            }
            else
            {
                nodes.Add(new GraphNode<T>(value));
                return true;
            }
        }

        //add an edge between the nodes with the given values in the graph, between nodes of particular values
        //if 1 or both of the values don't exist in the graph: the method returns false
        //if an edge already exists between the nodes: the edge is not added, the method returns false
        public bool AddEdge(T value1, T value2)
        {
            //find both nodes to try and connect
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null)
            {
                //can't add an edge to a node that doesn't exist
                return false;
            }
            else if (node1.Neighbours.Contains(node2))
            {
                //edge already exists
                return false;
            }
            else
            {
                //this is an undirected graph: there's no direction to the edges, so add as neighbours to each other => connect both sides
                node1.AddNeighbour(node2); //in a directed graph: only have this line of code & delete the next line => add an edge from node1 to node2
                node2.AddNeighbour(node1);
                return true;
            }
        }

        //remove the node with the given value from the graph
        //if the node is not found in the graph: the method returns false
        public bool RemoveNode(T value)
        {
            GraphNode<T> removeNode = Find(value);
            if (removeNode == null)
            {
                return false;
            }
            else
            {
                //need to remove as neighbour for all nodes: don't want a linkage (an edge to this node that you're taking out of the graph)
                nodes.Remove(removeNode);
                foreach (GraphNode<T> node in nodes)
                {
                    node.RemoveNeighbour(removeNode);
                }
                return true;
            }
        }

        //remove an edge between the nodes with the given values from the graph
        //if 1 or both of the values don't exist in the graph: the method returns false
        public bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);

            if (node1 == null || node2 == null)
            {
                //there can't be an edge between them because 1 or both of them does not exist in the graph
                return false;
            }

            else if (!node1.Neighbours.Contains(node2))
            {
                //edge does not exist
                return false;
            }
            else
            {
                //this is an undirected graph, so remove as neighbours to each other
                node1.RemoveNeighbour(node2); //in a directed graph: only have this line of code & delete the next line => remove edge from node1 to node2
                node2.RemoveNeighbour(node1);
                return true;
            }
        }

        //find the graph node with the given value, returns graph node or null if not found
        public GraphNode<T> Find(T value)
        {
            foreach (GraphNode<T> node in nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }

        //convert the graph to a comma-separated string of nodes
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(nodes[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(",");
                }
            }
            return builder.ToString();
        }

        #endregion
    }
}