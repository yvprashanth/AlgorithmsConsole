﻿using AlgorithmsConsole.BinaryTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BST test = new BST(10);

            //BST.Lookup(test, 10);
            //test = BST.Insert(test, 2);
            //test = BST.Insert(test, 20);

            BST tree = BST.Build(8);
            //BST.InOrderRecursive(tree);
            //Console.WriteLine("Iterative");
            //BST.InOrderIterative(tree);


            //BST.PreOrderRecursive(tree);
            //Console.WriteLine("Iterative");
            //BST.PreOrderIterative(tree);


            //int depth = BST.MaxDepth(tree);
            //int minValue = BST.minValue(tree);
            //int maxValue = BST.maxValue(tree);

            //BST.InOrderIterative(tree);

            //BST.NoOfLeaves(tree);
            //BST.LevelOrderTraversal(tree);
            //BST.LevelOrderInReverseTraversal(tree);
            bool result = BST.FindInBinaryTreeUsingIteration(tree, 15);
            //BST.InsertIntoNonBST(tree, 20);
            //BST.LevelOrderTraversalInReverse(tree);

            BST randomTree = BST.GenerateRandomTree(10);
            var t1 = BST.Height(randomTree);
            var t2 = BST.HeightNonRecursion(randomTree);


            int[] array = new int[]{1, 2, 3, 4, 5, 6, 7, 8};
            BST resultBST = BST.CreateBSTFromSortedArray(array, 0, array.Count());

            //BST.ZigZagTraversal(tree);
        }
    }
}
