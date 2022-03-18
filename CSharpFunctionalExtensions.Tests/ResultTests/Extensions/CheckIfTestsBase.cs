using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CheckIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected CheckIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }
        
        protected Result Func_Result(bool _) { actionExecuted = true; return Result.Success(); } 
        
        protected Result<K> Func_Result_K(bool _) { actionExecuted = true; return Result.Success<K>(K.Value); }
        protected Result<K,E> Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value); }
        protected UnitResult<E> Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>(); }
        protected UnitResult<E> Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>(); }

        protected Task<Result> Task_Func_Result(bool _) { actionExecuted = true; return Result.Success().AsTask(); }
        protected Task<Result<K>> Task_Func_Result_K(bool _) { actionExecuted = true; return Result.Success<K>(K.Value).AsTask(); }
        protected Task<Result<K, E>> Task_Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value).AsTask(); }
        protected Task<UnitResult<E>> Task_Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>().AsTask(); }
        protected Task<UnitResult<E>> Task_Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>().AsTask(); }

        protected bool Predicate(bool b) { predicateExecuted = true; return b; }
    }
}