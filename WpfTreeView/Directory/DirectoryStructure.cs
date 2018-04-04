using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    #region Directory Structure class
    /// <summary>
    /// A helper class to query about directories
    /// </summary>
    public static class DirectoryStructure
    {
        #region Get Logical Drives
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            //Get every logical drive on the machine
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }
        #endregion
        #region Get Directory content
        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The fullpath to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string FullPath)
        {
            //create empty list
            var items = new List<DirectoryItem>();

            #region Get folder
            //Try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(FullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch
            { }
            #endregion

            #region Get files
            //Try and get files from the folder
            //ignoring any issues doing so
            try
            {
                var fls = Directory.GetFiles(FullPath);
                if (fls.Length > 0)
                {
                    items.AddRange(fls.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch
            { }
            #endregion
            return items;
        }
#endregion  
        #region Helpers
        /// <summary>
        /// Find the file or folder from a full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            //C:\something\a folder
            //C:\somethin/a file.png
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //make all slashes back slashes
            var normailizePath = path.Replace('/', '\\'); //double \\ is just \

            //find last backslash
            var lastIndex = normailizePath.LastIndexOf('\\');

            //if we dont find a backslah, return path itself
            if (lastIndex < 0)
                return path;
            //return the name after the last backslash
            return normailizePath.Substring(lastIndex + 1);
        }
        #endregion
    }
    #endregion
}