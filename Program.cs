using AlgorithmsConsole.BinaryTrees;
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
            //BST.ZigZagTraversal(tree);
        }
    }
}
