using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        //static void GiveBookAName(GradeBook book)
        //{
        //    book = new GradeBook();
        //    book.Name = "The New gradebook";
        //}

        //static void IncrementNumber(int number)
        //{
        //    number += 1;
        //}

        static void Main(string[] args)
        {
            //SpeechSynthesizer speech = new SpeechSynthesizer();
            //speech.Speak("Hello world");

            //Arrays();
            //Immutable();
            //PassByValueAndRef();

            GradeBook book = new GradeBook("Scott's book");

            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not locate the file grades.txt");
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No access");
                return;
            }

            book.WriteGrades(Console.Out);

            try
            {
                Console.WriteLine("Please enter a name for the book");
                string priv = Console.ReadLine();
                while (priv=="")
                {
                    Console.WriteLine("Please insert correct value");
                    priv = Console.ReadLine();
                }
                book.Name = priv;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid name");
            }
            
            GradeStatistics stats = book.ComputeStatistics();

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged -= OnNameChanged;

            //book.Name = "Allen's book";

            //WriteNames(book.Name);

            Console.WriteLine(book.Name);

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine("{0} {1}", stats.LetterGrade, stats.Description);
        }

        //private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine("***");
        //}

        //private static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        //}

        //private static void WriteBytes(int value)
        //{
        //    byte[] bytes = BitConverter.GetBytes(value);
        //    WryteByteArray(bytes);
        //}

        //private static void WriteBytes(float value)
        //{
        //    byte[] bytes = BitConverter.GetBytes(value);
        //    WryteByteArray(bytes);
        //}

        //private static void WryteByteArray(byte[] bytes)
        //{
        //    foreach (byte b in bytes)
        //    {
        //        Console.Write("0x{0:X} ", b);
        //    }
        //    Console.WriteLine();
        //}

        //private static void WriteNames(params string[] names)
        //{
        //    foreach (string name in names)
        //    {
        //        Console.WriteLine(name);
        //    }
        //}

        //private static void Arrays()
        //{
        //    float[] grades;
        //    grades = new float[3];

        //    AddGrades(grades);

        //    foreach (float grade in grades)
        //    {
        //        Console.WriteLine(grade);
        //    }
        //}

        //private static void AddGrades(float[] grades)
        //{
        //    if (grades.Length >= 3)
        //    {
        //        grades[0] = 91f;
        //        grades[1] = 89.1f;
        //        grades[2] = 75f;
        //    }
        //}

        //private static void Immutable()
        //{
        //    string name = " Scott ";
        //    name = name.Trim();

        //    DateTime date = new DateTime(2014, 1, 1);
        //    date = date.AddHours(25);

        //    Console.WriteLine(date);
        //    Console.WriteLine(name);
        //}

        //private static void PassByValueAndRef()
        //{
        //    GradeBook g1 = new GradeBook();
        //    GradeBook g2 = g1;

        //    GiveBookAName(g2);
        //    Console.WriteLine(g2.Name);

        //    int x1 = 4;
        //    IncrementNumber(x1);
        //    Console.WriteLine(x1);
        //}
    }
}
 