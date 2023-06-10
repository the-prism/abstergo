namespace Abstergo.Extensions
{
    public class EnumCharSet : Attribute
    {
        public char Value { get; private set; }

        public EnumCharSet(char value)
        {
            this.Value = value;
        }
    }
}
