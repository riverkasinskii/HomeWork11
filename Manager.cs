namespace testHomeWork11
{
    internal class Manager : Consultant, IAddable
    {
        /// <summary>
        /// Конструктор для получения информации о клиенте, менеджером
        /// </summary>
        public Manager() : base()
        {

        }

        /// <summary>
        /// Метод создания клиента
        /// </summary>
        /// <param name="client"></param>
        public void Create(Client client)
        {
            Client.Add(client);
        }

        /// <summary>
        /// Метод редактирования клиента по ID
        /// </summary>
        /// <param name="client"></param>
        public override void UpdateClient(Client client)
        {
            var oldClient = Client
                .FirstOrDefault(e => e.ID == client.ID);
            Client.Remove(oldClient!);
            Client.Add(client);
        }


        /// <summary>
        /// Метод для вывода данных о клиенте, менеджером
        /// </summary>
        /// <param name="client"></param>
        public override void ShowClient(Client client)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"" +
                $"ID: {client.ID}" +
                $" |Фамилия: {client.Surname}" +
                $" |Имя: {client.Name}" +
                $" |Отчество: {client.Patronymic}" +
                $" |Номер телефона: {client.PhoneNumber}" +
                $" |Паспорт: {client.Passport}" +
                $" \nИзменение записи: {client.RecordChange:g}" +
                $" \nЧто изменено: {client.DataHasBeenChanged}" +
                $" \nТип изменений: {client.ChangeType}" +
                $" \nДанные изменил: {client.WhoChangedData}");
        }
    }
}
