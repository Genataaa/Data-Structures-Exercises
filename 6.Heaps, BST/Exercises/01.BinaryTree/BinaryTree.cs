﻿namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public IAbstractBinaryTree<T> LeftChild { get; set; }

        public IAbstractBinaryTree<T> RightChild { get; set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();

            var result = this.DfsPreOrderStrings(this, sb, indent);

            return result;
        }

        public void ForEachInOrder(Action<T> action)
        {
            var list = new List<IAbstractBinaryTree<T>>();

            var elements = this.DfsInOrder(this, list);

            foreach (var node in elements)
            {
                action.Invoke(node.Value);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            var result = this.DfsInOrder(this, list);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            var result = this.DfsPostOrder(this, list);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            var result = this.DfsPreOrder(this, list);

            return result;
        }

        private string DfsPreOrderStrings(IAbstractBinaryTree<T> tree, StringBuilder sb, int indent)
        {
            sb.Append(new string(' ', indent));
            sb.AppendLine(tree.Value.ToString());

            if (tree.LeftChild != null)
            {
                this.DfsPreOrderStrings(tree.LeftChild, sb, indent + 2);
            }

            if (tree.RightChild != null)
            {
                this.DfsPreOrderStrings(tree.RightChild, sb, indent + 2);
            }

            return sb.ToString().TrimEnd();
        }

        private IEnumerable<IAbstractBinaryTree<T>> DfsPreOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> listForResults)
        {
            listForResults.Add(tree);

            if (tree.LeftChild != null)
            {
                this.DfsPreOrder(tree.LeftChild, listForResults);
            }

            if (tree.RightChild != null)
            {
                this.DfsPreOrder(tree.RightChild, listForResults);
            }

            return listForResults;
        }

        private IEnumerable<IAbstractBinaryTree<T>> DfsInOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> listForResults)
        {

            if (tree.LeftChild != null)
            {
                this.DfsInOrder(tree.LeftChild, listForResults);
            }

            listForResults.Add(tree);

            if (tree.RightChild != null)
            {
                this.DfsInOrder(tree.RightChild, listForResults);
            }

            return listForResults;
        }

        private IEnumerable<IAbstractBinaryTree<T>> DfsPostOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> listForResults)
        {
            if (tree.LeftChild != null)
            {
                this.DfsPostOrder(tree.LeftChild, listForResults);
            }

            if (tree.RightChild != null)
            {
                this.DfsPostOrder(tree.RightChild, listForResults);
            }

            listForResults.Add(tree);

            return listForResults;
        }
    }
}
