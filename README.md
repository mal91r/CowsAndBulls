# CowsAndBulls
Необходимо разработать консольное приложение – игру «Быки и коровы»1
.
Алгоритм игры: 
1. Компьютер загадывает четырёхзначное число, состоящее из 
неповторяющихся цифр (никакая цифра не может присутствовать в 
числе дважды, число не может начинаться с нуля). Для генерации 
случайного числа необходимо использовать методы библиотечного 
класса Random2
.
2. Затем пользователь, пытаясь угадать загаданное число, вводит 
четырёхзначное число.

3. Компьютер выводит сообщение о том, сколько цифр (коров) угадано, но 
не расположено на своих местах, и сколько цифр (быков) угадано и
находится на своих местах.
1 https://en.wikipedia.org/wiki/Bulls_and_Cows
2 https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-5.0
4. После чего пользователь переходит к п.2. Раунды продолжаются до тех 
пор, пока пользователь не отгадает загаданное число (т.е. получит 
четыре “быка”).
