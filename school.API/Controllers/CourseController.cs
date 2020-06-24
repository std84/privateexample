using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Http;
using school.REPOSITORY;
using Newtonsoft.Json.Linq;
using school.MODAL;
using System.Net.Http;
using System.Net.Http.Headers;

namespace school.API.Controllers
{
      [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICourseRepository _CourseService;
      // private readonly IMapper _mapper;
        readonly ILogger<CourseController> _log;
        public CourseController(ILogger<CourseController> log,IMapper mapper, ICourseRepository CourseService)
        {
            _log = log;
            _CourseService = CourseService;

            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {

            var user = await _CourseService.GetAllAsync();// _repo.GetUser(id);
            if(user == null){
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(user);// Ok(user);
        }
        
        [HttpGet("GetCourseAssigments/{id}")]
        public async Task<IActionResult> GetCourseAssigments(int id)
        {

            var user = await _CourseService.GetCourseAssigments(id);// _repo.GetUser(id);
            if (user == null)
            {
                _log.LogInformation("Hello, course not found!");
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            _log.LogInformation("Hello, course  found!");
            return Ok(user);// Ok(user);
        }
        [HttpGet("GetStudentByCourse/{id}")]
        public async Task<IActionResult> GetStudentByCourse(int id)
        {

            var user = await _CourseService.GetStudentByCourseAsync(id);// _repo.GetUser(id);
            if (user == null)
            {
                _log.LogInformation("Hello, course not found!");
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            _log.LogInformation("Hello, course  found!");
            return Ok(user);// Ok(user);
        }
        [HttpGet("GetCourseById/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {

            var user = await _CourseService.GetCourseByIdAsync(id);// _repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(user);// Ok(user);
        }
        [HttpPut("UploadPhoto"), DisableRequestSizeLimit]
         public async Task<IActionResult> UploadPhoto()
        {
        
                //comment: GET ID
                var arr= Request.Form.ToArray();
                var courseId=  arr[0].Value[0];
               // comment: GET FILES
                var file = Request.Form.Files[0];

                var folderName = Path.Combine("Resources", "Images");
                folderName = Path.Combine(folderName, "Course");
                folderName = Path.Combine(folderName, courseId);
                string wprh=Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory());
                wprh = Path.Combine(wprh, "courseproject-SPA");
                 wprh = Path.Combine(wprh, "src");
                wprh = Path.Combine(wprh, "assets");
                wprh = Path.Combine(wprh, folderName);
     
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), wprh);
                 if (!Directory.Exists(pathToSave)){
                    System.IO.Directory.CreateDirectory(wprh);
                 }

                if (file.Length > 0)
                {
                  //  var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileName = "courseFile_"+ courseId;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                //   var res = _CourseService.updateCoursePhoto(int.Parse(courseId),dbPath);
                //if(await _CourseService.updateCoursePhoto(int.Parse(courseId),dbPath))
                       return Ok();
                
                }
               
                    return BadRequest();
                
         
        }
             [HttpPut("updateCourse")]
        public async Task<IActionResult> updateCourse( CourseInfo info){
           // if(courseId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
               // return Unauthorized();
            if(info.courseId != 0){
                
                //var course = await _CourseService.GetCourseByIdAsync(info.courseId);
              //   course = info;
                if(await _CourseService.UpdateCourse(info)){
                     _log.LogInformation("Hello, course uptaded!");
                  return Ok();
                }
            }
            else{
              var res = _mapper.Map< Course >(info);
              await _CourseService.AddAsync(res);  
              _log.LogInformation("Hello, course uptaded!");
                  return Ok();
            }
          _log.LogInformation("Hello, course not uptaded!");
            return BadRequest();

        }
    [HttpDelete("DeletePhotoForCourse/{id}")]
        public async Task<IActionResult> DeletePhotoForCourse(int userId, int id){
              if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var user = await _CourseService.GetCourseByIdAsync(userId);

           // if(!user.Photos.Any(p => p.Id == id))
              //return Unauthorized();
            
           // var photoFromRepo = await _CourseService.GetPhoto(id);

           /* if( photoFromRepo.IsMain)
                return BadRequest(" can not delete it is main photo");
            if(photoFromRepo.PublicID != null){
                var deleteParams = new DeletionParams(photoFromRepo.PublicID);
                var result = _cloudinary.Destroy(deleteParams);
                if(result.Result == "ok"){
                    _repo.Delete(photoFromRepo);
                }
            }
            if(photoFromRepo.PublicID == null){
                _repo.Delete(photoFromRepo);
            }
      */
           // if( await _CourseService.())
                return Ok();

          // return BadRequest(" Failed to delete the photo");
            
        }

    }
}
