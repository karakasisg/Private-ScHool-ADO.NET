using System;

namespace PrivateSchoolDatabase
{
    abstract class Human
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Human()
        {

        }

        public Human(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("firstName", "First Name cannot be null or empty!");
            }
            if (!IsValidName(firstName))
            {
                throw new ArgumentException("firstName", "First Name must start with capital letter and contain only alphabet letters.");
            }
            FirstName = firstName;
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("lastName", "Last Name cannot be null or empty!");
            }
            if (!IsValidName(lastName))
            {
                throw new ArgumentException("lastName", "Last Name must start with capital letter and contain only alphabet letters.");
            }
            LastName = lastName;
        }

        public override string ToString()
        {
            return String.Format("The Human's info can be seen below:\nFirst Name: {0}\nLast Name: {1}", FirstName, LastName);
        }

        private bool IsValidName(string name)
        {
            if (Char.IsLower(name[0]))
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
