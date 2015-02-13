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

        // Give an algorithm for finding maximum element in a tree
        public int FindMax(BST tree)
        {
            int maxValue = Int32.MinValue;
            if (tree == null)
                return Int32.MinValue;
            int rootValue = tree._data;
            int maxLeftValue = FindMax(tree.left);
            int maxRightValue = FindMax(tree.right);
            // Find the largest of the three values
            if (maxLeftValue > maxRightValue)
                maxValue = maxLeftValue;
            else maxValue = maxRightValue;
            if (rootValue > maxValue)
                maxValue = rootValue;
            return maxValue;
        }

        // Given an sorted array create a binary search tree with minimal height
        public static BST CreateBSTFromSortedArray(int[] array, int lower, int higher)
        {
            if (lower > higher)
                return null;
            // start from the middle
            int middle = (lower + higher)/2;
            BST result = new BST(middle);
            result.left = CreateBSTFromSortedArray(array, lower, middle - 1);
            result.right = CreateBSTFromSortedArray(array, middle + 1, higher);
            return result;
        }

        // Give an algorithm to find max element in binary tree without recursion - do iterative traversal and check along the way if the currently visited element is the max there is
        public int FindMaxIterativeWay(BST tree)
        {
            Queue<BST> queue = new Queue<BST>();
            int maxValue = Int32.MinValue;
            if (tree == null)
                return Int32.MinValue;
            queue.Enqueue(tree);
            while (queue.Count > 0)
            {
                BST current = queue.Dequeue();
                if (current._data > maxValue)
                    maxValue = current._data;
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
            return maxValue;
        }


        public bool FindInBinaryTreeUsingRecursion(BST tree, int data)
        {
            if (tree == null)
                return false;
            else
            {
                if (data == tree._data)
                    return true;
                else if (data < tree._data)
                    return FindInBinaryTreeUsingRecursion(tree.left, data);
                else if (data > tree._data)
                    return FindInBinaryTreeUsingRecursion(tree.right, data);
            }
            return false;
        }

        // Level order search
        public static bool FindInBinaryTreeUsingIteration(BST tree, int data)
        {
            Queue<BST> queue = new Queue<BST>();
            if (tree == null)
                return false;
            else
            {
                queue.Enqueue(tree);
                while (queue.Count > 0)
                {
                    BST current = queue.Dequeue();
                    if (current != null)
                    {
                        if (data == current._data)
                            return true;
                        if (data < current._data)
                            queue.Enqueue(current.left);
                        if (data > current._data)
                            queue.Enqueue(current.right);
                    }
                }
            }
            return false;
        }


        // Give an algorithm for inserting an element into a binary tree
        // We can insert the node anywhere we would want to as this is not a BST. 
        // Wherever we find that left or right child is null we can insert
        public static void InsertIntoNonBST(BST tree, int data)
        {
            if (tree == null)
                return;
            Queue<BST> queue = new Queue<BST>();
            queue.Enqueue(tree);
            while (queue.Count > 0)
            {
                BST current = queue.Dequeue();
                if (current != null)
                {
                    if (current.left == null)
                    {
                        current.left = new BST(data);
                        // Delete queue
                        return;
                    }
                    else if (current.right == null)
                    {
                        current.right = new BST(data);
                        // Delete queue
                        return;
                    }
                    else if(current.left != null)
                        queue.Enqueue(current.left);
                    else if (current.right != null)
                        queue.Enqueue(current.right);
                }
            }
        }


        // Give an algorithm for finding the size of binary tree in recursive fashion
        public static int SizeOfBST(BST tree)
        {
            if (tree == null)
                return 0;
            return 1 + SizeOfBST(tree.left) + SizeOfBST(tree.right);
        }

        public static int SizeOfBSTNonRecursive(BST tree)
        {
            if (tree == null)
                return 0;
            Queue<BST> queue = new Queue<BST>();
            int count = 0;
            queue.Enqueue(tree);
            while (queue.Count > 0)
            {
                BST current = queue.Dequeue();
                count += 1;
                if (current != null)
                {
                    if (current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                }
            }
            return count;
        }

        // Give an algorithm for printing the level order data in reverse order. 
        // For ex the output for the below tree should be 4567231
        public static void LevelOrderTraversalInReverse(BST tree)
        {
            if (tree == null)
                return;
            Stack<BST> stack = new Stack<BST>();
            Queue<BST> queue = new Queue<BST>();
            
            queue.Enqueue(tree);
            while (queue.Count() > 0)
            {
                BST current = queue.Dequeue();
                if (current != null)
                {
                    if (current.right != null)
                        queue.Enqueue(current.right);
                    if (current.left != null)
                        queue.Enqueue(current.left);
                    stack.Push(current);
                }
            }

            while(stack.Count() > 0)
                Console.WriteLine(stack.Pop()._data);
        }

        // Give an algorithm for deleting a tree
        public static void DeleteTree(BST tree)
        {
            // Deleting via Post Order Traversal 
            if (tree == null)
                return;
            if(tree.left != null)
                DeleteTree(tree.left);
            if (tree.right != null)
                DeleteTree(tree.right);
            // C++ Free
            // free(tree);
        }

        // Give an algorithm for finding the height of a tree
        public static int Height(BST tree)
        {
            int max = 0;
            if (tree == null)
                return 0;
            else
            {
                int left = Height(tree.left);
                int right = Height(tree.right);
                if (left > right)
                    max = left;
                else
                    max = right;
                return max + 1;
            }
        }

        public static BST GenerateRandomTree(int numberOfNodes)
        {
            Random rand = new Random();
            BST tree = new BST(rand.Next());
            for (int i = 0; i < numberOfNodes; i++)
                InsertIntoBST(tree, rand.Next());
            return tree;
        }

        // Give an algorithm for finding the height of a tree without recursion
        public static int HeightNonRecursion(BST tree)
        {
            int max = 0;
            Queue<BST> queue = new Queue<BST>();
            int height = 0;
            if (tree != null)
            {
                queue.Enqueue(tree);
                //height++;
            }
            while (queue.Count() > 0)
            {
                BST current = queue.Dequeue();
                if (current != null)
                {
                    if (current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                    if(current.left != null || current.right != null)
                        height++;
                }

            }
            return height;
        }

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

        public static bool IsMirror(BST tree1, BST tree2)
        {
            if (tree1 == null && tree2 == null)
                return true;
            if(tree1 == null || tree2 == null)
                return false;
            if(tree1._data != tree2._data)
                return false;
            return IsMirror(tree1.left, tree1.right) && IsMirror(tree1.right, tree2.left);
        }

        public static BST MirrorOfTree(BST tree)
        {
            BST mirror = new BST(tree._data);
            BST current = tree;
            if (current != null)
            {
                if(current.left != null)
                    mirror.left = current.left;
                if (current.right != null)
                    mirror.right = current.right;
            }

            return mirror;
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

        //public static void ZigZagTraversal(BST tree)
        //{
        //    Queue<BST> queue = new Queue<BST>();
        //    Stack<BST> stack = new Stack<BST>();
        //    if (tree == null)
        //        return;
        //    int count = 0;
        //    queue.Enqueue(tree);
        //    count++;
        //    while (queue.Count() > 0)
        //    {                
        //        // Even means insert left to right
        //        if (count % 2 == 0)
        //        {
        //            // Even row means stack

        //            BST current = queue.Dequeue();
        //            Console.WriteLine(current._data);

        //            if (current.left != null)
        //                queue.Enqueue(current.left);
        //            if (current.right != null)
        //                queue.Enqueue(current.right);
        //            count++;
        //        }
        //        else
        //        {
        //            // Odd row means add to queue
        //            if (current.right != null)
        //                queue.Enqueue(current.right);
        //            if (current.left != null)
        //                queue.Enqueue(current.left);
        //            count++;
        //        }
        //    }
        //}

        // Push everything to a queue dequeue the queue and then push it to a stack and then print the stack
        public static void LevelOrderInReverseTraversal(BST tree)
        {
            Queue<BST> queue = new Queue<BST>();
            Stack<BST> stack = new Stack<BST>();
            if (tree == null)
                return;
            queue.Enqueue(tree);
            while (queue.Count() > 0)
            {
                var temp = queue.Dequeue();
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                stack.Push(temp);
            }

            while (stack.Count() > 0)
            {
                var another = stack.Pop();
                Console.WriteLine(another._data);
            }
        }

        // Level Order Traversal
        public static Queue<BST> LevelOrderTraversal(BST tree)
        {
            Queue<BST> queue = new Queue<BST>();

            // Logic being first push the current node down the queue, then push its left child and then right child
            if (tree == null)
                return queue;
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
            return queue;
        }

        // Given a Binary Tree find the maximum element in a non recursive fashion
        public static int FindMaxNonRecursive(BST tree)
        {
            // Loop through the tree in level order fashion and compare with the root
            Queue<BST> queue = new Queue<BST>();
            return 0;
        }

        // Given a Binary Tree find a particular element
        public static bool FindElement(BST tree)
        {
            return false;
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

        public static BST InsertIntoBST(BST tree, int value)
        {
            if (tree == null)
                return new BST(value);
            else
            {
                if (value <= tree._data)
                    tree.left = InsertIntoBST(tree.left, value);
                else
                    tree.right = InsertIntoBST(tree.right, value);
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
