namespace SampleCoreAPI.Controllers
{
    public class ConflictTest
    {
        public string GetConflict()
        {
            string conflict = "This is a conflict test.";
            conflict += " Additional line to create a conflict.";
            return conflict;
        }
    }
}