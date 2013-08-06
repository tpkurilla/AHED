using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>Comment</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class CommentModel : Model<Comment>, IDeepClone<CommentModel>
    {
        #region Properties

        public string Text
        {
            get { return Value.Value; }
            set
            {
                if (value != Value.Value)
                {
                    if (ValidateComment(value))
                        Value.Value = value;
                }
            }
        }

        #endregion

        #region Creation

        public CommentModel()
        {
        }

        public CommentModel(Comment comment)
            : base(comment)
        {
        }

        public CommentModel(CommentModel commentModel)
            : base(commentModel)
        {
        }

        public void SetProperties()
        {
            // Nothing to see here...move along
        }

        #endregion Creation

        #region Validation

        #region Property Names

        public const string TextName = "Text";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Comment</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Comment</c>.</returns>
        private bool ValidateComment(string value)
        {
            if (value == null)
            {
                AddError(TextName, Properties.Resources.Comment_Invalid_Comment, false);
                return false;
            }

            RemoveError(TextName, Properties.Resources.Comment_Invalid_Comment);
            return true;
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        CommentModel IDeepClone<CommentModel>.DeepClone()
        {
            return new CommentModel(this);
        }

        #endregion IDeepClone Interface
    }
}
