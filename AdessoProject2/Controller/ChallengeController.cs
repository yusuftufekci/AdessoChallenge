using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdessoProject2.Model;
using Microsoft.AspNetCore.Mvc;

namespace AdessoProject2.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChallengeController : ControllerBase
    {
        [HttpPost("solution_of_the_challenge")]
        public ActionResult Challenge([FromBody] ChallengeModel model)
        {
            var response = new ResponseModel();

            if(model.totalPeople < 0)

            {
                response.Status = "Error";
                response.Message = "Lutfen 0 dan buyuk bir sayi giriniz...";
            }
            else if(model.totalPeople == 1 )
            {
                response.Status = "OK";
                response.Data = 1;
            }
            else
            {
                var result = ChallengeResult(model.totalPeople);
                response.Status = "OK";
                response.Data = result;
               
            }

            return Ok(response);
        }


        public int ChallengeResult(int totalPeople)
        {
            int oldLength;
            int temp = 0;
            int result;
            int[] arr = new int[totalPeople];

            for (int i = 0; i < totalPeople; i++)
                arr[i] = i + 1;


            while (arr.Length != 1)
            {
                if (temp + 1 == arr.Length)
                {
                    arr = arr.Where((source, index) => index != 0).ToArray();
                    temp = 0;
                }
                else
                {
                    oldLength = arr.Length;
                    arr = arr.Where((source, index) => index != temp + 1).ToArray();

                    if (temp + 2 > oldLength)
                    {
                        temp = 0;
                    }
                    else
                    {
                        temp += 1;
                    }
                }
            }
            result = arr[0];
            return result;
        }
      
       
    }

}

