namespace LinqConsoleApp
{
    public class EmpTask6
    {
        public string Ename { get; set; }
        public string Job { get; set; }
        public string Dname { get; set; }
        
        public override string ToString()
        {
            return Ename + " (Job: " +  Job + ", Dname: " +  Dname + ")";
        }
    }
}