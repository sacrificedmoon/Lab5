namespace Lab._5
{
    internal class Users
    {
        private string name;
        private string email;
        public Users(string userInputName, string userInputMail)
        {
            name = userInputName;
            email = userInputMail;
        }

        public string Name()
        {
            return name;
        }


    }
}