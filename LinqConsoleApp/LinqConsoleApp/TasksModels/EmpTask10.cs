namespace LinqConsoleApp
{
    public class EmpTask10
    {
        public string Ename { get; set; }
        public string Dname { get; set; }
        
        public override string ToString()
        {
            return Ename + " (Dname: " +  Dname + ")";
        }
    }
}