//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yarik
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        public int ID_Employees { get; set; }
        public string EmployeesSurname { get; set; }
        public string EmployeesName { get; set; }
        public string EmployeesMiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string Passwordd { get; set; }
        public int EmployeesRole_ID { get; set; }
    
        public virtual EmployeesRole EmployeesRole { get; set; }
    }
}
