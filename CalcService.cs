using Microsoft.Extensions.Logging;
using System;

namespace testFunction
{
    public class CalcService
    {
        public int Operations(dynamic data, ILogger log,string operacao)
        {
            int result = 0;
            switch (operacao){
                case "sum":
                    log.LogInformation("Return of sum method");
                    result = data.numberA + data.numberB;
                    break;
                    
                case "divided":
                    try{ 
                        log.LogInformation("Return of division method");
                        result = data.numberA / data.numberB;
                        break;
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message.ToString());
                    }
                case "subtraction":
                    log.LogInformation("Return of subtraction method");
                    result = data.numberA - data.numberB;
                    break;
                case "multiplication":
                    log.LogInformation("Return of multiplication method");
                    result = data.numberA * data.numberB;
                    break;
            }
            return result;
        }
    }
}