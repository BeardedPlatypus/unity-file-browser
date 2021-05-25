using System.Collections.Generic;
using FileBrowser;
using FileBrowser.Configurations;
using UnityEngine;

namespace Samples.Scripts
{
    public class MenuController : MonoBehaviour
    {
        public TMPro.TMP_Text text;
    
        public void OpenFileDialog()
        {
            var config = new FileDialogConfiguration
            {
                Title = "Open file dialog",
                FileDialogType = FileDialogType.Open,
                Multiselect = true 
            };
        
            var result = FileBrowser.FileBrowserService.OpenFileDialog(config);
            SetResult(result);
        }

        public void SaveFileDialog()
        {
            var config = new FileDialogConfiguration
            {
                Title = "Save file dialog",
                FileDialogType = FileDialogType.Save,
            };
        
            var result = FileBrowser.FileBrowserService.OpenFileDialog(config);
            SetResult(result);
        }

        public void OpenFolderDialog()
        {
            var config = new FolderDialogConfiguration
            {
                Title = "Open folder dialog",
            };
        
            var result = FileBrowser.FileBrowserService.OpenFolderDialog(config);
            SetResult(result);
        }

        private void SetResult(IEnumerable<string> result) =>
            text.text = string.Join("\n", result);
    }
}
