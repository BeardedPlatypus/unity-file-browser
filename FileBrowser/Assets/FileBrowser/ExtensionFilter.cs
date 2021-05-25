using System.Collections.Generic;

namespace FileBrowser
{
    /// <summary>
    /// <see cref="ExtensionFilter"/> defines a single filter to filter files shown
    /// in a file dialog with.
    /// </summary>
    public readonly struct ExtensionFilter
    {
        /// <summary>
        /// The description of the file types shown in the file dialog.
        /// </summary>
        public readonly string Description;
        
        /// <summary>
        /// The associated extensions.
        /// </summary>
        /// <remarks>
        /// The extensions are not expected to have the '.' in the string,
        /// e.g. "png"
        /// </remarks>
        public readonly IReadOnlyList<string> AssociatedExtensions;

        /// <summary>
        /// Creates a new <see cref="ExtensionFilter"/> with the given
        /// parameters.
        /// </summary>
        /// <param name="description">The description of the file types.</param>
        /// <param name="extensions">The file extensions associated with this filter</param>
        public ExtensionFilter(string description, 
                               params string[] extensions)
        {
            Description = description;
            AssociatedExtensions = extensions;
        }
        
        /// <summary>
        /// <see cref="Presets"/> defines functions to retrieve commonly used
        /// <see cref="ExtensionFilter"/> structs.
        /// </summary>
        public static class Presets
        {
            /// <summary>
            /// Get the <see cref="ExtensionFilter"/> for all files.
            /// </summary>
            /// <returns>
            /// The <see cref="ExtensionFilter"/> for all files.
            /// </returns>
            public static ExtensionFilter AllFiles() => 
                new ExtensionFilter("All files", "*");

        }
    }
}