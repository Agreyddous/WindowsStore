using System;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.ValueObjects;

namespace WindowsStore.Entities
{
    [DataContract]
    public class User : Entity
    {
        public User(Username username, Name name, Email email, Documents documents, Birthday birthday, string imageSource, bool admin)
        {
            Username = username;
            Name = name;
            Email = email;
            Documents = documents;
            Birthday = birthday;
            ImageSource = imageSource;
            Admin = admin;
        }

        [DataMember]
        public Username Username { get; private set; }
        [DataMember]
        public Name Name { get; private set; }
        [DataMember]
        public Email Email { get; private set; }
        [DataMember]
        public Documents Documents { get; private set; }
        [DataMember]
        public Birthday Birthday { get; private set; }
        [DataMember]
        public string ImageSource { get; private set; }
        [DataMember]
        public bool Admin { get; private set; }
    }
}