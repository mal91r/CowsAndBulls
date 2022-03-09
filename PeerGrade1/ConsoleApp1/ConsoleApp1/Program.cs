using System;
using System.Linq;

namespace ConsoleApp1
{
    static class Program
    {
        /// <summary> 
        /// Осоновное тело программы
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Добро подаловать в игру \"Быки и коровы\"!");
            Greating(); //возможность почитать правила или просто начать игру
            int len = NumLength();//прошу пользователя ввести длину числа
            int[] mas = new int[len]; //представление загаданного числа в виде массива
            for (int i = 0; i < mas.Length; i++)//для того, чтобы можно было заполнять рандомным нулем дальше 
            {
                mas[i] = -1;
            }
            Generation(ref mas);//Генерирую случайное len-значное число
            int bulls; //вспомогательная переменная, в нее сохраняется количество быков, что помогает определить конец игры
            do
            {
                bulls = Game(mas); //процесс игры
                if (bulls == len)
                {
                    Console.WriteLine("Игра окончена, вы угадали! ");
                }
                else
                {
                    Console.WriteLine("Упп-с, ошибка.. Игра продолжается!");
                }
            } while (bulls != len);
            Console.Write("Было загадано число ");
            foreach (var number in mas)
            {
                Console.Write(number);
            }
            Console.WriteLine("");
            Console.WriteLine("Хотите сыграть еще раз? Введите \"Start\". Для завершения игры введите любой другой текст.");
            string repeat = Console.ReadLine();
            if (repeat == "Start") //реализация возможности сыграть еще раз
            {
                Main();
            }
        }

        /// <summary> 
        /// правила
        /// </summary>
        static void Settings() 
        {
            Console.WriteLine("Быки и коровы — логическая игра, в ходе которой за несколько попыток один из игроков должен определить, что задумал другой игрок. " +
                "Варианты игры могут зависеть от типа отгадываемой последовательности — это могут быть числа, цвета, пиктограммы или слова. " +
                "После каждой попытки задумавший игрок выставляет «оценку», указывая количество угаданного без совпадения с их позициями (количество «коров») и полных совпадений (количество «быков»).");
            Console.WriteLine("Для начала игры введите \"Start\".");
            while (Console.ReadLine() != "Start")
            {
                Console.WriteLine("Ошибка. Неизвестная команда.");
            }
        }

        /// <summary> 
        /// меню игры
        /// </summary>
        static void Greating() 
        {
            Console.WriteLine("Чтобы ознакомиться с правилами, введите \"Правила\". Для начала игры ввердите \"Start\".");
            string s = Console.ReadLine();
            if (s == "Правила")
            {
                Settings();
            }
            else if (s == "Start")
            {
                Console.WriteLine("Игра начинается!");
            }
            else
            {
                Console.WriteLine("Ошибка. Неизвестная команда.");
                Greating();
            }
        }

        /// <summary> 
        /// запрос длины числа у пользователя
        /// </summary>
        static int NumLength() 
        {
            int length = 0;
            do
            {
                Console.WriteLine("Введите длину угадываемого числа(число от 1 до 10)");
                if (!int.TryParse(Console.ReadLine(), out length) || length <= 0 || length > 10)
                {
                    Console.WriteLine("Ошибка ввода..");
                }
            } while (length <= 0 || length > 10);
            return length;
        }


        /// <summary> 
        /// генерация случайного числа
        /// </summary>
        static void Generation(ref int[] mas) 
        {
            Random rand = new Random();
            mas[0] = rand.Next(1, 10);//задаю значение первому элементу массива(числа)
            for (int i = 1; i < mas.Length; i++)//создаю число, генерируя каждую цифру отдельно
            {
                int x = rand.Next(0, 10);

                if (!mas.Contains(x)) //если сгенерированная цифра не входит в число
                {
                    mas[i] = x;
                }
                else
                {
                    i--;
                }
            }
            Console.WriteLine("Число загадано!");
        }



        /// <summary> 
        /// ввод числа пользователем и реализация игры
        /// </summary>
        static int Game(int[] mas) 
        {
            string number;
            do
            {
                Console.WriteLine($"Введите {mas.Length}-значное число.");
                number = Console.ReadLine();
                if (number.Length != mas.Length)
                {
                    Console.WriteLine($"Число должно быть {mas.Length}-значным.");
                    return 0;
                }
                else if (!int.TryParse(number, out _))
                {
                    Console.WriteLine($"Необходимо ввести целое число.");
                    return 0;
                }
                else if (number[0] == '0')
                {
                    Console.WriteLine($"Число не может начинаться с 0.");
                    return 0;
                }
            } while (number.Length != mas.Length || !int.TryParse(number, out _) || number[0] == '0'); //обработка исключений



            int cows = 0, bulls = 0;
            for (int i = 0; i < number.Length; i++) //подсчет коров и быков
            {
                if (mas.Contains(number[i] - '0'))
                {
                    cows++;
                    if (number[i] - '0' == mas[i])
                    {
                        bulls++;
                    }
                }
            }
            Console.WriteLine($"Коровы: {cows}. Быки: {bulls}.");
            return bulls;
        }

    }
}
