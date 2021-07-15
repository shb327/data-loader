using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        private static IEnumerable<Emp> Emps { get; set; }
        private static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            Depts = DataLoader.LoadDepts();
            Emps = DataLoader.LoadEmps();
        }

        // <summary>
        // SELECT * FROM Emps WHERE Job = "Backend programmer";
        // </summary>
        public static IEnumerable<Emp> Task1()
        {
            return Emps
                .Where(emp => emp.Job == "Backend programmer")
                .ToList();
        }

        // <summary>
        // SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        // </summary>
        public static IEnumerable<Emp> Task2()
        {
            return Emps
                .Where(emp => emp.Job == "Backend programmer" && emp.Salary > 1000)
                .OrderByDescending(emp => emp.Ename)
                .ToList();
        }

        // <summary>
        // SELECT MAX(Salary) FROM Emps;
        // </summary>
        public static int Task3()
        {
            return Emps.Max(e => e.Salary);
        }

        // <summary>
        // SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        // </summary>
        public static IEnumerable<Emp> Task4()
        {
            return Emps
                .Where(emp => emp.Salary == Task3())
                .ToList();
        }

        // <summary>
        // SELECT ename AS FirstName, job AS EmployeeJob FROM Emps;
        // </summary>
        public static IEnumerable<EmpTask5> Task5()
        {
            return Emps
                .Select(emp => new { FirstName = emp.Ename, EmployeeJob = emp.Job})
                .ToList() //list of anonymous type 
                .Select(emp => new EmpTask5 {FirstName = emp.FirstName, EmployeeJob = emp.EmployeeJob})
                .ToList(); //list of type "EmpTask5"

            // return Emps
            //     .Select(emp => new EmpTask5() {FirstName = emp.Ename, EmployeeJob = emp.Job})
            //     .ToList();
        }
        
        // <summary>
        // SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        // INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        // Result: Joining collections Emps and Depts.
        // </summary>
        public static IEnumerable<EmpTask6> Task6()
        {
            return Emps
                .Join(Depts,emp => emp.Deptno, dept => dept.Deptno, 
                    (emp, dept) => new EmpTask6 { Ename = emp.Ename, Job = emp.Job, Dname = dept.Dname})
                .ToList();
        }

        // <summary>
        // SELECT Job AS EmployeeJob, COUNT(1) EmployeeNumber FROM Emps GROUP BY Job;
        // </summary>
        public static IEnumerable<JobTask7> Task7()
        {
            return Emps
                .GroupBy(emp => emp.Job)
                .Select(group => new JobTask7 {EmployeeJob = group.Key, EmployeeNumber = group.Count()})
                .ToList();
        }

        /// <summary>
        /// Return value "true" if at least one of 
        /// the elements of collection works as "Backend programmer".
        /// </summary>
        public static bool Task8()
        {
            return Emps
                .Select(emp => emp.Job)
                .Contains("Backend programmer");
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public static Emp Task9()
        {
            return Emps
                .Where(emp => emp.Job == "Frontend programmer")
                .OrderByDescending(emp => emp.HireDate)
                .First();
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "No value", null, null;
        /// </summary>
        public static IEnumerable<Emp> Task10()
        {
            return Emps
               .Select(emp => new Emp { Ename = emp.Ename, Job = emp.Job, HireDate = emp.HireDate })
               .Union(new List<Emp>() { new Emp { Ename = "No value", Job = null, HireDate = null } })
               .ToList();
        }

        //Find the employee with the highest salary using the Aggregate () method
        public static Emp Task11()
        {
            return Emps
                .Aggregate((max, cemp) => max.Salary > cemp.Salary ? max : cemp);
        }

        //Using the LINQ language and the SelectMany method, 
        //perform a CROSS JOIN join between collections Emps and Depts
        public static IEnumerable<EmpTask10> Task12()
        {
            return Emps
                .SelectMany(emp => Depts,
                    (emp, dept) => new EmpTask10 {Ename = emp.Ename, Dname = dept.Dname})
                .ToList();
        }
    }
}
