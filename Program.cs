using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public abstract class Kid
        {
            public abstract void DoHomework();
        }
        public class Junior : Kid
        {
            public Junior()
            {
                Console.WriteLine("Мама, забери меня");
            }
            public override void DoHomework()
            {
                Console.WriteLine("Ты сделал домашку?");
            }
        }
        class Freshman : Kid
        {
            public Freshman()
            {
                Console.WriteLine("Где аудитория?");
            }
            public override void DoHomework()
            {
                Console.WriteLine("Дайте списать...");
            }

        }
        public abstract class Young
        {
            public abstract void Skipping();
        }
        public class MiddleSchoolKid : Young
        {
            public MiddleSchoolKid()
            {
                Console.WriteLine("Пойдем гулять?");
            }
            public override void Skipping()
            {
                Console.WriteLine("Давай прогуляем этот урок?");
            }
        }
        class Upperclassman : Young
        {
            public Upperclassman()
            {
                Console.WriteLine("Не пойду на пару");
            }
            public override void Skipping()
            {
                Console.WriteLine("Пойдем поедим лучше");
            }

        }
        public abstract class Profi
        {
            public abstract void Crying();
        }
        public class HighSchoolKid : Profi
        {
            public HighSchoolKid()
            {
                Console.WriteLine("Скоро ЕГЭ...");
            }
            public override void Crying()
            {
                Console.WriteLine("Я не сдам...");
            }
        }
        class Undergrad : Profi
        {
            public Undergrad()
            {
                Console.WriteLine("Опять работать, а потом учиться");
            }
            public override void Crying()
            {
                Console.WriteLine("Диплоооооом");
            }

        }
        // абстрактная фабрика
        public abstract class Education
        {
            public abstract Kid CreateKid();
            public abstract Young CreateYoung();
            public abstract Profi CreateProfi();
        }
        public class School : Education
        {
            public override Kid CreateKid()
            {
                return new Junior();
            }
            public override Young CreateYoung()
            {
                return new MiddleSchoolKid();
            }
            public override Profi CreateProfi()
            {
                return new HighSchoolKid();
            }
        }
        public class University : Education
        {
            public override Kid CreateKid()
            {
                return new Freshman();
            }
            public override Young CreateYoung()
            {
                return new Upperclassman();
            }
            public override Profi CreateProfi()
            {
                return new Undergrad();
            }
        }
        public class Controller
        {
            Education level;
            public Controller(Education level)
            {
                this.level = level;
            }
            public void PlayLife()
            {
                Kid kid = level.CreateKid();
                Young young = level.CreateYoung();
                Profi profi = level.CreateProfi();

                kid.DoHomework();
                young.Skipping();
                profi.Crying();
            }
        }
        static void Main(string[] args)
        {
            // абстрактная фабрика
            Controller scotn = new Controller(new School());
            Controller ucotn = new Controller(new University());

            scotn.PlayLife();
            ucotn.PlayLife();
        }
    }
}