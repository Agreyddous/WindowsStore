namespace WindowsStore.ValueObjects
{
    public class Documentos
    {
        public Documentos(string cpf)
        {
            CPF = cpf;
        }

        public string CPF { get; private set; }
    }
}