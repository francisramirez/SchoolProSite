

using Microsoft.EntityFrameworkCore;
using SchoolProSite.DAL.Context;
using SchoolProSite.DAL.Entities;
using SchoolProSite.DAL.Enums;
using SchoolProSite.DAL.Exceptions;
using SchoolProSite.DAL.Interfaces;
using System.Net.NetworkInformation;

namespace SchoolProSite.DAL.Dao
{
    public class DaoDepartment : IDaoDepartment
    {
        private readonly SchoolContext context;

        public DaoDepartment(SchoolContext context)
        {
            this.context = context;
        }
        public bool ExistsDepartment(Func<Department, bool> filter)
        {
            return this.context.Departments.Any(filter);
        }

        public Department? GetDepartment(int Id)
        {
            return this.context.Departments.Find(Id);
        }

        public List<Department> GetDepartments()
        {
            return this.context.Departments
                               .OrderByDescending(depto => depto.CreationDate)
                               .ToList();
        }

        public List<Department> GetDepartments(Func<Department, bool> filter)
        {
            return this.context.Departments.Where(filter).ToList();
        }

        public void RemoveDepartment(Department department)
        {
            Department departmentToRemove = this.GetDepartment(department.DepartmentId);

            departmentToRemove.Deleted = department.Deleted;
            departmentToRemove.DeletedDate = department.DeletedDate;
            departmentToRemove.UserDeleted = departmentToRemove.UserDeleted;

            this.context.Departments.Update(departmentToRemove);

            this.context.SaveChanges();
        }

        public void SaveDepartment(Department department)
        {

            string message = string.Empty;

            if (!IsDepartmentValid(department, ref message, Operations.Save))
                throw new DaoDepartmentException(message);

            this.context.Departments.Add(department);
            this.context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {

            string message = string.Empty;

            if (!IsDepartmentValid(department, ref message, Operations.Update))
                throw new DaoDepartmentException(message);


            Department departmentToUpdate = this.GetDepartment(department.DepartmentId);

            if (departmentToUpdate is null)
                throw new DaoDepartmentException("El departamento no se encuentra registrado.");
            

            departmentToUpdate.ModifyDate = department.ModifyDate;
            departmentToUpdate.Name = department.Name;
            departmentToUpdate.StartDate = department.StartDate;
            departmentToUpdate.Budget = department.Budget;
            departmentToUpdate.Administrator = department.Administrator;
            departmentToUpdate.UserMod = department.UserMod;


            this.context.Departments.Update(departmentToUpdate);
            this.context.SaveChanges();
        }

        private bool IsDepartmentValid(Department department, ref string message, Operations operations)
        {
            bool result = false;

            if (string.IsNullOrEmpty(department.Name))
            {
                message = "El nombre del departamento es requerido.";
                return result;
            }

            if (department.Name.Length > 50)
            {
                message = "El nombre del departamento no puede ser mayor a 50 caracteres.";
                return result;
            }

            if (department.Budget == 0)
            {
                message = "El presupuesto no puede ser cero(0).";
                return result;
            }

            if (operations == Operations.Save)
            {
                if (this.ExistsDepartment(cd => cd.Name == department.Name))
                {
                    message = "El departamento ya encuentra registrado";
                    return result;
                }
                else
                {
                    result = true;
                }

            }
            else
                result = true;


            return result;
        }
    }
}
