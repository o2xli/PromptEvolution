using Snapshooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptEvolution.Tests
{
    public static class Extensions
    {
        public static string MakeFileSystemReady(this string source)
        {
            var result = string.Concat(source.Split(Path.GetInvalidFileNameChars()));
            
            var maxLength = 50;
            if (result.Length <= maxLength)
            {
                return result;
            }

            return $"{result.Substring(0, maxLength)}...";
        }
    }
}
