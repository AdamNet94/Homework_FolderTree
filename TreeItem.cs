using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapSoft
{
    class TreeItem
    {
        String name;
        readonly List<TreeItem> children = new List<TreeItem>();

        public TreeItem GetWritableFolderStructure(List<string> readableFolders,
            List<string> writableFolders)
        {
            // finding the rootFolder-Node in the Graph tree
            var foldersOccurrence = BuildPathOccurrence(readableFolders);
            // finding max value, which gives the path that occurrs in most other paths (basically in every path -- since it's supposed to be a tree)
            var rootPath = foldersOccurrence.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var rootFolder = rootPath.Split('/').Last();
            this.name = "/" + rootFolder;

            // building up the Tree structure
            Buildtree(this.name, writableFolders, readableFolders, this);

            return this;
        }

        private Dictionary<string, int> BuildPathOccurrence(List<string> readableFolders)
        {
            var foldersOccurrence = new Dictionary<string, int>();

            for (int i = 0; i < readableFolders.Count; i++)
            {
                var path = readableFolders.ElementAt(i);
                foldersOccurrence.Add(path, 0);

                for (int j = i; j < readableFolders.Count; j++)
                {
                    var anotherPath = readableFolders.ElementAt(i);
                    if (anotherPath.Contains(path))
                        foldersOccurrence[path] += 1;
                }
            }
            return foldersOccurrence;
        }

        private void Buildtree(string ancestorPath, List<string> writableFolders, List<string> readableFolders, TreeItem parent)
        {
            foreach (var possibleChild in readableFolders)
            {
                // if there is only one more slash in the candidate's path then it is a child folder of the parent
                string residualPath = possibleChild.Remove(possibleChild.LastIndexOf('/'));
                if (residualPath.Equals(ancestorPath))      
                {
                    if (IsWritable(possibleChild, writableFolders))
                    {
                        TreeItem child = new TreeItem
                        {
                            name = possibleChild.Substring(possibleChild.LastIndexOf('/'))
                        };
                        parent.children.Add(child);
                        Buildtree(possibleChild, writableFolders, readableFolders, child);
                    }
                    else Buildtree(possibleChild, writableFolders, readableFolders, parent);
                }
            }
        }

        private bool IsWritable(string nodePath, List<string> writableFolders)
        {
            foreach (var writableFolder in writableFolders)
            {
                if (writableFolder.Contains(nodePath))
                    return true;
            }
            return false;
        }
    }
}