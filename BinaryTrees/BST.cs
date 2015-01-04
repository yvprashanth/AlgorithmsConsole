using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsConsole.BinaryTrees
{
    public class BST
    {
        int _data;
        private BST left;
        private BST right;
        // Initiating Constructor
        public BST(int data)
        {
            _data = data;
            left = null;
            right = null;
        }

        public static void PreOrderRecursive(BST tree)
        {
            if (tree != null)
            {
                Console.WriteLine(tree._data);
                if(tree.left != null)
                    PreOrderRecursive(tree.left);
                if (tree.right != null)
                    PreOrderRecursive(tree.right);
            }
        }

        public static void PreOrderIterative(BST tree)
        {
            Stack<BST> stack = new Stack<BST>();
            if (tree != null)
                stack.Push(tree);
            while (stack.Count() > 0)
            {
                BST poppedItem = stack.Pop();
                Console.WriteLine(poppedItem._data);
                if(poppedItem.right != null)
                    stack.Push(poppedItem.right);
                if (poppedItem.left != null)
                    stack.Push(poppedItem.left);
            }
        }

        // Post Order is Left, Right, Root
        public static void PostOrderIterative(BST tree)
        {
            Stack<BST> stack = new Stack<BST>();
        }

        public static void LevelOrderTraversal(BST tree)
        {
            Queue<BST> queue = new Queue<BST>();
            if (tree == null)
                return;
            else
            {
                queue.Enqueue(tree);
                // While queue is not empty
                while (queue.Count() > 0)
                {
                    var temp = queue.Dequeue();
                    Console.Write(temp._data);
                    Console.Write(",");
                    if (temp.left != null)
                        queue.Enqueue(temp.left);
                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }
            }
        }

        // Given a Binary Tree find the maximum element in a non recursive fashion
        public static int FindMaxNonRecursive(BST tree)
        {
            // Loop through the tree in level order fashion and compare with the root
            Queue<BST> queue = new Queue<BST>();
            return 0;
        }

        public static void InOrderRecursive(BST tree)
        {
            if (tree != null)
            {
                if (tree.left != null)
                    InOrderRecursive(tree.left);
                Console.WriteLine(tree._data);
                if (tree.right != null)
                    InOrderRecursive(tree.right);
            }
        }

        public static void InOrderIterative(BST tree)
        {
            BST current;
            if (tree == null)
                return;
            Stack<BST> stack = new Stack<BST>();
            current = tree;

            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            while (stack.Count() != 0)
            {
                BST temp = stack.Pop();
                Console.WriteLine(temp._data);

                // Find the next node
                if (temp.right != null)
                {
                    temp = temp.right;
                    // The next node to be visited is the leftmost
                    while (temp != null)
                    {
                        stack.Push(temp);
                        temp = temp.left;
                    }
                }
            }
        }

        // Gets the maximum value of the Binary Search Tree
        public static int maxValue(BST tree)
        {
            BST temp = tree;
            while (temp.right != null)
                temp = temp.right;
            return temp._data;
        }

        // Gets the minimum value of the Binary Search Tree
        public static int minValue(BST tree)
        {
            BST temp = tree;
            while (temp.left != null)
                temp = temp.left;
            return temp._data;
        }

        //Given a binary tree, compute its "maxDepth" -- 
        //the number of nodes along the longest path from the root node down to the farthest leaf node. 
        //The maxDepth of the empty tree is 0, the maxDepth of the tree on the first page is 3.
        public static int MaxDepth(BST tree)
        {
            if (tree == null)
                return 0;
            else
            {
                int leftCount = MaxDepth(tree.left);
                int rightCount = MaxDepth(tree.right);
                if (leftCount > rightCount)
                    return leftCount + 1;
                else
                    return rightCount + 1;
            }
        }

        public static int Size(BST tree)
        {
            if (tree == null)
                return 0;
            return Size(tree.left) + Size(tree.right) + 1;
        }

        // Upto size n, build a balanced binary search tree
        public static BST Build(int n)
        {
            if (n <= 0)
                return new BST(Int32.MinValue);
            List<int> array = new List<int>();
            for(int i = 0; i < n; i++)
            {
                array.Add(i);
            }
            BST result = sortedArrayToBST(array.ToArray(), 0, n - 1);
            return result;
        }

        private static BST sortedArrayToBST(int[] arr, int start, int end) {
              if (start > end) return null;

              // same as (start+end)/2, avoids overflow.
              int mid = start + (end - start) / 2;
              BST node = new BST(arr[mid]);
              node.left = sortedArrayToBST(arr, start, mid-1);
              node.right = sortedArrayToBST(arr, mid+1, end);
              return node;
        }

        public static BST Insert(BST tree, int value)
        {
            if (tree == null)
                return new BST(value);
            else
            {
                if (value <= tree._data)
                    tree.left = Insert(tree.left, value);
                else
                    tree.right = Insert(tree.right, value);
                return tree;
            }
        }

        public static int Lookup(BST tree, int target)
        {
            if (tree == null)
                return Int32.MinValue;
            else
            {
                if (target == tree._data)
                    return 1;
                if (target < tree._data)
                    return Lookup(tree.right, target);
                if (target > tree._data)
                    return Lookup(tree.left, target);
            }
            return Int32.MinValue;  
        }
    }
}
