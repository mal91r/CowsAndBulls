using System;


namespace PeerGrade1
{
    /// <summary>
    /// Класс Program 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Отбирает рандомные числа в которых нет повторяющихся чисел.
        /// </summary> 
        static void CorrectRandom()
        {
            // Генерируем случайное четырёхзначное число с неповторяющимися цифрами.
            Random rnd = new Random();
            int random = rnd.Next(1000, 10000);

            // Цифры, из которых будет состоять сгенерированное компьютером число.
            int numberR1,
                numberR2,
                numberR3,
                numberR4;
 
            numberR1 = random / 1000;
            
            numberR2 = (random / 100) % 10;
            
            numberR3 = (random / 10) % 10;

            numberR4 = random % 10;

            // Проверяем наличие повторяющихся чисел в сгенерированном компьютером числе.
            if (numberR1 == numberR2)
            {
                CorrectRandom();
            }

            else if (numberR1 == numberR3)
            {
                CorrectRandom();
            }

            else if (numberR1 == numberR4)
            {
                CorrectRandom();
            }

            else if (numberR2 == numberR3)
            {
                CorrectRandom();
            }

            else if (numberR2 == numberR4)
            {
                CorrectRandom();
            }

            else if (numberR3 == numberR4)
            {
                CorrectRandom();
            }

            else
            {
                Console.WriteLine($"{Environment.NewLine}Вы можете на выбор выбрать упрощенный режим(в котором сразу отобразится сгенерированное компьютером число) или " +
                                   $"{Environment.NewLine}обычный(в котором вы должны пройти игру сами)");
                Console.WriteLine($"{Environment.NewLine}Если вы хотите выбрать упрощенный режим то напишите: Ok (на английском)" +
                                  $"{Environment.NewLine}Если вы хотите выбрать обычный режим то напишите: No (на английском)");
                Console.Write($"{Environment.NewLine}Ваш ответ: ");
                string answer = Console.ReadLine();

                SwitchAnswerMode(answer, random);
            }
        }

        /// <summary>
        /// Предназначен для повторения последовательности циклов отгадывания числа.
        /// </summary>
        /// <param name="random">Число сгенерированное компьютером</param>
        static void Guees(int random)
        {
            // Цифра, которую введёт пользователь.
            int i;
            Console.Write($"{Environment.NewLine}Ваше предположение: ");
            string str = Console.ReadLine();
            int.TryParse(str, out i);

            ErrorControl(str, random);

            NumberRepeatControl(str, random);

            // Цифры, из которых состоит введённое человеком число.
            int numberi1,
                numberi2,
                numberi3,
                numberi4;

            numberi1 = i / 1000;
         
            numberi2 = (i / 100) % 10;
          
            numberi3 = (i / 10) % 10;
          
            numberi4 = i % 10;


            // Цифры, из которых состоит сгенерированное компьютером число.
            int numberR1,
                numberR2,
                numberR3,
                numberR4;

            numberR1 = random / 1000;

            numberR2 = (random / 100) % 10;

            numberR3 = (random / 10) % 10;

            numberR4 = random % 10;

            HowMuchBulls(numberi1, numberi2, numberi3, numberi4, numberR1, numberR2, numberR3, numberR4);

            HowMuchCows(numberi1, numberi2, numberi3, numberi4, numberR1, numberR2, numberR3, numberR4);


            if (random == i)
            {
                Console.WriteLine($"{Environment.NewLine}Поздравляю игра окончена!!! Вы угадали всех \"четырёх быков\"");

                Console.WriteLine("Если вы хотите продолжить игру, то напишите: Ok (на английском)" +
                                "\nЕсли вы хотите завершить программу, то напишите: No (на английском)");
                Console.Write($"{Environment.NewLine}Ваш ответ: ");
                string answer = Console.ReadLine();

                SwitchAnswerGame(answer);

            }

            else
            {
                do
                {
                    Console.WriteLine($"{Environment.NewLine}Следующая попытка");
                    Guees(random);
                }
                while (random == i);
            }
        }

        /// <summary>
        /// Контролирует корректность входных данных.
        /// </summary>
        /// <param name="str">Число введенное пользователем</param>
        /// <param name="random">Число сгенерированное компьютером</param>
        static void ErrorControl(string str, int random)
        {
            // Возможность преобразования строки в число.
            if (!int.TryParse(str, out int i))
            {
                Console.WriteLine($"{Environment.NewLine}Некорректная запись!!! Повторите ввод");
                Guees(random);
                return;
            }

            // Область допустимых значений.
            else if (i < 1000)
            {
                Console.WriteLine($"{Environment.NewLine}Слишком маленькое число!!! Повторите ввод");
                Guees(random);
                return;
            }

            // Область допустимых значений.
            else if (i >= 10000)
            {
                Console.WriteLine($"{Environment.NewLine}Слишком большое число!!! Повторите ввод");
                Guees(random);
                return;
            }
        }

