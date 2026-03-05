using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.CommonResult
{
   public class Error
    {
        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }
        private Error(string code,string description,ErrorType type)
        {
            Code= code;
            Description= description;
            Type= type;

        }
        //static fatory method to create error
        public static Error Failure(string Code="General.Filure",string Description="A General Failure Has Occured")
        {
            return new Error(Code,Description,ErrorType.Failure);
        }
        public static Error Validation (string Code="General.Validation",string Description="A General Validation Has Occured")
        {
            return new Error(Code,Description,ErrorType.Validation);
        }
        public static Error NotFound(string Code="General.NotFound",string Description="The Requested Resource Was NotFound ")
        {
            return new Error(Code,Description,ErrorType.NotFound);
        }
        public static Error UnAuthorized(string Code= "General.UnAuthorized", string Description="You are not Authorized  ")
        {
            return new Error(Code,Description,ErrorType.Unauthorized);
        }
        public static Error Forbidden(string Code= "General.Forbidden", string Description="You donot have the Permission to Access ")
        {
            return new Error(Code,Description,ErrorType.Forbidden);
        }
        public static Error InvalidCrendentials (string Code= "General.InvalidCrendentials", string Description="The Provided  ")
        {
            return new Error(Code,Description,ErrorType.InvalidCrendentials);
        }
    }
}
