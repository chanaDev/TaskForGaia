using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection
{
    public static class DataAccess
    {
        public static DBForTestEntities db = new DBForTestEntities();

        public static List<Operation> GetOperations()
        {
            return db.Operations.ToList();
        }

        public static double GetResult(double field1, double field2, int operationID)
        {
            string operation = db.Operations.Where(o => o.OperationID == operationID).Select(o => o.OperationValue).FirstOrDefault();
            double result = double.NaN;

            switch (operation)
            {
                case "+":
                    result = field1 + field2;
                    break;
                case "-":
                    result = field1 - field2;
                    break;
                case "*":
                    result = field1 * field2;
                    break;
                case "/":
                    if (field2 != 0)
                    {
                        result = field1 / field2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        public static void SaveCalcToHistory(double field1, double field2, int operationID, double result)
        {
            db.CalculationHistories.Add(new CalculationHistory()
            {
                Field1 = field1,
                Field2 = field2,
                OperationID = operationID,
                Result = result,
                CalcDate=DateTime.Now
            });
            db.SaveChanges();
        }
    }
}
