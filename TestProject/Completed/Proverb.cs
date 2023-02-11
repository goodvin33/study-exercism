using System;
using System.Linq;

namespace TestProject
{
    public static class Proverb
    {
            private static string TemplatePhrase = "For want of a {0} the {1} was lost.";

            public static string[] Recite(string[] subjects)
            {
                if(subjects.Length == 0)
                    return Array.Empty<string>();

            return subjects.Zip(subjects.Skip(1))
            .Select(x => String.Format(TemplatePhrase, x.First, x.Second))
            .Append($"And all for the want of a {subjects.First()}.")
            .ToArray();
            }
    }
}
