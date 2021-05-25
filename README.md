# unity-file-browser

A simple (windows-only for now) file browser wrapper for unity, based on the [Unity Standalone File Browser](https://github.com/gkngkc/UnityStandaloneFileBrowser). 
It wraps the [Ookii.Dialogs.WinForms](https://github.com/ookii-dialogs/ookii-dialogs-winforms) into a single static class to allow the consumer to query users for paths. 

# Installation
 
There are two main ways to install this package in your Unity project:

* [The latest `unitypackage` release]().
* [The upm branch]()

# Examples

An example scene can be found in the `samples` folder:

```csharp
/// <summary>
/// Open a "Open File Dialog" and use the result.
/// </summary> 
public void OpenFileDialog()
{
    var config = new FileDialogConfiguration
    {
        Title = "Open file dialog",
        FileDialogType = FileDialogType.Open,
        Multiselect = true 
    };

    var result = FileBrowser.FileBrowserService.OpenFileDialog(config);
    UseResult(result);
}

/// <summary>
/// Open a "Save File Dialog" and use the result.
/// </summary> 
public void SaveFileDialog()
{
    var config = new FileDialogConfiguration
    {
        Title = "Save file dialog",
        FileDialogType = FileDialogType.Save,
    };

    var result = FileBrowser.FileBrowserService.OpenFileDialog(config);
    UseResult(result);
}

/// <summary>
/// Open a "Open Folder Dialog" and use the result.
/// </summary> 
public void OpenFolderDialog()
{
    var config = new FolderDialogConfiguration
    {
        Title = "Open folder dialog",
    };

    var result = FileBrowser.FileBrowserService.OpenFolderDialog(config);
    UseResult(result);
}
```