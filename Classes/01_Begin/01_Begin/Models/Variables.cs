namespace _01_Begin.Models
{
    public class Variables
    {
        // Tipos implicitos
        // var test = 10;

        // Anotacao de tipos
        public int userCount = 10;

        // Uma variavel pode ser declarada e nao incializada
        public int totalCount;

        // CONSTANTES
        // Para declarar uma constante utilizamos a palavra-chave CONST
        // No entanto a CONST deve ser inicializada quando declarada 
        public const int interestRate = 10;

        // MVVM
        public Byte myByte = new Byte();
        public Int myInt = new Int();
        public Long myLong = new Long();
        public Sbyte mySbyte = new Sbyte();
        public Short myShort = new Short();
        public Uint myUint = new Uint();
        public Ulong myUlong = new Ulong();
        public Ushort myUshort = new Ushort();



        // O metodo construtor e invocado na instanciacao do objeto por meio da palavra reservada new
        // Por regra, o construtor sempre tem o mesmo nome da classe
        public Variables()
        {
            totalCount = 0;

            // Tipo implicito
            // a palvra chave var se encarrega de definir o tipo da variavel na instrucao de atribuicao
            var signalStrength = 22;
            var companyName = "ACME";

        }

    }
}
