namespace CodeTranslator
{
    public class ProgramHelper : ProgramConverter, ICodeChecker, IConvertible
    {
        public bool CheckCodeSyntax(string check, string language)
        {
            return check == language;
        }
    }
}
