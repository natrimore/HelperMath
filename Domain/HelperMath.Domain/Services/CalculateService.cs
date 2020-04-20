using HelperMath.DataAccess.Models;
using HelperMath.Domain.Helper;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace HelperMath.Domain.Services
{
    public class CalculateService : ICalculateService
    {
        public CalculationModel AbsoluteValue(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel AreaUnderCurve(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Cosine(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Derive(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel DoRequest(string requestMethod)
        {
            var client = new RestClient(AppSettings.NewtonApi);
            var request = new RestRequest(requestMethod, Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new CalculationModel();
                }
                return JsonConvert.DeserializeObject<CalculationModel>(response.Content);
            }
            catch (Exception ex)
            {
                return new CalculationModel();
            }
        }

        public CalculationModel Factor(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Find0s(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Integrate(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel InverseCosine(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel InverseSine(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel InverseTangent(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Logarithm(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Simplify(string expression)
        {
            return DoRequest($"/simplify/{expression}");
        }

        public CalculationModel Sine(string expression)
        {
            throw new System.NotImplementedException();
        }

        public CalculationModel Tangent(string expression)
        {
            throw new System.NotImplementedException();
        }
    }
}
