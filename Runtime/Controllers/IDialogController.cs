using System.Collections.Generic;
using BeardedPlatypus.FileBrowser.Configurations;

namespace BeardedPlatypus.FileBrowser.Controllers
{
    /// <summary>
    /// <see cref="IDialogController"/> defines the interface of a file
    /// browser controller used to open file dialogs.
    /// </summary>
    internal interface IDialogController
    {
        /// <summary>
        /// Open a file dialog corresponding with the given <paramref name="configuration"/>
        /// and return the paths selected by the user.
        /// </summary>
        /// <param name="configuration">The configuration of the dialog</param>
        /// <returns>
        /// The paths selected by the user. 
        /// </returns>
        /// <remarks>
        /// An empty collection is returned if the action is cancelled.
        /// </remarks>
        IEnumerable<string> OpenFileDialog(FileDialogConfiguration configuration);

        /// <summary>
        /// Open a folder dialog corresponding with the given <paramref name="configuration"/>
        /// and return the paths selected by the user.
        /// </summary>
        /// <param name="configuration">The configuration of the dialog</param>
        /// <returns>
        /// The paths selected by the user. 
        /// </returns>
        /// <remarks>
        /// An empty collection is returned if the action is cancelled.
        /// </remarks>
        IEnumerable<string> OpenFolderDialog(FolderDialogConfiguration configuration);
    }
}