        /// <summary>
        /// Контролирует повторяющиеся цифры в числе, введённым человеком.
        /// </summary>
        /// <param name="str">Число введенное пользователем</param>
        /// <param name="random">Число сгенерированное компьютером</param>
        static void NumberRepeatControl(string str, int random)
        {
            int.TryParse(str, out int i);

            // Цифры, из которых состоит введённое человеком число.
            int numberi1, numberi2, numberi3, numberi4;

            numberi1 = i / 1000;

            numberi2 = (i / 100) % 10;

            numberi3 = (i / 10) % 10;

            numberi4 = i % 10;

            // Проверяем повторения цифр в числе.
            if (numberi1 == numberi2)
            {
                Console.WriteLine($"{Environment.NewLine}В числе есть повторяющиеся числа!!! Будьте внимательны");
                Guees(random);
                return;
            }

            else if (numberi1 == numberi3)
            {
                Console.WriteLine($"{Environment.NewLine}В числе есть повторяющиеся числа!!! Будьте внимательны");
                Guees(random);
                return;
            }

            else if (numberi1 == numberi4)
            {
                Console.WriteLine($"{Environment.NewLine}В числе есть повторяющиеся числа!!! Будьте внимательны");
                Guees(random);
                return;
            }

            else if (numberi2 == numberi3)
            {
                Console.WriteLine($"{Environment.NewLine}В числе есть повторяющиеся числа!!! Будьте внимательны");
                Guees(random);
                return;
            }

            else if (numberi2 == numberi4)
            {
                Console.WriteLine($"{Environment.NewLine}В числе есть повторяющиеся числа!!! Будьте внимательны");
                Guees(random);
                return;
            }

            else if (numberi3 == numberi4)
            {
                Console.WriteLine($"{Environment.NewLine}В числе есть повторяющиеся числа!!! Будьте внимательны");
                Guees(random);
                return;
            }
        }

        /// <summary>
        /// Считает количество угаданных быков.
        /// </summary>
        /// <param name="numberi1">Первая цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberi2">Вторая цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberi3">Третья цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberi4">Четвёртая цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberR1">Первая цифра числа, сгенерированное компьютером</param>
        /// <param name="numberR2">Вторая цифра числа, сгенерированное компьютером</param>
        /// <param name="numberR3">Третья цифра числа, сгенерированное компьютером</param>
        /// <param name="numberR4">Четвёртая цифра числа, сгенерированное компьютером</param>
        static void HowMuchBulls(int numberi1, int numberi2, int numberi3, int numberi4, int numberR1, int numberR2, int numberR3, int numberR4)
        {

            // Если угаданы все быки.
            if ((numberi1 == numberR1) && (numberi2 == numberR2) && (numberi3 == numberR3) && (numberi4 == numberR4))
            {
                return;
            }

            // Если угадано трое быков.
            if (((numberi1 == numberR1) && (numberi2 == numberR2) && (numberi3 == numberR3)) ||
                ((numberi1 == numberR1) && (numberi2 == numberR2) && (numberi4 == numberR4)) ||
                ((numberi1 == numberR1) && (numberi3 == numberR3) && (numberi4 == numberR4)) ||
                ((numberi2 == numberR2) && (numberi3 == numberR3) && (numberi4 == numberR4)))
            {
                Console.WriteLine("Вы отгадали трёх быков");
                return;
            }

            // Если угадано два быка.
            if (((numberi1 == numberR1) && (numberi2 == numberR2)) ||
                ((numberi1 == numberR1) && (numberi3 == numberR3)) ||
                ((numberi1 == numberR1) && (numberi4 == numberR4)) ||
                ((numberi2 == numberR2) && (numberi3 == numberR3)) ||
                ((numberi2 == numberR2) && (numberi4 == numberR4)) ||
                ((numberi3 == numberR3) && (numberi4 == numberR4)))
            {
                Console.WriteLine("Вы отгадали двух быков");
                return;
            }

            // Если угадан один бык.
            if ((numberi1 == numberR1) || (numberi2 == numberR2) || (numberi3 == numberR3) || (numberi4 == numberR4))
            {
                Console.WriteLine("Вы отгадали одного быка");
            }

        }

