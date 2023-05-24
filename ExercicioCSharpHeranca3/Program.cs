using ExercicioCSharpHeranca3.Entities;
using System.Globalization;

namespace ExercicioCSharpHeranca3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Tax payer #1 data: ");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());


                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(type == 'i' | type == 'I')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    TaxPayer taxPayer = new Individual(name,anualIncome,healthExpenditures);
                    list.Add(taxPayer);
                }
                else if (type == 'c' | type == 'C')
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    TaxPayer taxPayer = new Company(name,anualIncome,numberOfEmployees);
                    list.Add(taxPayer);
                }
            }
            Console.WriteLine("\nTAXES PAID: ");
             double sum = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name}: $ {item.Tax().ToString("F2", CultureInfo.InvariantCulture)}");
                sum += item.Tax(); 
            }

                Console.WriteLine($"\nTOTAL TAXES: $ {sum.ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}