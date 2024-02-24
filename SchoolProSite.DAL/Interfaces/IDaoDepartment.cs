
using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoDepartment
    {
        void SaveDepartment(Department department);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);
        Department GetDepartment(int Id);
        List<Department> GetDepartments();
        List<Department> GetDepartments(Func<Department, bool> filter);
        bool ExistsDepartment(Func<Department, bool> filter);

       
    }
}