        /// <summary>
        /// Считает количество угаданных коров.
        /// </summary>
        /// <param name="numberi1">Первая цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberi2">Вторая цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberi3">Третья цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberi4">Четвёртая цифра числа, которую ввёл пользователь</param> 
        /// <param name="numberR1">Первая цифра числа, сгенерированное компьютером</param>
        /// <param name="numberR2">Вторая цифра числа, сгенерированное компьютером</param>
        /// <param name="numberR3">Третья цифра числа, сгенерированное компьютером</param>
        /// <param name="numberR4">Четвёртая цифра числа, сгенерированное компьютером</param>
        static void HowMuchCows(int numberi1, int numberi2, int numberi3, int numberi4, int numberR1, int numberR2, int numberR3, int numberR4)
        {
            // Если угаданы все быки.
            if ((numberi1 == numberR1) && (numberi2 == numberR2) && (numberi3 == numberR3) && (numberi4 == numberR4))
            {
                return;
            }

            // Количество угаданных коров. По умолчанию количество равно нулю.
            int n = 0;

            // Возможное количество коров, если угаданы первый и второй быки.
            if ((numberi1 == numberR1) && (numberi2 == numberR2))
            {
                if (numberi3 == numberR4)
                {
                    ++n;
                }

                if (numberi4 == numberR3)
                {
                    ++n;
                }

                Cows(n);

                return;
            }

            // Возможное количество коров, если угаданы первый и третьи быки.
            if ((numberi1 == numberR1) && (numberi3 == numberR3))
            {
                if (numberi2 == numberR4)
                {
                    ++n;
                }

                if (numberi4 == numberR2)
                {
                    ++n;
                }

                Cows(n);

                return;
            }

            // Возможное количество коров, если угаданы первый и четвёртый быки.
            if ((numberi1 == numberR1) && (numberi4 == numberR4))
            {
                if (numberi2 == numberR3)
                {
                    ++n;
                }

                if (numberi3 == numberR2)
                {
                    ++n;
                }

                Cows(n);

                return;
            }

            // Возможное количество коров, если угаданы второй и третьи быки.
            if ((numberi2 == numberR2) && (numberi3 == numberR3))
            {
                if (numberi1 == numberR4)
                {
                    ++n;
                }

                if (numberi4 == numberR1)
                {
                    ++n;
                }

                Cows(n);

                return;
            }

            // Возможное количество коров, если угаданы второй и четвёртый быки.
            if ((numberi2 == numberR2) && (numberi4 == numberR4))
            {
                if (numberi1 == numberR3)
                {
                    ++n;
                }

                if (numberi3 == numberR1)
                {
                    ++n;
                }

                Cows(n);

                return;
            }

            // Возможное количество коров, если угаданы третий и четвёртый быки.
            if ((numberi3 == numberR3) && (numberi4 == numberR4))
            {
                if (numberi1 == numberR2)
                {
                    ++n;
                }

                if (numberi2 == numberR1)
                {
                    ++n;
                }

                Cows(n);

                return;
            }

            // Возможное количество коров, если угадан первый бык.
            if (numberi1 == numberR1)
            {
                if ((numberi2 == numberR3) || (numberi2 == numberR4))
                {
                    ++n;
                }

                if ((numberi3 == numberR2) || (numberi3 == numberR4))
                {
                    ++n;
                }

                if ((numberi4 == numberR2) || (numberi4 == numberR3))
                {
                    ++n;
                }
            }

            // Возможное количество коров, если угадан второй бык.
            if (numberi2 == numberR2)
            {
                if ((numberi1 == numberR3) || (numberi1 == numberR4))
                {
                    ++n;
                }

                if ((numberi3 == numberR1) || (numberi3 == numberR4))
                {
                    ++n;
                }

                if ((numberi4 == numberR1) || (numberi4 == numberR3))
                {
                    ++n;
                }
            }

            // Возможное количество коров, если угадан третий бык.
            if (numberi3 == numberR3)
            {
                if ((numberi1 == numberR2) || (numberi1 == numberR4))
                {
                    ++n;
                }

                if ((numberi2 == numberR1) || (numberi2 == numberR4))
                {
                    ++n;
                }

                if ((numberi4 == numberR1) || (numberi4 == numberR2))
                {
                    ++n;
                }
            }

            // Возможное количество коров, если угадан четвёртый бык.
            if (numberi4 == numberR4)
            {
                if ((numberi1 == numberR2) || (numberi1 == numberR3))
                {
                    ++n;
                }

                if ((numberi2 == numberR1) || (numberi2 == numberR3))
                {
                    ++n;
                }

                if ((numberi3 == numberR1) || (numberi3 == numberR2))
                {
                    ++n;
                }
            }

            // Возможное количество коров, если не угадан ни один бык.
            if ((numberi1 != numberR1) && (numberi2 != numberR2) && (numberi3 != numberR3) && (numberi4 != numberR4))
            {
                if ((numberi1 == numberR2) || (numberi1 == numberR3) || (numberi1 == numberR4))
                {
                    ++n;
                }

                if ((numberi2 == numberR1) || (numberi2 == numberR3) || (numberi2 == numberR4))
                {
                    ++n;
                }

                if ((numberi3 == numberR1) || (numberi3 == numberR2) || (numberi3 == numberR4))
                {
                    ++n;
                }

                if ((numberi4 == numberR1) || (numberi4 == numberR2) || (numberi4 == numberR3))
                {
                    ++n;
                }

                // Когда вообще ничего не угадано.
                if (n == 0)
                {
                    Console.WriteLine("Вы не угадали ни одного быка\nВы не угадали ни одну корову");
                }
            }

            Cows(n);
        }

