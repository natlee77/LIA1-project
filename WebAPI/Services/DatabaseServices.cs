using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Model;


namespace WebAPI.Services
{
    public class DatabaseServices : IDatabaseServices
    {
        private readonly LIADbContext _context;

        public DatabaseServices(LIADbContext context)
        {
            _context = context;
        }

        // Create Beginning

        public async Task<ResultWithMessageModel> CreateBillAsync(BillModel billModel)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            try
            {
                if (_context.Users.Any(x => x.Id == billModel.UserId))
                {
                    var bill = new Bill()
                    {
                        Price = billModel.Price,
                        BillPeriod = billModel.BillPeriod,
                        BillExpire = billModel.BillExpire,
                        UserId = billModel.UserId
                    };

                    _context.Bills.Add(bill);
                    await _context.SaveChangesAsync();

                    result.Result = true;
                    result.Message = "Bill Successfully Created";
                    return result;
                }

                supplementMessage = "UserId Do Not Exist";
                result.Result = false;
                result.Message = $"Bill UnSuccessfully Created: Try(attempt) :{supplementMessage}";
                return result;
            }
            catch
            {
            }
            result.Result = false;
            result.Message = $"Bill UnSuccessfully Created: Try(attempt) :{supplementMessage}";
            return result;
        }


        public async Task<ResultWithMessageModel> CreateContractAparmentAsync(ContractAparmentModel contractApartment)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            if (_context.Users.Any(x => x.Id == contractApartment.UserId))
            {
                try
                {
                    var contractapartment = new ContractApartment()
                    {
                        Address = contractApartment.Address,
                        City = contractApartment.City,
                        ApartmentNumber = contractApartment.ApartmentNumber,
                        Price = contractApartment.Price,
                        StartDate = contractApartment.StartDate,
                        ExpireDate = contractApartment.ExpireDate,
                        UserId = contractApartment.UserId
                    };

                    _context.ContractApartments.Add(contractapartment);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"ContractAparment Successfully Created : {supplementMessage}";
                    return result;

                }
                catch
                {


                }
                result.Result = false;
                result.Message = $"ContractApartment UnSuccessfully Created : {supplementMessage}";
                return result;
            }
           
