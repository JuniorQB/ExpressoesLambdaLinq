using ExpressoesLambdaLinq.Entities;
using System.IO;


class Program
{


    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter full file path:");
        string path = Console.ReadLine();
        


        using (StreamReader sr = File.OpenText(path))
        {
            while (!sr.EndOfStream) { 
                string[] fields = sr.ReadLine().Split(',');

                Employee emp = new Employee(fields[0], fields[1], double.Parse(fields[2]));

                employees.Add(emp);
            }
        }
        Console.Write("Enter salary:");
        double salary = double.Parse(Console.ReadLine());

        Console.WriteLine($"Email of people whose salary is more than {salary}");
        var result = employees.Where(e => e.Salary >= salary).OrderBy(e => e.Email).Select(e => e.Email);

        foreach(string email  in result)
        {
            Console.WriteLine(email);
        }

        var sum = employees.Where(e=> e.Name[0] == 'M').Sum(e => e.Salary);
        Console.WriteLine("Sum of salaray of peaople whose name starts with 'M': " + sum);
    }
}