        /// <summary>
        /// Выводит количество угаданных коров.
        /// </summary>
        /// <param name="n">Количество угаданных коров</param>
        static void Cows(int n)
        {
            switch (n)
            {
                case 1:
                    Console.WriteLine($"{Environment.NewLine}Вы отгадали одну корову");
                    break;
                case 2:
                    Console.WriteLine($"{Environment.NewLine}Вы отгадали двух коров");
                    break;
                case 3:
                    Console.WriteLine($"{Environment.NewLine}Вы отгадали трёх коров");
                    break;
                case 4:
                    Console.WriteLine($"{Environment.NewLine}Вы отгадали четырех коров");
                    break;
            }
        }

        /// <summary>
        /// Предлагает пользователю завершить программу или начать игру снова.
        /// </summary>
        /// <param name="answer">Ответ пользователя</param>
        static void SwitchAnswerGame(string answer)
        {
            switch (answer)
            {
                case "Ok":
                    Console.WriteLine($"{Environment.NewLine}\tНачилась новая игра");
                    CorrectRandom();
                    break;

                case "No":
                    Console.WriteLine("Для выхода нажмите Enter");
                    break;

                default:
                    Console.WriteLine($"{Environment.NewLine}Вы ввели некорректную запись");
                    Console.Write($"{Environment.NewLine}Повторите ответ: ");
                    string repeatAnswer = Console.ReadLine();
                    SwitchAnswerGame(repeatAnswer);
                    break;
            }
        }

        /// <summary>
        /// Метод SwitchAnswerMode предлагает пользователю выбрать режим игры.
        /// </summary>
        /// <param name="answer">Ответ пользователя</param> 
        /// <param name="random">Число сгенерированное компьютером</param>
        static void SwitchAnswerMode(string answer, int random)
        {
            switch (answer)
            {
                case "Ok":
                    Console.WriteLine($"{Environment.NewLine}Включён упрощенный режим!!!");
                    Console.WriteLine("Число сгенерированное компьютером: " + random);
                    Guees(random);
                    break;

                case "No":
                    Console.WriteLine($"{Environment.NewLine}Включен обычный режим!!!");
                    Guees(random);
                    break;

                default:
                    Console.WriteLine($"{Environment.NewLine}Вы ввели некорректную запись");
                    Console.Write($"{Environment.NewLine}Повторите ответ: ");
                    string repeatAnswer = Console.ReadLine();
                    SwitchAnswerMode(repeatAnswer, random);
                    break;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nCейчас компьютер загадает четырёхзначное число с неповторяющимися цифрами. Попытайтесь отгадать это число.");
            Console.WriteLine("В игре действуют следующие правила: ");
            Console.WriteLine("\t1. \"Коровы\" - это цифры, из которых состоит число, но цифр не расположенных на своих местах");
            Console.WriteLine("\t2. \"Быки\" - это цифры, из которых состоит число, но цифр расположенных на своих местах");
            Console.WriteLine("\tНапример: если компьютер сгенерировал число 1234, а вы ввели 1354, значит вы угадали двух быков и одну корову");
            Console.WriteLine("\t3. Игра продолжается до тех пор, пока вы не угадаете загаданное число, т.е. \"четыре быка\"");
            Console.WriteLine($"{Environment.NewLine}Игра начилась!!!");

            CorrectRandom();

        }
    }
}
