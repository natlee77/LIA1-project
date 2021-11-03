using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Model;

namespace WebAPI.Services
{
    public interface IDatabaseServices
    {
        // Create Beginning 
        Task<ResultWithMessageModel> CreateBillAsync(BillModel bill);

        Task<ResultWithMessageModel> CreateContractAparmentAsync(ContractAparmentModel contractAparment);
        Task<ResultWithMessageModel> CreateContractParkingAsync(ContractCreateParking contractParking);

        Task<ResultWithMessageModel> CreateErrorReportAsync(ErrorReportModel errorReport);

        Task<ResultWithMessageModel> CreateLaundaryBookingAsync(LaundaryBookingModel laundaryBooking);
        Task<ResultWithMessageModel> CreateLaundryRoomAsync(LaundryRoomModel laundryRoom);

        Task<ResultWithMessageModel> CreateParkingCategoryAsync(ParkingCategoryModel parkingCategory);
        Task<ResultWithMessageModel> CreateParkingLotAsync(ParkingLotModel parkingLot);

        Task<ResultWithMessageModel> CreateUserMessageAsync(UserMessageModel messageModel);
        Task<ResultWithMessageModel> CeateUserAsync(UserRegisterModel user);

        Task<ResultWithMessageModel> CreateMaintanceAsync(MaintanceModel maintance);
        //Create Ending

        //Get Beginning
        Task<ResultWithIEnumerableModel> GetAllByTargetAsync(string Target);

        Task<ResultWithIEnumerableModel> GetMaintenanceByUserIdAsync(int UserId);
        //Get Ending
    }
}
