namespace CodeTranslator
{
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string check, string language);
    }
}
