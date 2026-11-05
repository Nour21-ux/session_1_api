namespace session_1.Results
{
    public class GenirecResult<T> : Result
    {
        public T Value { get; set; }
        public GenirecResult(bool isSucsess,T value, string error) : base(isSucsess, error)
           => Value = value;

        public static GenirecResult<T> Sucsess(T value) => new GenirecResult<T>(true, value, string.Empty);
        public static GenirecResult<T> Failure(string error) => new GenirecResult<T>(false, default, error);
        

        
    }
}
