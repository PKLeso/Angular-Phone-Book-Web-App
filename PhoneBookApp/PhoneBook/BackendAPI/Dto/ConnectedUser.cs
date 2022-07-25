namespace PhoneBook.Dto
{
    public class ConnectedUser
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string connId { get; set; }

        public ConnectedUser(Guid newId, string newName, string newConnId)
        {
            id = newId;
            name = newName;
            connId = newConnId;
        }
    }
}
