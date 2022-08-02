namespace CodeTranslator
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string input)
        {
            return "Conversion result: C#";
        }

        public string ConvertToVB(string input)
        {
            return "Conversion result: VB";
        }
    }
}
