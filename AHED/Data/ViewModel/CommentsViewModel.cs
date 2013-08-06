﻿using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    /// <summary>
    /// View Model of choice when multiple comments may be entered.
    /// </summary>
    public class CommentsViewModel : SelectableViewModel<CommentModel,Comment>
    {
        #region Creation

        public CommentsViewModel(){}

        public CommentsViewModel(CommentModel model, ModelCache<CommentModel,Comment> cache)
            : base(model, cache)
        {
            base.DisplayName = Properties.Resources.CommentViewModel_Display_Name;
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            Comment = Model.Text;
        }

        #endregion Creation

        #region Properties

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (value == _comment)
                    return;

                Model.Text = value;
                _comment = Model.Text;
                base.RaisePropertyChanged(CommentName);
            }
        }

        #endregion Properties

        #region Property Names

        public const string CommentName = "Comment";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members

    }
}
