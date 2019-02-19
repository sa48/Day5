using System;

namespace TaxCalculator
{
    class Program
    {
        //these arrays is visible in all the static method, 
        //so you can use them in your method implementation

        static int[] minIncomeArray = new int[]
            { 20000, 30000, 40000, 80000,
              120000, 160000, 200000, 320000 };
        static double[] taxRateArray = new double[]
            { 0.02, 0.035, 0.07, 0.115,
              0.15, 0.17, 0.18, 0.20 };
        static int[] basePayableAmountArray = new int[]
            { 0, 200, 550, 3350,
              7950, 13950, 20750, 42350 };

        static void Main(string[] args)
        {
            int annualIncome = AskForIncome();
            int taxBracket = GetTaxBracket(annualIncome);
            double taxPayable =
                CalculateIncomeTax(annualIncome, taxBracket);
            PrintResult(annualIncome, taxPayable);
            //Console.WriteLine(GetTaxBracket(21000));
        }

        static int AskForIncome()
        {
            Console.Write("Please enter your annual taxable income: ");
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        static void PrintResult(double taxableAnnualIncome, double taxAmount)
        {
            Console.WriteLine($"For taxable annual income of ${taxableAnnualIncome:#,0.00}, " 
                + $"the tax payable amount is ${taxAmount:#,0.00}");
        }

        static int GetTaxBracket(double annualIncome)
        {
            //loop start i from the last element in minIncomeArray array (count down)
            //    compare the minIncome with the user's annual income
            //    if user's annual income > minIncome 
            //       then we found the user's tax bracket
            //       exit the method (return)
            //
            //we can't find the bracket, so user's bracket is -1

            for (int currentBracket = minIncomeArray.Length-1; currentBracket >= 0;
                currentBracket--)
            {
                if (minIncomeArray[currentBracket] < annualIncome)
                {
                    //we found the bracket
                    return currentBracket;
                }
            }

            return -1;
        }

        static double CalculateIncomeTax(int annualIncome, int bracket)
        {
            //Payable tax = (annual income – minimum income) * tax Rate +base payable amount
            if (bracket == -1)
            {
                return 0;
            } else
            {
                return (annualIncome - minIncomeArray[bracket]) * taxRateArray[bracket]
                    + basePayableAmountArray[bracket];
            }
        }
    }
}

