namespace AlgorithemAndDataStructure.LinqInCSahrp
{
    public class LinqProblem2
    {
        public static void Run()
        {
            var employees = new[]
            {
                new{Id=1,Name="Omid",DeptId=1},
                new{Id=2,Name = "Saeed",DeptId=2},
                new{Id=3,Name = "Vahid",DeptId=1},
                new{Id=4,Name = "Saleh",DeptId=2},
                new{Id=5,Name = "Samyar",DeptId=2},
            };

            var departments = new[]
            {
                new{Id=1,Name="HR"},
                new{Id=2,Name="IT"}
            };


            var result = employees.Join(departments,
           emp => emp.DeptId,
           dept => dept.Id,
           (emp, dept) => new { emp.Name, Department = dept.Name }

           );

            var res2 = departments.GroupJoin(employees,
            dept=>dept.Id,
            emp=>emp.DeptId,
            (dep,emp)=>new
            {
                Department = dep.Name,
                Employee=emp.Select(e=>e.Name)
            }

            );
        }

        
    }
}