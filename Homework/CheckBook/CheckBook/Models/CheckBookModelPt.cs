namespace CheckBook.Models
{
    public class CheckBookModelPt
    {
        public int number;
        public string NumberInWords { get; set; } = string.Empty;

        public string ConvertNumber(int number)
        {
            if (number == 0)
                return "Zero reais";
            else if (number == 1000000)
                return "Um milhão";

            int reais = (int)number;
            string words = string.Empty;

            // Converte reais
            words += ConvertGroup(reais);

            return char.ToUpper(words[0]) + words.Substring(1);
        }

        private string ConvertGroup(int number)
        {
            string words = string.Empty;
            int hundreds = number / 100;
            int remainder = number % 100; // Pega o resto da visao

            if (hundreds > 0)
            {
                // Tratamento especial para 100
                if (number == 100)
                    return "cem";
                else
                    words += GetHundredsWord(hundreds);
            }

            if (remainder > 0)
            {
                if (!string.IsNullOrEmpty(words))
                    words += " e ";

                if (remainder < 10)
                {
                    words += GetUnitsWord(remainder);
                }
                else if (remainder < 20)
                {
                    words += GetTeensWord(remainder);
                }
                else
                {
                    int tens = remainder / 10;
                    int units = remainder % 10;
                    words += GetTensWord(tens);
                    if (units > 0)
                        words += " e " + GetUnitsWord(units);
                }
            }

            return words;
        }

        private string GetUnitsWord(int digit)
        {
            switch (digit)
            {
                case 1: return "um";
                case 2: return "dois";
                case 3: return "três";
                case 4: return "quatro";
                case 5: return "cinco";
                case 6: return "seis";
                case 7: return "sete";
                case 8: return "oito";
                case 9: return "nove";
                default: return "";
            }
        }

        private string GetTeensWord(int number)
        {
            switch (number)
            {
                case 10: return "dez";
                case 11: return "onze";
                case 12: return "doze";
                case 13: return "treze";
                case 14: return "quatorze";
                case 15: return "quinze";
                case 16: return "dezesseis";
                case 17: return "dezessete";
                case 18: return "dezoito";
                case 19: return "dezenove";
                default: return "";
            }
        }

        private string GetTensWord(int digit)
        {
            switch (digit)
            {
                case 2: return "vinte";
                case 3: return "trinta";
                case 4: return "quarenta";
                case 5: return "cinquenta";
                case 6: return "sessenta";
                case 7: return "setenta";
                case 8: return "oitenta";
                case 9: return "noventa";
                default: return "";
            }
        }

        private string GetHundredsWord(int digit)
        {
            switch (digit)
            {
                case 1: return "cento";
                case 2: return "duzentos";
                case 3: return "trezentos";
                case 4: return "quatrocentos";
                case 5: return "quinhentos";
                case 6: return "seiscentos";
                case 7: return "setecentos";
                case 8: return "oitocentos";
                case 9: return "novecentos";
                default: return "";
            }
        }
    }
}
