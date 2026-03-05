using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce.Shared.CommonResult
{
  public class Result
    {
        private readonly List<Error> _errors = [];
        
        public bool IsSuccess => _errors.Count == 0;//True
        public bool IsFailure => !IsSuccess;//false
        public IReadOnlyList<Error> Errors => _errors;
        protected Result()
        {
            
        }
        //faile WithError
       protected Result(Error error)
        {
            _errors.Add(error);
        }
        //faile WithErrors
      protected Result(List<Error> errors)
        {
            _errors.AddRange(errors);
        }
        public static Result ok => new Result();
        public static Result Fail(Error error) =>new Result(error);
        public static Result Fail(List<Error> errors) =>new Result(errors);

    }
    public class Result<TValue> : Result
    {
       private readonly TValue _value;
        public TValue Value =>IsSuccess? _value:throw new InvalidOperationException("Cannot Access The Value of Failed Result");
        //ok Success With Value
        private Result(TValue value) : base()
        {
            _value=value;
        }
        //failwith Error
       private Result(Error error):base(error)
        {
            _value = default!;
        }
       private Result(List<Error> errors):base(errors)
        {
            _value = default!;
        }
        public static Result<TValue> ok(TValue value) =>new (value);
        public static new Result<TValue>Fail(Error error) =>new (error) ;
        public static new Result<TValue>Fail(List<Error> errors) =>new(errors);
        public static implicit operator Result<TValue>(TValue value)=>ok(value);
        public static implicit operator Result<TValue>(Error error)=>Fail(error);
        public static implicit operator Result<TValue>(List<Error> errors)=>Fail(errors);


    }

}
