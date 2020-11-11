using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Graphs
{
    //generic class for storing any data type: represent vertex in graph
    public class GraphNode<T>
    {
        #region Fields

        T value; //graph node value
        List<GraphNode<T>> neighbours; //other graph node that are neighbours of this graph node: this graph node is connected to neighbours with edges

        #endregion

        #region Constructors
        //constructor: set the value of the node & create an empty list of neighbours
        public GraphNode(T value)
        {
            this.value = value;
            neighbours = new List<GraphNode<T>>(); //a new graph node doesn't have any edges connecting it to anything
        }

        #endregion

        #region Properties

        //get the value stored in the node
        public T Value
        {
            get
            {
                return value;
            }
        }

        //Get a read-only list of the neighbours of the node: prevent modification of list content. Must use the methods for data type to change rather than list manipulation
        public IList<GraphNode<T>> Neighbours //interface to a list: does NOT contain the methods to modify the contents of the list
        {
            get
            {
                return neighbours.AsReadOnly();
            }
        }
        #endregion

        #region Methods

        //adds the given node as a neighbour for this node
        //before adding a neighbour: check to make sure you don't already have an edge to that neighbour to avoid adding duplicate nodes
        public bool AddNeighbour(GraphNode<T> neighbour)
        {
            if (neighbours.Contains(neighbour))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //remove the given node as a neighbour for this node: only remove neighbours in this list. 
        public bool RemoveNeighbour(GraphNode<T> neighbour)
        {
            return neighbours.Remove(neighbour); //will return false if the neighbour is NOT contained in the list
        }

        //removes all the neighbours for the node: helpful for the graph class to clear the graph & remove all the references between the nodes in the graph for GC
        public bool RemoveAllNeighbours()
        {
            for (int i = neighbours.Count - 1; i >= 0; i--)
            {
                neighbours.RemoveAt(i);
            }
            return true;
        }

        //convert the node to a string, returns the string providing the value and the list of neighbours for the node
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[Node Value: " + value + "Neighbours: ");
            for (int i = 0; i < neighbours.Count; i++)
            {
                nodeString.Append(neighbours[i].Value + " ");
            }
            nodeString.Append("]");
            return nodeString.ToString();
        }

        #endregion
    }
}