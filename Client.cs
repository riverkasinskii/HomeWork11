namespace testHomeWork11
{
    /// <summary>
    /// Клиент
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="Surname"></param>
        /// <param name="Name"></param>
        /// <param name="Patronymic"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Passport"></param>
        public Client(int ID, string Surname, string Name, string Patronymic,
            string PhoneNumber, string Passport, DateTime RecordChange, string DataHasBeenChanged,
            string ChangeType, string WhoChangedData)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.Passport = Passport;
            this.RecordChange = RecordChange;
            this.DataHasBeenChanged = DataHasBeenChanged;
            this.ChangeType = ChangeType;
            this.WhoChangedData = WhoChangedData;
        }
        /// <summary>
        /// Конструктор для создания экземпляра класса Client без параметров
        /// </summary>
        public Client()
        {

        }
        /// <summary>
        /// ID клиента
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Отчество клиента
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Телефон клиента
        /// </summary>
        private string? phoneNumber = "+375295404190";
        public string? PhoneNumber
        {
            get { return phoneNumber!; }
            set { phoneNumber = value; }
        }

        /// <summary>
        /// Паспорт клиента
        /// </summary>
        public string? Passport { get; set; }

        /// <summary>
        /// Дата и время изменения записи
        /// </summary>
        public DateTime RecordChange { get; set; }

        /// <summary>
        /// Какие данные были изменены у клиента
        /// </summary>
        public string? DataHasBeenChanged { get; set; }

        /// <summary>
        /// Тип изменений
        /// </summary>
        public string? ChangeType { get; set; }

        /// <summary>
        /// Кто изменил данные
        /// </summary>
        public string? WhoChangedData { get; set; }

    }
}
