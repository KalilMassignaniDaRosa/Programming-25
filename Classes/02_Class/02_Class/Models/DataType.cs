namespace _02_Class.Models
{
    public class DataType
    {
        // O caracter usa ''
        // String usam ""
        public char myVar = 'a';
        public char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        // Podemos tambem atribuir referencia de caracteres Unicode
        public char myChar4 = '\u2726';

        // Podemos ainda mesclar caracteres especiais como:
        // nova linha, tabulacao e etc.
        public string textLine = "This is a text line.\n\n\nAnd this is another line.";

        /*
         \e = Caracter de escape
         \n = Nova linha
         \r = Retorno
         \t = Tabulacao horizontal
         \" = Aspas duplas, usadas para exibir aspas dentro de string
         \' = Aspas simples, usado para  exibir aspas simples na string
         */
        
        private int count = 10;
        public string message;

        public DataType()
        {
            // Interpolacao
            // Combinando strings de diferentes maneiras no C#
            message = $"Counter is at {count}";

            string userName = "Kalil";
            int inboxCount = 10;
            int maxCount = 100;

            message += $"\nThe user {userName} has {inboxCount} messages.";
            message += $"\nEspace avaible in box {maxCount - inboxCount}";
        }
    }
}
