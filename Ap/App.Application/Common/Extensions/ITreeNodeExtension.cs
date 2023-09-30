using System;
using System.Collections.Generic;
using System.Linq;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Utility.Extensions;
using Yozian.Extension;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class ITreeNodeExtension
    {
        /// <summary>
        /// 
        /// </summary>
        public static T ConvertToNodeTree<T, TKey>(this IEnumerable<T> @this, T rootNode)
            where T : class, ITreeNode<T, TKey>, new()
        {
            if (null == rootNode.Key)
            {
                throw new ArgumentException("RootNode Key Should NOT be null");
            }

            var source = @this.Select(x => x as ITreeNode<T, TKey>)
               .Select(
                    x =>
                    {
                        x.ParentKey ??= rootNode.Key;

                        return x;
                    }
                )
               .ToList();

            return buildTree(rootNode, source) as T;
        }

        /// <summary>
        /// 將 Tree 攤平成 List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static List<T> FlatToList<T, TKey>(
            this T @this
        )
            where T : ITreeNode<T, TKey>
        {
            return traverseAllChildren<T, TKey>(@this);
        }


        /// <summary>
        /// 找出符合的第一個節點
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static T FindNode<T, TKey>(
            this T @this,
            Func<T, bool> predictor
        )
            where T : ITreeNode<T, TKey>
        {
            return traverseAllChildren<T, TKey>(@this).Where(predictor).FirstOrDefault();
        }


        /// <summary>
        /// 找出此節點下所有 子節點
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static List<T> FindAllChildrenNodes<T, TKey>(
            this T @this,
            Func<T, bool> predictor = null
        )
            where T : ITreeNode<T, TKey>
        {
            return traverseAllChildren<T, TKey>(@this);
        }


        private static ITreeNode<T, TKey> buildTree<T, TKey>(ITreeNode<T, TKey> root, IList<ITreeNode<T, TKey>> source)
            where T : class
        {
            if (source.Count == 0)
            {
                return root;
            }

            root.Nodes ??= new List<T>();

            var mappings = new Dictionary<TKey, ITreeNode<T, TKey>>();

            // 檢查是否有重複 key
            try
            {
                source
                   .Select(
                        it =>
                        {
                            it.Nodes ??= new List<T>();

                            return it;
                        }
                    )
                   .ForEach(it => mappings.Add(it.Key, it));
            }
            catch (ArgumentException e)
            {
                throw new MyBusinessException(ResponseCodes.GeneralBusinessError, $"可能有重複 key 無法建立樹狀結構: {e.Message}");
            }

            mappings.Values.ForEach(
                item =>
                {
                    // parentKey should not be null
                    if (item.ParentKey == null)
                    {
                        throw new NullReferenceException("node [ParentKey] should NOT be Null");
                    }

                    if (item.ParentKey.Equals(root.Key))
                    {
                        root.Nodes.Add(item as T);

                        root.Nodes = root.Nodes.OrderBy(n => ((ITreeNode<T, TKey>) n).Sort).ToList();

                        return;
                    }

                    if (!mappings.TryGetValue(item.ParentKey, out var parent))
                    {
                        return;
                    }

                    parent.Nodes.Add(item as T);

                    parent.Nodes = parent.Nodes.OrderBy(n => ((ITreeNode<T, TKey>) n).Sort).ToList();
                }
            );

            return root;
        }


        private static List<T> traverseAllChildren<T, TKey>(T node)
            where T : ITreeNode<T, TKey>
        {
            var children = new List<T>();

            if (node.Nodes.IsNullOrEmpty())
            {
                return children;
            }

            children.AddRange(node.Nodes);

            var subNodes = node.Nodes.SelectMany(traverseAllChildren<T, TKey>);

            children.AddRange(subNodes);

            return children;
        }
    }
}
