using System.Collections.Generic;
using FileBrowser.Configurations;
using FileBrowser.Controllers;

namespace FileBrowser
{
    /// <summary>
    /// <see cref="FileBrowserService"/> exposes the different file browser
    /// dialogs and serves as the entrypoint for the <see cref="FileBrowser"/>
    /// library.
    /// </summary>
    public static class FileBrowserService
    {
#if UNITY_STANDALONE_WIN
        private static readonly IDialogController DialogController = new DialogControllerWindows();
#endif

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
        public static IEnumerable<string> OpenFileDialog(FileDialogConfiguration configuration) =>
            DialogController.OpenFileDialog(configuration);

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
        public static IEnumerable<string> OpenFolderDialog(FolderDialogConfiguration configuration) =>
            DialogController.OpenFolderDialog(configuration);
    }
}
