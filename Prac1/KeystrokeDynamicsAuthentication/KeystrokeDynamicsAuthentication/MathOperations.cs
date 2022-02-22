using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KeystrokeDynamicsAuthentication
{
    class MathOperations
    {
        public double Expectation(double[] elements)
        {
            double sum = 0;
            for(int i = 0; i < elements.Length; i++)
            {
                sum += elements[i];
            }
            double expectation = sum / elements.Length;
            return expectation;
        }
        
        public double Dispersion(double[] elements, double expectatiom)
        {
            double sum = 0;
            for(int i = 0; i < elements.Length; i++)
            {
                sum += Math.Pow(elements[i] - expectatiom, 2);
            }
            
            double dispersion = sum / (elements.Length - 1);
            return dispersion;
        }

        public double StudentCoefficient(double element, double expectation, double standardDeviation)
        {
            double studentCoefficient = Math.Abs((element - expectation) / standardDeviation);
            return studentCoefficient;
        }

        public double StudentCoefficient(double expectationX, double expectationY, double standardDeviation, int degreeOfFreedom)
        {
            double studentCoefficient = Math.Abs((expectationX - expectationY) / (standardDeviation * Math.Sqrt(2.0 / degreeOfFreedom)));
            return studentCoefficient;
        }

        public double StandardDeviation(double diapersionReferenceIntervals, double diapersionCurrentAttempt, int degreeOfFreedom)
        {
            double numerator = (Math.Pow(diapersionReferenceIntervals, 2) + Math.Pow(diapersionCurrentAttempt, 2)) * (degreeOfFreedom - 1);
            double denominator = 2 * degreeOfFreedom - 1;

            double standardDeviation = Math.Sqrt(numerator / denominator);
            return standardDeviation;
        }
    }
}
