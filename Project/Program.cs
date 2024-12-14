using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {


            ShowUser();







            {
                //    (string Name, string Surname, uint Age,
                //    string[] NameOfPet, string[] FavColor) User;


                //    //ввод имени
                //    User.Name = GetInput("Введите ваше имя");

                //    //ввод фамилии
                //    User.Surname = GetInput("Введите вашу фамилию");

                //    // ввод возраста
                //    string inputAge = GetInput("Введите ваш возраст");

                //    User.Age = InputNumber(inputAge);

                //    //ввод данных о питомце
                //    string pet = GetInput("Есть ли у вас животные");
                //    uint numberOfPet = pet == "Да" ? InputNumber(GetInput("Сколько у вас питомцев")) : 0;
                //    User.NameOfPet = HasPet(ref numberOfPet);

                //    //ввод любимых цветов
                //    uint NumberOfColor = InputNumber(GetInput("Сколько у вас любимых цветов: "));
                //    User.FavColor = FavColor(ref NumberOfColor);

                //    Console.Clear();


                //    Console.WriteLine($"Ваше имя: {User.Name}");
                //    Console.WriteLine($"Ваша фамилия:  {User.Surname}");
                //    Console.WriteLine($"Ваш возраст: {User.Age}");

                //    if (pet == "Да")
                //    {
                //        Console.WriteLine($"У вас питомцев: {numberOfPet}, и зовут их:");
                //        ShowArray(ref User.NameOfPet);
                //    }
                //    else
                //    {
                //        Console.WriteLine("Жаль что у вас нет живности((");
                //    }

                //    Console.WriteLine($"Количество ваших любимых цветов: {NumberOfColor}. \nИ вам нравятся такие цвета как:   ");
                //    ShowArray(ref User.FavColor);
            }



        }


        static (string Name, string Surname, uint Age, uint NumberOfPet, string[] NameOfPet, string[] FavColor) EnterUser()
        {
            (string Name, string Surname, uint Age, uint NumberOfPet, string[] NameOfPet, string[] FavColor) User;

            //ввод имени
            User.Name = GetInput("Введите ваше имя");

            //ввод фамилии
            User.Surname = GetInput("Введите вашу фамилию");

            // ввод возраста
            string inputAge = GetInput("Введите ваш возраст");

            User.Age = InputNumber(inputAge);

            //ввод данных о питомце
            string pet = GetInput("Есть ли у вас животные");
            User.NumberOfPet = 0;
            if (pet == "Да" || pet == "да")
            {
                User.NumberOfPet = InputNumber(GetInput("Сколько у вас питомцев"));
            }

            User.NameOfPet = HasPet(ref User.NumberOfPet);
            Console.WriteLine(User.NumberOfPet);


            //uint numberOfPet = pet == "Да" ? InputNumber(GetInput("Сколько у вас питомцев")) : 0;
            //User.NumberOfPet = numberOfPet;
            //User.NameOfPet = HasPet(ref User.NumberOfPet);

            //ввод любимых цветов
            uint NumberOfColor = InputNumber(GetInput("Сколько у вас любимых цветов: "));
            User.FavColor = FavColor(ref NumberOfColor);

            return User;

        }


        static void ShowUser()
        {
            var User = EnterUser();
            Console.WriteLine($"Ваше имя: {User.Name}");
            Console.WriteLine($"Ваша фамилия:  {User.Surname}");
            Console.WriteLine($"Ваш возраст: {User.Age}");

            Console.WriteLine($"Ваши питомцы:");
            ShowArray(ref User.NameOfPet);


            Console.WriteLine($"Количество ваших любимых цветов:");
            ShowArray(ref User.FavColor);


        }


        //метод задания имен питомцев
        static string[] HasPet(ref uint number)
        {
            string[] result = new string[number];
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Как зовут вашего {i + 1} питомца");
                string Name = Console.ReadLine();
                result[i] = Name;
            }
            return result;
        }

        //метод запроса данных у пользователя
        static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //метод проверки числа
        static uint InputNumber(string number)
        {
            uint uintnumb;
            int intnumb;
            for (; ; )
            {
                bool result = uint.TryParse(number, out uintnumb);
                bool result2 = int.TryParse(number, out intnumb);

                if (result && result2)
                {
                    uintnumb = uint.Parse(number);
                    break;
                }
                else if (result && int.Parse(number) < 0)
                {
                    number = GetInput("Вы ввели 0, введите еще раз");
                }

                else if (result2 && int.Parse(number) < 0)
                {
                    number = GetInput("Вы ввели отрицательное число, введите еще раз");

                }
                else if (result == false)
                {
                    number = GetInput("Вы ввели текст, введите еще раз");

                }
            }
            return uintnumb;
        }

        //метод заполнения массива любимых цветов
        static string[] FavColor(ref uint number)
        {
            string[] result = new string[number];
            for (int i = 0; i < number; i++)
            {
                string Name = GetInput($"Введите {i + 1} любимый цвет");
                result[i] = Name;
            }
            return result;
        }

        static string[] ShowArray(ref string[] array)
        {
            string[] result = array;

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {result[i]} ");
            }

            return result;
        }
    }
}
