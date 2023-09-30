using System.Collections.Generic;

namespace App.Application.Common.Dtos
{
    public interface ITreeNode<T, TKey>
    {
        /// <summary>
        /// Node Identification
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// Parent Node Identification
        /// </summary>
        public TKey ParentKey { get; set; }

        /// <summary>
        /// Children Nodes
        /// </summary>
        public IList<T> Nodes { get; set; }

        /// <summary>
        /// Sort Order (ASC)
        /// </summary>
        public int Sort { get; set; }
    }
}
