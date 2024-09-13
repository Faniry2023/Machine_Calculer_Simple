using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Calculer_Simple.Calcul
{
    public class Operation
    {
        public static Double Division(string enterS, string reponseS)
        {
            double enter = Double.Parse(enterS);
            double reponse = 0;
            try
            {
                reponse = Double.Parse(reponseS);

                return reponse / enter;
            }catch(System.FormatException ex) { reponse = 0; return enter; }
        }

        public static Double Multiplication(string enterS, string reponseS)
        {
            double enter = Double.Parse(enterS);
            double reponse = 1;
            try
            {
                reponse = Double.Parse(reponseS);

                return reponse * enter;
            }
            catch (System.FormatException ex) { reponse = enter; return enter; }
        }
        public static Double Addition(string enterS, string reponseS)
        {
            double enter = Double.Parse(enterS);
            double reponse = 0;
            try
            {
                reponse = Double.Parse(reponseS);

                return reponse + enter;
            }
            catch (System.FormatException ex) { reponse = enter; return enter; }
        }

        public static Double Soustraction(string enterS, string reponseS)
        {
            double enter = Double.Parse(enterS);
            double reponse = 0;
            try
            {
                reponse = Double.Parse(reponseS);

                return reponse - enter;
            }
            catch (System.FormatException ex) { reponse = enter; return enter; }
        }
    }
}
