namespace CodeTranslator
{
    public interface IConvertible
    {
        string ConvertToCSharp(string input);
        string ConvertToVB(string input);
    }
}
