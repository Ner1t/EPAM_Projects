using CodeTranslator;

namespace CodeTranslatorUI

{
    public class Program
    {
        static void Main(string[] args)
        {
            IConvertible[] arrayObjects = new IConvertible[3];
            arrayObjects[0] = new ProgramConverter();
            arrayObjects[1] = new ProgramHelper();
            arrayObjects[2] = new ProgramConverter();

            string currentLanguage = "C#";
            string check = "C#";

            foreach (var obj in arrayObjects)
            {
                if (obj is ICodeChecker method)
                {
                    System.Console.WriteLine(method.CheckCodeSyntax(check, currentLanguage) ? obj.ConvertToVB(check) : obj.ConvertToCSharp(check));
                }
                else
                {
                    System.Console.WriteLine(obj.ConvertToCSharp(check));
                    System.Console.WriteLine(obj.ConvertToVB(check));
                }
            }
        }
    }
}
