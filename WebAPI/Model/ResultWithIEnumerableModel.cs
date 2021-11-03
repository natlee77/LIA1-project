using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ResultWithIEnumerableModel
    {
        public string Target { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
        public IEnumerable<BillModel> Bill { get; set; }
        public IEnumerable<ContractAparmentModel> ContractAparment { get; set; }
        public IEnumerable<ContractParkingModel> ContractParking { get; set; }
        public IEnumerable<ErrorReportModel> ErrorReports { get; set; }
        public IEnumerable<LaundaryBookingModel> LaundaryBookings { get; set; }
        public IEnumerable<LaundryRoomModel> LaundryRooms { get; set; }
        public IEnumerable<ParkingCategoryModel> ParkingCategories { get; set; }
        public IEnumerable<ParkingLotModel> ParkingLots { get; set; }
        public IEnumerable<UserMessageModel> UserMessages { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
        public IEnumerable<MaintanceModel> Maintenance { get; set; }
    }
}
