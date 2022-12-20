using DataConnection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web_API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CalculatorController:ApiController
    {
        //[HttpGet]
        //public List<Operation> Get()
        //{
        //    var operations = DataAccess.GetOperations();
        //    return operations.ToList();
        //}

        [HttpGet]
        public List<string> Get()
        {
            var operations = DataAccess.GetOperations();
            return operations.Select(o=>o.OperationValue).ToList();
        }

        [HttpPost]
        public double GetResult([FromBody]string value)
        {
            var res = JsonConvert.DeserializeObject<CalculationHistory>(value);
            var result = DataAccess.GetResult(res.Field1.Value, res.Field2.Value, res.OperationID.Value);
            DataAccess.SaveCalcToHistory(res.Field1.Value, res.Field2.Value, res.OperationID.Value,result);
            return result;
        }

    }
}
