using System.Runtime.CompilerServices;

namespace GameServer.Helpers
{
    public class StringHelpers
    {
        public static Ganre StringToGanre(string str) 
        {
            string smallGanre = str.ToLower();
            if (smallGanre == "shooter")
            {
                return Ganre.Shooter;
            }
            if (smallGanre == "rpg")
            {
                return Ganre.RPG;
            }
            if (smallGanre == "racing")
            {
                return Ganre.Racing;
            }
            else
            {
                throw new Exception("Not supported ganre");
            }
        }
        public static string GanreToString(Ganre ganre)
        {
            if(ganre == Ganre.Shooter)
            {
                return "Shooter";
            }
            if (ganre == Ganre.RPG)
            {
                return "RPG";
            }
            if (ganre == Ganre.Racing)
            {
                return "Racing";
            }
            throw new Exception("Not supported ganre");
        }
    }
}
