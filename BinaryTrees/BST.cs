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


        // Give an algorithm for finding the number of leaves in a binary tree without using recursion
        public static int NoOfLeaves(BST tree)
        {
            if (tree == null)
                return 0;
            int count = 0;

            // In this case there are 0 leaves
            if (tree.left == null && tree.right == null)
                return 0;
            Queue<BST> queue = new Queue<BST>();
            queue.Enqueue(tree);

            while (queue.Count() > 0)
            {
                BST current = queue.Dequeue();
                if (current.left == null && current.right == null)
                    count += 1;
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
            queue.Clear();
            return count;
        }

        // Post Order is Left, Right, Root
        public static void PostOrderIterative(BST tree)
        {
            Stack<BST> stack = new Stack<BST>();
        }

        // Level Order Traversal
        public static void LevelOrderTraversal(BST tree)
        {
            Queue<BST> queue = new Queue<BST>();

            // Logic being first push the current node down the queue, then push its left child and then right child
            if (tree == null)
                return;
            queue.Enqueue(tree);
            while (queue.Count() > 0)
            {
                BST current = queue.Dequeue();
                Console.WriteLine(current._data);
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
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
            BST current = tree;
            if (tree == null)
                return;
            Stack<BST> stack = new Stack<BST>();
            
            // Push all the way to the left
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            // Now find the next node
            while (stack.Count() > 0)
            {
                BST temp = stack.Pop();
                Console.WriteLine(temp._data);

                if (temp.right != null)
                {
                    temp = temp.right;

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
