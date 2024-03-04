namespace AdaTech.EncurtadorDeLinks.WebAPI.Services
{
    public interface IRandomizer
    {
        int Sortear(int length);
    }

    public class Randomizer : IRandomizer
    {
        private readonly Random _ramdom;

        public Randomizer()
        {
            _ramdom = new Random();
        }

        public int Sortear(int length)
            => _ramdom.Next(length);
    }
}