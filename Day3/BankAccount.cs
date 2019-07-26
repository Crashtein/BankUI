using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class BankAccount
    {
        string Owner;
        double Balance;
        List<Transaction> allTransactions;
        
        public BankAccount(string name)
        {
            Owner = name;
            Balance = 0;
            allTransactions = new List<Transaction>();
        }
        public string name()
        {
            return Owner;
        }
        public void cashIn()
        {
            Console.WriteLine("Podaj kwote jaką chcesz wpłacić[zł](np. 250,53): ");
            string sAmount = Console.ReadLine();
            if (Double.TryParse(sAmount, out double Amount)){
                if (Amount > 0)
                {
                    Console.WriteLine("Dodaj opis do transakcji: ");
                    string description = Console.ReadLine();
                    Balance += Amount;
                    //add new transaction to list with amount and description
                    allTransactions.Add(new Transaction(Amount, DateTime.Now, "Wpłata. " + description));

                    Console.WriteLine("Wpłacono: " + String.Format("{0:N2}", Amount) + " zł");
                    Console.WriteLine("Opis: " + "Wpłata. " + description);
                }
                else
                {
                    Console.WriteLine("Kwota musi być większa od 0!");
                }
            }
            else
            {
                Console.WriteLine("Błędnie podana kwota!");
            }
            Console.ReadKey();
        }
        public void cashOut()
        {
            Console.WriteLine("Podaj kwote jaką chcesz wypłacić[zł](np. 250,53): ");
            string sAmount = Console.ReadLine();
            if (Double.TryParse(sAmount, out double Amount))
            {
                if (Amount <= Balance)
                {
                    if (Amount > 0)
                    {
                        Console.WriteLine("Dodaj opis do transakcji: ");
                        string description = Console.ReadLine();
                        Balance -= Amount;
                        //add new transaction to list with amount and description
                        allTransactions.Add(new Transaction(-Amount, DateTime.Now, "Wypłata. " + description));

                        Console.WriteLine("Wypłacono: " + String.Format("{0:N2}", Amount) + " zł");
                        Console.WriteLine("Opis: " + "Wypłata. " + description);
                    }
                    else
                    {
                        Console.WriteLine("Kwota musi być większa od 0!");
                    }
                }
                else
                {
                    Console.WriteLine("Niewystarczająco funduszy!");
                }
            }
            else
            {
                Console.WriteLine("Błędnie podana kwota!");
            }
            Console.ReadKey();
        }
        public void showBalance()
        {
            Console.WriteLine("Bilans Twojego konta wynosi: " + String.Format("{0:N2}", Balance) + " zł");
            if(Balance>0)
                Console.WriteLine("Średniawka, ale może na bułki wystarczy ;)");
            Console.WriteLine("Wciśnij przycisk aby powrócić do menu");
            Console.ReadKey();
        }
        public void showTransactions()
        {
            int i = 1;
            foreach(Transaction tr in allTransactions)
            {
                Console.WriteLine("Transakcja numer: " + i.ToString());
                Console.WriteLine("Kwota transakcji: " + String.Format("{0:N2}", tr.amount()) + " zł");
                Console.WriteLine("Data transakcji: " + tr.date());
                Console.WriteLine("Opis transakcji: " + tr.notes());
                i++;
            }
            Console.ReadKey();
        }
        public void saveAccount()
        {
            string fileName = Owner + ".txt";
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.IO.Directory.CreateDirectory(currentPath + "\\accounts\\");
            System.IO.File.WriteAllText(currentPath + "\\accounts\\" + fileName, Balance.ToString());
            foreach (Transaction tr in allTransactions)
            {
                System.IO.File.AppendAllText(currentPath + "\\accounts\\" + fileName, "\r\n" + tr.amount().ToString() + "\r\n" 
                    + tr.date().ToString() + "\r\n" + tr.notes());
            }
        }
        public void loadAccount()
        {
            string filename = Owner + ".txt";
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.IO.StreamReader file = new System.IO.StreamReader(currentPath + "\\accounts\\" + filename);
            if(Double.TryParse(file.ReadLine(),out Balance)){
                Console.WriteLine("Konto prawidłowe. Ładowanie danych transakcji...");
                string sAmount=null;
                string sTime = null;
                string description=null;
                while ((sAmount=file.ReadLine()) != null)
                {
                    sTime = file.ReadLine();
                    description = file.ReadLine();
                    allTransactions.Add(new Transaction(Double.Parse(sAmount), DateTime.Parse(sTime), description));
                }
            }
            else
            {
                Console.WriteLine("Błąd wczytywania danych konta, uszkodzony plik. Wyłącz aplikacje i skontaktuj się z supportem!");
                Console.ReadKey();
                Environment.Exit(1);
            }
            file.Close();
        }
    }
}
