using Dapper;
using DummyEF.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DummyEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly DummyDBContext _dummyDB;

        public DummyController(DummyDBContext dummyDB)
        {
            _dummyDB = dummyDB;
        }


        [HttpGet]
        public async Task<IEnumerable<Dumm>> GetALL()
        {
            var data = await _dummyDB.Dumms.ToListAsync();

            return data;
        }

        [HttpGet]
        [Route("Emloyeee")]
        public  async Task<IActionResult> GetEmployee()
        {
            var employee = await  _dummyDB.Dumms
                .OrderBy(e =>e.Id)
                .Take(50)
                .ToListAsync();

            return Ok(employee);

        }


        // Dapper using 
        [HttpGet]
        [Route("DapperEmployee")]
        public async Task<IActionResult> GetEmployeeDapper()
        {
           
            
                const string query = @"Select id,first_name as FirstName FROM Dumm";

                using (var connection = _dummyDB.Database.GetDbConnection())
                {
                    await connection.OpenAsync();
                    var result = await connection.QueryAsync<Dumm>(query);
                    return Ok(result);
                }
            }
            
        }

    }

