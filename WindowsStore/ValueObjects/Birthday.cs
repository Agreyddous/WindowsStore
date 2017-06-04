using System;

namespace WindowsStore.ValueObjects
{
    public class Birthday
    {
        public Birthday(DateTime date) => Date = date;

        public DateTime Date { get; private set; }
    }
}