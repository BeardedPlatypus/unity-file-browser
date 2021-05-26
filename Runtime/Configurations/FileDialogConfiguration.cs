using System.Collections.Generic;

namespace BeardedPlatypus.FileBrowser.Configurations
{
    /// <summary>
    /// <see cref="FileDialogConfiguration"/> defines the configuration for a
    /// file dialog.
    /// </summary>
    public sealed class FileDialogConfiguration : DialogConfiguration
    {
        public override string Title { get; set; } = "File Dialog";

        /// <summary>
        /// <see cref="FileDialogType"/> defines the type of file dialog.
        /// </summary>
        /// <remarks>
        /// This value will default to Open.
        /// </remarks>
        public FileDialogType FileDialogType { get; set; } = FileDialogType.Open;

        /// <summary>
        /// <see cref="ExtensionFilters"/> defines the extension filters for the
        /// file dialog.
        /// </summary>
        /// <remarks>
        /// This value will default to all files.
        /// </remarks>
        public IReadOnlyList<ExtensionFilter> ExtensionFilters { get; set; } =
            new[] {ExtensionFilter.Presets.AllFiles()};
    }
}