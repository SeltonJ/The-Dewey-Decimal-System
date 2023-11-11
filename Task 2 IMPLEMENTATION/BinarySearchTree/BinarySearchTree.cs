using System;
using System.Collections.Generic;

namespace Task_2_IMPLEMENTATION.BinarySearchTree
{

    /// <summary>
    /// Represents a generic binary search tree.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the binary search tree. Must implement IComparable<T>.</typeparam>
    [Serializable]
    public class BinarySearchTree<T> where T : IComparable<T>
    {

        /// <summary>
        /// Represents a node within the binary search tree.
        /// </summary>
        private class Node
        {
            public T Data;
            public Node Left;
            public Node Right;


            /// <summary>
            /// Initializes a new instance of the Node class with the specified data.
            /// </summary>
            /// <param name="data">The data to store in the node.</param>
            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class.
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
        }

        /// <summary>
        /// Inserts a new value into the binary search tree.
        /// </summary>
        /// <param name="data">The data to insert into the tree.</param>
        public void Insert(T data)
        {
            root = Insert(root, data);
        }

        /// <summary>
        /// Recursively inserts a new value into the binary search tree starting from the given node.
        /// </summary>
        /// <param name="node">The root node of the tree or subtree.</param>
        /// <param name="data">The data to insert into the tree.</param>
        /// <returns>The new root of the tree or subtree.</returns>
        private Node Insert(Node node, T data)
        {
            if (node == null)
            {
                node = new Node(data);
            }
            else if (data.CompareTo(node.Data) < 0)
            {
                node.Left = Insert(node.Left, data);
            }
            else if (data.CompareTo(node.Data) > 0)
            {
                node.Right = Insert(node.Right, data);
            }
            return node;
        }

        /// <summary>
        /// Performs an in-order traversal of the binary search tree and returns a list of the elements.
        /// </summary>
        /// <returns>A List<T> of elements in ascending order.</returns>
        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderTraversal(root, result);
            return result;
        }

        /// <summary>
        /// Recursively performs an in-order traversal of the binary search tree starting from the given node and adds the elements to the result list.
        /// </summary>
        /// <param name="node">The current node to process.</param>
        /// <param name="result">The list to which the elements are added.</param>
        private void InOrderTraversal(Node node, List<T> result)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Data);
                InOrderTraversal(node.Right, result);
            }
        }
    }
}
