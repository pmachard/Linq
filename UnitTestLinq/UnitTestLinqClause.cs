using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestLinq
{
    [TestClass]
    public class UnitTestLinqClause
    {
        [TestMethod]
        public void TestMethod_from_Clause_1()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/from-clause
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result = from num in numbers
                          where num < 5
                          select num;
        }

        public class Student
        {
            public string LastName { get; set; }
            public List<int> Scores { get; set; }
        }

        [TestMethod]
        public void TestMethod_from_Clause_2()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/from-clause
            List<Student> students = new List<Student>
            {
               new Student {LastName="Omelchenko", Scores= new List<int> {97, 72, 81, 60}},
               new Student {LastName="O'Donnell", Scores= new List<int> {75, 84, 91, 39}},
               new Student {LastName="Mortensen", Scores= new List<int> {88, 94, 95, 85}},
               new Student {LastName="Garcia", Scores= new List<int> {97, 89, 85, 82}},
               new Student {LastName="Beebe", Scores= new List<int> {35, 72, 91, 70}}
            };

            var result = from student in students
                             from score in student.Scores
                             where score > 90
                             select new { Last = student.LastName, score };
        }

        [TestMethod]
        public void TestMethod_from_Clause_3()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/from-clause
            char[] upperCase = { 'A', 'B', 'C' };
            char[] lowerCase = { 'x', 'y', 'z' };

            var result =
                from upper in upperCase
                from lower in lowerCase
                select new { upper, lower };
                    // A is matched to x
                    // A is matched to y
                    // A is matched to z
                    // B is matched to x
                    // B is matched to y
                    // B is matched to z
                    // C is matched to x
                    // C is matched to y
                    // C is matched to z

            var resultBis =
                from lower in lowerCase
                where lower != 'x'
                from upper in upperCase
                select new { lower, upper };
                    // y is matched to A
                    // y is matched to B
                    // y is matched to C
                    // z is matched to A
                    // z is matched to B
                    // z is matched to C
        }

        [TestMethod]
        public void TestMethod_Let_Clause_1()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/let-clause
            string[] phrases =
                    {
                        "Le Soleil, le foyer de tendresse et de vie,",
                        "Verse l’amour brûlant à la terre ravie,",
                        "Et, quand on est couché sur la vallée, on sent",
                        "Que la terre est nubile et déborde de sang ;",
                        "Que son immense sein, soulevé par une âme,",
                        "Est d’amour comme Dieu, de chair comme la femme,",
                        "Et qu’il renferme, gros de sève et de rayons,",
                        "Le grand fourmillement de tous les embryons !"
                    };

            var result =
                from phrase in phrases
                let mots = phrase.Split(' ')
                from mot in mots
                let motEnMinuscule = mot.ToLower()
                where motEnMinuscule[0] == 'a' || motEnMinuscule[0] == 'e' || motEnMinuscule[0] == 'i' || motEnMinuscule[0] == 'o' || motEnMinuscule[0] == 'u'
                select mot;
        }

        [TestMethod]
        public void TestMethod_Where_Clause_1()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/where-clause
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var Result =
                from num in numbers
                where num < 5
                select num;
        }

        [TestMethod]
        public void TestMethod_Where_Clause_2()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/where-clause
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result =
                from num in numbers
                where num < 5 && num % 2 == 0
                select num;

            // Create the query with two where clause.
            var resultBis =
                from num in numbers
                where num < 5
                where num % 2 == 0
                select num;
        }

        [TestMethod]
        public void TestMethod_Where_Clause_3()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/where-clause
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var queryEvenNums =
                from num in numbers
                where IsEven(num)
                select num;
        }

        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        [TestMethod]
        public void TestMethod_Where_group_1()
        {
            // exemple provenant de : var studentQuery1 = https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/group-clause
            string[] students = { "polo", "jacques", "joel", "ana", "paul" };

            var result = 
                from student in students
                group student by student[0];


            var resultBis =
                from student in students
                group student by student[0] into g
                orderby g.Key
                select g;
        }


        [TestMethod]
        public void TestMethod_Where_into_1()
        {
            // exemple provenant de : https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/where-clause
            string[] words = { "apples", "blueberries", "oranges", "bananas", "apricots" };

            // Create the query.
            var results =
                from w in words
                group w by w[0] into fruitGroup
                where fruitGroup.Count() >= 2
                select new { FirstLetter = fruitGroup.Key, Words = fruitGroup.Count() };

            /* Output:
               a has 2 elements.
               b has 2 elements.
            */
        }

        [TestMethod]
        public void TestMethod_Anonimous_1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result =
                from num in numbers
                where num < 5 && num % 2 == 0
                select num;

            var resultBis = 
                numbers.Where(num => (num < 5 && num % 2 == 0))
                        .Select(num => num);
        }

    }
}
