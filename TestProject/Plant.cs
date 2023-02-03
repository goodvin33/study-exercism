using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public enum Plant
    {
        Violets,
        Radishes,
        Clover,
        Grass
    }

    public class KindergartenGarden
    {
        private List <string> ListOfChildren = new List <string>()
        {
            "Alice",
            "Bob",
           "Charlie",
            "David",
            "Eve",
            "Fred",
            "Ginny",
            "Harriet",
            "Ileana",
            "Joseph",
            "Kincaid",
            "Larry"
        };

        private readonly string Diagram;
        private Dictionary<string, string> ChildrenAndPlants;


        public KindergartenGarden(string diagram)
        {
            Diagram = diagram;
            ChildrenAndPlants = new Dictionary<string, string>();

            ListOfChildren.ForEach(child => ChildrenAndPlants.Add(child, ""));

            for(int i = 0; i < GetPlantsOfChildren().Count; i++)
            {
                ChildrenAndPlants[ChildrenAndPlants.Keys.ElementAt(i)] = GetPlantsOfChildren()[i];
            } 
            
        }

        public IEnumerable<Plant> Plants(string student)
        {
            List<Plant> plants = new List<Plant>();

            foreach(char firstLetter in ChildrenAndPlants[student].ToArray())
            {
                plants.Add(GetPlant(firstLetter));
            }

            return plants;

        }

        private Plant GetPlant(char firstLetter) => firstLetter switch
        {
            'V' => Plant.Violets,
            'R' => Plant.Radishes,
            'C' => Plant.Clover,
            'G' => Plant.Grass,
            _=> Plant.Grass
        };

        private List<string> GetPlantsOfChildren()
        {
            List<string> plantsOfChildren = new List<string>();
            string plantsOneChild ="";
            int counterLines = 0;
            string diagram = Diagram;

            string[] lines = diagram.Split('\n');

            while (lines[lines.Length-1].Length>0)
            {
                
                for (int counterLetterInGroup = 0; counterLetterInGroup < 2; counterLetterInGroup++)
                {
                    plantsOneChild += lines[counterLines][counterLetterInGroup];
                }

                lines[counterLines] = lines[counterLines].Substring(2, lines[counterLines].Length-2);

                if (counterLines == 1)
                {
                    counterLines = 0;
                    plantsOfChildren.Add(plantsOneChild);
                    plantsOneChild = "";
                }
                else
                {
                    counterLines++;
                } 
            } 

            return plantsOfChildren;   
        }
    }
}
