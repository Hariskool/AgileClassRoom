using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgileClassRoom.ViewModel;
using System.Net;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
            _department = department;
        }
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            try
            {
                return _department.GetAllDepartment();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}", Name = "GetDepartment")]
        public Department Get(int id)
        {
            try
            {
                return _department.GetDepartmentbyId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DepartmentViewModel departmentViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (_department.CheckDepartmentExits(departmentViewModel.DepartmentName))
                    {
                        var response = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.Conflict
                        };

                        return response;
                    }
                    else
                    {
                        var temprole = AutoMapper.Mapper.Map<Department>(departmentViewModel);

                        _department.InsertDepartment(temprole);

                        var response = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK
                        };

                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage()
                    {

                        StatusCode = HttpStatusCode.BadRequest
                    };

                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] DepartmentViewModel departmentViewModel)
        {
            try
            {
                var temprole = AutoMapper.Mapper.Map<Department>(departmentViewModel);
                _department.UpdateDepartment(temprole);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.BadRequest
                };

                return response;

            }
        }
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {

                var result = _department.DeleteDepartment(id);

                if (result)
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}