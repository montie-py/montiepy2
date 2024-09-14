namespace montiepy2.Core.Enums
{
    [Flags]
    internal enum ResumeType
    {
        Csharp,
        Java,
        Php,
        Cj = Csharp | Java,
        Cp = Csharp | Php,
        Jp = Java | Php,
    }
}