using System;

public static class StringConverter
{
    public static string GetConvertString(int money)
    {
        if (money < 0)
            throw new InvalidOperationException(nameof(money));

        string amountString = money.ToString();
        string editedAmountString = amountString;
        int typeCurrency = 0;

        if (amountString.Length > 3)
        {
            typeCurrency = (amountString.Length - 1) / 3;

            int numberOfDigitsString = amountString.Length - (amountString.Length / 3 * 3);

            if (numberOfDigitsString == 0)
                numberOfDigitsString = 3;

            editedAmountString = string.Empty;

            for (int i = 0; i <= numberOfDigitsString; i++)
            {
                if (i == numberOfDigitsString && i != 0)
                    editedAmountString += $".{amountString[i]}";
                else
                    editedAmountString += amountString[i];
            }
        }

        if (typeCurrency == 0)
            return editedAmountString;
        else if (typeCurrency == 1)
            return editedAmountString + 'К';
        else if (typeCurrency == 2)
            return editedAmountString + 'М';
        else if (typeCurrency == 3)
            return editedAmountString + 'В';
        else if (typeCurrency == 4)
            return editedAmountString + 'T';
        else if (typeCurrency == 5)
            return editedAmountString + 'q';
        else if (typeCurrency == 6)
            return editedAmountString + "qi";

        return amountString;
    }
}