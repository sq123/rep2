﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace обучалка
{
    class airport
    {
        public
        int maxspeed = 700;
        int speed = 0;
        int fuel = 0;
        int maxfuel = 10;
        int height = 0;
        int maxheight = 900;
        bool engine = false;
        public int Getspeed()
        {
            return speed;
        }
        public int Getheight()
        {
            return height;
        }
        public int Getfuel()
        {
            return fuel;
        }

        int ind; //это индекс объекта. это временная переменная, которую можно удалить, если реализуешь иначе. но она пока для того, что бы вызов метода "респаун" не ругался.***
        //но сейчас он нафиг не нужен, так как мы создаём только 1 экземпляр


        public airport()
        {
            fuel = 10;
            Console.WriteLine("Диспетчерская. Система управления самолетами.");

        }
        public void getfuel()  // заправка     
        {
            fuel = maxfuel;
            met.center();
        }
        public void morespeed(int a)   // увелич. скорости
        {

            fuel = fuel - a * maxfuel * 5 / 100;  //на каждое изм. скорости требуется 5 проц от макс кол-ва топлива
            if (speed + a < maxspeed)
            {
                speed = speed + a;
                met.center();
            }
            else
            {
                Console.WriteLine("Нельзя увеличить скорость на данное значение, превышает макс. скорость.");
                met.center();
            }

        }
        public void lessspeed(int a)   // уменьш. скорости
        {

            if (speed - a > 0)
            {
                speed = speed - a;
                met.center();
            }
            else
            {
                speed = 0;
                met.center();
            }
            if (speed < maxspeed / 100)   // при слишком низкой скорости самолет разбивается
            {
                height = 0;
                Console.WriteLine("Слишком низкая скорость. Самолет упал и разбился.");
            }
        }
        public void moreheight(int a)   // увелич. высоты
        {
            fuel = fuel - a * maxfuel / 100;  //на каждое изм. высоты требуется 10 проц от макс кол-ва топлива
            if (height + a < maxspeed)
            {
                height = height + a;
                met.center();
            }
            else
            {
                Console.WriteLine("Нельзя увеличить высоту на данное значение, превышает макс. высоту.");
                met.center();
            }
        }
        public void lessheight(int a)   // уменьш. высоты
        {

            if (height - a > 0)
            {
                height = height - a;
                met.center();
            }
            else   // при уменьш. высоты до уровня земли проверяется скорость самолета, если она слишком большая самолет разбивается
            {
                if (speed > maxspeed * 50 / 100)
                {
                    height = 0;
                    Console.WriteLine("Самолет разбился.");

                }
                else
                {
                    height = 0;
                    Console.WriteLine("Самолет приземлился.");
                    met.center();
                }
            }
        }
        public void startengine()
        {
            engine = true;
            Console.WriteLine("Запуск двигателя.");
            met.center();
        }
        public void stopengine()
        {
            engine = false;
            Console.WriteLine("Отключение двигателя.");
            met.center();

        }
    }


    static class met    //класс-набор методов
    {
        public static airport plane = new airport();//наш любимый самолётик
        static void print_menu()//просто пусть печать юудет в отделном вызываемом методе. в методе центр эта писанина лишняя наверное. да и так удобнее, хотя возможно это просто я так привык делать. 
        {//но если нам понадобится вызвать менюшку хотя бы в 2х и больше мест, то этот метод оправдан. так что считай, что это на вырост
            Console.WriteLine("Введите команду \n 1 - запуск двиг., \n 2 - остановка двиг., \n 3 - заправка, \n 4 - увелич. скорость, \n 5 - уменьшить скорость, \n 6 - увелич. высоту, \n 7 - уменьш. высоту.");
        }
        static void StartProgramm()       //метод, создающий объекты самолёт и заносящий их в Авиапарк. принимаемый параметр = количеству самолётов в авиапарке
        { }//хотя этот метод теперь лишний, но вс равно не удаляй. пусть он будет на будущее. ты там ещё создашь нормальный конструктор Самолёту и тогда заюзаешь

        public static void center()//"метод-интерфейс" для пользователя. показывает менюшку и перенаправляет по выбору.
        {
            Console.ReadKey();
            Console.Clear();
            met.print_menu();//вызов метода-мечати твоей менюшки. там расписанно подробно
            int command = Convert.ToInt32(Console.ReadLine());
            Console.Clear();    //чистим консоль... в эстетических целях)
            int hei = plane.Getheight();
            int speed = plane.Getspeed();
            int fuel = plane.Getfuel();
            if (hei > 0 && fuel == 0)
            {
                Console.WriteLine("Нету топлива на высоте > 0. Самолет упал и разбился.");
                return;
            }
            switch (command)
            {

                case 1:
                    plane.startengine();
                    break;
                case 2:


                    if (hei > 0)  // тут ты обращался просто к полю метода.. но я даже не понимаю как оно бы сработало у тебя в мэине) либо делай все поля пабликами и тогда не мучайся, либо дела Set и Get для каждого поля класса.
                    {
                        Console.WriteLine("Откл. двигателя на высоте > 0. Самолет упал и разбился.");
                    }
                    else
                    {
                        plane.stopengine();
                    }
                    break;
                case 3:
                    if (hei == 0 && speed == 0)
                    {
                        plane.getfuel();
                    }
                    else
                    {
                        Console.WriteLine("Невозможно осущ. заправку при скорости > 0 и при высоте > 0.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите увелич. скорости. (Макс скорость - 700 единиц.)");
                    int i = Convert.ToInt32(Console.ReadLine());
                    plane.morespeed(i);
                    break;
                case 5:
                    Console.WriteLine("Введите уменьш. скорости. (Макс скорость - 700 единиц.)");
                    int j = Convert.ToInt32(Console.ReadLine());
                    plane.lessspeed(j);
                    break;
                case 6:
                    Console.WriteLine("Введите увелич. высоты. (Макс высота - 900 единиц.)");
                    int t = Convert.ToInt32(Console.ReadLine());
                    plane.moreheight(t);
                    break;
                case 7:
                    Console.WriteLine("Введите уменьш. высоты. (Макс высота - 900 единиц.)");
                    int m = Convert.ToInt32(Console.ReadLine());
                    plane.lessheight(m);
                    break;
                default:
                    Console.WriteLine("Введите команду из списка.");
                    met.center();
                    break;
            }

        }
        //met.plane.startengine(); а это пример обращения к полю и тд. вот такую штуку вставь в конце каждого метода-действия. 
    }


    class Program  //базовый класс
    {
        static void Main(string[] args) //точка входа в программу
        {
            met.center();   //просто передача управления в наш метод-интерфейс
            Console.WriteLine("Остановка прогр.");
            Console.ReadKey();
        }
    }
}