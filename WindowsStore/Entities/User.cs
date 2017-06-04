using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.ValueObjects;

namespace WindowsStore.Entities
{
    public class User : Entity
    {
        public User(Name name, Email email, Documents documents, Birthday birthday, BitmapSource image, bool admin)
        {
            Name = name;
            Email = email;
            Documents = documents;
            Birthday = birthday;
            Image = image;
            Admin = admin;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Documents Documents { get; private set; }
        public Birthday Birthday { get; private set; }
        public BitmapSource Image { get; private set; }
        public bool Admin { get; private set; }
    }
}