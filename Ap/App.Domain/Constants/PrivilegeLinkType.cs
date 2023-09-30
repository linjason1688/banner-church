#region

#endregion

namespace App.Domain.Constants
{
    public enum PrivilegeNodeType
    {
        /// <summary>
        /// will never save to db, in program use
        /// </summary>
        Root,

        /// <summary>
        /// Just a menu node
        /// </summary>

        // [Display(Name = "節點")]
        Node,

        /// <summary>
        /// </summary>

        // [Display(Name = "連結節點")]
        Link,

        /// <summary>
        /// </summary>

        // [Display(Name = "功能")]
        Functionality
    }
}
