using System;

namespace TestProject
{
    public static class ResistorColor
    {
        public static int ColorCode(string color) => Array.IndexOf(Colors(), color);

        public static string[] Colors() => new string [] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    }
}