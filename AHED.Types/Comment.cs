using System;

namespace AHED.Types
{
    /// <summary>
    /// Wraps a string-valued property.  Unlike many of the other
    /// AHED types, a comment cannot be null-valued.  If it is
    /// present, then it must have a value.
    /// </summary>
    [Serializable]
    public class Comment : IDeepClone<Comment>, IPropertyInitializer
    {
        public string Value { get; set; }

        public Comment()
        {
            Value = String.Empty;
        }

        public Comment(string comment)
        {
            Value = comment;
        }

        /// <summary>
        /// Since strings are immutable, no need to actually make a copy
        /// for a deep clone.
        /// </summary>
        /// <param name="comment">Comment to copy.</param>
        public Comment(Comment comment)
        {
            Value = comment.Value;
        }

        public bool InitializeProperties()
        {
            Value = String.Empty;

            return true;
        }

        /// <summary>
        /// Since strings are immutable, no need to actually make a copy
        /// for a deep clone.
        /// </summary>
        /// <returns>A new Comment copy of this Comment.</returns>
        public Comment DeepClone()
        {
            return new Comment(this);
        }
    }
}
