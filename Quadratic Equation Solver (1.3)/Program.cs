using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Quadratic_Equation_Solver__1._3_ {
    class Program {
        static void Main(string[] args) {

            printHyphens();
            Console.WriteLine();
            Console.WriteLine("Quadratic equation solver 1.3");
            printHyphens();

            Console.WriteLine();

            RunProgram();
            Console.ReadKey();
        }

        static void printHyphens() {
            for(int i = 0; i < 70; i++) {
                Console.Write("-");
            }
        }

        static double[] GetManualSequenceValues() {
            printHyphens();
            Console.WriteLine();
            Console.WriteLine("Note that the equation must be in the form of ax^2 + bx + c");
            
            Console.WriteLine("Please enter the value for a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the value for b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the value for c:");
            double c = Convert.ToDouble(Console.ReadLine());

            double[] valueArray = new double[3];

            valueArray[0] = a;
            valueArray[1] = b;
            valueArray[2] = c;

            return valueArray;
        }

        static double[] GetAutomaticSequenceValues() {

            printHyphens();

            ReEnterValues:
            Console.WriteLine();
            Console.WriteLine("Please note that the equation must be strictly in the form of ax^2+bx+c without any other characters or spaces");

            Console.WriteLine("Please enter your equation.");
            string equationInput = Console.ReadLine();

            Match match = Regex.Match(equationInput, @"(-?\d+)x\^2\s*[+-]\s*(\d+)x\s*([+-]\d+)");
            double a = 0;
            double b = 0;
            double c = 0;

            if (match.Success) {

                Console.WriteLine("Your equation is: " + equationInput + " ...    PRESS ENTER TO CONFIRM (or press A for again)");
                string usrInput = Console.ReadLine();
                if (usrInput.Equals("a")) {
                    goto ReEnterValues;
                }

                a = Convert.ToDouble(match.Groups[1].Value.Trim());

                Console.WriteLine(match.Groups[2].Value.Trim());



                b = Convert.ToDouble(match.Groups[2].Value.Trim());
                c = Convert.ToDouble(match.Groups[3].Value.Trim());

                a = Convert.ToDouble(a);
                b = Convert.ToDouble(b);
                c = Convert.ToDouble(c);


            }
            else {
                Console.WriteLine("Please enter a valid equation.");
                goto ReEnterValues;
            }

            double[] valueArray = new double[3];

            valueArray[0] = a;
            valueArray[1] = b;
            valueArray[2] = c;

            return valueArray;
        }

        static double calculateX1(double[] valueArray) {

            double a = valueArray[0];
            double b = valueArray[1];
            double c = valueArray[2];

            double upper1 = -b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
            double lower = 2 * a;

            double result1 = upper1 / lower;

            return result1;
           
        }

        static double calculateX2(double[] valueArray) {
            double a = valueArray[0];
            double b = valueArray[1];
            double c = valueArray[2];

            double upper2 = -b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
            double lower = 2 * a;

            double result2 = upper2 / lower;

            return result2;
        }

        static void printResults(double result1, double result2) {

            

            Console.WriteLine("Results:");

            if (double.IsNaN(result1)) {
                Console.WriteLine("First result: Not a number (IMAGINARY)");
            }
            else {
                Console.WriteLine("First result: x = " + result1);

            }



            if (double.IsNaN(result2)) {
                Console.WriteLine("Second result: Not a number (IMAGINARY)");

            }
            else {
                Console.WriteLine("Second result: x = " + result2);

            }

            Console.WriteLine("Error: Please do restart the program.");
            
            

            
        }

        static void informationFunction(double result1, double result2, double[] valuesArray) {

            Console.WriteLine();

            Console.WriteLine("Information of the function:");
            Console.WriteLine();
            printHyphens();
            Console.WriteLine();
            double a = valuesArray[0];
            double b = valuesArray[1];
            double c = valuesArray[2];

            if (a > 0) {
                Console.WriteLine("       Parabola opens forward. (U - shape)");
            }
            else if (a < 0) {
                Console.WriteLine("       Parabola opens downwards. (n - shape)");
            }

            double p = -1 * b / (2 * a);
            double d = b * b - 4 * a * c;
            double q = -1 * d / (4 * a);

            string minormax = "";
            if (a > 0) {
                minormax = "Minimum";
            }
            else {
                minormax = "Maximum";
            }

            Console.WriteLine("       " + minormax + ": " + "X = " + p + ",   Y = " + q);
            Console.WriteLine("       Coordinates of " + minormax + " = " + "(" + p + ", " + q + ")");

            double yIntercept = c;

            Console.WriteLine("       Y-Intercept = {0}", c);

            Console.WriteLine();

        }
        static void RunProgram() {
            

            ValidCommandRetry:

            Console.WriteLine("Would you like to enter equation manually or automatically? Press either:");
            Console.WriteLine("       Manually = m");
            Console.WriteLine("       Automatically = a");

            Console.WriteLine();
            string typeOfEnterance = Console.ReadLine();

            if (typeOfEnterance.Equals("m")) {
                double[] valuesArray = GetManualSequenceValues();
                double x1 = calculateX1(valuesArray);
                double x2 = calculateX2(valuesArray);
                Console.WriteLine();
                printResults(x1, x2);
                informationFunction(x1, x2, valuesArray);
            }
            else if (typeOfEnterance.Equals("a")) {
                double[] valuesArray = GetAutomaticSequenceValues();
                double x1 = calculateX1(valuesArray);
                double x2 = calculateX2(valuesArray);
                Console.WriteLine();
                printResults(x1, x2);
                informationFunction(x1, x2, valuesArray);
            }
            else {
                Console.WriteLine("Please enter a valid command.");
                goto ValidCommandRetry;
            }

            SolveAnotherEquation:
            Console.WriteLine("Enter another equation? (y/n)");
            string restartProgram = Console.ReadLine();

            if (restartProgram.Equals("y")) {
                goto ValidCommandRetry;  
            }
            else if (restartProgram.Equals("n")) {
                Environment.Exit(0);
            }
            else {
                Console.WriteLine("Please enter a valid command.");
                goto SolveAnotherEquation;
            }



        }
    }
}
