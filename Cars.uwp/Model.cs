using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Model
    {
        private Analystik.REST.API _api;

        public Model()
        {
            var context = new Analystik.REST.Context();
            context.BaseUrl = "http://cars101.azurewebsites.net/api/";
            //context.BaseUrl = "http://169.254.164.142/api/";
            this._api = new Analystik.REST.API(context);
        }

        public Task<Models.Make[]> GetMakes()
        {
            return this._api.Get<Models.Make[]>("Makes");

        }
        public Task<Models.Model[]> GetModels(int makeId)
        {
            return this._api.Get<Models.Model[]>($"Makes/{makeId}/models");
        }
        public Task<Models.Car[]> GetCars(int makeId, int modelId)
        {
            return this._api.Get<Models.Car[]>($"makes/{makeId}/models/{modelId}/Cars");
        }

        public Task<Analystik.REST.IResponse<Models.FinancialEvaluation>>  Calculate(Models.Profile profile)
        {
            return this._api.Put<Models.FinancialEvaluation>($"calculate", profile);
        }


        public Task<Models.Province[]> GetProvinces()
        {
            return this._api.Get<Models.Province[]>("Provinces");
        }

    }
}
