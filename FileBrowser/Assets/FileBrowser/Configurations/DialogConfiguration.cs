using System;

namespace FileBrowser.Configurations
{
    /// <summary>
    /// <see cref="DialogConfiguration"/> defines the properties of a dialog
    /// </summary>
    public abstract class DialogConfiguration
    {
        /// <summary>
        /// <see cref="Title"/> defines the title of the dialog.
        /// </summary>
        public abstract string Title { get; set; }

        /// <summary>
        /// <see cref="InitialDirectory"/> defines the directory in which the
        /// dialog is opened.
        /// </summary>
        /// <remarks>
        /// This value will default to the home directory of the user.
        /// </remarks>
        public string InitialDirectory { get; set; } = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// <see cref="Multiselect"/> defines whether the user is allowed to
        /// select multiple objects.
        /// </summary>
        /// <remarks>
        /// This value will default to <c>false</c>.
        /// </remarks>
        /// <remarks>
        /// This value is ignored when the dialog is a save dialog.
        /// </remarks>
        public bool Multiselect { get; set; } = false;
    }
}