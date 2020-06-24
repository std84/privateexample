using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Http;
using school.REPOSITORY;
using school.MODAL;
using AutoMapper;

namespace school.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStudentRepository _CourseService;
      // private readonly IMapper _mapper;

        public StudentController(ILogger<WeatherForecastController> logger,IMapper mapper, IStudentRepository CourseService)
        {
            _logger = logger;
            _CourseService = CourseService;
           // _//mapper = mapper;
        }
         [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
           
            var user = await _CourseService.GetAllAsync();// _repo.GetUser(id);
            if(user == null){
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(user);// Ok(user);
        }
        [HttpGet("GetStudentByCourse/{id}")]
        public async Task<IActionResult> GetStudentByCourse(int id)
        {

            var user = await _CourseService.GetStudentByCourseAsync(id);// _repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(user);// Ok(user);
        }
        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
           
            var user = await _CourseService.GetStudentById(id);// _repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(user);// Ok(user);
        }
                 [HttpPut("updateStudent")]
        public async Task<IActionResult> updateStudent( Student info){
           // if(courseId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
               // return Unauthorized();
            if(info.id != 0){
                
                //var course = await _CourseService.GetCourseByIdAsync(info.courseId);
              //   course = info;
                if(await _CourseService.updateStudent(info)){
                     _logger.LogInformation("Hello, course uptaded!");
                  return Ok();
                }
            }
            else{
              var res = _mapper.Map< Student >(info);
              await _CourseService.AddAsync(res);  
              _logger.LogInformation("Hello, course uptaded!");
                  return Ok();
            }
          _logger.LogInformation("Hello, course not uptaded!");
            return BadRequest();

        }
        
    }
}