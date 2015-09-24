using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_TraverseAndSaveDirectory
{
    class TraverseDirectoryMain
    {
        static void Main()
        {
            string directoryName = @"D:\Movies";

            Folder rootFolder = new Folder(directoryName);

            BuildTree(rootFolder);

            Console.WriteLine("Folder: {0}\nSize: {1} bytes", directoryName, GetFolderSize(rootFolder));
        }

        public static void BuildTree(Folder directory)
        {

            List<DirectoryInfo> childrenDirectories = 
                new DirectoryInfo(directory.Name).GetDirectories().ToList();

            List<FileInfo> childrenFiles = 
                new DirectoryInfo(directory.Name).GetFiles().ToList();

            foreach (var file in childrenFiles)
            {
                var currFile = new File(file.FullName, file.Length);
                directory.Files.Add(currFile);
            }

            foreach (var childDirectory in childrenDirectories)
            {
                var currFolder = new Folder(childDirectory.FullName);
                directory.ChildFolders.Add(currFolder);
                BuildTree(currFolder);
            }
        }

        public static long GetFolderSize(Folder rootFolder)
        {
            if (rootFolder == null )
            {
                return 0;
            }

            long childSum = 0;

            foreach (var folder in rootFolder.ChildFolders)
            {
                childSum += GetFolderSize(folder);
            }

            return childSum + rootFolder.Files.Sum( f => f.Size);
        }
    }
}
