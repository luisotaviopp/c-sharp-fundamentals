using System;
using System.Collections.Generic;

namespace GradeBook 
{

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name 
        {
            get;
            set;
        }
    }

    public interface IBook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
    }

    public abstract class Book : NamedObject , IBook
    {
        public Book (string name) : base(name) {}

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;

        readonly private string category;

        public InMemoryBook (string name) : base (name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public InMemoryBook (string name, string category) : base (name)
        {
            grades = new List<double>();
            this.Name = name;
            this.category = category;
        }

//        public event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();

            stats.average = 0.0;
            stats.high = double.MaxValue;
            stats.low = double.MinValue;

            foreach (var number in grades)
            {
                stats.low = Math.Min(number, stats.low);
                stats.high = Math.Max(number, stats.high);
            }

            stats.sum = Sum();
            stats.average = Average();

            switch(stats.average) 
            {
                case var d when d >= 90.0:
                    stats.letter = 'A';
                    break;
                
                case var d when d >= 80.0:
                    stats.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    stats.letter = 'C';
                    break;

                case var d when d >= 60.0:
                    stats.letter = 'D';
                    break;

                default:
                    stats.letter = 'F';
                    break;
            }

            return stats;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;
                
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {            
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("");
                throw new ArgumentException($"Ops. Max value of {nameof(grade)} should be 100.");
            }
        }

        public double Average () 
        {
            return (Sum() / grades.Count);
        }

        public double Sum () 
        {
            double sum = 0;

            foreach (double number in this.grades)
            {
               sum += number;
            }

            return sum;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string newName)
        {
            this.Name = newName;
        }
    }
}