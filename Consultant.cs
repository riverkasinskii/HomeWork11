namespace testHomeWork11
{
    internal class Consultant : IChangeable
    {
        /// <summary>
        ///  Свойство хранящее клиентов
        /// </summary>
        private protected List<Client> Client { get; set; }

        /// <summary>
        /// Конструктор для получения информации о клиенте, консультантом
        /// </summary>
        public Consultant()
        {
            Client = new List<Client>();
            Client = GetClientFromFileTxt();
        }

        /// <summary>
        /// Метод получения всех клиентов из списка
        /// </summary>
        /// <returns></returns>
        public List<Client> GetAll()
        {
            return Client;
        }

        /// <summary>
        /// Метод получения списка клиентов из файла
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClientFromFileTxt()
        {
            var clients = new List<Client>();
            GetInfoFile("database.txt");
            string[] clientsTxt = File.ReadAllLines("database.txt");
            foreach (var clientLine in clientsTxt)
            {
                Client client = StringSplitClient(clientLine);
                clients.Add(client);
            }
            return clients;
        }

        /// <summary>
        /// Вспомогательный метод проверки создания файла базы хранения списка клиентов
        /// </summary>
        /// <param name="fileInfo"></param>
        public static void GetInfoFile(string fileInfo)
        {
            FileInfo file = new(fileInfo);
            if (file.Exists)
            {
                
            }
            else
            {
                file.Create();
            }
        }
        

        /// <summary>
        /// Метод сокрытия данных паспорта для консультанта
        /// </summary>
        public virtual void ShowClient(Client client)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"" +
                $"ID: {client.ID}" +
                $" |Фамилия: {client.Surname}" +
                $" |Имя: {client.Name}" +
                $" |Отчество: {client.Patronymic}" +
                $" |Номер телефона: {client.PhoneNumber}" +
                $" |Паспорт: *********" +
                $" \nИзменение записи: {client.RecordChange:g}" +
                $" \nЧто изменено: {client.DataHasBeenChanged}" +
                $" \nТип изменений: {client.ChangeType}" +
                $" \nДанные изменил: {client.WhoChangedData}");
        }

        /// <summary>
        /// Метод разделения клиента на поля класса Client
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Client StringSplitClient(string value)
        {
            string[] arrayClient = value.Split('#');
            int ID = int.Parse(arrayClient[0]);
            string Surname = arrayClient[1];
            string Name = arrayClient[2];
            string Patronymic = arrayClient[3];
            string PhoneNumber = arrayClient[4];
            string Passport = arrayClient[5];
            DateTime RecordChange = DateTime.Parse(arrayClient[6]);
            string DataHasBeenChanged = arrayClient[7];
            string ChangeType = arrayClient[8];
            string WhoChangedData = arrayClient[9];

            Client client = new(
                ID,
                Surname,
                Name,
                Patronymic,
                PhoneNumber,
                Passport,
                RecordChange,
                DataHasBeenChanged,
                ChangeType,
                WhoChangedData
                );
            return client;
        }

        /// <summary>
        /// Метод редактирования клиента по ID
        /// </summary>
        /// <param name="client"></param>
        public virtual void UpdateClient(Client client)
        {
            var oldClient = Client
                .FirstOrDefault(e => e.ID == client.ID);
            Client.Remove(oldClient!);
            Client.Add(client);
        }

        /// <summary>
        /// Метод сохранения изменений
        /// </summary>
        public void SaveChangesFileTxt()
        {
            using (StreamWriter sw = new("database.txt", false))
            {
                foreach (var client in Client)
                {
                    sw.WriteLine(client.ID + "#" +
                                 client.Surname + "#" +
                                 client.Name + "#" +
                                 client.Patronymic + "#" +
                                 client.PhoneNumber + "#" +
                                 client.Passport + "#" +
                                 client.RecordChange.ToString("g") + "#" +
                                 client.DataHasBeenChanged + "#" +
                                 client.ChangeType + "#" +
                                 client.WhoChangedData);
                }
            }
        }

        /// <summary>
        /// Метод получения ID клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client GetById(int id)
        {
            return Client.FirstOrDefault(client => client.ID == id)!;
        }

    }
}
