﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

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

            GradeBook book = new GradeBook();
            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            WriteNames("Pop", "Dida", "Darkec", "Stepa");

            int number = 20;
            WriteBytes(number);
            WriteBytes(stats.AverageGrade);

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WryteByteArray(bytes);
        }

        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WryteByteArray(bytes);
        }

        private static void WryteByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} ", b);
            }
            Console.WriteLine();
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

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
 