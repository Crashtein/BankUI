using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            BankAccount acc = null;
            while (acc == null)
            {
                input = null;
                Console.WriteLine("Witaj w aplikacji bankowej! Wybierz co chcesz zrobić: ");
                while (input != "1" && input != "2")
                {
                    Console.Clear();
                    Console.WriteLine("1) Stwórz konto bankowe.");
                    Console.WriteLine("2) Zaloguj się na swoje konto.");
                    input = Console.ReadLine();
                }

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Stwórz konto bankowe!");
                        Console.WriteLine("Podaj nazwe użytkownika: ");
                        acc = new BankAccount(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Podaj nazwe użytkownika: ");
                        string username = Console.ReadLine();
                        if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\accounts\\" + username + ".txt"))
                        {
                            acc = new BankAccount(username);
                            acc.loadAccount();
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono konta!");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        //never
                        break;
                }
            }
            

            input = null;
            while(input != "0")
            {
                input = null;
                while (input != "1" && input != "2" && input != "3" && input != "4" && input != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Witaj na swoim koncie! " + acc.name());
                    Console.WriteLine("Co chcesz zrobić?");
                    Console.WriteLine("Menu: ");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("1) Wpłać pieniądze");
                    Console.WriteLine("2) Wypłać pieniądze");
                    Console.WriteLine("3) Pokaż stan konta");
                    Console.WriteLine("4) Wyświetl listę dokonanych operacji");
                    Console.WriteLine("0) Wyjdź");
                    Console.WriteLine("-------------------------------------");
                    input = Console.ReadLine();
                }
                switch (input)
                {
                    case "1":
                        acc.cashIn();
                        acc.saveAccount();
                        break;
                    case "2":
                        acc.cashOut();
                        acc.saveAccount();
                        break;
                    case "3":
                        acc.showBalance();
                        break;
                    case "4":
                        acc.showTransactions();
                        break;
                    case "0":
                        acc.saveAccount();
                        Console.WriteLine("Dziękujemy za korzystanie z naszych usług!");
                        Console.WriteLine("Wciśnij klawisz aby zamknąć aplikacje:");
                        Console.ReadKey();
                        break;
                    default:
                        //never happens
                        break;
                }
            }

        }
    }
}
