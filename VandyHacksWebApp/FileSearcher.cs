using System.Web;
using System;
using System.IO;
using System.Collections.Generic;

namespace VandyHacksWebApp
{
    public class FileSearcher
    {
        private const string filePath = @"C:\VandyFiles";
        private const string skeletonFormat = "Skeleton";
        private const string ogFormat = "Original";

        private const string XSmall = "XSmall.jpg";
        private const string Small = "Small.jpg";
        private const string MEDIUM = "Medium.jpg";
        private const string Large = "Large.jpg";
        private const string XLarge = "XLarge.jpg";
        private const string XXLarge = "XXLarge.jpg";

        public struct FileReturn
        {
            public double circumference;
            public double height;
        }
        public static FileReturn GetFileInfo(string path)
        {
            string[] lines = File.ReadAllLines(path);
            FileReturn fr = new FileReturn();
            fr.circumference = Double.Parse(lines[0]);
            fr.height = Double.Parse(lines[1]);
            return fr;
        }

        public static int GetNumberOfFileSets()
        {
            var allFiles = GetAllFileSets();
            return allFiles.Length;
        }
       
        public static FileSet[] GetAllFileSets()
        {
            var allFiles = Directory.GetFiles(filePath);
            List<string> skeletonFiles = new List<string>();
            List<string> ogFiles = new List<string>();
            List<FileSet> fileSets = new List<FileSet>();

            for(int x = 0; x < allFiles.Length; x++)
            {
                if(allFiles[x].Contains(skeletonFormat))
                {
                    skeletonFiles.Add(allFiles[x]);
                }
                else if(allFiles[x].Contains(ogFormat))
                {
                    ogFiles.Add(allFiles[x]);
                }
            }

            string[] sortedSkelFiles = SortSkeletonFiles(skeletonFiles);
            string[] sortedOgFiles = SortOgFiles(ogFiles);
            for(int x = 0; x< sortedOgFiles.Length; x++)
            {
                fileSets.Add(new FileSet { ogFile = sortedOgFiles[x], skeletonFile = sortedSkelFiles[x] } );
            }

            return fileSets.ToArray();
        }
        public static FileSet GetFileSet(int index)
        {
            var allFiles = GetAllFileSets();
            return allFiles[index];
        }

        public static string GetSkeletonFile(int index)
        {
            var allFiles = GetAllFileSets();
            return allFiles[index].skeletonFile;
        }
        public static string GetOgFile(int index)
        {
            var allFiles = GetAllFileSets();
            return allFiles[index].ogFile;
        }
        public static string GetGloveFile(int index)
        {
            var allFiles = GetAllFileSets();
            return allFiles[index].gloveFile;
        }
        private static string[] SortSkeletonFiles(List<string> files)
        {
            string[] outputFiles = new string[files.Count];
            for (int x = 0; x < files.Count; x++)
            {
                string num = files[x].Remove(0,
                    files[x].IndexOf(skeletonFormat) + skeletonFormat.Length);
                num = num.Remove(num.IndexOf('.'));
                int index = Convert.ToInt32(num);
                outputFiles[index] = files[x];
            }
            return outputFiles;
        }
        private static string[] SortOgFiles(List<string> files)
        {
            string[] outputFiles = new string[files.Count];
            for (int x = 0; x < files.Count; x++)
            {
                string num = files[x].Remove(0,
                    files[x].IndexOf(ogFormat) + ogFormat.Length);
                num = num.Remove(num.IndexOf('.'));
                int index = Convert.ToInt32(num);
                outputFiles[index] = files[x];
            }
            return outputFiles;
        }

        public struct FileSet
        {
            public string ogFile;
            public string gloveFile;
            public string skeletonFile;
        }
    }

}