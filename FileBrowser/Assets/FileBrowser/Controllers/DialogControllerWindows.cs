#if UNITY_STANDALONE_WIN

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FileBrowser.Configurations;
using Ookii.Dialogs.WinForms;

namespace FileBrowser.Controllers
{
    /// <summary>
    /// <see cref="DialogControllerWindows"/> implements the interface
    /// for opening file and folder dialogs on windows builds.
    /// </summary>
    internal sealed class DialogControllerWindows : IDialogController
    {
        public IEnumerable<string> OpenFileDialog(FileDialogConfiguration configuration) =>
            configuration.FileDialogType switch
            {
                FileDialogType.Open => OpenFileOpenDialog(configuration),
                FileDialogType.Save => OpenFileSaveDialog(configuration),
                _ => Enumerable.Empty<string>(),
            };
        
        // TODO extend this for dialog.FileName
        private IEnumerable<string> OpenFileOpenDialog(FileDialogConfiguration configuration)
        {
            using var dialog = new VistaOpenFileDialog
            {
                Title = configuration.Title,
                Filter = GetExtensionFilter(configuration.ExtensionFilters),
                FilterIndex = 1,
                Multiselect = configuration.Multiselect,
                InitialDirectory = configuration.InitialDirectory,
            };

            return dialog.ShowDialog(GetWindow()) == DialogResult.OK
                ? dialog.FileNames
                : Enumerable.Empty<string>();
        }
        
        private IEnumerable<string> OpenFileSaveDialog(FileDialogConfiguration configuration)
        {
            using var dialog = new VistaSaveFileDialog
            {
                Title = configuration.Title,
                Filter = GetExtensionFilter(configuration.ExtensionFilters),
                FilterIndex = 1,
                InitialDirectory = configuration.InitialDirectory,
            };

            return dialog.ShowDialog(GetWindow()) == DialogResult.OK
                ? dialog.FileNames
                : Enumerable.Empty<string>();
        }

        public IEnumerable<string> OpenFolderDialog(FolderDialogConfiguration configuration)
        {
            using var dialog = new VistaFolderBrowserDialog
            {
                Description = configuration.Title,
                SelectedPath = configuration.InitialDirectory,
            };
            
            return dialog.ShowDialog(GetWindow()) == DialogResult.OK
                ? new [] { dialog.SelectedPath }
                : Enumerable.Empty<string>();
        }

        private static string GetExtensionFilter(IEnumerable<ExtensionFilter> extensions) =>
            string.Join("|", extensions.Select(GetExtensionFilter));

        private static string GetExtensionFilter(ExtensionFilter filter)
        {
            var extensions = string.Join(";", filter.AssociatedExtensions.Select(e => $"*.{e}"));
            return $"{filter.Description}|{extensions}";
        }

        private static WindowWrapper GetWindow() => new WindowWrapper(GetActiveWindow());
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        private class WindowWrapper : IWin32Window
        {
            public WindowWrapper(IntPtr handle) => Handle = handle;
            public IntPtr Handle { get; }
        }
    }
}

#endif