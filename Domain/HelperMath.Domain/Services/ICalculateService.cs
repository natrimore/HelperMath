using HelperMath.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelperMath.Domain.Services
{
    public interface ICalculateService 
    {
        CalculationModel DoRequest(string requestMethod);
        CalculationModel Simplify(string expression);
        CalculationModel Factor(string expression);
        CalculationModel Derive(string expression);
        CalculationModel Integrate(string expression);
        CalculationModel Find0s(string expression);
        CalculationModel AreaUnderCurve(string expression);
        CalculationModel Cosine(string expression);
        CalculationModel Sine(string expression);
        CalculationModel Tangent(string expression);
        CalculationModel InverseCosine(string expression);
        CalculationModel InverseSine(string expression);
        CalculationModel InverseTangent(string expression);
        CalculationModel AbsoluteValue(string expression);
        CalculationModel Logarithm(string expression);

    }
}
