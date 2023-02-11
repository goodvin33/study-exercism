using System;   

namespace TestProject
{


    static class Badge
    {
        public static string Print(int? id, string name, string? department)
        // => "[734] - Ernest Johnny Payne - STRATEGIC COMMUNICATION"
        {
            string label;

            if (id == null)
            {
                label = $"{name} {(department == null ? "OWNER" : "- " + department.ToUpper())}";

            }
            else
            {
                label = $"[{id}] - {name} {(department == null ? "" : "- " + department.ToUpper())}";

            }

            return (label);

        }
    }
}
