using System;
using System.Linq;

namespace KaffaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string OptionNumber = "0";
            string[] option = {
                "1 - 1) Validate CNPJ format (Mask)\n",
                "2 - 2) Validate CNPJ digits\n",
                "3 - 3) Test if two rectangles intersect\n",
                "4 - 4) Compute area of intersection between two rectangles\n",
                "5 - 5) Simple Todo List\n",
                "6 - 6) Rest Client - World Clock\n",
                "7 - 7) Rest Server - World Clock\n"};
            do{
                foreach(string item in option){
                    Console.Write(item);
                }
                Console.WriteLine("Enter the number of the exercise:"); 
                OptionNumber = Console.ReadLine();
                switch (OptionNumber)
                {
                    case "1":
                        validateCNPJ();
                        break;
                    case "2":
                        validateCNPJ_Digits();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        ToDo todo = new ToDo();
                        todo.prompt();
                        break;
                    case "6":
                        WorldClockRestClient worldClockRestClient = new WorldClockRestClient();
                        worldClockRestClient.main();
                        break; 
                    case "7":
                        WorldClockRestServer worldClockRestServer = new WorldClockRestServer();
                        worldClockRestServer.main();
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }while(new string[] { "1", "2", "3", "4", "5", "6", "7"}.Contains(OptionNumber));
            return;
        }

        private static string formatCNPJ(){
            Console.WriteLine("Enter the number of the CNPJ:"); 
            string cnpj = Console.ReadLine();
            return cnpj;
        }

        //1) Validate CNPJ format (Mask)
        public static void validateCNPJ(){
            //First situation: Checks if the format is "00.000.000/0000-00"
            var cnpj = "";
            cnpj = formatCNPJ();
            bool formatted = (cnpj.Length == 18 && cnpj.ElementAt(2) == '.' && cnpj.ElementAt(6) == '.' && cnpj.ElementAt(10) == '/' && cnpj.ElementAt(15) == '-');

            //Second situation: Checks if the format is "00000000000000"
            bool numberOnly = (cnpj.All(Char.IsNumber) && cnpj.Length == 14);

            if ( formatted || numberOnly)
                Console.WriteLine(cnpj);
            else
                Console.WriteLine("Invalid format.");
        }

        //2) Validate CNPJ digits
        public static void validateCNPJ_Digits(){
            var cnpj = "";
            cnpj = formatCNPJ();
            bool formatted = (cnpj.Length == 18 && cnpj.ElementAt(2) == '.' && cnpj.ElementAt(6) == '.' && cnpj.ElementAt(10) == '/' && cnpj.ElementAt(15) == '-');

            if (formatted)
            {
                //Check if the characters of CNPJ are numeric, excluding the "  .   .   /    -  "
                var isCNPJ = cnpj.Substring(0,2).All(Char.IsNumber) 
                    && cnpj.Substring(3, 3).All(Char.IsNumber) 
                    && cnpj.Substring(7, 3).All(Char.IsNumber)
                    && cnpj.Substring(11, 4).All(Char.IsNumber)
                    && cnpj.Substring(16, 2).All(Char.IsNumber);
                if (isCNPJ)
                {
                    Console.WriteLine("CNPJ is valid.");
                    return;
                }               
            }
            Console.WriteLine("CNPJ is invalid");
        }
    }
}
