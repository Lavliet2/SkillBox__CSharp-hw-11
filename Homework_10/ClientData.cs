namespace Homework_10
{
    public class ClientData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }

        public ClientData(string firstName, string lastName, string patronymic, string phoneNumber, string passport)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Passport = passport;
        }
    }
}
