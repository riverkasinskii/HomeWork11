namespace testHomeWork11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
{
                Console.WriteLine("\n\t\tБаза данных банка: <<Несите ваши денюжки>>\n");
                Console.WriteLine("Если в системе менеджер. Введите manager:\n");
                Console.WriteLine("Если в системе консультант. Введите consultant:\n");

                string? login = Console.ReadLine();

                switch (login)
                {
                    case "manager":
                        {
                            do
                            {
                                Console.Clear();
                                Manager manager = new();
                                Console.WriteLine("\nПоказать клиента на экране по ID. Нажмите 1:\n");
                                Console.WriteLine("Изменить номер телефона клиента по ID. Нажмите 2:\n");
                                Console.WriteLine("Добавить нового клиента по ID. Нажмите 3:\n");
                                Console.WriteLine("Отредактировать данные о клиенте. Нажмите 4:\n");

                                int choise = Convert.ToInt32(Console.ReadLine());

                                switch (choise)
                                {
                                    case 1:
                                        {
                                            var clients = manager.GetAll();
                                            Console.WriteLine("\nВведите ID  для вывода на экран\n");
                                            int clientId = Convert.ToInt32(Console.ReadLine());
                                            var getClientId = manager.GetById(clientId);

                                            foreach (var client in clients)
                                            {
                                                if (clientId == client.ID)
                                                {
                                                    manager.ShowClient(client);
                                                }
                                            }
                                            if (getClientId == null)
                                            {
                                                Console.WriteLine("\nНет клиента под таким ID.");
                                            }
                                            break;
                                        }

                                    case 2:
                                        {
                                            Console.WriteLine("\nВведите ID клиента для редактирования номера телефона\n");

                                            int clientId = Convert.ToInt32(Console.ReadLine());

                                            var client = manager.GetById(clientId);

                                            if (client != null)
                                            {
                                                client.ID = clientId;

                                                Console.WriteLine("\nВведите новый номер телефона клиента: \n");
                                                client.PhoneNumber = Console.ReadLine()!;

                                                client.RecordChange = DateTime.Now; //Дата изменения записи

                                                client.DataHasBeenChanged = "Номер телефона"; //Какие данные были изменены

                                                client.ChangeType = "Редактирование"; //Тип изменений

                                                client.WhoChangedData = "Менеджер"; //Кто отредактировал данные

                                                manager.UpdateClient(client);
                                                manager.SaveChangesFileTxt();

                                                Console.WriteLine("\nЗапись отредактирована.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nКлиента с таким ID нет в базе данных\n");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("\nВведите данные клиента");

                                            Client client = new();

                                            Console.Write("\nВведите ID: ");
                                            int clientId = int.Parse(Console.ReadLine()!);
                                            var getClientId = manager.GetById(clientId);
                                            if (getClientId == null)
                                            {
                                                client.ID = clientId;

                                                Console.Write("\nВведите фамилию: ");
                                                client.Surname = Console.ReadLine();

                                                Console.Write("\nВведите имя: ");
                                                client.Name = Console.ReadLine();

                                                Console.Write("\nВведите отчество: ");
                                                client.Patronymic = Console.ReadLine();

                                                Console.Write("\nВведите номер телефона: ");
                                                client.PhoneNumber = Console.ReadLine();

                                                Console.Write("\nВведите данные паспорта: ");
                                                client.Passport = Console.ReadLine();

                                                client.RecordChange = DateTime.Now; //Дата создания записи

                                                client.DataHasBeenChanged = "Новая запись"; //Какие данные были изменены

                                                client.ChangeType = "Добавление"; //Тип изменений

                                                client.WhoChangedData = "Менеджер"; //Кто добавил данные о клиенте

                                                Console.WriteLine("\nЗапись создана.");

                                                manager.Create(client);
                                                manager.SaveChangesFileTxt();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nКлиент с таким ID есть в базе. Введите другой ID");
                                            }

                                        }
                                        break;
                                    case 4:
                                        {
                                            Console.WriteLine("\nВведите ID клиента для редактирования\n");
                                            var clientId = int.Parse(Console.ReadLine()!);

                                            var client = manager.GetById(clientId);

                                            if (client != null)
                                            {                                                
                                                client.ID = clientId;

                                                Console.Write("\nВведите фамилию: ");
                                                client.Surname = Console.ReadLine();

                                                Console.Write("\nВведите имя: ");
                                                client.Name = Console.ReadLine();

                                                Console.Write("\nВведите отчество: ");
                                                client.Patronymic = Console.ReadLine();

                                                Console.Write("\nВведите номер телефона: ");
                                                client.PhoneNumber = Console.ReadLine();

                                                Console.Write("\nВведите данные паспорта: ");
                                                client.Passport = Console.ReadLine();

                                                client.RecordChange = DateTime.Now; //Дата редактирования записи

                                                client.DataHasBeenChanged = "Все данные о клиенте"; //Какие данные были изменены

                                                client.ChangeType = "Редактирование"; //Тип изменений

                                                client.WhoChangedData = "Менеджер"; //Кто отредактировал данные о клиенте

                                                Console.WriteLine("\nЗапись отредактирована.");

                                                manager.UpdateClient(client);
                                                manager.SaveChangesFileTxt();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nКлиента с таким ID нет в базе");
                                            }
                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("Введены некорректные данные!");
                                        }
                                        break;
                                }
                                Console.WriteLine("\nДля продолжения работы нажмите Enter," +
                                    " для возврата в предыдущее меню нажмите любую другую клавишу.\n");
                            } while (Console.ReadKey().Key == ConsoleKey.Enter);
                        }
                        break;

                    case "consultant":
                        {
                            do
                            {
                                Console.Clear();
                                Consultant consultant = new();
                                Console.WriteLine("\nПоказать клиента на экране по ID. Нажмите 1:\n");
                                Console.WriteLine("Изменить номер телефона клиента по ID. Нажмите 2:\n");

                                int choise = Convert.ToInt32(Console.ReadLine());

                                switch (choise)
                                {
                                    case 1:
                                        {
                                            var clients = consultant.GetAll();
                                            Console.WriteLine("\nВведите ID сотрудника для вывода на экран\n");
                                            int clientId = Convert.ToInt32(Console.ReadLine());
                                            var getClientId = consultant.GetById(clientId);

                                            foreach (var client in clients)
                                            {
                                                if (clientId == client.ID)
                                                {
                                                    consultant.ShowClient(client);
                                                }
                                            }
                                            if (getClientId == null)
                                            {
                                                Console.WriteLine("\nНет клиента под таким ID.");
                                            }
                                            break;
                                        }

                                    case 2:
                                        {
                                            Console.WriteLine("\nВведите ID клиента для редактирования номера телефона\n");

                                            int clientId = Convert.ToInt32(Console.ReadLine());

                                            var client = consultant.GetById(clientId);

                                            if (client != null)
                                            {
                                                client.ID = clientId;

                                                Console.WriteLine("\nВведите новый номер телефона клиента: \n");
                                                client.PhoneNumber = Console.ReadLine()!;

                                                client.RecordChange = DateTime.Now; //Дата изменения записи

                                                client.DataHasBeenChanged = "Номер телефона"; //Что было изменено

                                                client.ChangeType = "Редактирование"; //Тип изменений

                                                client.WhoChangedData = "Консультант"; //Кто изменил данные

                                                consultant.UpdateClient(client);

                                                consultant.SaveChangesFileTxt();

                                                Console.WriteLine("\nНомер телефона отредактирован.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nКлиента с таким ID нет в базе данных\n");
                                            }
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine("Введены некорректные данные!");
                                        }
                                        break;
                                }
                                Console.WriteLine("\nДля продолжения работы нажмите Enter," +
                                    " для возврата в предыдущее меню нажмите любую другую клавишу.\n");
                            } while (Console.ReadKey().Key == ConsoleKey.Enter);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nВведены некорректные данные!");
                        }
                        break;
                }
                Console.WriteLine("\nДля выбора пользователя в системе нажмите Enter," +
                    " для выхода из программы нажмите любую клавишу\n");
            } while (Console.ReadKey().Key == ConsoleKey.Enter) ;
        }
    }
}