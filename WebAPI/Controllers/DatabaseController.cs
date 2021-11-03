using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Model;
using WebAPI.Services;
 

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly LIADbContext _context;
        private readonly IDatabaseServices _services;

        public DatabaseController(LIADbContext context, IDatabaseServices services)
        {
            _context = context;
            _services = services;
        }

        // Post Beginning
        [HttpPost("CreateBill")]
        public async Task<IActionResult> CreateBillAsync(BillModel bill)
        {
            var result = (await _services.CreateBillAsync(bill));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }




        [HttpPost("CreateContractApartment")]
        public async Task<IActionResult> CreateContractApartmentAsync(ContractAparmentModel contractAparment)
        {
            var result = (await _services.CreateContractAparmentAsync(contractAparment));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }

        [HttpPost("CreateContractParking")]
        public async Task<IActionResult> CreateContractParkingAsync(ContractCreateParking contractParking)
        {
            var result = (await _services.CreateContractParkingAsync(contractParking));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }




        [HttpPost("CreateErrorReport")]
        public async Task<IActionResult> CreateErrorReportAsync(ErrorReportModel errorReport)
        {
            var result = (await _services.CreateErrorReportAsync(errorReport));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }




        [HttpPost("CreateLaundryBooking")]
        public async Task<IActionResult> CreateLaundryBookingAsync(LaundaryBookingModel laundaryBooking)
        {
            var result = (await _services.CreateLaundaryBookingAsync(laundaryBooking));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }

        [HttpPost("CreateLaundryRoom")]
        public async Task<IActionResult> CreateLaundryRoomAsync(LaundryRoomModel laundryRoom)
        {
            var result = (await _services.CreateLaundryRoomAsync(laundryRoom));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }




        [HttpPost("CreateParkingCategory")]
        public async Task<IActionResult> CreateParkingCaregoryAsync(ParkingCategoryModel parkingCategory)
        {
            var result = (await _services.CreateParkingCategoryAsync(parkingCategory));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }

        [HttpPost("CreateParkingLot")]
        public async Task<IActionResult> CreateParkingLotAsync(ParkingLotModel parkingLot)
        {
            var result = (await _services.CreateParkingLotAsync(parkingLot));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }




        [HttpPost("CreateUserMessage")]
        public async Task<IActionResult> CreateUserMessageAsync(UserMessageModel userMessage)
        {
            var result = (await _services.CreateUserMessageAsync(userMessage));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUserAsync(UserRegisterModel user)
        {
            var result = (await _services.CeateUserAsync(user));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }

        [HttpPost("CreateMaintenance")]
        public async Task<IActionResult> CreateMaintenanceAsync(MaintanceModel maintance)
        {
            var result = (await _services.CreateMaintanceAsync(maintance));
            if (result.Result)
            {
                return new OkObjectResult($"{result.Message}");
            }
            return new BadRequestObjectResult($"{result.Message}");
        }

        // Post Ending

        // Get Begning


        [HttpGet("GetAllTarget")]
        public async Task<IActionResult> GetAllTargetUser(string Target)
        {
            var Result = (await _services.GetAllByTargetAsync(Target));
            if (Result.Result)
            {

                if (Target == "Bill")
                {
                    return new OkObjectResult(Result.Bill);
                }
                if (Target == "ContractAparment")
                {
                    return new OkObjectResult(Result.ContractAparment);
                }
                if (Target == "ContractParking")
                {
                    return new OkObjectResult(Result.ContractParking);
                }
                if (Target == "ErrorReport")
                {
                    return new OkObjectResult(Result.ErrorReports);
                }
                if (Target == "LaundryBooking")
                {
                    return new OkObjectResult(Result.LaundaryBookings);
                }
                if (Target == "LaundryRoom")
                {
                    return new OkObjectResult(Result.LaundryRooms);
                }
                if (Target == "ParkingCategory")
                {
                    return new OkObjectResult(Result.ParkingCategories);
                }
                if (Target == "ParkingLot")
                {
                    return new OkObjectResult(Result.ParkingLots);
                }
                if (Target == "UserMessage")
                {
                    return new OkObjectResult(Result.UserMessages);
                }

                if (Target == "User")
                {
                    return new OkObjectResult(Result.Users);
                }

                if (Target == "Maintenance")
                {
                    return new OkObjectResult(Result.Maintenance);
                }


            }
            return new BadRequestObjectResult(Result.Message);
        }

        [HttpGet("GetMaintenanceByUserId")]
        public async Task<IActionResult> GetMaintenanceByUserId(int UserId)
        {
            var Result = (await _services.GetMaintenanceByUserIdAsync(UserId));
            if (Result.Result)
            {
                return new OkObjectResult(Result.Maintenance);
            }
            return new BadRequestObjectResult($"{Result.Message}");
        }

        // Get Ending
    }
}
