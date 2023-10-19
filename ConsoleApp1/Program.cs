namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Caculator
    public interface ICaculate
    {
        int OperandA { get; set; }
        int OperandB { get; set; }
        float Result { get; set; }
        void InputOperands();
        void CheckOperands();

        void Caculate();

        void Output();
    }

    public class AdditionCaculator : ICaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void CheckOperands()
        {
            throw new NotImplementedException();
        }

        public void Caculate()
        {
            throw new NotImplementedException();
        }

        public void InputOperands()
        {
            throw new NotImplementedException();
        }

        public void Output()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}