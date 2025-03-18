namespace _02_Class.Models
{
    public class TypeCasting
    {
        // Declarando variaveis na classe
        public int myInteger = 20;
        public long myLong;

        public string myType1;
        public string myType2;

        public TypeCasting()
        {
            // Conversao implicita de tipos 
            myLong = myInteger;

            //myInteger =myLong;
            // Neste caso o long e muito grande para o int e a conversao implicita nao e permitida

            // Conversao explicita
            long myLong2 = 138129210;
            int myInteger2;
            myInteger2 = (int)myLong2;

            // E possivel identificar qual e o tipo de uma variavel em tempo de execucao
            myType1 = myLong2.GetType().ToString();
            myType2 = myInteger2.GetType().ToString();
        }
    }
}
