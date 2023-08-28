namespace WeatherAPI_React
{
    public class ApiCounter
    {
        private int count;

        public ApiCounter()
        {
            count = 0;
        }
        public void IncrementCount()
        {
            Interlocked.Increment(ref count);
        }

        public int GetCount()
        {
            return count;
        }
    }
}
