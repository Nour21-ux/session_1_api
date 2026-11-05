namespace session_1.Results
{
    public class Result
    {
        public bool IsSucsess { get;  }
        public bool IsFalier => !IsSucsess;
        public string Error { get;  }
        public Result(bool isSucsess,string error)
        {
            IsSucsess = isSucsess;
            Error = error;
        }

        public static Result Sucsess()=>new Result(true,string.Empty);
        public static Result Failure( string error) => new Result(false, error);
    }
}
