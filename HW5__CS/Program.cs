using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW5__CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
           {
                Console.WriteLine("Задание 001.\n" +
                    "З\nЗадача 1. Код обрабатывает ввод пользователя вида «Program.exe 123sdgfs12312» и выдаёт 2 найденных числа 123 и 12312.\n" +
                    "Измените код таким образом, чтобы при вводе «Program.exe 123s dgfs  123 12» он нашёл 3 числа - 123 123 и 12.\n" +
                    "Задание 2. Измените код таким образом, чтобы он корректно принимал отрицательные числа типа int.\r\n" +
                "__________________________________________________________________________________________");
                string input="";
                if (args.Length > 0)
                {
                    input = args[0];
                }
                Regex regex = new Regex(@"((-){0,1}(\d){1,})");
                MatchCollection matchFind = regex.Matches(input);
                int counter = 0;
                foreach (var item in matchFind)
                {
                    Console.WriteLine($"Совпадение номер {counter} {item}");
                    counter++;
                }
           }
            Console.WriteLine("Задание 002.\n" +
                    "Скомпилировать консольную программу, которая спрашивает у пользователей имя, адрес электронной почты и номер мобильного телефона в формате +7XXXXXXXXXX или 8XXXXXXXXXX.\n" +
                    "Пользователь может вводить данные в произвольном порядке, во вводе может присутствовать лишняя, не обрабатываемая программой информация.\n" +
                    "После того, как пользователь вводит слово END_INPUT в любом месте своего ввода, ввод прекращается и на экран выводятся результаты\n" +
                    "в виде таблицы(колонки, разделённые табуляцией первая строчка - шапка таблицы).\r\n" +
                    "__________________________________________________________________________________________");            
            
            List<string> userName = new List<string>();
            List<string> userEmail = new List<string>();
            List<string> userPhone = new List<string>();           
            var regexpName = new Regex(@"([A-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})");
            var regexpEmail = new Regex(@"([a-яA-Я0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})");
            var regexPhone = new Regex(@"(8|\+7)(\d){10}");
            var regexStopEnter = new Regex(@"(END_INPUT)", RegexOptions.IgnoreCase);
            int counterStopEnter = 0;
            string name = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;            
            Console.WriteLine("Ведите через пробел в любом порядке:\nимя, номер телефона в формате +7XXXXXXXXXX или 8XXXXXXXXXX и адрес электронной почты\n" +
                "(для завершения ввода наберите END_INPUT): ");           
            while (counterStopEnter == 0)
            {
                string str = Console.ReadLine();                
                MatchCollection matchesStopEnter = regexStopEnter.Matches(str);
                foreach (Match match in matchesStopEnter)
                {
                    counterStopEnter++;
                }
                MatchCollection matchesName = regexpName.Matches(str);
                if (matchesName.Count > 0)
                {
                    foreach (Match match in matchesName)
                    {
                        name = matchesName[0].ToString();                        
                    }
                }
                else
                {
                    name = "default_name";                    
                }
                userName.Add(name);
                MatchCollection matchesEmail = regexpEmail.Matches(str);
                if (matchesEmail.Count > 0)
                {
                    foreach (Match match in matchesEmail)
                    {
                        email = matchesEmail[0].ToString();                        
                    }
                }
                else
                {
                    email = "default_email";                    
                }
                userEmail.Add(email);
                MatchCollection matchesPhone = regexPhone.Matches(str);
                if (matchesPhone.Count > 0)
                {
                    foreach (Match match in matchesPhone)
                    {
                        phone = matchesPhone[0].ToString();                        
                    }
                }
                else
                {
                    phone = "default_phone";                    
                }
                userPhone.Add(phone);                
            }
            Console.WriteLine(new string('-', 20 + 13 + 20 + 4));
            Console.WriteLine($"|{"Name",-20}|{"Phone",13}|{"Email",20}|");
            Console.WriteLine(new string('-', 20 + 13 + 20 + 4));

            for (int i = 0; i < userName.Count; i++)
            {
                Console.WriteLine($"|{userName[i],-20}|{userPhone[i],13}|{userEmail[i],20}|");
                Console.WriteLine(new string('-', 20 + 13 + 20 + 4));
            }            
            Console.ReadKey();           
        }
    }
}