            if (!_context.Users.Any(x => x.Id == contractApartment.UserId))
            {
                supplementMessage = $"UserId:{contractApartment.UserId} Do not Exist In Database";
            }
           var appremntNumberCount = contractApartment.ApartmentNumber.Count();
            if (appremntNumberCount > 4)
            {
                supplementMessage = supplementMessage + $" ApartmentNumber Contains {appremntNumberCount} char Max is 4";
            }
            result.Result = false;
            result.Message = $"ContractApartment UnSuccessfully Created : {supplementMessage}";
            return result;
        }
      
        //funkar i Swagger 
        public async Task<ResultWithMessageModel> CreateContractParkingAsync(ContractCreateParking contractParking)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            if ((_context.Users.Any(x => x.Id == contractParking.UserId)) & (_context.ParkingCategories.Any(x => x.Id == contractParking.ParkingCategoryId)))
            {

            }
            try
            {
                var contractparking = new ContractParking()
                {
                    Address = contractParking.Address,
                    City = contractParking.City,
                    LotNumber = contractParking.LotNumber,
                    Price = contractParking.Price,
                    StartDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddYears(1),
                    ParkingCategoryId = contractParking.ParkingCategoryId,
                    UserId = contractParking.UserId
                };

                _context.ContractParkings.Add(contractparking);
                await _context.SaveChangesAsync();
                result.Result = true;
                result.Message = $"ContractParking Successfully Created : {supplementMessage}";
                return result;

            }
            catch
            {


            }

            if (!_context.Users.Any(x => x.Id == contractParking.UserId))
            {
                supplementMessage = $"UserId:{contractParking.UserId} Do not Exist In Database ";
            }
            if (!_context.ParkingCategories.Any(x => x.Id == contractParking.ParkingCategoryId))
            {
                supplementMessage = supplementMessage + $": ParkingCategory:{contractParking.ParkingCategoryId} Do Not Exist In Database";
            }
            var lotNumberCount = contractParking.LotNumber.Count();
            if (lotNumberCount > 4)
            {
                supplementMessage = supplementMessage + $" LotNumber Contains {lotNumberCount} 4 char is Max";
            }

            result.Result = false;
            result.Message = $"ContractParking UnSuccessfully Created : {supplementMessage}";
            return result;
        }



        public async Task<ResultWithMessageModel> CreateErrorReportAsync(ErrorReportModel errorReport)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            if (_context.Users.Any(x => x.Id == errorReport.UserId))
            {
                try
                {
                    var errorreport = new ErrorReport()
                    {
                        Description = errorReport.Description,
                        ErrorDate = DateTime.Now,
                        UserId = errorReport.UserId,
                        Categorie = errorReport.Categorie
                        
                    };

                    _context.ErrorReports.Add(errorreport);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"ErrorReport Successfully Created : {supplementMessage}";
                    return result;

                }
                catch
                {


                }
                result.Result = false;
                result.Message = $"ErrorReport UnSuccessfully Created : {supplementMessage}";
                return result;
            }
           
            if (!_context.Users.Any(x => x.Id == errorReport.UserId))
            {
                supplementMessage = $"UserId:{errorReport.UserId} Do not Exist In Database";
            }
            result.Result = false;
            result.Message = $"ErrorReport UnSuccessfully Created : {supplementMessage}";
            return result;
        }



        public async Task<ResultWithMessageModel> CreateLaundaryBookingAsync(LaundaryBookingModel laundaryBooking)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            if ((_context.Users.Any(x => x.Id == laundaryBooking.UserId)) & (_context.LaundryRooms.Any(x => x.Id == laundaryBooking.LaundryRoom)) )
            {
                try
                {
                    var laundrybooking = new LaundryBooking()
                    {
                        BookingDate = DateTime.Now,
                        BookingAvailable = laundaryBooking.BookingAvailable,
                        LaundryRoom = laundaryBooking.LaundryRoom,
                        UserId = laundaryBooking.UserId
                    };

                    _context.LaundryBookings.Add(laundrybooking);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"LaundryBooking Successfully Created : {supplementMessage}";
                    return result;

                }
                catch
                {


                }
                result.Result = false;
                result.Message = $"LaundryBooking UnSuccessfully Created : {supplementMessage}";
                return result;
            }
           
            if (!_context.Users.Any(x => x.Id == laundaryBooking.UserId))
            {
                supplementMessage = $"UserId:{laundaryBooking.UserId} Do not Exist In Database";
            }
            if (!_context.LaundryRooms.Any(x => x.Id == laundaryBooking.LaundryRoom))
            {
                supplementMessage = supplementMessage + $" LaundryRoom {laundaryBooking.LaundryRoom} Does Not Exist";
            }
            result.Result = false;
            result.Message = $"LaundryBooking UnSuccessfully Created : {supplementMessage}";
            return result;
        }
        public async Task<ResultWithMessageModel> CreateLaundryRoomAsync(LaundryRoomModel laundryRoom)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            try
            {
                var laundryroom = new LaundryRoom()
                {
                    Address = laundryRoom.Address
                };

                _context.LaundryRooms.Add(laundryroom);
                await _context.SaveChangesAsync();
                result.Result = true;
                result.Message = $"LaundryRoom Successfully Created : {supplementMessage}";
                return result;

            }
            catch
            {


            }

            result.Result = false;
            result.Message = $"LaundryRoom UnSuccessfully Created : {supplementMessage}";
            return result;
        }



        public async Task<ResultWithMessageModel> CreateParkingCategoryAsync(ParkingCategoryModel parkingCategory)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            if (_context.ParkingLots.Any(x => x.Id == parkingCategory.ParkingLots))
            {
                try
                {
                    var parkingcategory = new ParkingCategory()
                    {
                        Price = parkingCategory.Price,
                        ParkingCategory1 = parkingCategory.ParkingCategory1,
                        ParkingLots = parkingCategory.ParkingLots
                    };

                    _context.ParkingCategories.Add(parkingcategory);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"ParkingCategory Successfully Created : {supplementMessage}";
                    return result;

                }
                catch
                {


                }
            }
            if (!_context.ParkingLots.Any(x => x.Id == parkingCategory.ParkingLots))
            {
                supplementMessage = $"ParkingLot:{parkingCategory.ParkingLots} Does not Exist";
            }
            
            result.Result = false;
            result.Message = $"ParkingCategory UnSuccessfully Created : {supplementMessage}";
            return result;
        }
        public async Task<ResultWithMessageModel> CreateParkingLotAsync(ParkingLotModel parkingLot)
        {
            var result = new ResultWithMessageModel();
            try
            {

                    var parkinglot = new ParkingLot()
                    {
                        Address = parkingLot.Address,
                        AvailableLots = parkingLot.AvailableLots,
                        TotalLots = parkingLot.TotalLots,
                    };

                    _context.ParkingLots.Add(parkinglot);
                    await _context.SaveChangesAsync();

                    result.Result = true;
                    result.Message = "ParkingLot Successfully Created";
                    return result;


            }
            catch 
            {

               
            }
            result.Result = false;
            result.Message = "ParkingLot UnSuccessfully Created: Try(attempt)";
            return result;
        }



        public async Task<ResultWithMessageModel> CreateUserMessageAsync(UserMessageModel messageModel)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            if (_context.Users.Any(x => x.Id == messageModel.UserId))
            {
                try
                {
                    var message = new UserMessage()
                    {
                        Title = messageModel.Title,
                        Message = messageModel.Message,
                        UserId = messageModel.UserId,
                        MessageDate = DateTime.Now
                    };

                    _context.UserMessages.Add(message);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"UserMessage Successfully Created : {supplementMessage}";
                    return result;

                }
                catch
                {


                }
                result.Result = false;
                result.Message = $"UserMessage UnSuccessfully Created : {supplementMessage}";
                return result;
            }
            
            if (!_context.Users.Any(x => x.Id == messageModel.UserId))
            {
                supplementMessage = $"UserId:{messageModel.UserId} Do not Exist In Database";
            }
            result.Result = false;
            result.Message = $"UserMessage UnSuccessfully Created : {supplementMessage}";
            return result;
        }
        public async Task<ResultWithMessageModel> CeateUserAsync(UserRegisterModel userModel)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            try
            {
                if (!_context.Users.Any(x => x.FirstName == userModel.FirstName))
                {
                    var user = new User()
                    {
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Ssn = userModel.Ssn,
                        Email = userModel.Email,
                        Phonenumber = userModel.Phonenumber
                    };
                    user.CreatePasswordHash(userModel.Password);

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"User Successfully Created : {supplementMessage}";
                    return result;
                }
                supplementMessage = $"{userModel.FirstName} Already Exist";
                result.Result = false;
                result.Message = $"User UnSuccessfully Created : If(Condition) : {supplementMessage}";
                return result;
            }
            catch
            {


            }
            result.Result = false;
            result.Message = $"User UnSuccessfully Created : Try(attempt) : {supplementMessage}";
            return result;
        }

        public async Task<ResultWithMessageModel> CreateMaintanceAsync(MaintanceModel maintance)
        {
            var result = new ResultWithMessageModel();
            string supplementMessage = "";
            try
            {
                if (_context.Users.Any(x => x.Id == maintance.UserId))
                {
                    var Maintance = new AppartmentMaintance()
                    {
                        Description = maintance.Description,
                        ErrorDate = maintance.ErrorDate,
                        UserId = maintance.UserId,
                        Status = maintance.Status
                    };
                    _context.AppartmentMaintances.Add(Maintance);
                    await _context.SaveChangesAsync();
                    result.Result = true;
                    result.Message = $"Maintance Successfully Created : {supplementMessage}";
                    return result;
                }
                if (!_context.Users.Any(x => x.Id == maintance.UserId))
                {
                    supplementMessage = $"No User with Id {maintance.UserId} Exist";
                }
                result.Result = false;
                result.Message = $"Maintance UnSuccessfully Created : If(Condition) : {supplementMessage}";
                return result;
            }
            catch
            {


            }
            result.Result = false;
            result.Message = $"Maintance UnSuccessfully Created : Try(attempt) : {supplementMessage}";
            return result;
        }

        // Create Ending

        // Get Beginning


        public async Task<ResultWithIEnumerableModel> GetAllByTargetAsync(string Target)
        {
            var Result = new ResultWithIEnumerableModel();
    

            if (Target == "Bill")
            {

                try
                {
                    var BillList = new List<BillModel>();
                    var billList = _context.Bills.ToList();

                    foreach (var billLists in billList)
                    {
                        BillList.Add(new BillModel
                        {
                            Id = billLists.Id,
                            Price = billLists.Price,
                            BillExpire = billLists.BillExpire,
                            BillPeriod = billLists.BillPeriod,
                            UserId = billLists.UserId
                        });

                    }
                    Result.Result = true;
                    Result.Bill = BillList;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;
            }

            if (Target == "ContractAparment")
            {
                try
                {
                    var ContractAparmentList = new List<ContractAparmentModel>();
                    var contractAparmentListFromDB = _context.ContractApartments.ToList();
                    foreach (var contractApartment in contractAparmentListFromDB)
                    {
                        ContractAparmentList.Add( new ContractAparmentModel {
                            Id = contractApartment.Id,
                            Address = contractApartment.Address,
                            City = contractApartment.City,
                            ApartmentNumber = contractApartment.ApartmentNumber,
                            Price = contractApartment.Price,
                            StartDate = contractApartment.StartDate,
                            ExpireDate = contractApartment.ExpireDate,
                            UserId = contractApartment.UserId

                        });


                    }
                    Result.Result = true;
                    Result.ContractAparment = ContractAparmentList;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch 
                {

                    
                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;
            }

            if (Target == "ContractParking")
            {
                try
                {
                    var List = new List<ContractParkingModel>();
                    var FromDB = _context.ContractParkings.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new ContractParkingModel
                        {
                            Id = item.Id,
                            Address = item.Address,
                            City = item.City,
                            LotNumber = item.LotNumber,
                            Price = item.Price,
                            StartDate = item.StartDate,
                            ExpireDate = item.ExpireDate,
                            ParkingCategoryId = item.ParkingCategoryId,
                            UserId = item.UserId

                        });


                    }
                    Result.Result = true;
                    Result.ContractParking = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "ErrorReport")
            {
                try
                {
                    var List = new List<ErrorReportModel>();
                    var FromDB = _context.ErrorReports.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new ErrorReportModel
                        {
                            Id = item.Id,
                            Description = item.Description,
                            ErrorDate = item.ErrorDate,
                            UserId = item.UserId,
                            Categorie = item.Categorie
                            
                        });


                    }
                    Result.Result = true;
                    Result.ErrorReports = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "LaundryBooking")
            {
                try
                {
                    var List = new List<LaundaryBookingModel>();
                    var FromDB = _context.LaundryBookings.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new LaundaryBookingModel
                        {
                            Id = item.Id,
                            BookingDate = item.BookingDate,
                            BookingAvailable = item.BookingAvailable,
                            LaundryRoom = item.LaundryRoom,
                            UserId = item.UserId

                        });


                    }
                    Result.Result = true;
                    Result.LaundaryBookings = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "LaundryRoom")
            {
                try
                {
                    var List = new List<LaundryRoomModel>();
                    var FromDB = _context.LaundryRooms.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new LaundryRoomModel
                        {
                            Id = item.Id,
                            Address = item.Address

                        });


                    }
                    Result.Result = true;
                    Result.LaundryRooms = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "ParkingCategory")
            {
                try
                {
                    var List = new List<ParkingCategoryModel>();
                    var FromDB = _context.ParkingCategories.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new ParkingCategoryModel
                        {
                            ParkingId = item.Id,
                            Price = item.Price,
                            ParkingCategory1 = item.ParkingCategory1,
                            ParkingLots = item.ParkingLots

                        });


                    }
                    Result.Result = true;
                    Result.ParkingCategories = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "ParkingLot")
            {
                try
                {
                    var List = new List<ParkingLotModel>();
                    var FromDB = _context.ParkingLots.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new ParkingLotModel
                        {
                            Id = item.Id,
                            Address = item.Address,
                            AvailableLots = item.AvailableLots,
                            TotalLots = item.TotalLots,

                        });


                    }
                    Result.Result = true;
                    Result.ParkingLots = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "UserMessage")
            {
                try
                {
                    var List = new List<UserMessageModel>();
                    var FromDB = _context.UserMessages.ToList();
                    foreach (var item in FromDB)
                    {
                        List.Add(new UserMessageModel
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Message = item.Message,
                            UserId = item.UserId,
                            MessageDate = item.MessageDate

                        });


                    }
                    Result.Result = true;
                    Result.UserMessages = List;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            if (Target == "User")
            {

                try
                {
                    var UserList = new List<UserModel>();
                    var userListFromDB = _context.Users.ToList();

                    foreach (var userList in userListFromDB)
                    {
                        UserList.Add(new UserModel
                        {
                            Id = userList.Id,
                            FirstName = userList.FirstName,
                            LastName = userList.LastName,
                            Ssn = userList.Ssn,
                            Email = userList.Email,
                            Phonenumber = userList.Phonenumber
                        });
                    }
                    Result.Result = true;
                    Result.Users = UserList;
                    Result.Message = $"Succeded";
                    return Result;
                }
                catch
                {


                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;
            }

            if (Target == "Maintenance")
            {
                try
                {
                    var MaintenanceList = new List<MaintanceModel>();
                    var MaintenanceListFromDB = _context.AppartmentMaintances.ToList();

                    foreach (var Maintenance in MaintenanceListFromDB)
                    {
                        MaintenanceList.Add(new MaintanceModel
                        {      
                            Id = Maintenance.Id,
                            Description = Maintenance.Description,
                            ErrorDate = Maintenance.ErrorDate,
                            UserId = Maintenance.UserId,
                            Status = Maintenance.Status
                            
                        });
                        Result.Result = true;
                        Result.Maintenance = MaintenanceList;
                        Result.Message = $"Succeded";
                        return Result;
                    }
                }
                catch 
                {

                   
                }
                Result.Result = false;
                Result.Message = $"Failed Try(Attempt)";
                return Result;

            }

            Result.Result = false;
            Result.Message = $"{Target} : Target did not Match any Database  : Try Bill, ContractAparment, ContractParking, ErrorReport, LaundryBooking, LaundryRoom, ParkingCategory, ParkingLot, UserMessage, User, Maintenance ";
            return Result;
        }

        public async Task<ResultWithIEnumerableModel> GetMaintenanceByUserIdAsync(int UserId)
        {
            var Result = new ResultWithIEnumerableModel();
            try
            {
                var MaintenanceList = new List<MaintanceModel>();
                var MaintenanceListFromDB = _context.AppartmentMaintances.ToList();

                foreach (var Maintenance in MaintenanceListFromDB)
                {
                    if (UserId == Maintenance.UserId)
                    {
                        MaintenanceList.Add(new MaintanceModel
                        {
                            Id = Maintenance.Id,
                            Description = Maintenance.Description,
                            ErrorDate = Maintenance.ErrorDate,
                            UserId = Maintenance.UserId,
                            Status = Maintenance.Status

                        });

                    }
                    

                }
                Result.Result = true;
                Result.Maintenance = MaintenanceList;
                Result.Message = $"Succeded";
                return Result;
            }
            catch
            {


            }
            Result.Result = false;
            Result.Message = $"Failed Try(Attempt)";
            return Result;

        }



        //Get Ending
    }
}
