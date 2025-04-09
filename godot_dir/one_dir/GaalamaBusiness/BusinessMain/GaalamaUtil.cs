namespace GaalamaBusiness.BusinessMain;

public class GaalamaUtil
{
    public const string GaalamaVariableDefaultName = "__default__";

    public static GaalamaVariable GaalamaVariableDefault()
    {
        return new GaalamaVariable(GaalamaType.Object, GaalamaVariableDefaultName, null);
    }
}