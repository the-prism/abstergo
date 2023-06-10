namespace Abstergo.Extensions
{
    public class EnumValue : Attribute
    {
        public string Value { get; private set; }

        public EnumValue(string value)
        {
            this.Value = value;
        }
    }
}
