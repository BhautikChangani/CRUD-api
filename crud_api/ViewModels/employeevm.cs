namespace crud_api.ViewModels
{
    public class employeevm
    {
        public int? EmpId { get; set; }

        public int? DeptId { get; set; }

        public int? MngrId { get; set; }

        public string EmpName { get; set; }

        public decimal? Salary { get; set; }
        public string? DeptName { get; set; }
        public string MngrName { get; set; }
    }
}
