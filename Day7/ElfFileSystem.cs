using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public partial class ElfFileSystem(string filename)
    {
        public class TreeNode(string _name, TreeNode? _parent, bool _isDirectory)
        {
            public readonly TreeNode? parent = _parent;
            public readonly string name = _name;
            public readonly bool  isDirectory = _isDirectory;
            
            public int size;

            public Dictionary<string, TreeNode> children = [];

            public int CalculateSize()
            {
                if(!isDirectory)
                {
                    return size;
                }
                size = 0;

                foreach(var child in children)
                {
                    size += child.Value.CalculateSize();
                }

                return size;
            }

            public int GetSumDirsUnderValue(int currentTotal, int value)
            {
                if(!isDirectory)
                {
                    return currentTotal;
                }

                foreach(var child in children)
                {
                    currentTotal = child.Value.GetSumDirsUnderValue(currentTotal, value);
                }

                if(size <= value)
                {
                    currentTotal+=size;
                }

                return currentTotal;
            }

            public int GetSmallestDirSpace(int currentMin, int freeSpaceNeeded)
            {
                if (!isDirectory)
                {
                    return currentMin;
                }

                foreach (var child in children)
                {
                    currentMin = child.Value.GetSmallestDirSpace(currentMin, freeSpaceNeeded);
                }

                if (size >= freeSpaceNeeded && size < currentMin)
                {
                    currentMin = size;
                }

                return currentMin;
            }
        }

        private TreeNode root = new("/", null, true);
        [AllowNull]
        private TreeNode current { get; set; }


        private bool CheckForDirectoryChange(string line)
        {
            var result = CdRegex().Match(line);

            if (result.Success)
            {
                string directory = result.Groups[1].Value;

                switch (directory)
                {
                    case "..":
                        if (current.parent != null)
                        {
                            current = current.parent;
                        }
                        else
                        {
                            throw new Exception("Unexpected parent");
                        }
                        break;
                    case "/":
                        current = root;
                        break;
                    default:
                        {
                            if (!current.children.TryGetValue(directory, out var childNode))
                            {
                                throw new Exception("Unexpected child");
                            }
                            current = childNode;
                            break;
                        }
                }

                return true;
            }

            return false;
        }

        private bool CheckForDirectoryList(string line)
        {
            var result = DirRegex().Match(line);

            if (result.Success)
            {
                string directory = result.Groups[1].Value;

                var newNode = new TreeNode(directory, current, true);
                current.children.Add(directory, newNode);

                return true;
            }

            return false;
        }

        private bool CheckForFileList(string line)
        {
            var result = FileRegex().Match(line);

            if (result.Success)
            {
                string filename = result.Groups[2].Value;
                int size = int.Parse(result.Groups[1].Value);

                var newNode = new TreeNode(filename, current, false)
                {
                    size = size
                };
                current.children.Add(filename, newNode);

                return true;
            }

            return false;
        }

        public int Process(bool findSmallestDirectorySpace = false)
        {
            var lines = File.ReadAllLines(filename);

            root = new TreeNode("/", null, true);
            current = root;

            foreach (var line in lines)
            {
                if(CheckForDirectoryChange(line))
                {
                    continue;
                }
                if(line == "$ ls")
                {
                    // just ignore ls commands
                    continue;
                }

                // if we're here, it's adding either a file or a directory
                if(CheckForDirectoryList(line))
                {
                    continue;
                }
                if (CheckForFileList(line))
                {
                    continue;
                }

                throw new Exception("Unexpected line");
            }


            root.CalculateSize();

            if (!findSmallestDirectorySpace)
            {
                int smallDirTotal = root.GetSumDirsUnderValue(0, 100000);

                Console.WriteLine($"Answer: {smallDirTotal}");

                return smallDirTotal;
            }

            int totalSpace = 70000000;
            int neededSpace = 30000000;

            int spaceToFree = neededSpace - (totalSpace - root.size);

            if(spaceToFree <= 0)
            {
                return 0;
            }

            int smallestDirSpace = root.GetSmallestDirSpace(int.MaxValue, spaceToFree);

            Console.WriteLine($"Answer: {smallestDirSpace}");

            return smallestDirSpace;

        }

        [GeneratedRegex(@"\$ cd ([\w/.]+)")]
        private static partial Regex CdRegex();

        [GeneratedRegex(@"dir ([\w]+)")]
        private static partial Regex DirRegex();
        
        [GeneratedRegex(@"(\d+) ([\w.]+)")]
        private static partial Regex FileRegex();
    }
}
