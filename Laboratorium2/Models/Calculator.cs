namespace Laboratorium2.Models
{
    public class Calculator
    {
        public double? A { get; set; }
        public double? B { get; set; }
        public Operators? Op { get; set; }
        public bool isValid()
        {
            return A != null && B != null && Op != null;
        }
        public double Calculate()
        {
            switch(Op)
            {
                case Operators.MUL:
                    return (double)(A * B);
                case Operators.DIV:
                    return (double)(A / B);
                case Operators.ADD:
                    return (double)(A + B);
                case Operators.SUB:
                    return (double)(A - B);
                default: return double.NaN;
            }
        }
    }
}
