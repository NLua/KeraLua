namespace KeraLua
{
    public enum LuaStatus
    {
        OK =  0,
        Yield = 1,
        ErrRun = 2,
        ErrSyntax = 3,
        ErrMem = 4,
        ErrGCMM = 5,
        ErrErr = 6,
    }
}
