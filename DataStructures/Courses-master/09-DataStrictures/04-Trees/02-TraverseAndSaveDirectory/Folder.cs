using System;
using System.Collections.Generic;

namespace _02_TraverseAndSaveDirectory
{
    class Folder
    {
        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this.ChildFolders = new List<Folder>();
            this.Files = new List<File>();
        }
    }
}
