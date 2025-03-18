namespace CheckBook.Models
{
    public class CheckBookModel
    {
        public int number;
        public string inFull = string.Empty;

        public string ConvertNumber(int number)
        {
            switch(number)
            {
                case 1:
                    inFull = "Um";
                break;
                case 2:
                    inFull = "Dois";
                break;
                case 3:
                    inFull = "Tres";
                break;
                default:
                    inFull = "Erro";
                    break;
            }

            
           
            return inFull;
        }
    }
}
