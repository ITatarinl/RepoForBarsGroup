using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroup
{
    internal class Program
    {
        /*1. Создать новое консольное приложение.
        2. Создать класс, содержащий событие OnKeyPressed с типом EventHander<char>.
        3. Добавить в созданный класс метод Run, выполняющий в цикле чтение введённого символа и публикацию события OnKeyPressed.
        Если нажат символ 'c', выходить из цикла.
        4. Создать экземпляр класса, подписаться на событие.В обработчике события выводить нажатый символ к консоль. */

        static void Main(string[] args)
        {
            var task = new Task();
            task.OnKeyPressed += PrintChar;
            task.Run();

            void PrintChar(object sender, char let)
            {
                Console.WriteLine($" Symbol: {let}");
            }
        }
    }

    public class Task
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            bool quit = true;
            while (quit)
            {
                Console.Write("Press the button:");
                var let = Console.ReadKey();
                Console.WriteLine();

                switch (let.KeyChar)
                {
                    case 'с'://russian c
                        quit = false;
                        break;
                    case 'c'://english c
                        quit = false;
                        break;
                    default:
                        OnKeyPressed?.Invoke(this, let.KeyChar);
                        break;
                }

            }
        }
    }
}
