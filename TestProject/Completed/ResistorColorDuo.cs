using System;

namespace TestProject
{
    public static class ResistorColorDuo
    {
        public static int Value(string[] colors)
        {
            string result = "";
            

            for(int i = 0; i < colors.Length && i <= 1; i++)
            {
                result += Array.IndexOf(Colors(), colors[i]).ToString();
            }
            
            return (Convert.ToInt32(result));
        }
        public static string[] Colors() => new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    }
}
