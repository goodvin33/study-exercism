using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace TestProject
{
    public static class PlayAnalyzer
    {
    //        1 -> "goalie"
    //2 -> "left back"
    //3 & 4 "center back"
    //5 -> "right back"
    //6, 7 & 8 -> "midfielder"
    //9 -> "left wing"
    //10 -> "striker"
    //11 -> "right wing"

        public static string AnalyzeOnField(int shirtNum)
        {
            string result;
            switch(shirtNum)
            {
                case 1: result = "goalie";
                    break;
                case 2: result = "left back";
                    break;
                case 3:
                    result = "center back";
                    break;
                case 4:
                    result = "center back";
                    break;
                case 5:
                    result = "right back";
                    break;
                case 6:
                    result = "midfielder";
                    break;
                case 7:
                    result = "midfielder";
                    break;
                case 8:
                    result = "midfielder";
                    break;
                case 9:
                    result = "left wing";
                    break;
                case 10:
                    result = "striker";
                    break;
                case 11:
                    result = "right wing";
                    break;
                    default: 
                    if(shirtNum < 0 || shirtNum > 11)
                    {
                        throw new ArgumentOutOfRangeException("invalid shit number");
                    }
                    else
                    {
                        result = "";
                    }
                    break;
            }
           return result;
        }

        public static string AnalyzeOffField(object report)
        {
            string result = report switch
            {
                int supporters => $"There are {supporters.ToString()} supporters at the match.",
                string title => title,
                Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
                Foul foul => foul.GetDescription(),
                Incident incident  => incident.GetDescription(),
                Manager { Club: null } manager2 => $"{manager2.Name} )",
                Manager manager => $"{manager.Name} ({manager.Club})",
                _ => throw new ArgumentException(),
            };
            return result;
        }
    }
}
