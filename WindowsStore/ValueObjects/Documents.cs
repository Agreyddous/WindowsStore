namespace WindowsStore.ValueObjects
{
    public class Documents
    {
        public Documents(string cpf)
        {
            CPF = cpf;
        }

        public string CPF { get; private set; }
    }
}