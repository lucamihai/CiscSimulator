namespace CiscSimulator.Assembler.UnitTests
{
    public static class Resources
    {
        public const string Text1 =
            @"mov r0, r1
and r2, r4 # just a comment
add r2, 2  # just another comment
add (r4), 10
add r2, (r1)10
# A line containing only a comment";
    }
}
